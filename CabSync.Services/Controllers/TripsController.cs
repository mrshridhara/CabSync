using CabSync.Data;
using CabSync.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CabSync.Services.Controllers
{
    /// <summary>
    /// Provides methods to manipulate trips data.
    /// </summary>
    [RoutePrefix("api/trips")]
    public sealed class TripsController : ApiController
    {
        private readonly IRepository<Trip> tripRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="TripsController"/> class.
        /// </summary>
        public TripsController()
        {
            tripRepository = new TripsRepository();
        }

        /// <summary>
        /// Gets all the available trips.
        /// </summary>
        /// <returns>
        /// A sequence of available trips.
        /// </returns>
        [Route]
        public IHttpActionResult Get() => Ok(tripRepository.Read());

        /// <summary>
        /// Gets all the available trips for the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">
        /// The required date. Supports 'Today', 'Tomorrow' and 'Yesterday' as well.
        /// </param>
        /// <returns>
        /// A sequence of available trips.
        /// </returns>
        [Route("{date}")]
        public IHttpActionResult GetByStartDate(string date)
        {
            var matchingTrip = FilterTripsByDate(date).FirstOrDefault();

            if (default(Trip).Equals(matchingTrip))
                return NotFound();

            return Ok(matchingTrip);
        }

        /// <summary>
        /// Gets all the available trips for the specified <paramref name="date"/> and <paramref name="registrationNumber"/>.
        /// </summary>
        /// <param name="date">
        /// The required date. Supports 'Today', 'Tomorrow' and 'Yesterday' as well.
        /// </param>
        /// <param name="registrationNumber">The cab registration number.</param>
        /// <returns>
        /// A sequence of available trips.
        /// </returns>
        [Route("{date}/cabs/{registrationNumber}")]
        public IHttpActionResult GetByStartDateAndRegistrationNumber(string date, string registrationNumber)
        {
            var matchingTrip =
                FilterTripsByDate(date)
                    .Where(each => each.Cab.RegistrationNumber == registrationNumber)
                    .FirstOrDefault();

            if (default(Trip).Equals(matchingTrip))
                return NotFound();

            return Ok(matchingTrip);
        }

        /// <summary>
        /// Gets all the available trips for the specified <paramref name="date"/> and <paramref name="userId"/>..
        /// </summary>
        /// <param name="date">
        /// The required date. Supports 'Today', 'Tomorrow' and 'Yesterday' as well.
        /// </param>
        /// <param name="userId">The user ID.</param>
        /// <returns>
        /// A sequence of available trips.
        /// </returns>
        [Route("{date}/requesters/{userId}")]
        public IHttpActionResult GetByStartDateAndRequesterUserId(string date, string userId)
        {
            var matchingTrip =
                FilterTripsByDate(date)
                    .Where(each => each.Requesters.Any(eachUser => eachUser.UserId == userId))
                    .FirstOrDefault();

            if (default(Trip).Equals(matchingTrip))
                return NotFound();

            return Ok(matchingTrip);
        }

        private static DateTime Parse(string dateTimeString)
        {
            if ("Today".Equals(dateTimeString, StringComparison.OrdinalIgnoreCase))
                return DateTime.Today;

            if ("Tomorrow".Equals(dateTimeString, StringComparison.OrdinalIgnoreCase))
                return DateTime.Today.AddDays(1);

            if ("Yesterday".Equals(dateTimeString, StringComparison.OrdinalIgnoreCase))
                return DateTime.Today.AddDays(-1);

            DateTime dateTime;
            DateTime.TryParse(dateTimeString, out dateTime);
            return dateTime;
        }

        private IEnumerable<Trip> FilterTripsByDate(string date)
            => tripRepository
                .Read()
                .Where(each =>
                {
                    var dateValue = Parse(date);

                    return
                        each.StartDateTime.GetValueOrDefault().Date == dateValue
                        || each.EndDateTime.GetValueOrDefault().Date == dateValue;
                });
    }
}