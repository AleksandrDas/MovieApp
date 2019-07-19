using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieApp.Models
{
    public partial class MovieSessionModel

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }

        [Required]
        [StringLength(50)]
        public string Time { get; set; }

        [Required]
        [StringLength(10)]
        public string Price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual MovieModel Movies { get; set; }
        public MovieApp.Logic.Database.Sessions ToData()
        {
            return new MovieApp.Logic.Database.Sessions()
            {
                Id = Id,
                Time = Time,
                Price = Price,
                MovieId = MovieId,
            };
        }
        public static MovieSessionModel FromData(MovieApp.Logic.Database.Sessions data)
        {
            return new MovieSessionModel()
            {
                Id = data.Id,
                Time = data.Time,
                Price = data.Price,
                MovieId = data.MovieId,
            };

        }
    }
}