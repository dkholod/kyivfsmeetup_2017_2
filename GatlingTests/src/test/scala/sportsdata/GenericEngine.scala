package sportsdata

import io.gatling.http.Predef.http
import io.gatling.core.Predef._

object Settings {

  val baseUrl = "http://localhost/FsMeetup2/api/entities/events"

  val userAgent =
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36"

  def getHttpProtocol() = http
    .baseURL(baseUrl)
    .acceptHeader("application/json")
    .acceptEncodingHeader("gzip")
    .userAgentHeader(userAgent)
}