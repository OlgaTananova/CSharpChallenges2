using System;

namespace LibrarySystem.Core;

public class Librarian
{
    public int Id { get; set; }
    public string FullName { get; set; }

    public void AddBook(Book book)
    {

    }

    public Librarian(string name, int id)
    {
        Id = id;
        FullName = name;
    }
}
