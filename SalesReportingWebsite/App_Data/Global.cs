using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for Global
/// </summary>
public class Global:System.Web.HttpApplication
{
	public Global()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    protected void Application_EndRequest(Object sender, EventArgs e)
    {
        HttpContext context = HttpContext.Current;
        if (context.Response.Status.Substring(0, 3).Equals("401"))
        {
            context.Response.ClearContent();
            //context.Response.Write("Not authorised to view this page");
            context.Response.Write("<script language=javascript>self.location='Errors/Unauthorised.aspx';</script>");
        }
    }

    protected void Application_Error(object sender, EventArgs e)
    {
        // At this point we have information about the error
        HttpContext ctx = HttpContext.Current;

        Exception exception = ctx.Server.GetLastError();

        string errorInfo =
           "<br>Offending URL: " + ctx.Request.Url.ToString() +
            "<br>Source: " + exception.Source +
           "<br>Message: " + exception.Message + "<Br>";

        //"<br>Stack trace: " + exception.StackTrace;

        ctx.Response.Write("<b> Following Error Occured. </b>");
        ctx.Response.Write(errorInfo);

        // --------------------------------------------------
        // To let the page finish running we clear the error
        // --------------------------------------------------

        ctx.Server.ClearError();
    }
}