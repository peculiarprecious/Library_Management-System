
using LibraryManagementSystem;

// 1. Initialize empty lists
List<Book> books = new List<Book>();
List<LibraryUser> users = new List<LibraryUser>();
List<BorrowRecord> borrowHistory = new List<BorrowRecord>();

// 2. Create User Objects
LibraryUser user1 = new LibraryUser
{
    UserId = 1,
    Name = "Alice Erie",
    Email = "alice@email.com",
    Address = "Lagos",
    PhoneNumber = "09087654346"
};

LibraryUser user2 = new LibraryUser
{
    UserId = 2,
    Name = "Bob",
    Email = "bob@email.com",
    Address = "Warsaw",
    PhoneNumber = "080987654321"
};

// 3. Add Users to the existing 'users' list
users.Add(user1);
users.Add(user2);

// 4. Create Book Objects
Book book1 = new Book
{
    Id = 1,
    Title = "C# Basics",
    Author = "Wale Adenuga",
    IsAvailable = true
};
Book book2 = new Book
{
    Id = 2,
    Title = "OOP in C#",
    Author = "Mike Adekunle",
    IsAvailable = true
};
Book book3 = new Book
{
    Id = 3,
    Title = "Data Structures",
    Author = "Jame Richard",
    IsAvailable = true
};

books.Add(book1);
books.Add(book2);
books.Add(book3);

// 5. Create Borrow Records
BorrowRecord record1 = new BorrowRecord
{
    Book = book1,
    User = user1,
    BorrowDate = DateTime.Now
};

BorrowRecord record2 = new BorrowRecord
{
    Book = book2,
    User = user2,
    BorrowDate = DateTime.Now
};

// 6. Add Records to the list
borrowHistory.Add(record1);
borrowHistory.Add(record2);


bool isRunning = true;

while (isRunning)
{
    Console.WriteLine("\n---Library Management System ---");
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. View Books");
    Console.WriteLine("3. Add Users");
    Console.WriteLine("4. View Users");
    Console.WriteLine("5. Borrow Book");
    Console.WriteLine("6. Return Book");
    Console.WriteLine("7. Exit");

    Console.Write("Enter choice: ");
    int userChoice = int.Parse(Console.ReadLine() ?? "");

    switch (userChoice)
    {

        case 1:

            Console.WriteLine("\n--- Add New Book ---");

            int nextBookID = books.Count + 1;
            Console.WriteLine($"(ID: {nextBookID})");

            Console.WriteLine("\n---Enter Book Title");
            string? bookTitle = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(bookTitle)) //String Validation: Title cannot be empty
            {
                Console.WriteLine("Error: Title cannot be empty.");
                break;
            }

            Console.WriteLine("\n---Enter Author");
            string? author = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(author)) //String Validation: Title cannot be empty
            {
                Console.WriteLine("Error: Author cannot be empty.");
                break;
            }


            Book NewBook = new Book
            {
                Id = nextBookID,
                Title = bookTitle,
                Author = author

            };

            books.Add(NewBook);
            Console.WriteLine($"\nSuccess! '{bookTitle}' added with ID: {nextBookID}");
            break;
        case 2:

            

            Console.WriteLine("\n--- LIBRARY COLLECTION ---");
    // Column Headers (Negative numbers align left, positive align right)
    Console.WriteLine($"{"ID",-5} | {"Title",-25} | {"Author",-20} | {"Status"} ");
    Console.WriteLine(new string('-', 70)); // Creates a separator line

             if (books.Count == 0)
    {
        Console.WriteLine("No books found in the library.");
    }
    else
    {
        foreach (var b in books)
        {
            string status = b.IsAvailable ? "Available" : "Borrowed";
            
            Console.WriteLine($"{b.Id,-5} | {b.Title,-25} | {b.Author,-20} | [{status}]");
        }
    }

    break;
        case 3:

            Console.WriteLine("\n--- Add New User ---");

            break;
        case 4:

            Console.WriteLine("\n--- View all Users ---");

            break;
        case 5:

            Console.WriteLine("\n--- Borrow Book ---");

            break;
        case 6:

            Console.WriteLine("\n--- Return Book ---");

            break;
        case 7:
            isRunning = false;
            Console.WriteLine("Exiting program...");
            break;


        default:
            Console.WriteLine("Invalid selection, please try again.");
            break;
    }

}