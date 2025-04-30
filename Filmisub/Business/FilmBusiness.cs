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
        public FilmContext filmContext;

        public List<Film> GetAll()
        {
            using (filmContext = new FilmContext())
            {
                return filmContext.Films.ToList();
            }
        }

        public Film Get(int id)
        {
            using (filmContext = new FilmContext())
            {
                return filmContext.Films.Find(id);
            }
        }

        public void Add(Film film)
        {
            using (filmContext = new FilmContext())
            {
                filmContext.Films.Add(film);
                filmContext.SaveChanges();
            }
        }

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
