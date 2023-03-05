using Newtonsoft.Json;
using RickAndMortyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyAPI
{
    public static class CartoonProcessor
    {
        private static HttpClient client = new HttpClient();
        public static async Task<CharacterModel> LoadCharacter(int idCharacter = 0)
        {
            string url = "";
            url = $"https://rickandmortyapi.com/api/character/{idCharacter}";
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                string responceString = await response.Content.ReadAsStringAsync();
                CharacterModel character = JsonConvert.DeserializeObject<CharacterModel>(responceString);
                return character;
            }
        }
    }
}
