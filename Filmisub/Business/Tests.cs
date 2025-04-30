using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Filmisub.Business;
using Filmisub.Data.Models;

namespace Filmisub.Tests
{
    [TestFixture]
    public class Tests
    {
        private FilmBusiness filmBusiness;
        private string connectionString;

        [SetUp]
        public void Setup()
        {
            filmBusiness = new FilmBusiness();
            connectionString = ConfigurationManager.ConnectionStrings["FlowerContext"].ConnectionString;
        }

        [Test]
        public void Get_ExistingId_ShouldReturnCorrectFilm()
        {
            int id = 2003;
            Film film = filmBusiness.Get(id);
            Assert.That(film, Is.Not.Null);
            Assert.That(film.Id, Is.EqualTo(id));
        }

        [Test]
        public void Get_NonexistentId_ShouldReturnNull()
        {
            int id = -1;
            Film film = filmBusiness.Get(id);
            Assert.That(film, Is.Null);
        }

        [Test]
        public void Add_ShouldIncreaseFilmCount()
        {
            int initialCount = filmBusiness.GetAll().Count;
            Film film = new Film
            {
                Title = "New Film",
                Description = "New Film Description"
            };

            filmBusiness.Add(film);
            int updatedCount = filmBusiness.GetAll().Count;

            Assert.That(updatedCount, Is.EqualTo(initialCount + 1));
        }

        [Test]
        public void Update_ExistingId_ShouldUpdateTitle()
        {
            int id = 2003;
            Film existingFlower = filmBusiness.Get(id);
            string newName = "Updated Name";
            existingFlower.Title = newName;

            filmBusiness.Update(existingFlower);
            Film updatedFilm = filmBusiness.Get(id);

            Assert.That(updatedFilm, Is.Not.Null);
            Assert.That(updatedFilm.Title, Is.EqualTo(newName));
        }

        [Test]
        public void Delete_ExistingId_ShouldDecreaseFilmCount()
        {
            int id = 2005;
            int initialCount = filmBusiness.GetAll().Count;

            filmBusiness.Delete(id);
            int updatedCount = filmBusiness.GetAll().Count;

            Assert.That(updatedCount, Is.EqualTo(initialCount - 1));
        }

        [Test]
        public void Delete_NonexistentId_ShouldNotChangeFilmCount()
        {
            int id = -1;
            int initialCount = filmBusiness.GetAll().Count;

            filmBusiness.Delete(id);
            int updatedCount = filmBusiness.GetAll().Count;

            Assert.That(updatedCount, Is.EqualTo(initialCount));
        }

        [Test]
        public void DatabaseConnection_ShouldBeOpen()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Assert.That(connection.State, Is.EqualTo(System.Data.ConnectionState.Open));
            }
        }
    }
}
