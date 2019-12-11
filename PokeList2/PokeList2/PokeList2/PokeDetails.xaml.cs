using PokeList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeList2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokeDetails : ContentPage
    {
        public Pokemon PokemonValue { get; set; }

        public Pokemon Pokemon
        {
            get => PokemonValue;
            set
            {
                PokemonValue = value;
                OnPropertyChanged(nameof(Pokemon));
            }
        }

        public PokeDetails(Pokemon pokemon)
        {
            InitializeComponent();
            this.Pokemon = pokemon;
            BindingContext = this;
        }
    }
}