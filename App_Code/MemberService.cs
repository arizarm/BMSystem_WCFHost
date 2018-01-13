using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFHosting;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MemberService" in code, svc and config file together.
public class MemberService : IMemberService
{
    public WCF_Member GetMember(string id)
    {
        Member c = Data.GetMember(id);
        return new WCF_Member(c.MemberName, c.Email, c.PhoneNo, c.Password);
    }

    public string[] List()
    {
        return Data.ListMembers().ToArray<String>();
    }

    public WCF_Member Update(Member c)
    {
        Data.UpdateMember(c);
        WCF_Member a = new WCF_Member(c.MemberName, c.Email, c.PhoneNo, c.Password);
        return a;
    }

    public WCF_Member Create(Member c)
    {
        Data.InsertMember(c);
        WCF_Member a = new WCF_Member(c.MemberName, c.Email, c.PhoneNo, c.Password);
        return a;
    }

    public void Delete(Member c)
    {
        Data.DeleteMember(c);
    }

    public string[] SearchMember(string id)
    {
        return Data.SearchMember(id).ToArray<String>();
    }
}
