using System;

namespace LibrarySystem.Core;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime RegistrationDate { get; set; }
    public List<Loan> Loans { get; set; } = new(); // list of loans

    public decimal OutstandingFines { get; set; }

    public User(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        RegistrationDate = DateTime.Now;
    }

}
