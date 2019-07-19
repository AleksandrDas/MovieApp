namespace MovieApp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class MovieModel
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "Nosaukums")]
        public string Title { get; set; }

        public int? Year { get; set; }

        public int CinemaId { get; set; }

        public virtual CinemaModel Cinema { get; set; }
        public List<MovieSessionModel> MovieSessions { get; set; }

        public MovieApp.Logic.Database.Movies ToData()
        {
            return new MovieApp.Logic.Database.Movies()
            {
                Id = Id,
                Title = Title,
                CinemaId = CinemaId,
                Year = Year,
            };
        }

        public static MovieModel FromData(MovieApp.Logic.Database.Movies data)
        {
            return new MovieModel()
            {
                Id = data.Id,
                CinemaId = data.CinemaId,
                Title = data.Title,
                Year = data.Year,
            };
        }
    }
}
