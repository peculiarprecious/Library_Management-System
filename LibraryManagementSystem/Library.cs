namespace LibraryManagementSystem;

public class Library(string LibraryName)
{
    public string LibraryName { get; set; } = LibraryName;
    private readonly List<Book> _books = [];
    private readonly List<LibraryUser> _users = [];
    private readonly List<BorrowRecord> _borrowHistory = [];
    public void AddBook(Book newBook)
    {
        if (newBook == null) //Check to prevent empty book record
        {
            Console.WriteLine("Book cannot be empty");
            return;
        }
        _books.Add(newBook); //   Create the record
        Console.WriteLine($"\n'{newBook.Title} added successfully'");
    }

    public void AddNewUser(LibraryUser newuser)
    {
        if (newuser == null) //Check to prevent empty user record
        {
            Console.WriteLine("User cannot be empty");
            return;
        }
        bool emailExists = _users.Any(u => u.Email.Equals(newuser.Email, StringComparison.OrdinalIgnoreCase));

        if (emailExists)
        {
            Console.WriteLine($"Error: A user with the email '{newuser.Email}' is already registered.");
            return;
        }
        _users.Add(newuser);  //   Create the record
        Console.WriteLine($"\n'{newuser.Name}' added successfully");
    }



    public void DisplayAllBooks()
    {
        Console.WriteLine("\n--- LIBRARY COLLECTION ---");

        if (_books.Count == 0)
        {
            Console.WriteLine("No books found in the library.");
            return;
        }

        // Header 
        Console.WriteLine($"{"ID",-5} | {"Title",-20} | {"Author",-15} | {"ISBN",-15} |  {"Price",-15} | {"Category",-15} | {"Total Copies",-6} | {"Avail.Copies",-6} | {"Status"}");
        Console.WriteLine(new string('-', 120));

        foreach (var b in _books)
        {
            string status = b.IsAvailable ? "Available" : "Out of Stock";
            Console.WriteLine($"{b.Id,-5} | {b.Title,-20} | {b.Author,-15} | {b.ISBN,-15} | {b.Price,-15} | {b.Category,-15} |{b.TotalCopies,-6} | {b.AvailableCopies,-6} | [{status}]");
        }
    }

    //View users

    public void DisplayAllUsers()
    {
        Console.WriteLine("\n--- VIEW ALL REGISTERED USERS ---");

        if (_users.Count == 0)
        {
            Console.WriteLine("No users found. Please register a user first.");
            return;
        }

        // Table Headers
        Console.WriteLine($"{"ID",-5} | {"Full Name",-20} | {"Email",-25} | {"Address",-20} | {"Phone Number",-15}");
        Console.WriteLine(new string('-', 95));

        foreach (var u in _users)
        {
            Console.WriteLine($"{u.UserId,-5} | {u.Name,-20} | {u.Email,-25} | {u.Address,-20} | {u.PhoneNumber,-15}");
        }
    }

    public void BorrowBook(LibraryUser user, Book book)
    {
        // Check if the book is actually available using your property
        if (!book.IsAvailable)
        {
            Console.WriteLine($"Error: '{book.Title}' is currently out of stock.");
            return;
        }

        //  Create the record
        BorrowRecord record = new BorrowRecord
        {
            Book = book,
            User = user,
            BorrowDate = DateTime.Now
        };

        // Update the Library's private history list
        _borrowHistory.Add(record);

        // Decrease the available copies in the Book object
        book.AvailableCopies--;

        Console.WriteLine($"Success! {user.Name} borrowed '{book.Title}'.");
        Console.WriteLine($"Remaining copies: {book.AvailableCopies}");
    }


    public void BorrowBook(string userName, string bookTitle)
    {
        // Find the User in the private _users list
        var user = _users.Find(u => u.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));
        if (user == null)
        {
            Console.WriteLine($"Error: User '{userName}' not found.");
            return;
        }

        // Find the Book in the private _books list
        var book = _books.Find(b => b.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
        if (book == null)
        {
            Console.WriteLine($"Error: Book '{bookTitle}' not found.");
            return;
        }

        //  Check Availability 
        if (!book.IsAvailable)
        {
            Console.WriteLine($"Error: '{book.Title}' is currently out of stock.");
            return;
        }


        book.AvailableCopies--; // Decrease Copies

        var record = new BorrowRecord
        {
            User = user,
            Book = book,
            BorrowDate = DateTime.Now
        };
        _borrowHistory.Add(record);

        Console.WriteLine($"\nSuccess! {user.Name} has borrowed '{book.Title}'.");
        Console.WriteLine($"Remaining copies: {book.AvailableCopies}");
    }

    public void DisplayBorrowHistory()
    {
        Console.WriteLine("\n--- BORROW HISTORY ---");


        if (_borrowHistory.Count == 0)
        {
            Console.WriteLine("No borrow records found.");
            return;
        }

        // Table Headers
        Console.WriteLine($"{"Book ID",-7} | {"Title",-20} | {"User ID",-7} | {"Borrower",-15} | {"Borrow Date",-15}");
        Console.WriteLine(new string('-', 80));

        foreach (var bRecord in _borrowHistory)
        {
            Console.WriteLine($"{bRecord.Book.Id,-7} | {bRecord.Book.Title,-20} | {bRecord.User.UserId,-7} | {bRecord.User.Name,-15} | {bRecord.BorrowDate:d}");
        }
    }

    public void ReturnBook(string userName, string bookTitle)
    {
        Console.WriteLine("\n--- Processing Return ---");

        // Find the specific record in your private _borrowHistory list
        // Check both the User's Name and the Book's Title
        var record = _borrowHistory.Find(r =>
            r.User.Name.Equals(userName, StringComparison.OrdinalIgnoreCase) &&
            r.Book.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));

        if (record != null)
        {
            // Increase the available copies (putting it back on the shelf)
            record.Book.AvailableCopies++;

            // Remove the record from history to show the book is no longer out
            _borrowHistory.Remove(record);

            Console.WriteLine($"Success! '{record.Book.Title}' has been returned by {record.User.Name}.");
            Console.WriteLine($"Current stock: {record.Book.AvailableCopies}");
        }
        else
        {
            // If no matching record is found, it means that user didn't borrow that book
            Console.WriteLine($"Error: No active borrow record found for {userName} with the book '{bookTitle}'.");
        }
    }

    public void SearchByTitle(string title)
    {
        Console.WriteLine($"\n--- Searching for: {title} ---");

        var foundBook = _books.Find(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

        if (foundBook != null)
        {
            string status = foundBook.IsAvailable ? "AVAILABLE" : "OUT OF STOCK";

            Console.WriteLine($"[MATCH FOUND]");
            Console.WriteLine($"Title:     {foundBook.Title}");
            Console.WriteLine($"Author:    {foundBook.Author}");
            Console.WriteLine($"Category:  {foundBook.Category}");
            Console.WriteLine($"Price:     {foundBook.Price:C}");
            Console.WriteLine($"Status:    [{status}] ({foundBook.AvailableCopies} copies on shelf)");
        }
        else
        {
            Console.WriteLine($"Error: No book found matching the title '{title}'.");
        }
    }



    public void SearchByAuthor(string authorName)
    {
        Console.WriteLine($"\n--- Searching for Books by: \"{authorName}\" ---");

        // FindAll to get a list of EVERY book by that author
        var results = _books.FindAll(b => b.Author.Contains(authorName, StringComparison.OrdinalIgnoreCase));

        if (results.Count > 0)
        {
            Console.WriteLine($"[ {results.Count} Match(es) Found ]");
            Console.WriteLine($"{"ID",-5} | {"Title",-25} | {"Category",-15} | {"Status"}");
            Console.WriteLine(new string('-', 60));

            foreach (var b in results)
            {
                string status = b.IsAvailable ? "Available" : "Out of Stock";
                Console.WriteLine($"{b.Id,-5} | {b.Title,-25} | {b.Category,-15} | [{status}]");
            }
        }
        else
        {
            Console.WriteLine($"Error: No books found by author '{authorName}'.");
        }
    }


    public void SearchUserByName(string name)
    {
        Console.WriteLine($"\n--- Searching for User: \"{name}\" ---");

        // Use .Find with OrdinalIgnoreCase so "alice" matches "Alice"
        var foundUser = _users.Find(u => u.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        if (foundUser != null)
        {
            Console.WriteLine($"[MATCH FOUND]");
            Console.WriteLine($"User ID:      {foundUser.UserId}");
            Console.WriteLine($"Full Name:    {foundUser.Name}");
            Console.WriteLine($"Email:        {foundUser.Email}");
            Console.WriteLine($"Address:      {foundUser.Address}");
            Console.WriteLine($"Phone:        {foundUser.PhoneNumber}");
        }
        else
        {
            Console.WriteLine($"Error: No user found matching the name '{name}'.");
        }
    }


    public void DisplayStatistics()
    {
        Console.WriteLine($"\n--- {LibraryName} STATISTICS ---");
        Console.WriteLine(new string('-', 40));

        // Total Book counts
        int totalNumOfBooks = _books.Count;
        Console.WriteLine($"Total Book Counts:   {totalNumOfBooks}");

        //Total Physical Copies (Sum of all copies of every book)
        int totalPhysicalCopies = _books.Sum(b => b.TotalCopies);
        Console.WriteLine($"Total Physical Books: {totalPhysicalCopies}");

        // Current Available Stock (Books currently on shelves)
        int currentStock = _books.Sum(b => b.AvailableCopies);
        Console.WriteLine($"Books on Shelves:     {currentStock}");

        //Total Registered Users
        int totalUsers = _users.Count;
        Console.WriteLine($"Registered Users:     {totalUsers}");

        //Total Borrowing Transactions
        int totalTransactions = _borrowHistory.Count;
        Console.WriteLine($"Total Books Borrowed:   {totalTransactions}");

        Console.WriteLine(new string('-', 40));
    }


}
