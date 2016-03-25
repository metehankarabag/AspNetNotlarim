using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace _120_CachingMultipleResponsesForaWebForm
{
    /* Bir WEBFORM için çoklu cevapları önbelleğe alma hakkında tartışacağız.
      Geçen derste kullanıdığımız tablodaki bilgileri bu derste türlerine göre almayı istiyoruz.
      Bunun için bilgileri türlerine göre alabileceğimiz bir STROED PROCEDURE yazmalıyız.

      Kodları yazıktan sonra @OutputCache yönergesinin VaryByParam özelliğine bir CONTROL adı ver.
      WENFORM Bu CONTROL'ü farklı değerleri ile  SERVER'e her gönderdiğinde SERVER tüm FORM'ü önbelleğe alacak.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) GetProductByName("All");

            Label1.Text = DateTime.Now.ToString();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e) { GetProductByName(DropDownList1.SelectedValue); }

        private void GetProductByName(string ProductName)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("spGetProductByName", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramProductName = new SqlParameter();
            paramProductName.ParameterName = "@ProductName";
            paramProductName.Value = ProductName;
            da.SelectCommand.Parameters.Add(paramProductName);

            DataSet DS = new DataSet();
            da.Fill(DS);
            GridView1.DataSource = DS;
            GridView1.DataBind();
        }

    }
}