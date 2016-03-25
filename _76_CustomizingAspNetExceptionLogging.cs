using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _76_CustomizingAspNetExceptionLogging
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            // DataSet is in System.Data namespace
            DataSet ds = new DataSet();
            // This line will throw an exception, as Data.xml 
            // file is not present in the project
            ds.ReadXml(Server.MapPath("~/Data.xml"));
            GridView1.DataSource = ds;
            GridView1.DataBind();
            //}
            //catch (Exception ex)
            //{
            //    Logger.Log(ex);
            //    Server.Transfer("~/Errors.aspx");
            //}

        }
    }
}