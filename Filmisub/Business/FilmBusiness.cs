using Filmisub.Data.Models;
using Filmisub.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmisub.Business
{
    public class FilmBusiness
    {
        // Instance of the FilmContext to interact with the database.
        public FilmContext filmContext;

        // Retrieves all films from the database.
        public List<Film> GetAll()
        {
            using (filmContext = new FilmContext())
            {
                return filmContext.Films.ToList();
            }
        }

        // Retrieves a film by its ID.
        public Film Get(int id)
        {
            using (filmContext = new FilmContext())
            {
                return filmContext.Films.Find(id);
            }
        }

        // Adds a new film to the database.
        public void Add(Film film)
        {
            using (filmContext = new FilmContext())
            {
                filmContext.Films.Add(film);
                filmContext.SaveChanges();
            }
        }

        // Updates an existing film's data.
        public void Update(Film film)
        {
            using (filmContext = new FilmContext())
            {
                var item = filmContext.Films.Find(film.Id);
                if (item != null)
                {
                    filmContext.Entry(item).CurrentValues.SetValues(film);
                    filmContext.SaveChanges();
                }
            }
        }

        // Deletes a film from the database by ID.
        public void Delete(int id)
        {
            using (filmContext = new FilmContext())
            {
                var film = filmContext.Films.Find(id);
                if (film != null)
                {
                    filmContext.Films.Remove(film);
                    filmContext.SaveChanges();
                }
            }
        }
    }

}
