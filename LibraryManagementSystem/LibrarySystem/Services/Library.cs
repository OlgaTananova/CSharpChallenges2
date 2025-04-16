using System;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using LibrarySystem.Core;

namespace LibrarySystem.Services;

public class Library
{
    private List<Book> _books { get; set; } = new();
    private List<User> _users { get; set; } = new();

    public bool AddUser(User user)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser != null)
        {
            Console.WriteLine($"User with such id already exists.");
            return false;
        }

        _users.Add(user);
        return true;
    }

    public bool AddBookToLibrary(Book book)
    {
        var existingBook = _books.FirstOrDefault(b => b.ISBN == book.ISBN);
        if (existingBook is not null)
        {
            Console.WriteLine($"The Book with ISNB{book.ISBN} already exists. Updating the existing book.");
            return UpdateBook(book.ISBN, book.TotalCopies);
        }

        _books.Add(book);
        Console.WriteLine($"The book with ISBN {book.ISBN} was successfully added to the library.");
        return true;

    }

    public bool UpdateBook(string isbn, int copies)
    {
        var book = _books.FirstOrDefault(b => b.ISBN == isbn);
        if (book is not null)
        {
            book.TotalCopies += copies;
            book.AvaliableCopies += copies;
            Console.WriteLine($"The book with ISBN {isbn} was successfully updated.");
            return true;
        }
        Console.WriteLine($"The Book with such ISBN was not found.");
        return false;
    }


    public bool BorrowBook(string title, int userId)
    {
        Book? borrowedBook = FindBookByTitle(title);

        User? user = FindUser(userId);

        if (borrowedBook == null || user == null) return false;

        if (borrowedBook.AvaliableCopies == 0)
        {
            Console.WriteLine($"The book is not avaliable now, trying to add the user with {userId} to the reservation list.");
            borrowedBook.ReservationQueue.Enqueue(user);
            return false;
        }
        Loan loan = new Loan(borrowedBook, user);

        borrowedBook.AvaliableCopies--;
        borrowedBook.LoanHistory.Add(loan);
        user.Loans.Add(loan);
        Console.WriteLine($"The user with id {userId} successfully borrowed the book with title \"{title}\" from the library.");
        return true;
    }

    public bool ReturnBook(int userId, string isbn)
    {
        User? user = FindUser(userId);
        Book? returnedBook = FindBookByISNB(isbn);
        if (user == null || returnedBook == null) return false;

        var loan = returnedBook.LoanHistory.FirstOrDefault(l => l.User == user && l.Book == returnedBook);
        var loanInUser = user.Loans.FirstOrDefault(l => l.User == user && l.Book == returnedBook);

        if (loan != null && loanInUser != null)
        {
            loan.ReturnedOn = DateTime.Now;
            loanInUser.ReturnedOn = DateTime.Now;
            if (loan.IsOverdue && loanInUser.IsOverdue)
            {
                decimal fine = loan.CalculateFine();

                Console.WriteLine($"You have a outstanding fine in the amount of {fine}");
                user.OutstandingFines += fine;
            }
            returnedBook.AvaliableCopies++;
            Console.WriteLine($"The user with id {userId} successfully returned the book with ISNB {isbn} to the library.");

            if (returnedBook.ReservationQueue.Count != 0)
            {
                var nextUser = returnedBook.ReservationQueue.Dequeue();
                BorrowBook(returnedBook.Title, nextUser.Id);
            }
            return true;
        }

        Console.WriteLine($"Could not find the load with the book with ISBN {isbn} and the user with id {userId}");
        return false;
    }

    public Book? FindBookByTitle(string title)
    {
        Book? book = _books.FirstOrDefault(b => b.Title.ToLower() == title?.ToLower());
        if (book == null)
        {
            Console.WriteLine($"The book with the title {title} was not found.");
        }
        return book;
    }

    public Book? FindBookByISNB(string isbn)
    {
        Book? bookByIsbn = _books.FirstOrDefault(b => b.ISBN.ToLower() == isbn?.ToLower());
        if (bookByIsbn == null)
        {
            Console.WriteLine($"The book with the ISNB {isbn} was not found.");
        }

        return bookByIsbn;
    }

    public User? FindUser(int id)
    {
        User? user = _users.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            Console.WriteLine($"The user with id {id} was not found.");
        }

        return user;
    }

    public void ShowUserSummary(int userId)
    {
        User? user = FindUser(userId);

        if (user == null) return;

        Console.WriteLine($"{user.FirstName} {user.LastName} with ID {user.Id}.");
        Console.WriteLine($"Outstanding fines: ${user.OutstandingFines}.");

        foreach (var loan in user.Loans)
        {
            Console.WriteLine($"Loan: book title - {loan.Book.Title}, book author - {loan.Book.Author}, borrowed on {loan.BorrowedOn}, due on {loan.DueDate}.");
        }
    }


}
