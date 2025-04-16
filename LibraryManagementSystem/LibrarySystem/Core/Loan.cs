using System;

namespace LibrarySystem.Core;

public class Loan
{

    public Book Book { get; set; }
    public User User { get; set; }
    public DateTime BorrowedOn { get; set; }
    public DateTime DueDate { get; set; }

    public DateTime? ReturnedOn { get; set; }

    public decimal FinePerDay { get; set; }

    public int BorrowTerm { get; set; }

    public bool IsOverdue => DueDate < DateTime.Now;

    public bool IsActive => ReturnedOn == null;

    public decimal CalculateFine()
    {
        if (IsOverdue)
        {
            var days = ReturnedOn != null ? (ReturnedOn.Value - DueDate).Days : (DateTime.Now - DueDate).Days;
            return days * FinePerDay;
        }
        return 0.0M;
    }

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
