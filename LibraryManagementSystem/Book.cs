namespace LibraryManagementSystem;

public class Book
{
    private static int _idCounter = 1; // Starts IDs at 1
    public int Id { get; private set; }
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string ISBN { get; set; } = "000-0000000000";
    private decimal _price;
    private int _totalCopies;
    private int _availableCopies;
    public bool IsAvailable => AvailableCopies > 0;
    private string _category = "General";


    public decimal Price
    {
        get => _price;

        set
        {
            if (value >= 0)
            {
                _price = value;
            }
            else
            {
                Console.WriteLine("Price cannot be negative");

                _price = 0;
            }
        }
    }


    public int TotalCopies
    {
        get => _totalCopies;

        set
        {
            if (value > 1)
            {
                _totalCopies = value;
            }
            else
            {
                _totalCopies = 1;
            }
        }
    }

    public int AvailableCopies
    {
        get => _availableCopies;

        set
        {
            if (value >= 0)
            {
                _availableCopies = value;
            }
            else
            {
                _availableCopies = 0;
            }
        }

    }

    public string Category
    {
        get => _category;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                _category = "General"; 
            else
                _category = value;
        }
    }




    public Book(string title, string author, string isbn, decimal price, int copies, string category)
    {
        Id = _idCounter++;
        Title = title;
        Author = author;
        ISBN = isbn;
        Price = price;
        TotalCopies = copies;
        AvailableCopies = TotalCopies;
        Category = category;


    }
}