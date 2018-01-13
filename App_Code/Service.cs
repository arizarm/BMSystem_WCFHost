using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFHosting;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
    {
    public void Add(WCFBook book)
    {
        Book b = new WCFHosting.Book();
        b.Author = book.Author;
        b.Title = book.Title;
        b.ISBN = book.Isbn;
        b.Stock = book.Stock;
        b.Price = book.Price;
        BookData.InsertBook(b);
    }

    public WCFBook GetBook(string id)
        {
            Book b = BookData.GetBook(Int32.Parse(id));
            return WCFBook.Make(b.BookID.ToString(), b.Title, b.ISBN, b.Author, b.Stock, b.Price);
        }

    public List<WCFBook> List()
        {
        List<WCFBook> wlist = new List<WCFBook>();
       List<Book> blist= BookData.ListCustomers();
        foreach(Book b in blist)
        {
            wlist.Add(WCFBook.Make(b.BookID.ToString(), b.Title, b.ISBN, b.Author, b.Stock, b.Price));
        }
        return wlist;
        }

    public void Update(WCFBook c)
    {
        Book b = new Book
        {
            BookID = Convert.ToInt32(c.Id), 
            Title = c.Title,
            Author = c.Author,
            ISBN = c.Isbn,
            Stock=c.Stock,
            Price=c.Price
        };
        BookData.UpdateBook(b);
    }

    //public Stream FetchImage(string isbn)
    //{
    //    string filePath = "~/Images/" + isbn;
    //    if (File.Exists(filePath))
    //    {
    //        FileStream fs = File.OpenRead(filePath);
    //        WebOperationContext.Current.OutgoingRequest.ContentType = "image/jpg";
    //        return fs;
    //    }
    //    else
    //    {
    //        byte[] byteArray = Encoding.UTF8.GetBytes("Requested image does not exist.");
    //        MemoryStream strm = new MemoryStream(byteArray);
    //        return strm;
    //    }
    //}
}
