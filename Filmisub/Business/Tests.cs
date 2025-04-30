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
            connectionString = ConfigurationManager.ConnectionStrings["FilmContext"].ConnectionString;
        }

        // Tests whether fetching a valid film ID returns the correct object.
        [Test]
        public void Get_ExistingId_ShouldReturnCorrectFilm()
        {
            int id = 2003;
            Film film = filmBusiness.Get(id);
            Assert.That(film, Is.Not.Null);
            Assert.That(film.Id, Is.EqualTo(id));
        }

        // Tests that requesting a non-existent ID returns null.
        [Test]
        public void Get_NonexistentId_ShouldReturnNull()
        {
            int id = -1;
            Film film = filmBusiness.Get(id);
            Assert.That(film, Is.Null);
        }

        // Tests that adding a film with partial data increases count.
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

        // Tests that adding a fully populated film saves all properties.
        [Test]
        public void Add_FullFilm_ShouldSaveAllFields()
        {
            Film film = new Film
            {
                Title = "Full Film",
                Director = "Test Director",
                Year = 2023,
                Genre = "Drama",
                Description = "Detailed film description."
            };

            filmBusiness.Add(film);

            Film saved = filmBusiness.GetAll().FirstOrDefault(f => f.Title == "Full Film");
            Assert.That(saved, Is.Not.Null);
            Assert.That(saved.Director, Is.EqualTo("Test Director"));
            Assert.That(saved.Year, Is.EqualTo(2023));
            Assert.That(saved.Genre, Is.EqualTo("Drama"));
            Assert.That(saved.Description, Is.EqualTo("Detailed film description."));
        }

        // Tests updating a film's title and director.
        [Test]
        public void Update_ExistingId_ShouldUpdateMultipleFields()
        {
            int id = 2003;
            Film film = filmBusiness.Get(id);

            string newTitle = "Updated Title";
            string newDirector = "Updated Director";
            film.Title = newTitle;
            film.Director = newDirector;

            filmBusiness.Update(film);
            Film updated = filmBusiness.Get(id);

            Assert.That(updated.Title, Is.EqualTo(newTitle));
            Assert.That(updated.Director, Is.EqualTo(newDirector));
        }

        // Tests updating year and genre.
        [Test]
        public void Update_ShouldChangeYearAndGenre()
        {
            var film = new Film
            {
                Title = "Year Genre Film",
                Director = "Dir",
                Year = 2000,
                Genre = "Old Genre",
                Description = "..."
            };
            filmBusiness.Add(film);
            var added = filmBusiness.GetAll().First(f => f.Title == "Year Genre Film");

            added.Year = 2024;
            added.Genre = "New Genre";
            filmBusiness.Update(added);

            var updated = filmBusiness.Get(added.Id);
            Assert.That(updated.Year, Is.EqualTo(2024));
            Assert.That(updated.Genre, Is.EqualTo("New Genre"));
        }

        // Tests that deleting an existing film decreases the total count.
        [Test]
        public void Delete_ExistingId_ShouldDecreaseFilmCount()
        {
            var film = new Film { Title = "Delete Test", Description = "To be deleted" };
            filmBusiness.Add(film);
            int id = filmBusiness.GetAll().First(f => f.Title == "Delete Test").Id;

            int countBefore = filmBusiness.GetAll().Count;
            filmBusiness.Delete(id);
            int countAfter = filmBusiness.GetAll().Count;

            Assert.That(countAfter, Is.EqualTo(countBefore - 1));
        }

        // Tests that deleting a non-existent ID does not affect the count.
        [Test]
        public void Delete_NonexistentId_ShouldNotChangeFilmCount()
        {
            int id = -99;
            int countBefore = filmBusiness.GetAll().Count;

            filmBusiness.Delete(id);
            int countAfter = filmBusiness.GetAll().Count;

            Assert.That(countAfter, Is.EqualTo(countBefore));
        }

        // Tests if the database connection string works.
        [Test]
        public void DatabaseConnection_ShouldBeOpen()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Assert.That(connection.State, Is.EqualTo(System.Data.ConnectionState.Open));
            }
        }

        // Tests that GetAll returns at least one entry when films are present.
        [Test]
        public void GetAll_ShouldReturnNonEmptyListAfterAdd()
        {
            filmBusiness.Add(new Film { Title = "Listed Film", Description = "For GetAll test" });
            var list = filmBusiness.GetAll();
            Assert.That(list.Count, Is.GreaterThan(0));
        }

        // Tests that films with empty fields still save correctly.
        [Test]
        public void Add_EmptyOptionalFields_ShouldStillSave()
        {
            var film = new Film
            {
                Title = "No Genre or Director",
                Year = 2023,
                Description = "Edge case test"
            };

            filmBusiness.Add(film);
            var saved = filmBusiness.GetAll().FirstOrDefault(f => f.Title == "No Genre or Director");

            Assert.That(saved, Is.Not.Null);
            Assert.That(saved.Genre, Is.Null.Or.Empty);
            Assert.That(saved.Director, Is.Null.Or.Empty);
        }

        // Tests re-adding a deleted film with the same data.
        [Test]
        public void ReAdd_DeletedFilm_ShouldSucceed()
        {
            var film = new Film { Title = "ReAdd Test", Description = "Will be deleted and re-added" };
            filmBusiness.Add(film);
            var saved = filmBusiness.GetAll().First(f => f.Title == "ReAdd Test");

            filmBusiness.Delete(saved.Id);

            filmBusiness.Add(film); // Re-add same data
            var readded = filmBusiness.GetAll().FirstOrDefault(f => f.Title == "ReAdd Test");
            Assert.That(readded, Is.Not.Null);
        }
    }
}
