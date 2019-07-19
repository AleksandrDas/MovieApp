using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApp.Models
{
    public class MovieReservationModel
    {
        public MovieModel Movie { get; set; }
        public List<MovieSessionModel> Sessions { get; set; }
        public MovieReservationModel()
        {
            Sessions = new List<MovieSessionModel>();
        }
    }
}