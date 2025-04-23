using System;
using LibrarySystem.Core;
using LibrarySystem.Services;

namespace LibrarySystemTests;

public class LibrarySystemTests
{

    [Fact]
    public void AddUser_WhenNoSuchUserInSystem_ReturnsTrue()
    {
        Library library = new();
        User user = new(1, "John", "Doe");

        var result = library.AddUser(user);

        Assert.True(result);
    }
    [Fact]
    public void AddUser_WhenUserExists_ReturnsFalse()
    {
        Library library = new();
        User user = new(1, "John", "Doe");
        library.AddUser(user);
        var result = library.AddUser(user);

        Assert.False(result);
    }

    [Fact]
    public void AddBookToLibrary_WhenNewBook_ReturnsTrue()
    {
        Library library = new();
        Book book = new Book("BOOK1", "War and Peace", "Leo Tolstoy", 10);

        var result = library.AddBookToLibrary(book);

        Assert.True(result);
    }


    [Fact]
    public void UpdateBook_WhenValidInput_ReturnsTrue()
    {
        Library library = new();
        Book book = new Book("BOOK1", "War and Peace", "Leo Tolstoy", 10);
        library.AddBookToLibrary(book);

        string isbn = "BOOK1";
        int copiesToAdd = 2;
        int copiesAfterUpdate = 12;

        var result = library.UpdateBook(isbn, copiesToAdd);
        var updatedBook = library.FindBookByISNB(isbn);

        Assert.True(result);
        Assert.Equal(copiesAfterUpdate, updatedBook?.TotalCopies);

    }

    [Fact]
    public void UpdateBook_WhenBookDoesNotExist_ReturnsFalse()
    {
        Library library = new();
        string isbn = "BOOK2";
        int copiesToAdd = 2;
        var result = library.UpdateBook(isbn, copiesToAdd);
        Assert.False(result);

    }

    [Fact]
    public void BorrowBook_WhenValidInput_ReturnsTrue()
    {
        Library library = new();
        User user = new(1, "John", "Doe");
        Book book = new("BOOK1", "War and Peace", "LeoTolstoy", 2);
        int avaliableCopiesAfterLoan = 1;
        library.AddUser(user);
        library.AddBookToLibrary(book);

        var result = library.BorrowBook(book.Title, user.Id);
        var loan = user.Loans.FirstOrDefault(l => l.Book.ISBN == book.ISBN);

        Assert.True(result);
        Assert.Equal(loan?.Book, book);
        Assert.Equal(avaliableCopiesAfterLoan, book.AvaliableCopies);
    }

    [Fact]
    public void BorrowBook_WhenNoAvaliableCopies_ReturnsFalse()
    {
        Library library = new();
        User user = new(1, "John", "Doe");
        Book book = new("BOOK1", "War and Peace", "LeoTolstoy", 0);
        int avaliableCopiesAfterLoan = 0;
        library.AddUser(user);
        library.AddBookToLibrary(book);

        var result = library.BorrowBook(book.Title, user.Id);
        Assert.False(result);
        Assert.Equal(avaliableCopiesAfterLoan, book.AvaliableCopies);
        Assert.NotEmpty(book.ReservationQueue);
    }

    [Fact]
    public void BorrowBook_WhenBookNotFound_ReturnsFalse()
    {
        Library library = new();
        User user = new(1, "John", "Doe");
        library.AddUser(user);
        string bookTitle = "random";

        var result = library.BorrowBook(bookTitle, user.Id);
        Assert.False(result);
    }

    [Fact]
    public void BorrowBook_WhenUserNotFound_ReturnsFalse()
    {
        Library library = new();
        Book book = new("BOOK1", "War and Peace", "LeoTolstoy", 2);
        library.AddBookToLibrary(book);
        int userId = 2;

        var result = library.BorrowBook(book.Title, userId);
        Assert.False(result);
    }


}
