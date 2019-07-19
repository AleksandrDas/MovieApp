namespace MovieApp.Logic.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Vards { get; set; }

        [StringLength(50)]
        public string Epasts { get; set; }

        [StringLength(100)]
        public string Parole { get; set; }
    }
}
