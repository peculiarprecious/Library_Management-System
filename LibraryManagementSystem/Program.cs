
using System.Text.RegularExpressions;
namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library myLibrary = new Library("Williams Hope Library");

            DataSeedSampleBook(myLibrary);
            DataSeedSampleUser(myLibrary);

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine($"\n--- Welcome to {myLibrary.LibraryName} ---");
                DisplayLibraryMenu();


                if (!int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    Console.WriteLine("Input must be an Integer");
                    continue;
                }

                switch (userChoice)
                {
                    case 1:
                        //Add book
                        AddNewbook(myLibrary);
                        break;
                    case 2:

                        //View All Books
                        myLibrary.DisplayAllBooks();
                        break;
                    case 3:
                        //Add user
                        AddNewUser(myLibrary);
                        break;
                    case 4:
                        //View all users
                        myLibrary.DisplayAllUsers();

                        break;
                    case 5:
                        //Borrow Book

                        Console.Write("Enter User Name: ");
                        string userName = (Console.ReadLine() ?? "").Trim();

                        Console.Write("Enter Book Title: ");
                        string bookTitle = (Console.ReadLine() ?? "").Trim();

                        myLibrary.BorrowBook(userName, bookTitle);
                        break;


                    case 6:
                        //View borrow history
                        myLibrary.DisplayBorrowHistory();
                        break;
                    case 7:
                        //Return book

                        Console.Write("Enter Borrower Name: ");
                        string uName = (Console.ReadLine() ?? "").Trim();

                        Console.Write("Enter Book Title to Return: ");
                        string bTitle = (Console.ReadLine() ?? "").Trim();

                        if (!string.IsNullOrWhiteSpace(uName) && !string.IsNullOrWhiteSpace(bTitle))
                        {
                            myLibrary.ReturnBook(uName, bTitle);
                        }
                        else
                        {
                            Console.WriteLine("Error: Names or title cannot be empty.");
                        }
                        break;



                    case 8:
                        //Serach book by Title

                        Console.Write("Enter Book Title to Search: ");
                        string searchTitle = (Console.ReadLine() ?? "").Trim();

                        if (!string.IsNullOrWhiteSpace(searchTitle))
                        {
                            myLibrary.SearchByTitle(searchTitle);
                        }
                        else
                        {
                            Console.WriteLine("Error: Search term cannot be empty.");
                        }
                        break;



                    case 9:
                        //search book by author

                        Console.Write("Enter Author's Name: ");
                        string authorSearch = (Console.ReadLine() ?? "").Trim();

                        if (!string.IsNullOrWhiteSpace(authorSearch))
                        {
                            myLibrary.SearchByAuthor(authorSearch);
                        }
                        else
                        {
                            Console.WriteLine("Error: Author name cannot be empty.");
                        }
                        break;

                    case 10:
                        //search user by name


                        Console.Write("Enter User Name to Search: ");
                        string userNameInput = (Console.ReadLine() ?? "").Trim();

                        if (!string.IsNullOrWhiteSpace(userNameInput))
                        {
                            myLibrary.SearchUserByName(userNameInput);
                        }
                        else
                        {
                            Console.WriteLine("Error: User name cannot be empty.");
                        }
                        break;

                    case 11:
                        //Display Libray Statistics
                        myLibrary.DisplayStatistics();
                        break;
                    case 12:
                        isRunning = false;
                        Console.WriteLine("Exiting program...");
                        break;


                    default:
                        Console.WriteLine("Invalid selection, please try again.");
                        break;
                }

            }

        }
        // Data seed sample for New Book
        static void DataSeedSampleBook(Library sampleBooks)
        {
            sampleBooks.AddBook(new Book("C# Basics", "Wale Adenuga", "978-0-13-468599-1", 15.99m, 10, "Programming"));
            sampleBooks.AddBook(new Book("OOP in C#", "Mike Adekunle", "978-0-596-52068-7", 20.99m, 10, "Programming"));
            sampleBooks.AddBook(new Book("Data Structures", "Jame Richard", "978-1-491-98765-1", 10.99m, 10, "Programming"));
        }

        static void DataSeedSampleUser(Library sampleUsers)
        {
            sampleUsers.AddNewUser(new LibraryUser("Alice Erie", "alice@email.com", "Lagos", "09087654346"));
            sampleUsers.AddNewUser(new LibraryUser("Bob Marley", "bob@email.com", "Lagos", "080987654321"));
            sampleUsers.AddNewUser(new LibraryUser("Ann Ekpo", "anne@email.com", "Lagos", "09067674386"));
        }

        static void DisplayLibraryMenu()
        {
            Console.WriteLine("1.  Add New Book");
            Console.WriteLine("2.  View All Books");
            Console.WriteLine("3.  Register New User");
            Console.WriteLine("4.  View All Users");
            Console.WriteLine("5.  Borrow a Book");
            Console.WriteLine("6.  View Borrow History");
            Console.WriteLine("7.  Return a Book");
            Console.WriteLine("8.  Search Book by Title");
            Console.WriteLine("9.  Search Book by Author");
            Console.WriteLine("10. Search User by Name");
            Console.WriteLine("11. Display Library Statistics");
            Console.WriteLine("12. Exit");
            Console.Write("\nEnter choice: ");
        }

        //Add Book
        static void AddNewbook(Library addNewBook)
        {
            Console.WriteLine("\n--- Add New Book ---");

            Console.WriteLine("Enter Book Title:");
            string bookTitle = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(bookTitle)) //String Validation: Title cannot be empty
            {
                Console.WriteLine("Error: Title cannot be empty.");
                return;
            }

            Console.WriteLine("Enter Author:");
            string? author = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(author)) //String Validation: Author cannot be empty
            {
                Console.WriteLine("Error: Author cannot be empty.");
                return;
            }
            Console.Write("Enter ISBN:");
            string isbn = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("Error: ISBN cannot be empty.");
                return;
            }
            Console.Write("Enter Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price format.");
                return;
            }


            Console.WriteLine("Enter Total Copies:");

            if (!int.TryParse(Console.ReadLine(), out int numberOfCopies))
            {
                Console.WriteLine("Invalid ID format. Please enter an integer");
                return;
            }

            Console.Write("Enter Category: ");
            string category = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine("Error: Category cannot be empty.");
                return;
            }


            Book NewBook = new Book(bookTitle, author, isbn, price, numberOfCopies, category);

            addNewBook.AddBook(NewBook);

        }


        //Add user
        static void AddNewUser(Library adduser)
        {
            Console.WriteLine("\n--- Add New User ---");

            Console.Write("Enter Name");
            string userName = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(userName)) //String Validation: Name cannot be empty
            {
                Console.WriteLine("Error: Name cannot be empty.");
                return;
            }

            Console.Write("Enter Email Address: ");

            // Regex pattern for a basic email structure
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            string email = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Error: Email cannot be empty.");
                return;
            }
            else if (!Regex.IsMatch(email, emailPattern))
            {
                Console.WriteLine("Error: Please enter a valid email address (e.g., user@example.com).");
                return;
            }
            Console.Write("Enter House Address: ");
            string address = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Error: Address cannot be empty.");
                return;
            }
            Console.Write("Enter Phone Number: ");
            string phoneNumber = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.WriteLine("Error: Phone Number cannot be empty.");
                return;
            }
            LibraryUser Newuser = new LibraryUser(userName, email, address, phoneNumber);

            adduser.AddNewUser(Newuser);
            Console.WriteLine($"\nUser: {userName} added succesfully");
        }

    }




}




