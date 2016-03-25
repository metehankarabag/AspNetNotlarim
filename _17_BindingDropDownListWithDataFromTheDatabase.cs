using System;
using System.Configuration;
using System.Data.SqlClient;

namespace _17_BindingDropDownListWithDataFromTheDatabase
{
    /*Bind DropDownList with Data From The Database
     
     WEB.CONFIG dosyasında bağlantı string'i tanımlandı bu bağlantı cümlesini yazdıktan sonra
     
     ConfigurationManager.ConnectionStrings'i kullanıp WEB.CONFIG'deki bağlantı cümlemizin adını değer olarak veriyoruz.
     
     SqlConnection sınıfının bir örneğini oluşturuyoruz. Oluştururken parametre olarak CONNECTIONSTRING istiyor. Bunu veriyoruz.
     
     SqlCommand sınıfının bir örneğini oluşturuyoruz. Oluştururken 2 parametre istiyor 1. komutun hangi işi yapacağı 2. hangi bağlantıyı kullanacağı bunları belirledikten sonra veri tabanını açıyoruz.
     
     Veri tabanının açtıktan sonra komutu çalıştıracağız. Komutu çalıştırmak için kullandığımız methodu komutun vereceği değere görebelirliyoruz.
     
     Komut çalıştırıdıktan sonra veri tabanındaki değerleri alıyor bu değerleri kullanacağımız kontrolün kaynağı olarak belirliyoruz
     
     DataTextField DataValueField: özllikleri ile kaynaktan gleecek sütun adlarını belirliyoruz.
     */

    //NOT: Bağlantıyı using blogu kurarak çalıştırırsan bağlantı iş bittiğinde otomatik olarak kapanır.
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (!IsPostBack)
                {
                    SqlCommand cmd = new SqlCommand("Select ID, CityName,Country from tblCity", con);
                    con.Open();
                    DropDownList1.DataSource = cmd.ExecuteReader();
                    DropDownList1.DataTextField = "CityName";
                    DropDownList1.DataValueField = "ID";
                    DropDownList1.DataBind();
                }
            }
        }
    }
}