using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //}

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult NewRental([FromBody]RentalDto rentalDto)
        {
            var customer = _context
                .Customers
                .Single(c => c.Id == rentalDto.CustomerId);

            var map = rentalDto.MovieIds.ToDictionary(
                movieId => movieId,
                movieId => rentalDto.MovieIds.Count(id => id == movieId));

            if (map.Values.Any(value => value > 1))
            {
                return BadRequest("Only one copy of a movie is allowed to rent at once.");
            }

            var movies = _context
                .Movies
                .Where(movie => rentalDto.MovieIds.Contains(movie.Id))
                .ToList();

            if (movies.Any(movie => movie.NumberAvailable < map[movie.Id]))
            {
                return BadRequest("Not enough items available.");
            }

            var now = DateTime.Now;

            var rentals = movies.Select(
                movie => new Rental()
                {
                    DateRented = now,
                    DateReturned = null,
                    Customer = customer,
                    Movie = movie
                });

            foreach (var movie in movies)
            {
                movie.NumberAvailable -= map[movie.Id];
            }

            _context.Rentals.AddRange(rentals);

            _context.SaveChanges();

            return Ok();
        }


        // PUT api/<controller>/5
        //[HttpPut]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}