using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using WCFHosting;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMemberService" in both code and config file together.
[ServiceContract]
public interface IMemberService
{
    [OperationContract]
    [WebGet(UriTemplate = "/Member/{name}", ResponseFormat = WebMessageFormat.Json)]
    WCF_Member GetMember(string name);

    [OperationContract]
    [WebGet(UriTemplate = "/Members", ResponseFormat = WebMessageFormat.Json)]
    string[] List();

    [OperationContract]
    [WebInvoke(UriTemplate = "/Update", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    WCF_Member Update(Member m);

    [OperationContract]
    [WebInvoke(UriTemplate = "/AddMember", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    WCF_Member Create(Member m);

    [OperationContract]
    [WebInvoke(UriTemplate = "/Delete", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    void Delete(Member m);

    [OperationContract]
    [WebGet(UriTemplate = "/Search/{n}", ResponseFormat = WebMessageFormat.Json)]
    string[] SearchMember(string n);
}

[DataContract]
public class WCF_Member
{
    [DataMember]
    public string MemberName;

    [DataMember]
    public string Email;

    [DataMember]
    public string PhoneNo;

    [DataMember]
    public string Password;

    public WCF_Member(string MemberName, string Email, string PhoneNo, string Password)
    {
        this.MemberName = MemberName;
        this.Email = Email;
        this.PhoneNo = PhoneNo;
        this.Password = Password;
    }

}
