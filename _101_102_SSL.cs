using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace _101_102_SSL
{//100,101,103 adındaki dosyalarda yazılar var.
    /*HTTP'den HTTPS'e kullanıcıları yeniden yöndendirme
      Otomatik olarak yeniden yönlenidrmek için Birkaç yok var. Bu videoada biz url Rewrite kullanmak hakkında tartışacağız. 3 temel adımı var.
      Step 1: http://www.iis.net/downloads/microsoft/url-rewrite >> indir
      Step 2: IIS'de SSL ayarlarından uygulama için Require SSL'in işaretini kaldır      
      Step 3: Uygulamanın temelindeki WEB.CONFIG dosyasında aşağıdaki kodları kopyala yapıştir.

      Şimdi  HTTP kullanarak uygulamaya gitmeye çalış. Sen otomatik olarak HTTPS'e yönlendirileceksin 
      Bu rules URL Rewirte kullanarak IIS'den direck olarak ta oluşturulabilir
      Bizim sıradaki videmuzda IIS Error sayfaları kullanmak hakkında tartışacağız.

    */
    public partial class Login : System.Web.UI.Page
    {
         protected void btnLogin_Click(object sender, EventArgs e)
        {
            AuthenticateUser(txtUserName.Text, txtPassword.Text);
        }
        private void AuthenticateUser(string username, string password)
        {
            string CS = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
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
                        lblMessage.Text = "Invalid user name and/or password. " +
                            AttemptsLeft.ToString() + "attempt(s) left";
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