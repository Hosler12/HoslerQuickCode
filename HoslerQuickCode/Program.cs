using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HoslerQuickCode
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleProcess();
        }

        static void ConsoleProcess()
        {
            List<Books> bookList = new List<Books>();
            AddObjects(bookList);
            DisplayObjects(bookList);
        }

        static void AddObjects(List<Books> bookList)
        {
            List<Books.Genre> genreList = new List<Books.Genre>();
            bool addMoreBooks = true;
            do
            {
                AddObjectsTextHeader("Would you like to provide additional books?");
                Console.WriteLine();
                addMoreBooks = DualConfirmation();
                if (addMoreBooks == true)
                {
                    Books userObject = new Books();
                    bool correctTitle = false;
                    do
                    {
                        AddObjectsTextHeader("Please enter a title: ");
                        userObject.Title = Console.ReadLine();
                        Console.WriteLine($"Is '{userObject.Title}' the Title you wanted?");
                        correctTitle = DualConfirmation();
                    } while (correctTitle == false);
                    bool correctAuthor = false;

                    do
                    {
                        AddObjectsTextHeader("Please enter the author: ");
                        userObject.Author = Console.ReadLine();
                        Console.WriteLine($"Is '{userObject.Author}' the Author you wanted?");
                        correctAuthor = DualConfirmation();
                    } while (correctAuthor == false);

                    bool foundPages = false;
                    do {
                        AddObjectsTextHeader("Please enter the number of pages: ");
                        foundPages = int.TryParse(Console.ReadLine(), out int pageLength);
                        userObject.Pages = pageLength;
                    } while (foundPages == false);

                    bool foundYears = false;
                    do
                    {
                        AddObjectsTextHeader("Please add in the release year here: ");
                        foundYears = int.TryParse(Console.ReadLine(), out int publishingYear);
                        userObject.ReleaseYear = publishingYear;
                    } while (foundYears == false);

                    bool genreAnswer = false;
                    do
                    {
                        Console.Clear();
                        DisplayListOfGenres(genreList);
                        AddGenreHeader();
                        switch (Console.ReadLine())
                        {
                            case "1":
                                userObject.GenreType = Books.Genre.HistoricalFiction;
                                genreAnswer = true;
                                break;
                            case "2":
                                userObject.GenreType = Books.Genre.Fantasy;
                                genreAnswer = true;
                                break;
                            case "3":
                                userObject.GenreType = Books.Genre.Biographical;
                                genreAnswer = true;
                                break;
                            case "4":
                                userObject.GenreType = Books.Genre.Classical;
                                genreAnswer = true;
                                break;
                            case "5":
                                userObject.GenreType = Books.Genre.Politics;
                                genreAnswer = true;
                                break;
                            case "6":
                                userObject.GenreType = Books.Genre.Religious;
                                genreAnswer = true;
                                break;
                            case "7":
                                userObject.GenreType = Books.Genre.Horror;
                                genreAnswer = true;
                                break;
                            case "8":
                                userObject.GenreType = Books.Genre.ScienceFiction;
                                genreAnswer = true;
                                break;
                            case "9":
                                userObject.GenreType = Books.Genre.Romance;
                                genreAnswer = true;
                                break;
                            case "10":
                                userObject.GenreType = Books.Genre.Nonfiction;
                                genreAnswer = true;
                                break;
                            case "11":
                                userObject.GenreType = Books.Genre.Historical;
                                genreAnswer = true;
                                break;
                            default:
                                Console.WriteLine("Please re-enter a choice from the menu, using only numbers 1-11.");
                                break;
                        }
                    } while (genreAnswer == false);
                    bookList.Add(userObject);
                    string[] fileObject = { userObject.Title, userObject.Author, Convert.ToString(userObject.Pages), Convert.ToString(userObject.ReleaseYear) };
                    System.IO.File.AppendAllLines(@"C:\Users\Public\BookList.txt", fileObject);
                }
            } while (addMoreBooks == true);
        }

        private static void DisplayListOfGenres(List<Books.Genre> genreType)
        {
            Console.WriteLine("\tGenre Types:");
            Console.WriteLine();
            int i = 0;
            foreach (string genre in Enum.GetNames(typeof(Books.Genre)))
            {
                i++;
                Console.WriteLine($"\t{i}) {genre}");
            }
        }

        private static void AddGenreHeader()
        {
            Console.WriteLine("\tBook List");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Please select the book's genre: ");
        }

        static void DisplayObjects(List<Books> bookList)
        {
            int sumPages = 0;
            foreach (var book in bookList)
            {
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Pages: {book.Pages.ToString()}");
                sumPages += book.Pages;
                Console.WriteLine($"Release Year: {book.ReleaseYear.ToString()}");
                Console.WriteLine($"Genre: {book.GenreType}");
                Console.WriteLine();
            }
            int averagePages = sumPages / bookList.Count();
            Console.WriteLine($"There is an average of '{averagePages} pages'");
            Console.WriteLine("You can find a text document of the list in C:\\Users\\Public\\BookList.txt.");
            Console.WriteLine("Press any Key to continue");
            Console.ReadLine();
        }

        static void AddObjectsTextHeader(string userQuestion)
        {
            Console.Clear();
            Console.WriteLine("\tBook List");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(userQuestion);
        }

        // Taken from the "Budget Calculator" Capstone project
        static bool DualConfirmation()
        {
            Console.WriteLine("Press ENTER if so. Press ESC if not.");
            ConsoleKeyInfo keyEntry;
            bool userRes = false;
            bool validKey = false;
            do
            {
                keyEntry = Console.ReadKey(intercept: true);
                switch (keyEntry.Key)
                {
                    case ConsoleKey.Enter:
                        userRes = true;
                        validKey = true;
                        break;
                    case ConsoleKey.Escape:
                        userRes = false;
                        validKey = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("ERROR: incorrect '{0}' key entered.", keyEntry.Key);
                        Console.WriteLine("Retry your key submission.");
                        break;
                }
            } while (validKey != true);
            Console.Clear();
            return userRes;
        }
    }
}
