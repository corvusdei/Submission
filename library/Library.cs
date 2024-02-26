using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Library
{
    List<Book> books = new List<Book>();

    // The following are ways Books can be interacted with in the Library.

    // AddBook used for updating inventory 
    public void AddBook(string title, string author, int publicationYear)
    {
        books.Add(new Book() { Title = title, Author = author, PublicationYear = publicationYear });
    }

    // RemoveBook used for updating inventory / when item is checked out
    public void RemoveBook(string title)
    {
        DateTime returnDate = DateTime.Now.AddDays(14);

        Book bookToRemove = books.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"{title} has been removed from the library. Return Date: {returnDate}");
        }
        else
        {
            Console.WriteLine($"{title} is not in the library.");
        }
    }

    // ListBooks displays available inventory
    public void ListBooks()
    {
        Console.WriteLine("Available Inventory:");
        foreach (var book in books)
        {
            Console.WriteLine($"Books:{book.Title} by {book.Author} , {book.PublicationYear}");
        }
    }
}

