using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmisub.Data.Models
{
    public class Film
    {
        // Primary key for the film entity.
        public int Id { get; set; }

        // Title of the film.
        public string Title { get; set; }

        // Director of the film.
        public string Director { get; set; }

        // Year the film was released.
        public int Year { get; set; }

        // Genre of the film.
        public string Genre { get; set; }

        // Brief description of the film.
        public string Description { get; set; }
    }

}
