using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MovieApp.Models
{
   

    public class MainViewModel
    {
        public List<CinemaModel> Cinemas { get; set; }
       
        public List<MovieModel> Movies { get; set; }
        public MainViewModel()
        {
            Movies = new List<MovieModel>();
            Cinemas = new List<CinemaModel>();
        }


    }
}
