using System.Runtime.CompilerServices;

class Program
{
    // Moved to outside main method for ease of access in new method
    static Library myLibrary = new Library();

    static void Main(string[] args)
    {
        // Example Inventory
        myLibrary.AddBook("Frankenstein", "Mary Shelley", 1932);
        myLibrary.AddBook("Of Mice and Men", "John Steinbeck", 1937);
        myLibrary.AddBook("Nineteen Eighty-Four", "George Orwell", 1949);

        //All Menu Options Below
        while (true)
        {
            GetUserInput();
        }
    }

    private static void GetUserInput()
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
                    // Prompt for title
                    Console.Write("Enter title: ");
                    // Initialise Title as Empty String
                    string title = String.Empty;
                    title = Console.ReadLine();
                    // While title remains Empty or Whitespace, display error and prompt again
                    while (string.IsNullOrWhiteSpace(title))
                    {
                        Console.WriteLine("Book title cannot be empty");
                        Console.Write("Enter title: ");
                        title = Console.ReadLine();
                    }
                    Console.Write("Enter author: ");
                    string author = String.Empty;
                    author = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(author))
                    {
                        Console.WriteLine("Book author cannot be empty");
                        Console.Write("Enter author: ");
                        author = Console.ReadLine();
                    }
                    Console.Write("Enter publication year: ");
                    // Small change to prevent being kicked back to main menu with invalid year
                    int publicationYear = 0;
                    int.TryParse(Console.ReadLine(), out publicationYear);
                    while (publicationYear > DateTime.Today.Year)
                    {
                        Console.WriteLine("Invalid publication year, please enter a valid number.");
                        int.TryParse(Console.ReadLine(), out publicationYear);
                    }

                    myLibrary.AddBook(title, author, publicationYear);
                    Console.WriteLine("Book added successfully.");
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
                    break;
                default:
                    Console.WriteLine("Not a valid input");
                    Console.WriteLine(String.Empty); // Just to add a gap between failed attempts.
                    GetUserInput();
                    break;
            }
        }
    }
}