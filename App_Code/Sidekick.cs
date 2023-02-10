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
}