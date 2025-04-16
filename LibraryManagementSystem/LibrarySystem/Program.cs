
using LibrarySystem.Core;
using LibrarySystem.Services;

Library library = new();
Book book1 = new Book("1234578", "War and Peace", "Leo Tolstoy", 1);
Book book2 = new Book("1234579", "Crime and Punishment", "Feodor Dostoevsky", 10);
Book book3 = new Book("123470", "Eugene Onegin", "Alexander Pushkin", 5);
User user = new User(1, "Olga", "Tananova");
User user2 = new User(2, "John", "Doe");

library.AddBookToLibrary(book1);
library.AddBookToLibrary(book2);
library.AddBookToLibrary(book3);
library.AddUser(user);
library.AddUser(user2);

while (true)
{
    Console.WriteLine("1. Borrow a Book");
    Console.WriteLine("2. Return a Book");
    Console.WriteLine("3. View User Summary");
    Console.WriteLine("4. Exit");
    Console.Write("Enter your choice: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.Write("Enter user ID: ");
            int userId = int.Parse(Console.ReadLine());
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();
            library.BorrowBook(title, userId);
            break;
        case "2":
            Console.WriteLine("Enter user ID:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter book ISBN:");
            string isbn = Console.ReadLine();
            library.ReturnBook(id, isbn);
            break;

        case "3":
            Console.WriteLine("Enter user ID:");
            int uid = int.Parse(Console.ReadLine());
            library.ShowUserSummary(uid);
            break;
        case "4":
            return;
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
}
