using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;

/// <summary>
/// Summary description for Sidekick
/// </summary>
public static class Sidekick
{
    public static void Alert(string message, Page page)
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "myalert", $"alert('{message}');", true);
    }

    public static string SeparateLongWords(string myString)
    {
        //string myString = "mondayfridaysaturday";
        string result = string.Empty;
        for (int i = 0; i < myString.Length; i++)
            result += (i % 20 == 0 && i != 0) ? (myString[i].ToString() + " ") : myString[i].ToString();
        return result;
    }

    public static List<T> ShuffleList<T>(List<T> list)
    {
        Random random = new Random();
        List<T> newShuffledList = new List<T>();
        int listcCount = list.Count;
        for (int i = 0; i < listcCount; i++)
        {
            int randomElementInList = random.Next(0, list.Count);
            newShuffledList.Add(list[randomElementInList]);
            list.Remove(list[randomElementInList]);
        }
        return newShuffledList;
    }
}