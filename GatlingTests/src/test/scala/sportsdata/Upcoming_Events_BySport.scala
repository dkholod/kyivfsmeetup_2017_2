package sportsdata

import scala.concurrent.duration._

import java.util.concurrent.ThreadLocalRandom

import io.gatling.core.Predef._
import io.gatling.http.Predef._

class SportsData_Upcoming_Events_BySport extends Simulation {

  val sportsFeeder = csv("sports.csv").random

  val upcomingEventsBySportScn = scenario("Upcoming events by Sport")
    .feed(sportsFeeder)
    .exec(
      http("getEventsBy:${sportNames}")
        .get("/upcoming/sport?limit=100&sport=${sportNames}")
        .check(status is 200))

  setUp(
    upcomingEventsBySportScn.inject(constantUsersPerSec(100) during(30 seconds)))
    .assertions(forAll.failedRequests.percent.lte(5),
      forAll.responseTime.max.lt(500))
    .protocols(Settings.getHttpProtocol())
}
