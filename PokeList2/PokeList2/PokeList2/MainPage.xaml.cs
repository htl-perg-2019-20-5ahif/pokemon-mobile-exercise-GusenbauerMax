using PokeList.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokeList2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private HttpClient HttpClient = new HttpClient();

        public List<Pokemon> PokemonsValue;
        public List<Pokemon> Pokemons
        {
            get => PokemonsValue;
            set
            {
                PokemonsValue = value;
                OnPropertyChanged(nameof(Pokemons));
            }
        }

        public MainPage()
        {
            InitializeComponent();
            this.Pokemons = new List<Pokemon>();
            BindingContext = this;
        }

        public async Task<Pokemons> GetPokemon()
        {
            var pokemonResponse = await HttpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/");
            pokemonResponse.EnsureSuccessStatusCode();
            var responseBody = await pokemonResponse.Content.ReadAsStringAsync();
            var pokemons = JsonSerializer.Deserialize<Pokemons>(responseBody);
            foreach (Pokemon pokemon in pokemons.Results)
            {
                Console.WriteLine(pokemon);
            }
            return pokemons;
        }

        public async Task<Pokemon> GetDetailedPokemon(Pokemon pokemon)
        {
            var pokemonResponse = await HttpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/" + pokemon.Name);
            pokemonResponse.EnsureSuccessStatusCode();
            var responseBody = await pokemonResponse.Content.ReadAsStringAsync();
            var detailedPokemon = JsonSerializer.Deserialize<Pokemon>(responseBody);
            return detailedPokemon;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var pokemons = await GetPokemon();
            //pokemons.Results[0] = (await GetDetailedPokemon(pokemons.Results.First()));
            List<Pokemon> pokemonList = new List<Pokemon>();
            foreach (Pokemon pokemon in pokemons.Results)
            {
                pokemonList.Add(await GetDetailedPokemon(pokemon));
            }
            Pokemons = pokemonList;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                await Navigation.PushModalAsync(new PokeDetails(e.Item as Pokemon));
            }
        }
    }
}
