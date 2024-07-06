using System;
using System.Collections;
using System.Collections.Generic;


namespace _10_StandartInterfaces
{
    class Cinema : IEnumerable
    {
        private List<Movie> movies = new List<Movie>();
        public void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }
        public void SortMovies(IComparer<Movie> comparer)
        {
            movies.Sort(comparer);
        }
        public IEnumerator GetEnumerator()
        {
            return movies.GetEnumerator();
        }
    }
    class Director : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public Director()
        {
            FirstName = "no Firstname";
            LastName = "no LastName";
            Description = "no description";
        }
        public Director(string F, string L, string d)
        {
            FirstName = F;
            LastName = L;
            Description = d;
        }

        public override string ToString()
        {
            return $"First name: {FirstName}, Last name: {LastName}, Description: {Description}";
        }

        public object Clone()
        {
            return new Director(FirstName, LastName, Description);
        }
    }

    enum Genre { Comedy, Horror, Adventure, Dramma, Fantazy }

    class Movie : ICloneable, IComparable
    {
        public string Title { get; set; }
        public Director Director { get; set; }
        public string Country { get; set; }
        public Genre Genre { get; set; }
        public int Year { get; set; }
        public byte Rating { get; set; }

        public object Clone()
        {
            return new Movie
            {
                Title = this.Title,
                Director = (Director)this.Director.Clone(),
                Country = this.Country,
                Genre = this.Genre,
                Year = this.Year,
                Rating = this.Rating
            };
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Movie otherMovie = obj as Movie;
            if (otherMovie != null)
                return this.Title.CompareTo(otherMovie.Title);
            else
                throw new ArgumentException("Object is not a Movie");
        }
        public override string ToString()
        {
            return $"Title: {Title}, Director: {Director}, Country: {Country}, Genre: {Genre}, Year: {Year}, Rating: {Rating}";
        }
    }
    class MovieComparerByYear : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return x.Year.CompareTo(y.Year);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Cinema cinema = new Cinema();

            Director director1 = new Director("John", "Doe", "Famous director");
            Director director2 = new Director("Jane", "Smith", "Renowned director");

            Movie movie1 = new Movie
            {
                Title = "Movie One",
                Director = director1,
                Country = "USA",
                Genre = Genre.Adventure,
                Year = 2020,
                Rating = 5
            };
            Movie movie2 = new Movie
            {
                Title = "Movie Two",
                Director = director2,
                Country = "UK",
                Genre = Genre.Comedy,
                Year = 2021,
                Rating = 4
            };

            cinema.AddMovie(movie1);
            cinema.AddMovie(movie2);

            Console.WriteLine("Movies before sorting:");
            foreach (Movie movie in cinema)
            {
                Console.WriteLine(movie);
            }

            cinema.SortMovies(new MovieComparerByYear());

            Console.WriteLine("\nMovies after sorting by year:");
            foreach (Movie movie in cinema)
            {
                Console.WriteLine(movie);
            }
        }
    }

}
