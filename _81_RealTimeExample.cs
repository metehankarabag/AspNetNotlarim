using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace _81_RealTimeExample
{
    /*
     ASP.NET sayfası çok yavaştır. Daha hızlı yapmak için ne yapacağız?

     Bu çok ortak bir görüşme sorusudur. 
     Yavaş olan sayalar için bir kaç neden var. Nedenler belirlememiz gerekiyor.

     Genellikle Visual studio installed'a sahip olmayacağımız için ve kodu en uygun hale getirmek için bir uygulamayı sunucuda tamir edemeyiz.

Step 1:
     Öncelikle yavaş olan, uygulamamı veri tabanımı ?
     Sayfa SQL soruguları veya depolanmış işlemler ile çalışıyorsa bu işlemleri data basede çalıştır ve 
     çalışması ne kadar zaman alıyor kontrol et. 
     Alternatif olarak sorguları ve onların aldığı zamanı denetlemek için SQL PROFILER kullanılabilir. 
     Sorgular çok zaman alıyorsa ozaman daha iyi performans için sorguları ayarlaman gerektiğini bil. 
     Sorguları ayarlamak için bir kaç yol var ve aşagıda onların başılarını listeledim.

     a) QUERY'ye yardım eden INDEX'ler var mı kontrol et.
     b) SELECT * yerine sadece gerekli sütunları kullan
     c) Kullandığın JOINS sayısını azaltmanın bir yolu varmı bak.
     d) Mümkünse SELECT sorgunda NO LOCK kullan
     e) CURSOR varsa ve JOIN'ler ile değiştirebiliyorsan değiştir.

Step 2:
     Sorgular hızlı çalışıyorsa, o zaman yavaşlığın nedeni olan uygulama kodları olduğunu biliyoruz.
     PAGE DIRECTİVE'inde TRACING i aç. 
     Tracing sayfasında hangi işlem ne kadar zaman alıyor çok rahatlıkla görürürsün

     Bir çok kez, sorun geliştirme ortamında tekrarlanabilir değildir. 
     Bu sorun sadece üretim sunucuda olur. Bu durumda TRACING sorunun temel(root) nedenini almak için pahabicilemez bir mekanizmadır.    
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Trace.Warn("GetAllEmployees() started");
            GetAllEmployees();
            Trace.Warn("GetAllEmployees() Complete");

            Trace.Warn("GetEmployeesByGender() started");
            GetEmployeesByGender();
            Trace.Warn("GetEmployeesByGender() Complete");

            Trace.Warn("GetEmployeesByDepartment() started");
            GetEmployeesByDepartment();
            Trace.Warn("GetEmployeesByDepartment() Complete");
        }

        private void GetAllEmployees()
        {
            gvAllEmployees.DataSource = ExecuteStoredProcedure("spGetEmployees");
            gvAllEmployees.DataBind();
        }

        private void GetEmployeesByGender()
        {
            gvEmployeesByGender.DataSource = ExecuteStoredProcedure("spGetEmployeesByGender");
            gvEmployeesByGender.DataBind();
        }

        private void GetEmployeesByDepartment()
        {
            gvEmployeesByDepartment.DataSource = ExecuteStoredProcedure("spGetEmployeesByDepartment");
            gvEmployeesByDepartment.DataBind();
        }

        private DataSet ExecuteStoredProcedure(string spname)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter(spname, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet DS = new DataSet();
            da.Fill(DS);
            //if (spname == "spGetEmployeesByGender")
            //{
            //    System.Threading.Thread.Sleep(7000);
            //}
            return DS;
        }
    }
}