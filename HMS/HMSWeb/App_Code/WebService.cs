using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BusinessLogic;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string PingServer() {
        return "Server Connected";
    }

    [WebMethod]
    public string CustomerLogin(string username, string password)
    {
        //JavaScriptSerializer js = new JavaScriptSerializer();
        return "done";
    }  

    [WebMethod]
    public string SayHello1(int firstName, string lastName)
    {
        return "Hello " + firstName + " " + Convert.ToDateTime(lastName).ToString();
    }

    [WebMethod]
    public string SayHelloJson(string firstName, string lastName)
    {
        var data = new { Greeting = "Hello", Name = firstName + " " + lastName };

        // We are using an anonymous object above, but we could use a typed one too (SayHello class is defined below)
        // SayHello data = new SayHello { Greeting = "Hello", Name = firstName + " " + lastName };

        JavaScriptSerializer js = new JavaScriptSerializer();

        return js.Serialize(data);
    }
}