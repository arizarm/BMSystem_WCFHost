using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using WCFHosting;
using System.IO;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
    [OperationContract]
    [WebGet(UriTemplate = "/Book/{id}", ResponseFormat = WebMessageFormat.Json)]
    WCFBook GetBook(string id);

    [OperationContract]
    [WebGet(UriTemplate = "/Book", ResponseFormat = WebMessageFormat.Json)]
    List<WCFBook> List();

    [OperationContract]
    [WebInvoke(UriTemplate = "/Update", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
    void Update(WCFBook book);
    
    [OperationContract]
    [WebInvoke(UriTemplate = "/New", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
    void Add(WCFBook book);

    //[OperationContract]
    //[WebGet(UriTemplate = "/Image/{isbn}", ResponseFormat = WebMessageFormat.Json)]
    //Stream FetchImage(string isbn);
}

[DataContract]
public class WCFBook
{
    string id;
    string title;
    string isbn;
    string author;
    int stock;
    decimal price;

    public static WCFBook Make(string id, string title, string isbn, string author, int stock, decimal price)
    {
        WCFBook b = new WCFBook();
        b.id = id;
        b.title = title;
        b.isbn = isbn;
        b.author = author;
        b.stock = stock;
        b.price = price;
        return b;
    }

    [DataMember]
    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    [DataMember]
    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    [DataMember]
    public string Isbn
    {
        get { return isbn; }
        set { isbn = value; }
    }

    [DataMember]
    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    [DataMember]
    public int Stock
    {
        get { return stock; }
        set { stock = value; }
    }

    [DataMember]
    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }
}

