namespace LibraryManagementSystem;

public class BorrowRecord
{
    public required Book Book { get; set; }        
    public required LibraryUser User { get; set; } 
    public DateTime BorrowDate { get; set; }
}