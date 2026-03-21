
using System.Text.RegularExpressions;
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
    Name = "Bob Marley",
    Email = "bob@email.com",
    Address = "Lagos",
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
    ISBN = "978-0-13-468599-1",
    TotalCopies = 5,
    AvailableCopies = 5

};
Book book2 = new Book
{
    Id = 2,
    Title = "OOP in C#",
    Author = "Mike Adekunle",
    ISBN = "978-0-596-52068-7",
    TotalCopies = 10,
    AvailableCopies = 10

};
Book book3 = new Book
{
    Id = 3,
    Title = "Data Structures",
    Author = "Jame Richard",
    ISBN = "978-1-491-98765-1",
    TotalCopies = 2,
    AvailableCopies = 2

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

book1.AvailableCopies--;
BorrowRecord record2 = new BorrowRecord
{
    Book = book2,
    User = user2,

    BorrowDate = DateTime.Now
};

book2.AvailableCopies--;
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
    Console.WriteLine("6. View Borrowed Books");
    Console.WriteLine("7. Return Book");
    Console.WriteLine("8. Search Book by Title or Author");
    Console.WriteLine("9. Search User by Name");
    Console.WriteLine("10. Exit");

    Console.Write("Enter choice: ");
    int userChoice = int.Parse(Console.ReadLine() ?? "");

    switch (userChoice)
    {

        case 1:

            Console.WriteLine("\n--- Add New Book ---");

            int nextBookID = books.Count + 1;
            Console.WriteLine($"(ID: {nextBookID})");

            Console.WriteLine("Enter Book Title:");
            string? bookTitle = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(bookTitle)) //String Validation: Title cannot be empty
            {
                Console.WriteLine("Error: Title cannot be empty.");
                break;
            }

            Console.WriteLine("Enter Author:");
            string? author = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(author)) //String Validation: Title cannot be empty
            {
                Console.WriteLine("Error: Author cannot be empty.");
                break;
            }
            Console.WriteLine("Enter ISBN:");
            string? isbn = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("Error: ISBN cannot be empty.");
                break;
            }

            Console.WriteLine("Enter Total Copies:");

            if (!int.TryParse(Console.ReadLine(), out int numberOfCopies))
            {
                Console.WriteLine("Invalid ID format. Please enter an integer");
                break;
            }


            Book NewBook = new Book
            {
                Id = nextBookID,
                Title = bookTitle,
                Author = author,
                ISBN = isbn,
                TotalCopies = numberOfCopies,
                AvailableCopies = numberOfCopies

            };

            books.Add(NewBook);
            Console.WriteLine($"\nSuccess! '{bookTitle}' added with ID: {nextBookID}");
            break;
        case 2:
            Console.WriteLine("\n--- LIBRARY COLLECTION ---");
            // Column Headers (Negative numbers align left, positive align right)
            Console.WriteLine($"{"ID",-5} | {"Title",-25} | {"Author",-20} | {"ISBN",-20} | {"Total Cpoies",-20} | {"Available Cpoies",-20} | {"Status"} ");
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

                    Console.WriteLine($"{b.Id,-5} | {b.Title,-25} | {b.Author,-20} | {b.ISBN,-20} | {b.TotalCopies,-20}  | {b.AvailableCopies,-20} | [{status}]");
                }
            }

            break;
        case 3:

            Console.WriteLine("\n--- Add New User ---");
            int nextUserID = users.Count + 1;
            Console.Write("Enter User Name: ");

            string? userName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName)) //String Validation: Name cannot be empty
            {
                Console.WriteLine("Error: Name cannot be empty.");
                break;
            }

            Console.Write("Enter Email Address: ");

            // Regex pattern for a basic email structure
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            string? email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Error: Email cannot be empty.");
                break;
            }
            else if (!Regex.IsMatch(email, emailPattern))
            {
                Console.WriteLine("Error: Please enter a valid email address (e.g., user@example.com).");
                break;
            }
            Console.Write("Enter House Address: ");
            string? address = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Error: Address cannot be empty.");
                break;
            }
            Console.Write("Enter Phone Number: ");
            string? phoneNumber = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.WriteLine("Error: Phone Number cannot be empty.");
                break;
            }

            LibraryUser NewUser = new LibraryUser
            {
                UserId = nextUserID,
                Name = userName,
                Email = email,
                Address = address,
                PhoneNumber = phoneNumber
            };

            users.Add(NewUser);
            Console.WriteLine($"User: {userName} added succesfully");
            break;


        case 4:

            Console.WriteLine("\n--- View all Users ---");
            if (users.Count == 0)
            {
                Console.WriteLine("No users found. Please add a user first");
            }
            else
            {
                // Table Headers (Negative numbers = left align, Positive = right align)
                Console.WriteLine($"{"ID",-5} | {"Full Name",-20} | {"Email",-25} | {"Address",-35} | {"Phone Number",-35}");
                Console.WriteLine(new string('-', 110)); // Separator line

                foreach (var u in users)
                {
                    Console.WriteLine($"{u.UserId,-5} | {u.Name,-20} | {u.Email,-25} | {u.Address,-35} | {u.PhoneNumber,-35}");
                }
            }


            break;
        case 5:

            Console.WriteLine("\n--- Borrow Book ---");

            // Get user ID and check if the user exist

            Console.WriteLine("Enter user Id:");
            if (!int.TryParse(Console.ReadLine(), out int borrowUserId))
            {
                Console.WriteLine("Invalid ID format. Please enter an integer");
                break;
            }
            var bUser = users.Find(u => u.UserId == borrowUserId);

            if (bUser == null)
            {
                Console.WriteLine("Error: User not found.");

                break;
            }
            //Get book by ID
            Console.WriteLine("Enter Book Id:");

            if (!int.TryParse(Console.ReadLine(), out int borrowBookId))
            {
                Console.WriteLine("Error: Invalid ID format. Id must be a number");
                break;
            }

            // Check if book exists and is actually available
            var bBook = books.Find(b => b.Id == borrowBookId);

            if (bBook == null)
            {
                Console.WriteLine("Error: Book not found!");
                break;
            }
            else if (!bBook.IsAvailable)
            {
                Console.WriteLine($"Error: '{bBook.Title}' is already borrowed.");
                break;
            }
            else
            {

                bBook.AvailableCopies--;  // 1. Reduce available copies

                // 4. Create the borrow record
                BorrowRecord newRecord = new BorrowRecord
                {
                    Book = bBook,
                    User = bUser,
                    BorrowDate = DateTime.Now
                };

                borrowHistory.Add(newRecord);

                Console.WriteLine($"\nSuccess! '{bBook.Title}' has been borrowed by {bUser.Name}.");
                Console.WriteLine($"Remaining copies in library: {bBook.TotalCopies}");
            }

            break;
        case 6:
            Console.WriteLine("\n--- Borrow History ---");

            if (borrowHistory.Count == 0)
            {
                Console.WriteLine("No borrow records found.");
            }
            else
            {
                // Table Headers
                Console.WriteLine($"{"Book ID",-5} | {"Book Title",-25} | {"User ID",-5} | {"Borrower Name",-15} | {"Author",-25} | {"ISBN",-25}| {"Borrow Date",-15}");
                Console.WriteLine(new string('-', 130));

                foreach (var bRecord in borrowHistory)
                {
                    Console.WriteLine($"{bRecord.Book.Id,-5} | {bRecord.Book.Title,-25} | {bRecord.User.UserId,-5} |  {bRecord.User.Name,-15} | {bRecord.Book.Author,-25} | {bRecord.Book.ISBN,-25} | {bRecord.BorrowDate,-15}");
                }
            }
            break;
        case 7:

            Console.WriteLine("\n--- Return Book ---");

            Console.WriteLine("Enter user Id:");
            if (!int.TryParse(Console.ReadLine(), out int returnUserId))
            {
                Console.WriteLine("Invalid ID format. Please enter an integer");
                break;
            }
            var rUser = users.Find(r => r.UserId == returnUserId);

            if (rUser == null)
            {
                Console.WriteLine("Error: User not found.");

                break;
            }
            //Get book by ID
            Console.WriteLine("Enter Book Id:");

            if (!int.TryParse(Console.ReadLine(), out int returnBookId))
            {
                Console.WriteLine("Error: Invalid ID format. Id must be a number");
                break;
            }

            var rBook = books.Find(r => r.Id == returnBookId);

            if (rBook == null)
            {
                Console.WriteLine("Error: Book not found!");
                break;
            }

            // Find the specific record where this user and this book
            var recordToReturn = borrowHistory.Find(r => r.User.UserId == returnUserId && r.Book.Id == returnBookId);

            if (recordToReturn != null)
            {
                // 4. Update the book linked to the record
                recordToReturn.Book.AvailableCopies++;

                // 5. Remove the record from the list
                borrowHistory.Remove(recordToReturn);

                Console.WriteLine($"\nSuccess! '{recordToReturn.Book.Title}' was returned by {rUser.Name}.");
                Console.WriteLine($"Current Book Inventory: {recordToReturn.Book.AvailableCopies} / {recordToReturn.Book.TotalCopies}");
            }
            else
            {
                Console.WriteLine("Error: No active borrow record found for this User and Book.");
            }

            break;
        case 8:
            Console.WriteLine("\n--- Search Book by Author or Title ---");

            Console.WriteLine("Enter Book Titleor  Author");

            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Error: Field cannot be empty.");
                break;
            }

            var bTitleOrAuthor = books.Find(a => a.Author.Contains(input, StringComparison.OrdinalIgnoreCase) || a.Title.Contains(input, StringComparison.OrdinalIgnoreCase));
            if (bTitleOrAuthor != null)
            {
                Console.WriteLine($"\nBook Found: {bTitleOrAuthor.Title} by {bTitleOrAuthor.Author}");

                if (bTitleOrAuthor.AvailableCopies > 0)
                {
                    Console.WriteLine($"Status: [Available] - {bTitleOrAuthor.AvailableCopies} copies on shelf.");
                }
                else
                {
                    Console.WriteLine("Status: [Not Available] - All copies are currently borrowed.");
                }
            }
            else
            {
                Console.WriteLine($"Error: No book found matching '{input}'.");
            }

            break;
        case 9:
            Console.WriteLine("\n--- Search User by Name ---");

            Console.Write("Enter User Name");
            string? userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Field cannot be empty");
                break;
            }
            var userName1 = users.Find(n => n.Name.Contains(userInput, StringComparison.OrdinalIgnoreCase));
            if (userName1 != null)
            {
                Console.WriteLine($"\nUser Found: {userName1.Name}");
            }
            else
            {
                Console.WriteLine($"Error: No user found matching '{userInput}'.");
            }


            break;
        case 10:
            isRunning = false;
            Console.WriteLine("Exiting program...");
            break;


        default:
            Console.WriteLine("Invalid selection, please try again.");
            break;
    }

}

