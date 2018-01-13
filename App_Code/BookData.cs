using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFHosting;

/// <summary>
/// Summary description for BookData
/// </summary>
public class BookData
{
    public static List<Book> ListCustomers()
    {
        using (Model1 m = new Model1())
        {
            return m.Books.ToList<Book>();
        }
    }

    public static Book GetBook(int id)
    {
        using (Model1 m = new Model1())
        {
            return m.Books.Where(p => p.BookID == id).ToList<Book>()[0];
        }
    }


    public static void UpdateBook(Book b)
    {
        using (Model1 m = new Model1())
        {
           Book book= m.Books.Where(p => p.BookID == b.BookID).First<Book>();
            book.Stock = b.Stock;
            book.ISBN = b.ISBN;
            book.Title = b.Title;
            book.Author = b.Author;
            book.Price = b.Price;
            m.SaveChanges();
        }
    }

    public static void InsertBook(Book c)
    {
        using (Model1 m = new Model1())
        {
            m.Books.Add(c);
            m.SaveChanges();
        }
    }

}