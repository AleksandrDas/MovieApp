namespace MovieApp.Models
{
    using MovieApp.Logic.Database;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Vards { get; set; }

        [StringLength(50)]
        [Required]
        public string Epasts { get; set; }

        [StringLength(100)]
        [Required]
        public string Parole { get; set; }
        [NotMapped]
        [Compare("Parole", ErrorMessage = "Paroles nesakrit!")]
        [Required]
        public string Parole2 { get; set; }

        public static UserModel FromData(Users user)
        {
            return new UserModel()
            {
                Id = user.Id,
                Epasts = user.Epasts,
                Vards = user.Vards,
            };
        }

    }
}
