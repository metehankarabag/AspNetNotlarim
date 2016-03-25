using System;
using System.Configuration; /*Obviously we want to read sql connection string from System.Config file*/
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace _22_CascadingDropDownList
{
    /*Cascading DropDownList
     
     
     
    */

    /*Veri tabanına bağlanma ile ilgili notlar
     
     DataSet verilerin olduğu bir tablo gibidir. SQL den gelen değerler DATASET olarak alınır ve kontrolün veri kaynağı olarak belirlenir.
     Veri tabanında bağlanma ve verileri alma işini bir method içinde yapacaksak method her zaman DATASET dönmelidir.
    
     Method ile SQL'e parametre dönereceksek, method parametre olarak SqlParameter nesnesi de istemeli.
     Bu parametre ile veri tabanına gitmeden önce IF kontrolu kullanmalıyız. Çünkü parametre yerine NULL değeride gönderilebilir.
     Sp nesnesi ile gidecek değer object olarak gider bu değeri çevirip öyle gönderebiliriz.
     
     
     Bağlantı nesnesini oluşturduktan sonra veri tabanında işlem yapabilmek için SQLCOMMAND veya SQLDATAADAPTER kullanılabilir.
     
     Burda SQLDATAADAPTER kullanılımış yine 2 parametre istiyor 1. parametre sorgu 2. parametre kullanılacak bağlantıyı belirliyor.
     
     Biz birinci parametre olarak STORED PROCEDURE verdik sorgumuz bunun içinde bu yüzden SQLDATAADAPTER'in SQL'de STORED PROCEDURE ile çalışacağını belirtmeliyiz.
     da.SelectCommand.CommandType = CommandType.StoredProcedure;
    
    */


    public partial class WebForm1 : System.Web.UI.Page
    {
        private DataSet GetData(string SPName, SqlParameter SPParameter)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter(SPName, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (SPParameter != null)
            {
                da.SelectCommand.Parameters.Add(SPParameter);
            }
            DataSet DS = new DataSet();
            da.Fill(DS);
            return DS;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               DropDownList1.DataSource = GetData("spGetContinents",null);
               DropDownList1.DataBind();
                /*verileri alabilmek için datatextfield ve valuefield ekleyecek html den*/
               ListItem liContinent = new ListItem("Select Continent","-1");
               DropDownList1.Items.Insert(0,liContinent);

               ListItem liCountry = new ListItem("Select Country", "-1");
               DropDownList2.Items.Insert(0, liCountry);

               ListItem liCity = new ListItem("Select City", "-1");
               DropDownList3.Items.Insert(0, liCity);

               DropDownList2.Enabled = false;
               DropDownList3.Enabled = false;
            }
        }
        
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                DropDownList2.SelectedIndex = 0;
                DropDownList2.Enabled = false;

                DropDownList3.SelectedIndex = 0;
                DropDownList3.Enabled = false;
            }
            else
            {
                DropDownList2.Enabled = true;
                SqlParameter parameter = new SqlParameter("@ContinentID",DropDownList1.SelectedValue);
                DataSet DS = GetData("spGetCountriesByContinentsID",parameter);
                DropDownList2.DataSource = DS;
                DropDownList2.DataBind();

                ListItem liCountry = new ListItem("Select Country", "-1");
                DropDownList2.Items.Insert(0, liCountry);

                DropDownList3.SelectedIndex = 0;
                DropDownList3.Enabled = false;
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedIndex == 0)
            {
                DropDownList3.SelectedIndex = 0;
                DropDownList3.Enabled = false;
            }
            else
            {
                DropDownList3.Enabled = true;
                SqlParameter parameter = new SqlParameter("@CountryID", DropDownList2.SelectedValue);
                DataSet DS = GetData("spGetCitiesByCountryID", parameter);
                DropDownList3.DataSource = DS;
                DropDownList3.DataBind();

                ListItem liCity = new ListItem("Select City", "-1");
                DropDownList3.Items.Insert(0, liCity);
            }
        }
    }
}