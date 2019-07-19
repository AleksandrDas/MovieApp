namespace MovieApp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CinemaModel
    {
        public CinemaModel()
        {
            Movies = new List<MovieModel>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(60)]
        [Display(Name = "Address")]
        public string Adress { get; set; }
        public int MovieCount { get; set; }

        public List<MovieModel> Movies { get; set; }

        public MovieApp.Logic.Database.Cinemas ToData()
        {
            return new MovieApp.Logic.Database.Cinemas()
            {
                Id = Id,
                Adress = Adress,
                Name = Name
            };
        }
        public static CinemaModel FromData(MovieApp.Logic.Database.Cinemas data)
        {
            return new CinemaModel()
            {
                Id = data.Id,
                Adress = data.Adress,
                Name = data.Name,
            };
        }
    }
}
