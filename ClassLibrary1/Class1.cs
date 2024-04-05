
using System.Diagnostics;

namespace ClassLibrary1
{
    public class Book
    {
        public string? title { get; set; }
        public string? author { get; set; }
        public string? lender { get; set; }
        public bool lended { get; set; } = false;
    }
    public class Lender
    {
        public string? name { get; set; }
        public int idNumber { get; set; }
        public List<Book> lendedBooks { get; set; } = new List<Book>();
    }
    
    public class Library
    {
        public List<Book> books { get; set; } = new List<Book>();
        public List<Lender> lenders { get; set; } = new List<Lender>();
        public Library()
        {
            this.RestoreHistory();
        }
        /// <summary>
        /// Adds new book to the library
        /// </summary>

        public bool AddBook(string title, string author)
        {
            Book book = new Book();
            book.title = title;
            book.author = author;
            if (books.Count(o => o.title == book.title && o.author == book.author) < 1) //checks duplicate
            { 
                books.Add(book);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Adds new lender to the library 
        /// </summary>
        public bool AddLender(string name, int id)
        {
            Lender lender = new Lender();
            lender.name = name;
            lender.idNumber = id;
            if ( lenders.Count(o => o.idNumber == lender.idNumber) <1 )//checks if id number is unique
            {
                lenders.Add(lender);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Lend book to borrower
        /// </summary>
        public bool LendBook(string name, int id, string title, string author)
        {
            foreach (Book book in books) 
            {
                if (book.title == title && book.author == author && book.lended == false)
                {
                    foreach (Lender lender in lenders)
                    {
                        if (lender.name == name && lender.idNumber == id)
                        {
                            lender.lendedBooks.Add(book);
                            book.lended = true;
                            book.lender = lender.name;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns book to the library
        /// </summary>

        public bool ReturnBook(string name, int id, string title, string author)//searches for book in the books list, then lender name in lender list and returns book
        {
           
            foreach (Book book in books)
            {
                if (book.title == title && book.author == author)
                {
                    foreach (Lender lender in lenders)
                    {
                        if (lender.name == name && lender.idNumber == id)
                        {
                            lender.lendedBooks.Remove(book);
                            book.lended = false;
                            return true;
                            
                        }
                    }
                }
            }
            return false;
        }
/*        public void DisplayBooks()//displays available books in library
        {

            Console.WriteLine("Available books:\n");
            Console.WriteLine("{0,0} {1,10}", "Title", "Author");
            foreach (Book book in books)
            {
                if (book.lended == false)
                {
                    Console.WriteLine("{0,0} {1,10}", book.title, book.author);
                }
            }
        }*/
/*        public void DisplayLenders()//displays all lended books and who they are lended by
        {
            Console.WriteLine("{0,0} {1, 10} {2,20}", "Lender", "Id", "Lended book");
            foreach (Book book in books)
            {
                if (book.lended == true)
                {
                    foreach (Lender lender in lenders)
                    {
                        if (book.lender == lender.name)
                        {
                            Console.WriteLine("{0,0} {1,10} {2,20}", lender.name, lender.idNumber, book.title);
                        }
                    }
                }

            }
        }*/
        /// <summary>
        /// Saves current history
        /// </summary>
        public void SaveHistory()//saves book and lender lists into separate csv files
        {
            List<string> bookStrings = new List<string>();
            foreach (Book book in books)
                bookStrings.Add($"{book.title},{book.author},{book.lender},{book.lended}");
            File.WriteAllLines("books.csv", bookStrings);
            List<string> lenderStrings = new List<string>();
            foreach (Lender lender in lenders)
                lenderStrings.Add($"{lender.name},{lender.idNumber}");
            File.WriteAllLines("lenders.csv", lenderStrings);

        }
        /// <summary>
        /// Restores history from last save point
        /// </summary>
        public void RestoreHistory()//reads books and lender files and restores objects and their respective lists, also implicitly restores the data from the lended books list
        {
            if (File.Exists("books.csv"))
            {
                string[] bookStrings = File.ReadAllLines("books.csv");
                foreach (string bookString in bookStrings)//creates new book objects from each line of the books.csv file 
                {
                    string[] attr = bookString.Split(",");
                    Book book = new Book() { title = attr[0], author = attr[1], lender = attr[2], lended = bool.Parse(attr[3]) };
                    books.Add(book);

                }
                string[] lenderStrings = File.ReadAllLines("lenders.csv");//like the one above but for lenders
                foreach (string lenderString in lenderStrings)
                {
                    string[] attr = lenderString.Split(",");
                    Lender lender = new Lender() { name = attr[0], idNumber = int.Parse(attr[1]) };
                    lenders.Add(lender);
                }
                foreach (Book book in books)//checks which books were lended by who and put the book back in their lendedBooks list
                {
                    if (book.lended == true)
                    {
                        foreach (Lender lender in lenders)
                        {
                            if (lender.name == book.lender)
                            {
                                lender.lendedBooks.Add(book);
                            }
                        }
                    }
                }
            }
            else { Console.WriteLine("No history"); }

        }
    }
}