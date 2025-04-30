using Filmisub.Business;
using Filmisub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Filmisub.Presentation
{
    internal class Display
    {
        public string accountType = ""; // Stores user account type.
        private int closeOperationId = 6; // Menu option number to exit the application.
        FilmBusiness filmBusiness = new FilmBusiness(); // Handles film-related operations.

        // Prompts user to input account type and assigns role accordingly.
        private void CheckAccountType()
        {
            Console.WriteLine("Enter your account type: ");
            accountType = Console.ReadLine();

            switch (accountType.ToLower())
            {
                case "admin":
                    accountType = "admin";
                    break;
                case "client":
                    accountType = "client";
                    break;
                default:
                    accountType = "client";
                    break;
            }
            Console.Clear();
        }

        // Displays admin menu options.
        private void ShowAdminMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Film Catalog");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all films");
            Console.WriteLine("2. Add new film");
            Console.WriteLine("3. Update film");
            Console.WriteLine("4. Fetch film by id");
            Console.WriteLine("5. Delete film");
            Console.WriteLine("6. Exit");
        }

        // Displays client menu options.
        private void ShowClientMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Film Catalog");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all films");
            Console.WriteLine("2. Add new film");
            Console.WriteLine("3. Fetch film by id");
            Console.WriteLine("4. Exit");
        }

        // Displays option to go back to menu.
        private void GoBack()
        {
            Console.WriteLine("\n0. Go back");
            var operation = int.Parse(Console.ReadLine());
            Console.Clear();

            if (accountType == "admin")
                if (operation == 0) ShowAdminMenu();
                else
                if (operation == 0) ShowClientMenu();

            Console.Clear();
        }

        // Handles the user's menu input and routes to operations.
        private void Input()
        {
            CheckAccountType();
            var operation = -1;

            if (accountType.ToLower() == "admin")
            {
                do
                {
                    ShowAdminMenu();
                    try
                    {
                        operation = int.Parse(Console.ReadLine());
                        switch (operation)
                        {
                            case 1: ListAll(); break;
                            case 2: Add(); break;
                            case 3: Update(); break;
                            case 4: Fetch(); break;
                            case 5: Delete(); break;
                            default: break;
                        }
                    }
                    catch (FormatException)
                    {
                        break;
                    }
                } while (operation != closeOperationId);
            }
            else
            {
                do
                {
                    ShowClientMenu();
                    try
                    {
                        operation = int.Parse(Console.ReadLine());
                        switch (operation)
                        {
                            case 1: ListAll(); break;
                            case 2: Add(); break;
                            case 3: Fetch(); break;
                            default: break;
                        }
                    }
                    catch (FormatException)
                    {
                        break;
                    }
                } while (operation != closeOperationId);
            }
        }

        // Constructor initializes the user interaction.
        public Display()
        {
            Input();
        }

        // Adds a new film to the database.
        private void Add()
        {
            Console.Clear();
            Film film = new Film();
            Console.WriteLine("Enter title: ");
            film.Title = Console.ReadLine();
            Console.WriteLine("Enter director: ");
            film.Director = Console.ReadLine();
            Console.WriteLine("Enter year: ");
            film.Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter genre: ");
            film.Genre = Console.ReadLine();
            Console.WriteLine("Enter description: ");
            film.Description = Console.ReadLine();
            filmBusiness.Add(film);

            Console.Clear();
            Console.WriteLine("Film added successfully!");
            Thread.Sleep(3000);
            Console.Clear();
        }

        // Lists all films.
        private void ListAll()
        {
            Console.Clear();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Films");
            Console.WriteLine(new string('-', 40));

            var films = filmBusiness.GetAll();
            foreach (var item in films)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine($"ID: {item.Id}");
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Director: {item.Director}");
                Console.WriteLine($"Year: {item.Year}");
                Console.WriteLine($"Genre: {item.Genre}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine(new string('-', 40));
            }

            GoBack();
        }

        // Updates an existing film.
        private void Update()
        {
            Console.Clear();
            Console.WriteLine("Enter id to update");
            int id = int.Parse(Console.ReadLine());
            Film film = filmBusiness.Get(id);

            if (film != null)
            {
                Console.WriteLine("Enter title: ");
                film.Title = Console.ReadLine();
                Console.WriteLine("Enter director: ");
                film.Director = Console.ReadLine();
                Console.WriteLine("Enter year: ");
                film.Year = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter genre: ");
                film.Genre = Console.ReadLine();
                Console.WriteLine("Enter description: ");
                film.Description = Console.ReadLine();
                filmBusiness.Update(film);

                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("Entry updated successfully!");
            }
            else
            {
                Console.WriteLine("Entry not found!");
            }

            Thread.Sleep(2000);
            Console.Clear();
        }

        // Fetches and displays a film by ID.
        private void Fetch()
        {
            Console.Clear();
            Console.WriteLine("Enter id to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Film film = filmBusiness.Get(id);

            if (film != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + film.Id);
                Console.WriteLine("Title: " + film.Title);
                Console.WriteLine("Director: " + film.Director);
                Console.WriteLine("Year: " + film.Year);
                Console.WriteLine("Genre: " + film.Genre);
                Console.WriteLine("Description: " + film.Description);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Entry not found!");
            }

            GoBack();
        }

        // Deletes a film by ID.
        private void Delete()
        {
            Console.Clear();
            Console.WriteLine("Enter Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            filmBusiness.Delete(id);

            Console.Clear();
            Console.WriteLine("Entry deleted successfully!");
            Thread.Sleep(3000);
            Console.Clear();
        }
    }
}
