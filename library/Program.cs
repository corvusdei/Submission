
class Book 
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }
}

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

    class Program
    {
        static void Main(string[] args)
        {

            Library myLibrary = new Library();


            // Example Inventory
            myLibrary.AddBook("Frankenstein", "Mary Shelley", 1932);
            myLibrary.AddBook("Of Mice and Men", "John Steinbeck", 1937);
            myLibrary.AddBook("Nineteen Eighty-Four", "George Orwell", 1949);

            //All Menu Options Below
            while (true)
            {
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. View Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Enter Input Here: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        //Case 1: Add Book
                        case 1:
                            Console.Write("Enter title: ");
                            string title = Console.ReadLine();
                            Console.Write("Enter author: ");
                            string author = Console.ReadLine();
                            Console.Write("Enter publication year: ");
                            if (int.TryParse(Console.ReadLine(), out int publicationYear))
                            {
                                myLibrary.AddBook(title, author, publicationYear);
                                Console.WriteLine("Book added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid publication year, please enter a valid number.");
                            }

                            break;
                        //Case 2: Remove Book
                        case 2:
                            Console.Write("Enter title to remove: ");
                            string bookToRemove = Console.ReadLine();
                            myLibrary.RemoveBook(bookToRemove);
                            break;
                       //Case 3: Display Inventory
                        case 3:
                            myLibrary.ListBooks();
                            break;
                       //Case 4: Ends Program
                        case 4:
                            Console.WriteLine("Closing Library...");
                            return;

                            //cool
                    }
                }
            }
        }
    }
}
  
