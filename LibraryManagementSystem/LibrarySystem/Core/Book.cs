using System;

namespace LibrarySystem.Core;

public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int TotalCopies { get; set; }
    public int AvaliableCopies { get; set; }

    public Queue<User> ReservationQueue { get; set; } = new();
    public List<Loan> LoanHistory { get; set; } = new();

    public Book(string isbn, string title, string author, int copies)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
        TotalCopies = copies;
        AvaliableCopies = copies;
    }
}
