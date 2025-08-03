namespace Bib_YounesBenzian


{
    internal class Program
    {

        static void Main(string[] args)
        {

            Library bib_younes = new Library("Bib_Younes");

            Console.WriteLine("Welkom in het bibliotheekbeheersysteem! ");
            Console.WriteLine("Druk op enter op verder te gaan...");
            Console.ReadLine();

            bool goOn = true;

            while (goOn)
            {
      
                Console.WriteLine("Kies een optie tussen 1-13 :");
                Console.WriteLine(" ");
                Console.WriteLine("1.  Voeg een boek toe");
                Console.WriteLine("2.  Voeg informatie toe aan een boek");
                Console.WriteLine("3.  Toon informatie van een boek");
                Console.WriteLine("4.  Zoek een boek");
                Console.WriteLine("5.  Verwijder een boek");
                Console.WriteLine("6.  Voeg een krant toe aan de leeszaal");
                Console.WriteLine("7.  Voeg een maandblad toe aan de leeszaal");
                Console.WriteLine("8.  Toon alle kranten in de leeszaal");
                Console.WriteLine("9.  Toon alle maandbladen in de leeszaal");
                Console.WriteLine("10. Toon de aanwinsten van de huidige dag");
                Console.WriteLine("11. Boek ontlenen");
                Console.WriteLine("12. Boek terugbrengen");
                Console.WriteLine("13. Toon alle boeken");
                Console.WriteLine(" ");
                Console.WriteLine("14. Exit");
                Console.WriteLine("");
                Console.Write("Keuze: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        addBookToBib(bib_younes);
                        break;
                    case 2:
                        Console.Clear();
                        addInformationToBib(bib_younes);
                        break;
                    case 3:
                        Console.Clear();
                        showBookInformation(bib_younes);
                        break;
                    case 4:
                        Console.Clear();
                        searchBook(bib_younes);
                        break;
                    case 5:
                        Console.Clear();
                        removeTheBookFromBib(bib_younes);
                        break;
                    case 6:
                        Console.Clear();
                        bib_younes.AddNewspaper();
                        break;
                        
                    case 7:
                        Console.Clear();
                        bib_younes.AddMagazine();
                        break;
                    case 8:
                        Console.Clear();
                        bib_younes.ShowAllNewspapers();
                        break;
                    case 9:
                        Console.Clear();
                        bib_younes.ShowAllMagazines();
                        break;
                    case 10:
                        Console.Clear();
                        bib_younes.AcquisitionsReadingRoomToday();
                        break;
                    case 11:
                        Console.Clear();
                        BorrowBook(bib_younes);
                        break;
                    case 12:
                        Console.Clear();
                        ReturnBook(bib_younes);
                        break;
                    case 13:
                        
                        Console.Clear();
                        showAllBooks(bib_younes);
                        break;
                       
                    case 14:
                        Console.Clear();
                        Console.WriteLine("U hebt gekozen voor het programma af te sluiten.");

                        goOn = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                        Console.ResetColor();
                        break;
                }
            }
        }

       
        public static void addBookToBib(Library bib)
        {
            Console.WriteLine("U hebt gekozen om een nieuw boek toe te voegen. ");
            Console.WriteLine("Druk op enter op verder te gaan...");
            Console.ReadLine();
            try
            {
                Console.Write("Titel: ");
                string title = Console.ReadLine();
                Console.Write("Auteur: ");
                string author = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
                {
                    throw new ArgumentException("Titel en auteur mogen niet leeg zijn.");
                }

                Book newBook = new Book(title, author);
                bib.AddBook(newBook);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Boek succesvol toegevoegd aan de bibliotheek.");
                Console.ResetColor();
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Fout bij toevoegen van boek: {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Onverwachte fout opgetreden: {ex.Message}");
                Console.ResetColor();
            }
        }
        public static void addInformationToBib(Library bib)
        {
            showAllBooks(bib);



            try
            {
                Console.Write("Wat is de titel van het boek: ");
                string title = Console.ReadLine();
                Console.Write("Wie is de auteur van het boek: ");
                string author = Console.ReadLine();

                Book foundBook = bib.FindBook(title, author);

                if (foundBook != null)
                {
                    Console.WriteLine("Welke informatie wilt u toevoegen?");
                    Console.WriteLine("1. ISBN");
                    Console.WriteLine("2. Publicatie jaar");
                    Console.WriteLine("3. Taal ");
                    Console.Write("Keuze: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("ISBN: ");
                            long isbn = long.Parse(Console.ReadLine());
                            foundBook.ISBN = isbn;
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.WriteLine("U hebt succesvol ISBN toegevoegd");
                            break;
                        case 2:
                            Console.Write("Publicatie jaar: ");
                            int publicationYear = Convert.ToInt32(Console.ReadLine());
                            foundBook.PublicationYear = publicationYear;
                            Console.WriteLine("U hebt succesvol publicatie jaar toegevoegd");
                            break;

                        case 3:
                            Console.Write("Taal: ");
                            string language = Console.ReadLine();
                            foundBook.Language = language;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"U hebt succesvol de taal {language} toegevoegd");
                            Console.ResetColor();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                            Console.ResetColor();
                            break;
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Boek niet gevonden.");
                    Console.ResetColor();
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ongeldige invoer. Verwacht werd een numerieke waarde.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Onverwachte fout opgetreden: {ex.Message}");
                Console.ResetColor();
            }
        }






        public static void showBookInformation(Library bibliotheek)
        {

            showAllBooks(bibliotheek);

            Console.Write("Wat is het titel van het boek: ");
            string title = Console.ReadLine();
            Console.Write("Wie is de auteur van het boek: ");
            string author = Console.ReadLine();

            Book foundBook = bibliotheek.FindBook(title, author);

            if (foundBook != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Informatie van het boek: ");
                foundBook.DisplayInfo();
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Boek niet gevonden.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.ResetColor();
            }
        }

       
        public static void searchBook(Library bib)
        {

            Console.WriteLine("Hoe wil je het boek zoeken?");
            Console.WriteLine("1. Op titel en auteur");
            Console.WriteLine("2. Op ISBN");
            Console.WriteLine("3. Op auteur");
            Console.WriteLine("4. Op titel");
            Console.Write("Keuze: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Titel: ");
                    string title = Console.ReadLine();
                    Console.Write("Auteur: ");
                    string author = Console.ReadLine();
                    Book foundBook = bib.FindBookByTitleAndAuthor(title, author);
                    if (foundBook != null)
                    {
                      
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Boek gevonden: Titel: {foundBook.Title} - Auteur: {foundBook.Author}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Boek niet gevonden.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.ResetColor();
                    }
                    break;
                case 2:
                    Console.Write("ISBN: ");
                    int isbn = Convert.ToInt32(Console.ReadLine());
                    foundBook = bib.FindISBN(isbn);
                    if (foundBook != null)
                    {
                  
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Boek gevonden: Titel: {foundBook.Title} - Auteur: {foundBook.Author}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Boek niet gevonden.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.ResetColor();
                    }
                    break;
                case 3:
                    Console.Write("Auteur: ");
                    string searchAuthor = Console.ReadLine();
                    List<Book> booksOfAuthors = bib.FindBooksByAuthor(searchAuthor);
                    if (booksOfAuthors.Count > 0)
                    {
                
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Boeken gevonden van deze auteur:");
                        Console.ResetColor();
                        foreach (Book boek in booksOfAuthors)
                        {
                            Console.WriteLine($"Titel: {boek.Title} - Auteur: {boek.Author}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geen boeken gevonden van deze auteur."); 
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.ResetColor();
                       
                    }
                    break;
                case 4:
                    Console.Write("Titel: ");
                    string searchTitle = Console.ReadLine();
                    List<Book> booksWithTitle = bib.FindBooksByTitle(searchTitle);
                    if (booksWithTitle.Count > 0)
                    {
                     
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Boeken gevonden met deze titel:");
                        Console.ResetColor();
                        foreach (Book boek in booksWithTitle)
                        {
                            Console.WriteLine($" Titel: {boek.Title} - Auteur: {boek.Author}");
                        }
                    }
                    else
                    {
                       
                        Console.WriteLine("Geen boeken gevonden met deze titel.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.ResetColor();
                    }
                    break;
                default:
                    Console.WriteLine("Ongeldige keuze.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.ResetColor();
                    break;
            }
        }

        public static void removeTheBookFromBib(Library bib)
        {
            showAllBooks(bib);
            Console.Write("Titel van het te verwijderen boek: ");
            string title = Console.ReadLine();
            Console.Write("Auteur van het te verwijderen boek: ");
            string author = Console.ReadLine();

            Book removeTheBook = bib.FindBookByTitleAndAuthor(title, author);
            if (removeTheBook != null)
            {
                bib.RemoveBook(removeTheBook);
            
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Boek succesvol verwijderd.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Boek niet gevonden.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.ResetColor();
            }
        }

       
        public static void showAllBooks(Library bib)
        {
            Console.WriteLine("Alle boeken in de bibliotheek:");

            if (bib.Books.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("De bibliotheek is leeg.");
                Console.ResetColor();
                return;
            }

            foreach (Book boek in bib.Books)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($" Titel: {boek.Title} - Auteur: {boek.Author}");
                Console.ResetColor();
            }
        }

       
        public static void BorrowBook(Library bib)
        {

            Console.WriteLine("Beschikbare boeken:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("//BOEKEN:");
            Console.ResetColor();
            foreach (var book in bib.Books)
            {
                if (book.IsAvailable)
                {
                   
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Titel: {book.Title} - Auteur: {book.Author}");
                    Console.ResetColor();
                }
            }

            Console.Write("Titel van het te lenen boek: ");
            string title = Console.ReadLine();
            Console.Write("Auteur van het te lenen boek: ");
            string author = Console.ReadLine();

          

            Book borrowBook = bib.FindBook(title, author);
            if (borrowBook != null && borrowBook.IsAvailable)
            {
                borrowBook.Borrow();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Boek succesvol geleend.");
                Console.ResetColor();
            }
            else if (borrowBook != null && !borrowBook.IsAvailable)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Boek is niet beschikbaar om te lenen.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Boek niet gevonden.");
                Console.ResetColor();
            }
        }

        public static void ReturnBook(Library bib)
        {
            Console.WriteLine("Geleende boeken:");
            bool anyBooksReturned = false;
            foreach (var book in bib.Books)
            {
                if (!book.IsAvailable)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Titel: {book.Title} - Auteur: {book.Author}");
                    Console.ResetColor();
                    anyBooksReturned = true;
                }
            }

            if (!anyBooksReturned)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("U heeft geen boeken geleend.");
                Console.ResetColor();
                return;
            }


            Console.Write("Titel van het terug te brengen boek: ");
            string title = Console.ReadLine();
            Console.Write("Auteur van het terug te brengen boek: ");
            string author = Console.ReadLine();

           

            Book returnBook = bib.FindBook(title, author);
            if (returnBook != null && !returnBook.IsAvailable)
            {
                returnBook.Return();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Boek succesvol teruggebracht.");
                Console.ResetColor();
            }
            else if (returnBook != null && returnBook.IsAvailable)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dit boek is al beschikbaar in de bibliotheek.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Boek niet gevonden.");
                Console.ResetColor();
            }
        }

    }

}

    



      