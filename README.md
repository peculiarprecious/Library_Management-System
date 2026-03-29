# Library Management System

## Description
A C# console application designed to manage library inventory, user registrations, and book transactions. This version focuses on Object-Oriented Programming (OOP) principles, specifically Encapsulation and Data Validation.

## Key Features
- Library Class: A central "Manager" class that handles all data through a private List<Book> and List<LibraryUser>.
- Advanced Search: Search for books by Title or Author, and users by Name (using case-insensitive partial matching).
- Inventory Tracking: Automatically tracks TotalCopies vs AvailableCopies during borrow and return transactions.
- Data Validation:
- Price and Copies properties are validated to ensure they are never negative.
- Category and Title properties are checked to ensure they are not empty.
- Library Statistics: Real-time calculation of unique titles, total physical copies, and transaction history.

## How to Run

1. Clone the repository.
2. Open the project in VS Code or Visual Studio.
3. Run dotnet run in the terminal.
4. Sample data (Seeding) is loaded automatically on startup for testing.

## Technical Skills Demonstrated
1. Encapsulation: Using private fields and public properties to protect data integrity.
2. Constructors: Implementing Primary and Standard Constructors to initialize objects with valid data.
3. LINQ: Using .Sum() and .FindAll() for efficient data searching and statistics.
4. Error Handling: Using int.TryParse and decimal.TryParse to prevent console crashes from invalid user input.

## Challenges Faced
- Refactoring to a Library Class: Moving logic from Program.cs into a dedicated Library class was a challenge. It required changing how methods accessed data, moving from static calls to instance-based calls.
- Navigating Encapsulation (Private Fields vs. Properties):
A significant challenge was understanding why I needed both a private field (like _price) and a public property (like Price). I learned that the private field acts as the "secure storage," while the property acts as a "gatekeeper" that uses a Setter to scrutinize and validate data before it is saved.

## Review of the Logic Mastered:
The Private Field: private decimal _price; 
The Property: public decimal Price { get => _price; set => ... } 
The Constructor: public Book(...) { Price = price; }

## Technologies Used
- C#
- .NET SDK
- Git/GitHub
