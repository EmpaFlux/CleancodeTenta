using MovieLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MovieLibrary.Adapter
{
    public class MovieAdapter
    {
        HttpClient client = new HttpClient();

        public List<Movie> GetMovies()
        {
            var list1 = GetTheMoviesFromAPI1();
            var list2 = GetTheMoviesFromAPI2();
            return CombineMoviesToOneList(list1, list2);
        }

        private List<Movie> GetTheMoviesFromAPI1()
        {
            var clientResponse = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json").Result;
            var movieList1 = System.Text.Json.JsonSerializer.Deserialize<List<Movie>>(new System.IO.StreamReader(clientResponse.Content.ReadAsStream()).ReadToEnd());
            return movieList1;
        }

        private List<Movie> GetTheMoviesFromAPI2()
        {
            var clientResponse = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json").Result;
            var responseContent = System.Text.Json.JsonSerializer.Deserialize<List<OtherMovie>>(new System.IO.StreamReader(clientResponse.Content.ReadAsStream()).ReadToEnd());
            var movieList = responseContent.Select(i => new Movie() { Title = i.Title, Id = i.Id, Rating = i.Rating.ToString() }).ToList();
            return movieList;
        }

        public Movie FindMovieByID(List<Movie> movieList, string id)
        {
            return movieList.Select(i => i).Where(i => i.Id == id).FirstOrDefault();
        }

        public List<Movie> SortTheMoviesAsAcending(List<Movie> movies)
        {
          return movies.OrderBy(movie => movie.Rating).ThenBy(movie => movie.Title).ToList();
        }

        public List<Movie> SortTheMoviesAsDecending(List<Movie> movies)
        {
            return movies.OrderByDescending(movie => movie.Rating).ThenBy(movie => movie.Title).ToList();
        }

        public List<Movie> CombineMoviesToOneList(List<Movie> list1, List<Movie> list2)
        {
            var titleList1 = list1.Select(i => i.Title).ToList();

            foreach (var item in list2)
            {
                if (!titleList1.Contains(item.Title)) list1.Add(item);
            }
            return list1;
        }
    }
}
