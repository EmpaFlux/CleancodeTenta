using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Adapter;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using MovieLibrary.Models;

namespace MovieLibrary.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MovieController
    {
        static HttpClient client = new HttpClient();
        MovieAdapter adaptation = new MovieAdapter();

        [HttpGet]
        [Route("/toplist")]
        public IEnumerable<string> GetMovieTitles(bool sortAsAscending = true)
        {
            var movieList = adaptation.GetMovies();
            if (sortAsAscending == true)
            {
                movieList = adaptation.SortTheMoviesAsAcending(movieList);
            }
            else
            {
                movieList = adaptation.SortTheMoviesAsDecending(movieList);
            }
            return movieList.Select(i => i.Title).ToArray();
        }

        [HttpGet]
        [Route("/movie")]
        public Movie GetMovieById(string id)
        {
            var movieList = adaptation.GetMovies();
            var movie = adaptation.FindMovieByID(movieList, id);
            return movie;
        }
    }
}