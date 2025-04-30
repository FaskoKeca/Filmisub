using Filmisub.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmisub.Data
{
    internal class FilmContext : DbContext
    {
        public FilmContext() : base("name=FilmContext")
        {
        }
        public DbSet<Film> Films { get; set; }
    }
}
