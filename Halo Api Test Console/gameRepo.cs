namespace Halo_Api_Test_Console
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class gameRepo
    {
        [JsonProperty("player_id")]
        public Guid PlayerId { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("avatar")]
        public Uri Avatar { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("cover_image")]
        public string CoverImage { get; set; }

        [JsonProperty("platforms")]
        public Platforms Platforms { get; set; }

        [JsonProperty("games")]
        public Games Games { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }

        [JsonProperty("friends_ids")]
        public List<Guid> FriendsIds { get; set; }

        [JsonProperty("new_steam_id")]
        public string NewSteamId { get; set; }

        [JsonProperty("steam_id_64")]
        public string SteamId64 { get; set; }

        [JsonProperty("steam_nickname")]
        public string SteamNickname { get; set; }

        [JsonProperty("memberships")]
        public List<string> Memberships { get; set; }

        [JsonProperty("faceit_url")]
        public string FaceitUrl { get; set; }

        [JsonProperty("membership_type")]
        public string MembershipType { get; set; }

        [JsonProperty("cover_featured_image")]
        public string CoverFeaturedImage { get; set; }

        [JsonProperty("infractions")]
        public Ions Infractions { get; set; }
    }

    public partial class Games
    {
        [JsonProperty("halo_3")]
        public Halo Halo3 { get; set; }

        [JsonProperty("halo_mcc")]
        public Halo HaloMcc { get; set; }

        [JsonProperty("halo_5")]
        public Halo Halo5 { get; set; }

        [JsonProperty("halo_infinite")]
        public Halo HaloInfinite { get; set; }
    }

    public partial class Halo
    {
        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("game_player_id")]
        public string GamePlayerId { get; set; }

        [JsonProperty("skill_level")]
        public long SkillLevel { get; set; }

        [JsonProperty("faceit_elo")]
        public long FaceitElo { get; set; }

        [JsonProperty("game_player_name")]
        public string GamePlayerName { get; set; }

        [JsonProperty("skill_level_label")]
        public string SkillLevelLabel { get; set; }

        [JsonProperty("regions")]
        public Ions Regions { get; set; }

        [JsonProperty("game_profile_id")]
        public string GameProfileId { get; set; }
    }

    public partial class Ions
    {
    }

    public partial class Platforms
    {
        [JsonProperty("steam")]
        public string Steam { get; set; }
    }

    public partial class Settings
    {
        [JsonProperty("language")]
        public string Language { get; set; }
    }

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Halo_Api_Test_Console.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Halo_Api_Test_Console.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
