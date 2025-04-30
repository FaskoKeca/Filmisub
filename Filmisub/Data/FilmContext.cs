using Filmisub.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmisub.Data
{
    public class FilmContext : DbContext
    {
        // Constructor to initialize the DbContext with the specified connection string name.
        public FilmContext() : base("name=FilmContext")
        {
        }

        // DbSet representing the Films table in the database.
        public DbSet<Film> Films { get; set; }
    }
}
