using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PokeList.Model
{
    public class Pokemons
    {
        [JsonPropertyName("results")]
        public List<Pokemon> Results { get; set; }
    }

    public class Pokemon
    {
        [JsonPropertyName("abilities")]
        public List<AbilityDetails> Abilities { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("sprites")]
        public Sprites Sprites { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }
    }

    public class Ability
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class AbilityDetails
    {
        [JsonPropertyName("ability")]
        public Ability Ability { get; set; }

        [JsonPropertyName("is_hidden")]
        public bool Is_hidden { get; set; }

        [JsonPropertyName("slot")]
        public int slot { get; set; }
    }

    public class Sprites
    {
        [JsonPropertyName("back_default")]
        public string Back_default { get; set; }

        [JsonPropertyName("front_default")]
        public string Front_default { get; set; }
    }
}
