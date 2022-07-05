using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace Halo_Api_Test_Console
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly HttpClient client2 = new HttpClient();

        static async Task Main(string[] args)
        {
            var repositories = await ProcessRepositories();
            var gameRepositories = await ProcessGameRepositories();


            Console.WriteLine(repositories.Nickname);
            Console.WriteLine(repositories.Games.Halo5.SkillLevel);
            Console.WriteLine("Halo 5 Name" + gameRepositories.SkillLevel);

            //foreach (var i in repositories.Games)
            // {
           // Console.WriteLine(repositories.Games);
            //}

        }

        private static async Task<gameRepo> ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("nickname", "insertfaceitnamehere");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer inseertapikeyhere");

        
            var response = client.GetAsync("https://open.faceit.com/data/v4/players?nickname=xL3G3ND6").Result;
            gameRepo repositories = new gameRepo();
            if (response.IsSuccessStatusCode)
            {
                JObject body = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                repositories = body.ToObject<gameRepo>();
            }
            
            var streamTask = client.GetStreamAsync("https://open.faceit.com/data/v4/players?nickname=xL3G3ND6");

            return repositories;

        }

        private static async Task<Halo> ProcessGameRepositories()
        {
            client2.DefaultRequestHeaders.Accept.Clear();
            client2.DefaultRequestHeaders.Add("nickname", "insertfaceitnamehere");
            client2.DefaultRequestHeaders.Add("Authorization", "Bearer insertapikeyhere");
            var streamTask = client.GetStreamAsync("https://open.faceit.com/data/v4/players?nickname=insertfaceitnamehere");
            var gameRepositories = await System.Text.Json.JsonSerializer.DeserializeAsync<Halo>(await streamTask);
            return gameRepositories;
        }
    }
}