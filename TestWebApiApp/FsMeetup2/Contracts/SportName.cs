using System.Collections.Generic;

namespace FsMeetup2.Contracts
{
    public enum SportName
    {
        Soccer = 0,
        Tennis = 1,
        BasketBall = 2,
        Darts = 3,
        Boxing = 4,
        Golf = 5,
        Handball = 6,
        Volleyball = 7,
        WinterOlympic = 8,
        BeachVolleyball = 9,
        IceHockey = 10,
        TableTennis = 11,
        HorseRacing = 12
    }

    public static class SportNameConvertor
    {
        public static Dictionary<SportName, string> Convertor =
            new Dictionary<SportName, string>
            {
                {SportName.Soccer, "Soccer"},
                {SportName.Tennis, "Tennis"},
                {SportName.BasketBall, "BasketBall"},
                {SportName.Darts, "Darts"},
                {SportName.Boxing, "Boxing"},
                {SportName.Golf, "Golf"},
                {SportName.Handball, "Handball"},
                {SportName.Volleyball, "Volleyball"},
                {SportName.WinterOlympic, "Winter Olympic"},
                {SportName.BeachVolleyball, "Beach Volleyball"},
                {SportName.IceHockey, "Ice Hockey"},
                {SportName.TableTennis, "Table Tennis"},
                {SportName.HorseRacing, "Horse Racing"}
            };
    }
}
