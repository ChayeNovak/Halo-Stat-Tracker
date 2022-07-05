using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Halo_Api_Test_Console
{
    public class Repository
    {
        [JsonPropertyName("nickname")]
        public string Name { get; set; }

       [JsonPropertyName("player_id")]
        public string Description { get; set; }

        [JsonPropertyName("halo_infinite")]
        public string Games { get; set; }

        /*[JsonPropertyName("html_url")]
        public Uri GitHubHomeUrl { get; set; }

        [JsonPropertyName("homepage")]
        public Uri Homepage { get; set; }

        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        [JsonPropertyName("pushed_at")]
        public string JsonDate { get; set; }

        public DateTime LastPush =>
            DateTime.ParseExact(JsonDate, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
       */
    }
}
