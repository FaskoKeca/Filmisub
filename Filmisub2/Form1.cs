using Filmisub.Data.Models;
using Filmisub.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Filmisub2
{
    public partial class Form1 : Form
    {
        private FilmBusiness filmBusiness = new FilmBusiness(); // Business logic for film operations.

        public Form1()
        {
            InitializeComponent(); // Initializes WinForms components.
            LoadFilms(); // Load films into DataGridView on startup.
        }

        // Loads all films and displays them in the grid view.
        private void LoadFilms()
        {
            var films = filmBusiness.GetAll();
            dataGridView1.DataSource = films;
        }

        // Clears all input fields.
        private void ClearFields()
        {
            txtId.Clear();
            txtTitle.Clear();
            txtDirector.Clear();
            txtYear.Clear();
            txtGenre.Clear();
            txtDescription.Clear();
        }

        // Constructs a Film object using values from input fields.
        private Film GetFilmFromInput()
        {
            return new Film
            {
                Title = txtTitle.Text,
                Director = txtDirector.Text,
                Year = int.TryParse(txtYear.Text, out int year) ? year : 0,
                Genre = txtGenre.Text,
                Description = txtDescription.Text
            };
        }

        // Adds a new film when the "Add" button is clicked.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var film = GetFilmFromInput();
            filmBusiness.Add(film);
            LoadFilms();
            ClearFields();
        }

        // Updates an existing film by ID.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                var film = GetFilmFromInput();
                film.Id = id;
                filmBusiness.Update(film);
                LoadFilms();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Invalid ID for update.");
            }
        }

        // Deletes a film using its ID.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                filmBusiness.Delete(id);
                LoadFilms();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Invalid ID for deletion.");
            }
        }

        // Fetches a film by ID and fills the input fields with its data.
        private void btnFetch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                var film = filmBusiness.Get(id);
                if (film != null)
                {
                    txtTitle.Text = film.Title;
                    txtDirector.Text = film.Director;
                    txtYear.Text = film.Year.ToString();
                    txtGenre.Text = film.Genre;
                    txtDescription.Text = film.Description;
                }
                else
                {
                    MessageBox.Show("Film not found.");
                }
            }
            else
            {
                MessageBox.Show("Invalid ID.");
            }
        }
    }
}
