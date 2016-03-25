using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace _151_AssigningMasterPageDynamically
{
    /*DYNAMIC MASTER PAGE belirleme
      Ana soru bir MASTER'daki CONTROL'ü veya değerini, diğer MASTER'lar arasında nasıl dolaştıracağımızdır.
       Bunun yapmak için bir ABSTRACT CLASS oluşturacağız.
       Bu CLASS'da bir CONTROL dönen ONLY GET ABSTRACT PROPERTY açıklamaları var.
       Artık bu CLASS'dan türetilen MASTER'lar PROPERTY'leri kullanmak ve bir CONTROL vermek zorunda
       Sonrası 149. derse ile aynı tek fark MASTERTYPE olarak BASEMASTER'ı veriyoruz.
       Çünkü MASTER CONTROL'lerini CONTENT PAGE'e çekmeliyiz ama hangi MASTER'in CONTROL'ünü çekeceğiz? 
       ABSRACT CLASS'daki PROPERTY açıklamasını kullanarak, kullanımdaki MASTER'ın CONTROL'lerini CONTENT PAGE'e alabiliriz.
       (BASE PAGE'da kod kullanarak MASTERTYPE belirledim. Kodda Master'da belirleyebiliriz. Page yönergesinde kullanmamıza gerek yok ama uyarı alıyoz)
     
      2.Soru MASTER PAGE hangi olayda belirlenir?
        MASTER PAGE, CONTENT PAGE'lerin INIT EVENT'larında birleşir.
        Yani MASTER PAGE, CONTENT PAGE'lerin INIT EVENT'larında önce belirlitir, INIT EVENT'ında kullanılır ve
        INIT EVENT'lardan önce PREINIT EVENT'ları çalışır
        
            Alt soru her CONTENT PAGE'in INIT EVENT'ında ayrı ayrı ayar yapmak zorundaymıyız?
            Hayır, Her CONTENT PAGE'i türetecek BASE PAGE CLASS'ı oluşturur ve 
            bu CLASS'da ONPREINIT() methodunun üzerine yazarsak, sorun çözülür.
      
      Kullanıcı Master Page'i PREINIT olayından sonra gelirleyeceği için belirledikten sonra sayfayı yenilememiz gerekir.
      Fakat biz kullanıcı hangi sayfada? Biz onu hangi sayafa yönlendireceğiz?
      Kullanıcı MASTER'ı belirledikten hemen sonra 
      Response.Redirect(Request.Url.AbsoluteUri) --> AbsoluteUri: Geçerli URL'i alıyor. Redirect ile yönlendiriyoruz.    
    */
    public partial class WebForm1 : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Master.SearchButton.Click += new EventHandler(SearchButton_Click);
        }

        protected void Page_Load(object sender, EventArgs e) { if (!IsPostBack) { GetData(null); } }
        protected void SearchButton_Click(object sender, EventArgs e) { GetData(Master.SearchTerm); }

        private void GetData(string searchTerm)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter searchParameter = new SqlParameter("@SearchTerm", searchTerm ?? string.Empty);
                cmd.Parameters.Add(searchParameter);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }
    }
}