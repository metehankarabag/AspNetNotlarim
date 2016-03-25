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

namespace _95_PasswordResetLink
{
    /*PASSWORD RESET LİNK
      Kullanıcı girişi olmayan kullanıcılar REGISTRATION klasöürne girebildiği için RESETPASSWORD.ASPX ekle
      Step 2: RESETPASSWORD.ASPX sayfasında aşağıdaki HMTL'i kopyala ve yapıştır.
      Step 3:SQL'de tblResetPasswordRequests tablosu oluştur.
        Şifre yenileme olduğun zaman, bu tablo kullanıcı adı birlikte sürekli farklı bir belirleyiciyi GUID(Globally Unique Identifier)'i tutacak.
        GUID reset sayfasının link'ine eklenerek kullanıcı mail'ine gönderilecek.
        Kullanıcı link'e tıkladığında, link'den bu değeri alacağız ve tblResetPasswordRequests tablosunlaki ile karşılaştıracağız.
        Kullanıcı adının link'de olmasına gerek yok.
      Step 4:Kullanıcı adının olup olmadığını kontrol etmek için STORED PROCEDURE oluştur ve 
      Step 5:Kullanıcı adı karşısında kaydedilen email adresine  STORED PROCEDURE ve mail linkini çağar. Aşağıdaki kodları RESETPASSWORD.ASPX.CS sayfasına yapıştır.
     
     */
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            AuthenticateUser(txtUserName.Text, txtPassword.Text);
        }
        private void AuthenticateUser(string username, string password)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                string encryptedpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

                SqlParameter paramUsername = new SqlParameter("@UserName", username);
                SqlParameter paramPassword = new SqlParameter("@Password", encryptedpassword);

                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int RetryAttempts = Convert.ToInt32(rdr["RetryAttempts"]);
                    if (Convert.ToBoolean(rdr["AccountLocked"]))
                    {
                        lblMessage.Text = "Account locked. Please contact administrator";
                    }
                    else if (RetryAttempts > 0)
                    {
                        int AttemptsLeft = (4 - RetryAttempts);
                        lblMessage.Text = "Invalid user name and/or password. " + AttemptsLeft.ToString() + "attempt(s) left";
                    }
                    else if (Convert.ToBoolean(rdr["Authenticated"]))
                    {
                        FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkBoxRememberMe.Checked);
                    }
                }
            }
        }
    }
}