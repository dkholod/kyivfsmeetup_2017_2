package sportsdata

import scala.concurrent.duration._

import java.util.concurrent.ThreadLocalRandom

import io.gatling.core.Predef._
import io.gatling.http.Predef._

class SportsData_Upcoming_Events_Combined extends Simulation {

  object AllUpcoming {

    val withLimit = repeat(20, "i") {
      exec(http("getEvents with limit ${i}")
        .get("/upcoming?limit=${i}")
        .check(status is 200))
    }.exitHereIfFailed
  }

  object UpcomingSports {

    val allSports = exitBlockOnFail {
      feed(csv("sports.csv").circular)
        .exec(
          http("getEventsBy:${sportNames}")
            .get("/upcoming/sport?limit=100&sport=${sportNames}")
            .check(status is 200))
    }
  }

  object UpcomingLeagues {
    val leagues = Seq("ItalySerieA", "ATPAcapulco", "NFL", "ChampionsLeague", "AustraliaNBL")

    val allLeagues = foreach(leagues, "league") {
      exec(http("getEventsBy:${league}")
        .get("/upcoming?limit=100&league=${league}")
        .check(status is 200))
    }
  }

  val widgets = scenario("Widgets").exec(UpcomingSports.allSports, UpcomingLeagues.allLeagues)
  val websites = scenario("WebSites").exec(AllUpcoming.withLimit, UpcomingSports.allSports, UpcomingLeagues.allLeagues)

  setUp(
    widgets.inject(rampUsers(100) over (30 seconds)),
    websites.inject(rampUsers(200) over (30 seconds))
  ).protocols(Settings.getHttpProtocol())
}
