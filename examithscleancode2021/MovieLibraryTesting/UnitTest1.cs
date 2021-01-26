using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Moq;
using MovieLibrary;
using MovieLibrary.Controllers;

namespace MovieLibraryTesting
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            List<Movie> expected = new List<Movie>();
            expected.Add(new Movie() { id = "1", title = "The Barbarians", rated = "8"});


            //Act
            Assert.AreEqual(expected, );
        }
    }
}