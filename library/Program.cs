using System.Runtime.CompilerServices;

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
                        if (int.TryParse(Console.ReadLine(), out int publicationYear) && publicationYear <= DateTime.Today.Year)
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


                }
            }
        }
    }
}