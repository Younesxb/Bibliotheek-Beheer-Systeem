using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;



namespace Bib_YounesBenzian
{
    internal class Library
    {
     
        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private List<Book> books;
        public List<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }

        public Library(string name)
        {
            this.Name = name;
            Books = new List<Book>();
        }



        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public Book FindISBN(int isbn)
        {
            foreach (var book in Books)
            {
                if (book.ISBN == isbn)
                {
                    return book;
                }
            }

            return null;
        }
        public Book FindBookByTitleAndAuthor(string title, string author)
        {
            foreach (Book book in Books)
            {
                if (book.Title == title && book.Author == author)
                {
                    return book;
                }
            }
            return null;
        }


        public Book FindBook(string title, string author)
        {
            foreach (Book book in Books)
            {
                if (book.Title == title && book.Author == author)
                {
                    return book;
                }
            }
            return null; 
        }

      

        public List<Book> FindBooksByTitle(string title)
        {
            List<Book> foundBooks = new List<Book>();
            foreach (Book book in Books)
            {
                if (book.Title == title)
                {
                    foundBooks.Add(book);
                }
            }
            return foundBooks;
        }

     

        public List<Book> FindBooksByAuthor(string author)
        {
            List<Book> booksByAuthor = new List<Book>();
            foreach (Book book in Books)
            {
                if (book.Author == author)
                {
                    booksByAuthor.Add(book);
                }
            }
            return booksByAuthor;
        }

        private Dictionary<DateTime, ReadingRoomItem> allReadingRoom = new Dictionary<DateTime, ReadingRoomItem>(); //Feedback verbeterd
        public Dictionary<DateTime, ReadingRoomItem> AllReadingRoom
        {
            get
            {
                
                return this.allReadingRoom;
            }
        }


        public void AddNewspaper()
        {

            Console.WriteLine("Wat is de naam van de krant? ");
            string newspaperName = Console.ReadLine();
            Console.WriteLine("Wat is de datum van de krant? (dd/mm/yyyy) ");
            DateTime newspaperDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.WriteLine("Wat is de uitgeverij van de krant? ");
            string newspaperPublisher = Console.ReadLine();

            NewsPaper newspaper = new NewsPaper(newspaperName, newspaperPublisher, newspaperDate);
            AllReadingRoom.Add(newspaperDate, newspaper);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Krant toegevoegd");
            Console.ResetColor();
        }

        public void AddMagazine()
        {
            Console.WriteLine("Voeg een maandblad toe aan de leeszaal:");
            Console.WriteLine("Wat is de naam van het maandblad? ");
            string magazineName = Console.ReadLine();
            Console.WriteLine("Wat is de maand van het maandblad? Cijfer geven bv: 02 ");
            byte magazineMonth = byte.Parse(Console.ReadLine());
            Console.WriteLine("Wat is het jaar van het maandblad? ");
            uint magazineYear = uint.Parse(Console.ReadLine());
            Console.WriteLine("Wat is de uitgeverij van het maandblad? ");
            string magazinePublisher = Console.ReadLine();

            Magazine magazine = new Magazine(magazineName, magazinePublisher, magazineMonth, magazineYear);
            AllReadingRoom.Add(DateTime.Now, magazine);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("MaandBlad toegevoegd");
            Console.ResetColor();
        }


        public void ShowAllNewspapers()
        {
            Console.WriteLine("De kranten in de leeszaal:");
            foreach (var item in AllReadingRoom)
            {
                if (item.Value is NewsPaper)
                {
                    NewsPaper newspaper = (NewsPaper)item.Value;
                    Console.WriteLine($"- {newspaper.Title} van {newspaper.Date.ToString("dddd d MMMM yyyy")} van uitgeverij {newspaper.Publisher}");
                }
            }
        }

        public void ShowAllMagazines()
        {
            Console.WriteLine("Alle maandbladen uit de leeszaal:");
            foreach (var item in AllReadingRoom)
            {
                if (item.Value is Magazine)
                {
                    Magazine magazine = (Magazine)item.Value;
                    Console.WriteLine($"- {magazine.Title} van {magazine.Month}/{magazine.Year} van uitgeverij {magazine.Publisher}");
                }
            }
        }

    

        public void AcquisitionsReadingRoomToday()
        {
            Console.WriteLine($"Aanwinsten in de leeszaal van {DateTime.Now.ToShortDateString()}:");
            foreach (var item in AllReadingRoom)
            {
                Console.WriteLine($"{item.Value.Title} met id {item.Value.Identification}");
            }
        }




    }
}
