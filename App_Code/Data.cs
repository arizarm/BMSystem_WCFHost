using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFHosting;

/// <summary>
/// Summary description for Data
/// </summary>
public class Data
{
    public static List<String> ListMembers()
    {
        using (Model2 m = new Model2())
        {
            return m.Members.Select<Member, String>(c => c.MemberName).ToList<String>();
        }
    }

    public static Member GetMember(string name)
    {
        using (Model2 m = new Model2())
        {
            return m.Members.Where
                    (p => p.MemberName == name).ToList<Member>()[0];
        }
    }

    public static void InsertMember(Member c)
    {
        using (Model2 m = new Model2())
        {
            m.Members.Add(c);
            m.SaveChanges();
        }
    }
    public static void UpdateMember(Member c)
    {
        using (Model2 m = new Model2())
        {
            m.Entry(c).State = System.Data.Entity.EntityState.Modified;
            m.SaveChanges();
        }
    }

    public static void DeleteMember(Member c)
    {
        using (Model2 m = new Model2())
        {
            m.Members.Remove(c);
            m.SaveChanges();
        }
    }

    public static List<String> SearchMember(string n)
    {
        using (Model2 m = new Model2())
        {
            List<String> mList = new List<String>();
            mList.AddRange(m.Members.Where(p => p.MemberName == n).Select<Member, String>(x => x.MemberName).ToList<String>());
            mList.AddRange(m.Members.Where(p => p.Email == n).Select<Member, String>(x => x.MemberName).ToList<String>());
            mList.AddRange(m.Members.Where(p => p.PhoneNo == n).Select<Member, String>(x => x.MemberName).ToList<String>());
            return mList;
        }
    }

}