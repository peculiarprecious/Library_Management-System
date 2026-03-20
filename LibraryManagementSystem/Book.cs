namespace LibraryManagementSystem;
public class Book
{
    public int Id{get; set;}
    public string Title{get; set;} = "";
    public string Author{get; set;} = "";
    public string ISBN { get; set; } = "000-0000000000"; 
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public bool IsAvailable => AvailableCopies > 0;
}