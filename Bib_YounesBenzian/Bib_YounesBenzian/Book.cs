using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bib_YounesBenzian
{

    internal class Book : ILendable
    {

        private string title;
        public string Title
        {
            get { return this.title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Titel mag niet leeg zijn");
                }
                this.title = value;
            }
        }

        private string author;
        public string Author
        {
            get { return this.author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Auteur mag niet leeg zijn");
                }
                this.author = value;
            }
        }

        private long isbn;
        public long ISBN
        {
            get { return this.isbn; }
            set
            {
                if (value.ToString().Length != 13)
                {
                    throw new ArgumentException("ISBN moet een 13-cijferig nummer zijn.");
                }
                this.isbn = value;
            }
        }

        private Genre genre;
        public Genre Genre
        {
            get { return this.genre; }
            set { this.genre = value; }
        }

        private string publisher;
        public string Publisher
        {
            get { return this.publisher; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Publisher mag niet leeg zijn");
                }
                this.publisher = value;
            }
        }

        private int publicationYear;
        public int PublicationYear
        {
            get { return this.publicationYear; }
            set
            {
                if (value < 2000)
                {
                    throw new ArgumentException("Bib_Younes heeft alleen boeken vanaf het jaar 2000");
                }
                this.publicationYear = value;
            }
        }

        private int pages;
        public int Pages
        {
            get { return this.pages; }
            set { this.pages = value; }
        }

        private string language;
        public string Language
        {
            get { return this.language; }
            set { this.language = value; }
        }



        public Book(string title, string author)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Titel mag niet leeg zijn", nameof(title));
            }
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Auteur mag niet leeg zijn", nameof(author));
            }

            Title = title;
            Author = author;
            IsAvailable = true;
        }


        private bool isavailable;
        
        public bool IsAvailable
    {
            get { return isavailable; }
            set { isavailable = value; }
        }
   
        private DateTime myVar;

        public DateTime BorrowingDate
        {
            get { return myVar; }
            set { myVar = value; }
        }



        private int borrowdays;

        public int BorrowDays
        {
            get { return borrowdays; }
            set { borrowdays = value; }
        }


        public void Borrow()
        {
            if (IsAvailable)
            {
                BorrowingDate = DateTime.Now;
                IsAvailable = false;
                BorrowDays = Genre == Genre.Schoolboek ? 10 : 20;
                Console.WriteLine($"Boek '{Title}' is uitgeleend. Verwachte retourdatum: {BorrowingDate.AddDays(BorrowDays)}");
            }
            else
            {
                Console.WriteLine($"Boek '{Title}' is niet beschikbaar om uit te lenen.");
            }
        }

        public void Return()
        {
            if (!IsAvailable)
            {
                DateTime returnDate = DateTime.Now;
                IsAvailable = true;
                int overdueDays = (int)(returnDate - BorrowingDate).TotalDays - BorrowDays;
                if (overdueDays > 0)
                {
                    Console.WriteLine($"Boek '{Title}' is te laat ingeleverd. U bent {overdueDays} dagen te laat.");
                }
                else
                {
                    Console.WriteLine($"Boek '{Title}' is op tijd ingeleverd.");
                }
            }
            else
            {
                Console.WriteLine($"Boek '{Title}' is al beschikbaar.");
            }
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Titel: {(string.IsNullOrWhiteSpace(this.Title) ? "Moet nog ingevuld worden" : this.Title)}");
            Console.WriteLine($"Auteur: {(string.IsNullOrWhiteSpace(this.Author) ? "Moet nog ingevuld worden" : this.Author)}");
            Console.WriteLine($"ISBN: {(this.ISBN == 0 ? "Moet nog ingevuld worden" : this.ISBN.ToString())}");

            Console.WriteLine($"Genre: {(this.Genre == Genre.Onbekend ? "Moet nog ingevuld worden" : this.Genre.ToString())}");
            Console.WriteLine($"Uitgever: {(string.IsNullOrWhiteSpace(this.Publisher) ? "Moet nog ingevuld worden" : this.Publisher)}");

            Console.WriteLine($"Publicatiejaar: {(this.PublicationYear == 0 ? "Moet nog ingevuld worden" : this.PublicationYear.ToString())}");
            Console.WriteLine($"Aantal pagina's: {(this.Pages == 0 ? "Moet nog ingevuld worden" : this.Pages.ToString())}");
            Console.WriteLine($"Taal: {(string.IsNullOrWhiteSpace(this.Language) ? "Moet nog ingevuld worden" : this.Language)}");
        }

    }
}




