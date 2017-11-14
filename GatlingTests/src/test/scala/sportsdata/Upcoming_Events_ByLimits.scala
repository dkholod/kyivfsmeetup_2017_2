package sportsdata

import scala.concurrent.duration._

import java.util.concurrent.ThreadLocalRandom

import io.gatling.core.Predef._
import io.gatling.http.Predef._

class SportsData_All_Upcoming_Events_ByLimits extends Simulation {

  val limits = Array(100, 200, 300)
  def selectLimit() = limits(ThreadLocalRandom.current.nextInt(3))
  val limitsFeeder = Iterator.continually(Map("Limit" -> selectLimit()))

  val allUpcomingEventsByLimitsScn = scenario("All upcoming events with limit")
    .feed(limitsFeeder)
    .exec(
      http("getEvents with limit ${Limit}")
        .get("/upcoming?limit=${Limit}")
        .check(status is 200))

  setUp(
    allUpcomingEventsByLimitsScn.inject(constantUsersPerSec(100) during(30 seconds)))
    .assertions(forAll.failedRequests.percent.lte(5),
                forAll.responseTime.max.lt(500))
    .protocols(Settings.getHttpProtocol())
}