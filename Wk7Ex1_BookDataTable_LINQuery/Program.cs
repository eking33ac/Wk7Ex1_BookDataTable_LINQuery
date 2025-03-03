using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk7Ex1_BookDataTable_LINQuery
{
    internal class Program
    {
        class Book
        {
            // properties
            public string Title;        // declare string property of the book class called Title
            public string Author;        // declare string property of the book class called Author
            public string Genre;        // declare string property of the book class called Genre
            public double Price;        // declare double property of the book class called Price

            public Book(string aTitle, string aAuthor, string aGenre, double aPrice)
            {
                Title = aTitle;     // set the title used in the class to be the title we input
                Author = aAuthor;       // set the Author used in the class to be the Author we input
                Genre = aGenre;     // set the Genre used in the class to be the Genre we input
                Price = aPrice;     // set the Price used in the class to be the Price we input
            }
        }


        static void Main(string[] args)
        {
            // declarations
            List<Book> allBooks = new List<Book>();     // declare a list to hold all the books
            // make the instances of book
            Book book1 = new Book("To Kill a Mockingbird", "Harper Lee", "Fiction", 15.99);
            Book book2 = new Book("1984", "George Orwell", "Dystopian", 12.99);
            Book book3 = new Book("Pride and Prejudice", "Jane Austen", "Romance", 9.99);
            Book book4 = new Book("Moby Dick", "Herman Melville", "Adventure", 18.99);
            Book book5 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 10.99);
            Book book6 = new Book("Brave New World", "Aldous Huxley", "Dystopian", 14.99);
            Book book7 = new Book("War and Peace ", "Leo Tolstoy", "Historical Fiction", 25.99);

            // put the book instances in a list
            allBooks.Add(book1); // add book1 to the list
            allBooks.Add(book2); // add book2 to the list
            allBooks.Add(book3); // add book3 to the list
            allBooks.Add(book4); // add book4 to the list
            allBooks.Add(book5); // add book5 to the list
            allBooks.Add(book6); // add book6 to the list
            allBooks.Add(book7); // add book7 to the list

            // use Linq to select books that cost more than $12
            List<Book> books12 = allBooks.Where(x => x.Price > 12).ToList();



            // Tell user we are outputting books that cost more than 12 dollars
            Console.WriteLine("Books which cost over $12.00:");

            // for each book in the list books12, output the title, author, genre, and price (all data)
            books12.ForEach(book => { Console.WriteLine($" - {book.Title}, {book.Author}, {book.Genre}, {book.Price}"); });
            //linebreaks for readability
            Console.WriteLine(); Console.WriteLine();



            // Use Linq to order books by price (ascending)
            List<Book> bookPriceAsc = allBooks.OrderBy(x => x.Price).ToList();

            // Tell user we are outputting books in ascending order by price
            Console.WriteLine("All books from lowest to highest price:");
            // for each book in the list bookPriceAsc, output the title, author, genre, and price (all data)
            bookPriceAsc.ForEach(book => { Console.WriteLine($" - {book.Title}, {book.Author}, {book.Genre}, {book.Price}"); });
            //linebreaks for readability
            Console.WriteLine(); Console.WriteLine();



            // Use Linq to order books by price (ascending)
            var booksByGenre = allBooks.GroupBy(b => b.Genre);
            

            // Tell user we are outputting books in ascending order by price
            Console.WriteLine("All books sorted by genre:");
            // for each book in the group in booksByGenre, 
            foreach (var group in booksByGenre)
            {
                // write the group key, aka the genre name
                Console.WriteLine($"Genre: {group.Key}");
                // for each value (book) in the key (genre)
                foreach (var book in group)
                {
                    //output the title and author
                    Console.WriteLine($" - {book.Title} by {book.Author}");
                }
            }
            //linebreaks for readability
            Console.WriteLine(); Console.WriteLine();




            // use linq to get only titles and authors of books
            var bookTitleAndAuthor = allBooks.Select(book => new { book.Title, book.Author });


            // Tell user we are outputting books with only title and author info
            Console.WriteLine("All books and authors:");
            //for each book in the bookTitleAndAuthor only list
            foreach (var book in bookTitleAndAuthor)
            {
                // output the title and author in a bulletted list
                Console.WriteLine($" - {book.Title} by {book.Author}");
            }
            //linebreaks for readability and to pause the screen
            Console.ReadLine();

        }
    }
}
