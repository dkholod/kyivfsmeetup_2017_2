using System.Collections.Generic;

namespace FsMeetup2.Contracts
{
    public enum LeagueName
    {
        ItalySerieA = 0,
        ATPAcapulco = 1,
        NFL = 2,
        ChampionsLeague = 3,
        AustraliaNBL =4
    }

    public static class LeagueNameConvertor
    {
        public static Dictionary<LeagueName, string> Convertor =
            new Dictionary<LeagueName, string>
            {
                {LeagueName.ItalySerieA, "Italy - Serie A"},
                {LeagueName.ATPAcapulco, "ATP Acapulco"},
                {LeagueName.NFL, "NFL"},
                {LeagueName.ChampionsLeague, "Champions League"},
                {LeagueName.AustraliaNBL, "Australia NBL"}
            };
    }
}
