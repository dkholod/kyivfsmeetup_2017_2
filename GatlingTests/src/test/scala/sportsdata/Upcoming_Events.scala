package sportsdata

import scala.concurrent.duration._

import java.util.concurrent.ThreadLocalRandom

import io.gatling.core.Predef._
import io.gatling.http.Predef._

class SportsData_All_Upcoming_Events extends Simulation {

  val allUpcomingEventsScn = scenario("All upcoming events")
    .exec(
      http(s"getEvents")
        .get("/upcoming?limit=100")
        .check(status is 200))

  setUp(
    allUpcomingEventsScn.inject(constantUsersPerSec(100) during(1 minute)))
    .assertions(forAll.failedRequests.percent.lte(5),
                forAll.responseTime.max.lt(500))
    .protocols(Settings.getHttpProtocol())
}