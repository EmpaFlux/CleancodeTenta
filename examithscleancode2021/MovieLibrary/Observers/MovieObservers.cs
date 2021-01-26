using System;
using System.Collections.Generic;
using MovieLibrary.Controllers;


namespace MovieLibrary.Observers
{
    public class MovieObserver: IObservable<ObservedMovies>
    {
        private IDisposable unsubscriber;
        private string mName;
    }
    
    public MovieObserver()

    public struct ObservedMovies
    {
        List<Movie> _movie;

        public ObservedMovies(List<Movie> movie)
        {
            _movie = movie;
        }

        public List<Movie> ObserverMovie
        {
            get { return _movie; }
        }
    }
}