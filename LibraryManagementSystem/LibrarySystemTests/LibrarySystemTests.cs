using System;
using System.Runtime.InteropServices;
using LibrarySystem.Core;
using LibrarySystem.Services;

namespace LibrarySystemTests;

public class LibrarySystemTests
{
    private (Library library, User user, Book book) CreateLibraryWithUserAndBook(
        int userId = 1,
        string userName = "John",
        string userSurname = "Doe",
        string bookTitle = "War and Peace",
        string bookAuthor = "Leo Tolstoy",
        string bookISBN = "BOOK1",
        int totalCopies = 2)
    {
        var library = new Library();
        var user = new User(userId, userName, userSurname);
        var book = new Book(bookISBN, bookTitle, bookAuthor, totalCopies);

        library.AddUser(user);
        library.AddBookToLibrary(book);

        return (library, user, book);
    }

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
        var (library, user, book) = CreateLibraryWithUserAndBook();
        int avaliableCopiesAfterLoan = 1;
        var result = library.BorrowBook(book.Title, user.Id);
        var loan = user.Loans.FirstOrDefault(l => l.Book.ISBN == book.ISBN);

        Assert.True(result);
        Assert.Equal(loan?.Book, book);
        Assert.Equal(avaliableCopiesAfterLoan, book.AvaliableCopies);
    }

    [Fact]
    public void BorrowBook_WhenNoAvaliableCopies_ReturnsFalse()
    {
        var (library, user, book) = CreateLibraryWithUserAndBook(totalCopies: 0);
        int avaliableCopiesAfterLoan = 0;
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

    [Fact]
    public void ReturnBook_WhenValid_ReturnsTrue_AndIncrementCopies()
    {
        var (library, user, book) = CreateLibraryWithUserAndBook();

        library.BorrowBook(book.Title, user.Id);
        int avaliableCopiesAterReturn = 2;
        var result = library.ReturnBook(user.Id, book.ISBN);

        Assert.True(result);
        Assert.Equal(avaliableCopiesAterReturn, book.AvaliableCopies);

    }

    [Fact]
    public void ReturnBook_WhenNotBorrowed_ReturnsFalse()
    {
        var (library, user, book) = CreateLibraryWithUserAndBook();

        var result = library.ReturnBook(user.Id, book.ISBN);

        Assert.False(result);

    }

    [Fact]
    public void ReturnBook_WithReservation_DequeuesNextUserAndBorrows()
    {
        var (library, user, book) = CreateLibraryWithUserAndBook(totalCopies: 1);
        User user2 = new(2, "Jane", "Smith");

        library.AddUser(user2);
        library.BorrowBook(userId: user.Id, title: book.Title);
        library.BorrowBook(userId: user2.Id, title: book.Title);

        var result = library.ReturnBook(userId: user.Id, isbn: book.ISBN);

        Assert.True(result);
        Assert.Contains(book, user2.Loans.Select(l => l.Book));
        Assert.Equal(0, book.AvaliableCopies);
        Assert.Empty(book.ReservationQueue);

    }


}
