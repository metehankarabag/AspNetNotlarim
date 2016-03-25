using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace _123_WebformCachingBasedOnGetAndPostRequests
{
    /*GET ve POST isteklerine göre CACHING
      120. ders ile bağlantılıdır.
       
      VaryByParam değeri None iken, WEBFORM'un sadece bir CACHE nesnesi olur.
      Yazdığımız kod gereği sayfa ilk yüklendiğinde tüm ürünler görünüyor.
      DROPDOWNLIST'de seçimi değiştirdiğimizde, bunun sonuçlarını alıyoruz.
      Fakat bir kez daha değiştirdiğimizde, cevap CACHE'den geldiği için yeni sonucları alamıyoruz.
      Yani sayfa ilk yüklendiğinde, ön belleğe alınsaydı WEBFORM sonuçlarını değiştiremezdik.
      Sonuçları görürürüz.
      Soru: Neden ön belleğe alınmadı?
      Cevap: ALL seçeneği önbelleğe alındı fakat GET isteği göre alındı. Bu yüzden POST isteği ile FORM'u SERVER'e gönderdiğimizde CACHE'ye                     ulaşamıyoruz. Yeni bir GET isteği ile SERVER'e gidersek ön bellekteki ALL sonuçlarına uşalırız.
      
      Bence VaryByParam="None",GET ve POST istekleri için ayrı bir istek önbelleğe alınır.
      Bu cevapı geliştirmek için herhangi bir öneri beklerim. değerli yorumlarını bırak.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { if (!IsPostBack) GetProductByName("All"); Label1.Text = DateTime.Now.ToString(); }

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