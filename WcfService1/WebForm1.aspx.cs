using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfService1.ServiceReference1;

namespace WcfService1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();

            // Use the 'client' variable to call operations on the service.

            // Always close the client.
            client.Open();
            Console.WriteLine(client.ToGetJSon());
            client.Close();

            Console.ReadKey();
        }
    }
}