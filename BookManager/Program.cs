using System;
using System.Collections.Generic;
using BookManager.Models;

class Program
{
    static List<Book> books = new List<Book>();
    static int nextId = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nBook Manager");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. List Books");
            Console.WriteLine("3. Update Book");
            Console.WriteLine("4. Delete Book");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddBook(); break;
                case "2": ListBooks(); break;
                case "3": UpdateBook(); break;
                case "4": DeleteBook(); break;
                case "5": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void AddBook()
    {
        Console.Write("Enter title: ");
        var title = Console.ReadLine();
        Console.Write("Enter author: ");
        var author = Console.ReadLine();

        books.Add(new Book { Id = nextId++, Title = title!, Author = author! });
        Console.WriteLine("Book added.");
    }

    static void ListBooks()
    {
        Console.WriteLine("\nBooks:");
        foreach (var book in books)
        {
            Console.WriteLine($"{book.Id}: {book.Title} by {book.Author}");
        }
    }

    static void UpdateBook()
    {
        Console.Write("Enter book ID to update: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var book = books.Find(b => b.Id == id);
            if (book != null)
            {
                Console.Write("Enter new title: ");
                book.Title = Console.ReadLine()!;
                Console.Write("Enter new author: ");
                book.Author = Console.ReadLine()!;
                Console.WriteLine("Book updated.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }

    static void DeleteBook()
    {
        Console.Write("Enter book ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var book = books.Find(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("Book deleted.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }
}