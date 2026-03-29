namespace LibraryManagementSystem;
public class LibraryUser
{
    private static int _id = 1;
    public int UserId { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
     public string Address { get; set; } = "";
    public string PhoneNumber { get; set; } = "";



    public LibraryUser(string name, string email, string address, string phonenumber)
    {
        UserId = _id++;
        Name = name;
        Email = email;
        Address = address;
        PhoneNumber = phonenumber;
    }

   
}

