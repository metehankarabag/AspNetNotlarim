using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _125_CachingMultipleVersionsUsingVaryByParam
{
    /*VARYBYPARAM ile USER CONTROL'ün bir den fazla sonucunu CACHE'leme
     	http://localhost:3304/WebForm1.aspx?ProductName=All <%--bunu kullan--%>
	 
      Ne zaman VaryByControl üzerine VaryByParam veya tam tersini kullanmalıyız?
      OR
      VaryByControl ve VaryByParam arasındaki fark nedir?
     
      QUERY STRING veya paramatreli bir POST isteğine dayalı olarak USER CONTROL'ün çoklu cevabını önbelleğe almak için VaryByParam kullan. 
      Aksi taktirde, bir kontrol değerinde dayalı kullanıcı kontrolünün çoklu cevaplarını önbelleğe almak istiyorsan o zaman VaryByControl kullan.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToString();
        }
    }
}