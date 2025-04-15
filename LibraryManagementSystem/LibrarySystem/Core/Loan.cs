using System;

namespace LibrarySystem.Core;

public class Loan
{

    public Book Book { get; set; }
    public User User { get; set; }
    public DateTime BorrowedOn { get; set; }
    public DateTime DueDate { get; set; }

    public decimal FinePerDay {get; set;}

    public int BorrowTerm { get; set; }

    public bool IsOverdue => DueDate > DateTime.Now;

    public decimal CalculateFine() => IsOverdue? (DateTime.Now - DueDate).Days * FinePerDay : 0; 

    public Loan(Book book, User user, int term = 21, decimal fine = 0.5m)
    {
        Book = book;
        User = user;
        BorrowTerm = term;
        FinePerDay = fine;
        BorrowedOn = DateTime.Now;
        DueDate = BorrowedOn.AddDays(BorrowTerm);

    }

}
