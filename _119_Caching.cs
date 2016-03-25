using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace _119_Caching
{
    /*CACHING
      CACHING bir uygulamanın performan ve ölçeklenebilirliğini geliştirir.
      CACHING sısklıkla kullanılan verilerin veya sayfaların SERVRE hafızasında depolanma tekniğinidr
        
      Veri tabanında bir tablo ve STORED PROCEDURE oluşturduk.
	  Bu STORED PROCEDURE'de WAITFORDELAY ile 5 sn uygulamada büyük bir tablo varmış gibi göstermek için uyuttuk. ve Select Sorugu çalıtırdık. 

     Uygulamayı çalıştırırsak, isteğimizin sonucunu almak için 5 sn beklemek zorundayız. 
	 Çünkü SERVER'in STORED PROCEDURE'ı çalıştırmak, yeni nesneleri oluşturmak, HTML oluşturmak gibi yapması gereken işleri var.	  
     
     @OutputCache sayfa yönergesini ile tüm FORM'u önbelleğe alalım.
     Bu yönergeyi kullanabilmek için 2 özelliğini kullanmak zorundayız.
     Duration: WebFom önbelleğe alındığı saniyeler için zaman belirtir.
     VaryByParam: Bir webformun birden fazla sonucunu ön belleğe alır. 
            Şimdilik değeri non a ayarla. Sonraki videolarda VaryByParam hakkında tartışacağız.
    
	Kullanıcı bir istekte bulunduğunda, SERVER yapması gereken işleri yapacak ve WEBFORM'u önbelleğe alacak. 
    Belirttiğimiz süre içerisinde kullanıcı tekrar aynı FORM için istekte bulunursa, ozaman cevabı CACHE'den alacak.
    Süre dolduktan osnra istek yapılırsa SERVER normal bir şekilde çalışacak.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("spGetProducts", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet DS = new DataSet();
            da.Fill(DS);
            GridView1.DataSource = DS;
            GridView1.DataBind();

            Label1.Text = DateTime.Now.ToString();
        }

    }
}