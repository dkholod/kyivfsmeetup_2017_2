using System;
using System.Collections.Generic;

using MongoDB.Bson.Serialization.Attributes;

using Newtonsoft.Json;

namespace FsMeetup2.Contracts
{
    [BsonIgnoreExtraElements]
    public class Event
    {
        public string Id { get; set; } = string.Empty;

        [JsonIgnore]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime LastUpdateDateTime { get; set; }

        public string SportId { get; set; } = string.Empty;

        public int SportOrder { get; set; }

        public string SportName { get; set; } = string.Empty;

        public string EventName { get; set; } = string.Empty;

        public string RegionId { get; set; } = string.Empty;

        public string RegionCode { get; set; } = string.Empty;

        public string RegionName { get; set; } = string.Empty;

        public string LeagueId { get; set; } = string.Empty;

        public string LeagueName { get; set; } = string.Empty;

        public int LeagueOrder { get; set; }

        public bool IsTopLeague { get; set; }

        public List<Participant> Participants { get; set; } = new List<Participant>();

        public DateTime StartEventDate { get; set; }

        public IList<string> Tags { get; set; } = new List<string>();

        public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();

        [JsonIgnore]
        public bool IsRemoved { get; set; } = false;
    }

    [BsonIgnoreExtraElements]
    public class Participant
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string VenueRole { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;
    }
}
