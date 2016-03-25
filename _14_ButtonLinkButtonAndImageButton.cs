using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _14_ButtonLinkButtonAndImageButton
{
    /*image butona propertiden alert('You are about to submit this page ') yazdık java script kodu kodlarda büyük küçük harf duyarlılığı var bu kod sadece ok penceresi açıyor*/
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("Submit Button has been clicked");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Write("Link Button has been clicked");
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("Image Button has been clicked");
        }
    }
}
