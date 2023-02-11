using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserInfoModel
/// </summary>
public class UserInfoModel
{
    public UserInformation GetUserInformation(string guId)
    {
        TechShopDBEntities db = new TechShopDBEntities();
        UserInformation info = (from x in db.UserInformations 
                                where x.GUID == guId 
                                select x).FirstOrDefault();
        return info;
    }

    public void InsertUserInformation(UserInformation info)
    {
        TechShopDBEntities db = new TechShopDBEntities();
        db.UserInformations.Add(info);
        db.SaveChanges();
    }
}