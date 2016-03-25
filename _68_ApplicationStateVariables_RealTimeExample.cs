using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _68_ApplicationStateVariables_RealTimeExample
{
    /*EXAMPLE
      APPLICATIONSTATE VARIABLES'i evrenseldir ve tüm SESSIONS onlarla bağlantı kurabilir. 
      Değişkenler online kullanıcıların sayısını izlemek için kullanılabilir. 
      kullanıcılar uygulamana bağlandığında, birer birer kullanıcının sayısını arttırmak istiyoruz. 
      Kullanıcı oturumu sonlandığı zaman online kullanıcı sayısını birer birer düşürmemiz gerekir. 
      Bir kullanıcı uygulamamıza bağlandığında, 
      her zaman yeni bir oturumun kurulduğu Session_Start() olayı çalıştırılır. 
      Oturum sonlandığında Session_End() olayı çalıştırışır. 
      
      Varsayılan olarak tarayıcı örnekleri SESSION COOKIE paylaşır. 
      Yeni bir BROWSER WEBFORM'a istek gönderdiğinde atanmış yeni bir SESSION - ID almak için, 
      WEB.CONFIG'de SESSIONSSTATE elemet'i için COOKIELESS'i TRUE olarak ayarla
      Number of Users Online = 1
      
      Yeni bir tarayıcı penceresi aç, diğer pencereden Url yi kopyala ve yapıştır. 
      Oturum id sini sildiğine emin ol, böylece web sunucu yeni bir oturum id si anahtar 2. istek için 
      Bu noktada, Online kullanıcı sayısı 2 ye arttırılmalı.      
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["UsersOnline"] != null)
            {
                Response.Write("Number of Users Online = " + Application["UsersOnline"].ToString());
            }
        }

    }
}