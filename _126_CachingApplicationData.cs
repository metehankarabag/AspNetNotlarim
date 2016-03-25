using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _126_CachingApplicationData
{
    /* Uygulama verisi depolama
      Geçen derslerde CACHE'de WEBFORM'ları depolamıştık.
     
      CACHE nesnesini kullanarak, SERVER hafızasındaki uygulama verisini depolamak mümkün
      Bu sayede veri daha hızla geri alınır. 
      Yani çalışması 5 sn alan bir STRORED PROCEDURE, vb işlemleri her seferinde çalıştırmak yerine bunların sonuçlarını CACHE'ye alabiliriz.
      
      Veriyi depolamak ve depolanmış veriyi almak için KEY-VALUE PAIR kullanırız.
      Cache["ProductsData"] = ds
      */
    public partial class WebForm1 : System.Web.UI.Page
    {   
        protected void btnGetProducts_Click(object sender, EventArgs e)
        {
            DateTime dtEndDateTime;
            DateTime dtStartDateTime = DateTime.Now;
            System.Text.StringBuilder sbMessage = new System.Text.StringBuilder();
            if (Cache["ProductsData"] != null)
            {
                DataSet ds = (DataSet)Cache["ProductsData"];
                gvProducts.DataSource = ds;
                gvProducts.DataBind();
                sbMessage.Append(ds.Tables[0].Rows.Count.ToString() + " rows retrieved from cache.");
            }
            else
            {
                DataSet ds = GetProductsData();
                Cache["ProductsData"] = ds;
                gvProducts.DataSource = ds;
                gvProducts.DataBind();
                sbMessage.Append(ds.Tables[0].Rows.Count.ToString() + " rows retrieved from database.");
            }
            dtEndDateTime = DateTime.Now;
            sbMessage.Append((dtEndDateTime - dtStartDateTime).Seconds.ToString() + " Seconds Load Time");
            lblMessage.Text = sbMessage.ToString();
        }

        private DataSet GetProductsData()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("spGetProducts", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataSet dsProducts = new DataSet();
            da.Fill(dsProducts);

            return dsProducts;
        }
    }
}