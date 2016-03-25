using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace _92_UsersInDatabaseTable
{
    /*     
     90. bölümde biz WEB.CONFIG dosyasında alınmış bir liste karşısında kullanıcı AUTHENTICATING hakkında tartışmıştık.
     91. bölümde kullanıcıları giriş için kullanıcı adı ve şifreleri yoksa kaydetme hakkında tartıştık.
     
     Bu otrumuda biz database tablosundan alınmış bir liste karşısında kullanıcların AUTHENTICATING hakkında tartışacağız
     
     Bu bölüm 91'e devamdır.
     WEB.CONFIG'den alınmış bir liste karşısında kullanıcıları AUTHENTICATING'i çok kolaydır.
     FORMS AUTHENTICATION sınıfı kullanıcıların AUTHENTICATING'i tüm zor işlerini yapan AUTHENTICATE() static methodu ortaya çıkarır.

     Bir data tablosunda alınan bir listeye karşısında kullanıcıları AUTHENTICATE'lemeyi istiyorsak, uygulamadaki kullanıcıları AUTHENTICATE'lemek için STORED PROCEDURE ve bir method yazmak zorunda olacazğız.

     Bir giriş olarak kullanıcı adı ve şifre kabuldend STORED PROCEDURE oluşturalım.

     Aşağıda private method LOGIN.ASPX.CS sayfasındaki yapıştır. 
     Bu method depolanmış işlem SPAUTHENTICATEUSER'ı çağarır.

	 AuthenticateUser() methodu çağarır login butonundaki tıklama olay
     */
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (AuthenticateUser(txtUserName.Text, txtPassword.Text))
               FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkBoxRememberMe.Checked);
            else 
               lblMessage.Text = "Invalid UserName and/or password";
            
        }
        private bool AuthenticateUser(string username, string password)
        {
            string CS = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
         
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // FormsAuthentication is in System.Web.Security
                string EncryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                // SqlParameter is in System.Data namespace
                SqlParameter paramUsername = new SqlParameter("@UserName", username);
                SqlParameter paramPassword = new SqlParameter("@Password", EncryptedPassword);

                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);

                con.Open();
                int ReturnCode = (int)cmd.ExecuteScalar();
                return ReturnCode == 1;
            }
        }
    }
}