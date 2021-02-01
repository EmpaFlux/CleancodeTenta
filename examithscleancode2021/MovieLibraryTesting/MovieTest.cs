using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Moq;
using MovieLibrary;
using MovieLibrary.Controllers;
using MovieLibrary.Models;
using MovieLibrary.Adapter;

namespace MovieLibraryTesting
{
    public class MovieTest
    {
        [Fact]
        public void SortMoviesAsAscendingTest()
        {
            var list = new List<Movie>() {
                new Movie() { Title = "The Room", Rating = "2.2" },
                new Movie() { Title = "The Barbarians", Rating = "7.0" },
            };
            var adapter = new MovieAdapter();

            var expected = new List<Movie>() {
                new Movie() { Title = "The Barbarians", Rating = "7.0"},
                new Movie() { Title = "The Room", Rating = "2.2" },
            };
            var actual = adapter.SortTheMoviesAsAcending(list);

            Assert.Equal(expected.Count, actual.Count);
            foreach (var movie in actual)
            {
                Assert.Equal(expected[actual.IndexOf(movie)].Title, movie.Title);
            }
        }
        [Fact]
        public void FindByIDTest()
        {
            var list = new List<Movie>() {
                new Movie() { Title = "Find this", Rating = "7.0", Id = "1" },
            };
            var service = new MovieAdapter();

            var expected = new Movie() { Title = "The Barbarians", Rating = "7.0", Id = "1" };
            var actual = service.FindMovieByID(list, "1");

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Title, actual.Title);
        }
    }
}