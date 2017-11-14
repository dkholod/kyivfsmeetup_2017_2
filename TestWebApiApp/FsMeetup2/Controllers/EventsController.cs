using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

using FsMeetup2.Contracts;
using Metrics;
using MongoDB.Driver;

using Swashbuckle.Swagger.Annotations;

namespace FsMeetup2.Controllers
{
    public class EventsController : ApiController
    {
        readonly IMongoCollection<Event> _eventsCollection;
        readonly Meter _metrics = Metric.Meter("entities_events_upcoming", Metrics.Unit.Items, Metrics.TimeUnit.Seconds);

        public EventsController()
        {
            var mongoClient = new MongoClient("mongodb://192.168.99.100:27017");
            var db = mongoClient.GetDatabase("SportsData");

            _eventsCollection = db.GetCollection<Event>("Events");
        }

        [HttpGet]
        [Route("api/entities/events/upcoming")]
        [SwaggerOperation("GetUpcomingEvents")]
        public async Task<IEnumerable<Event>> GetUpcomingEvents(int limit)
        {
            var now = DateTime.UtcNow;
            var inWeek = DateTime.UtcNow.AddDays(7);

            var events = await _eventsCollection
                .Find(x => x.StartEventDate > now && x.StartEventDate < inWeek)
                .Limit(limit)
                .ToListAsync();

            _metrics.Mark("_nofilter");
            return events;
        }

        [HttpGet]
        [Route("api/entities/events/upcoming/sport")]
        [SwaggerOperation("GetUpcomingBySport")]
        public async Task<IEnumerable<Event>> GetUpcomingBySport(int limit, SportName sport)
        {
            var now = DateTime.UtcNow;
            var inWeek = DateTime.UtcNow.AddDays(7);

            var sportName = SportNameConvertor.Convertor[sport];

            var events = await _eventsCollection
                .Find(x => x.StartEventDate > now && x.StartEventDate < inWeek && x.SportName == sportName)
                .Limit(limit)
                .ToListAsync();

            _metrics.Mark("_bysport");
            return events;
        }

        [HttpGet]
        [Route("api/entities/events/upcoming/league")]
        [SwaggerOperation("GetUpcomingByLeague")]
        public async Task<IEnumerable<Event>> GetUpcomingByLeague(int limit, LeagueName league)
        {
            var now = DateTime.UtcNow;
            var inWeek = DateTime.UtcNow.AddDays(7);

            var leagueName = LeagueNameConvertor.Convertor[league];

            var events = await _eventsCollection
                .Find(x => x.StartEventDate > now && x.StartEventDate < inWeek && x.LeagueName == leagueName)
                .Limit(limit)
                .ToListAsync();

            _metrics.Mark("_byleague");
            return events;
        }
    }
}