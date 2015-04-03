using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BusinessLogic;
using WebUtility;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

/// <summary>
/// Summary description for CustomerService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class CustomerService : System.Web.Services.WebService {

    public CustomerService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public Customer CustomerLogin(string username, string password)
    {
        String HashedUsername = Utility.GetSHA512Hash(username);
        String HashedPassword = Utility.GetSHA512Hash(password);

        Customer customerLogger = new CustomerLogic().login(HashedUsername, HashedPassword);

        return customerLogger; 
    }

    [WebMethod]
    public string RequestService(int ServiceID, int Unit, int CustomerID, int BookingID, String CustomerRemarks)
    {
        
        return "OrderReceived";
    }
}
