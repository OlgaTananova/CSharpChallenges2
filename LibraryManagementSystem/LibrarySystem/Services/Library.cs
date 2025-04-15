using System;
using System.Dynamic;
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

    public bool UpdateBook(string isnb, int copies)
    {
        var book = _books.FirstOrDefault(b => b.ISBN == isnb);
        if (book is not null)
        {
            book.TotalCopies += copies;
            book.AvaliableCopies += copies;
            Console.WriteLine($"The book with ISBN {isnb} was successfully updated.");
            return true;
        }
        Console.WriteLine($"The Book with such ISBN was not found.");
        return false;
    }

    public void BorrowBook(Book book, User user)
    {
        throw new NotImplementedException();
    }

    public void ReturnBook(string name, string isnb)
    {
        throw new NotImplementedException();
    }

    public Book FindBook(string title)
    {
        throw new NotImplementedException();
    }


}
