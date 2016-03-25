using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _140_CreatingAnImageGallery
{
    /*Galier oluşturmak 
      ilk önce dosyaları bulmamız gerekiyor.
      Directory.GetFiles()'a dosyaları içinde olduğu klasörü veriyoruz.
      Bu klasör içindeki tüm dosya yollarını buluyor.
      FileInfo nesnesi ile dosya adlarını alıyoruz.
      Gerekli ayarları yapıtıktan sonra resmi gösteriyoruz.
       
      Image Button tıklandığında sender örneğinden aldığımız Controlü Cast'layıp ImageUrl değerini QUERYSTRING ile WebForm2'ye gönderiyoruz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { LoadImages(); }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile) { string fileName = FileUpload1.FileName; FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + fileName); }
            Response.Redirect("~/WebForm1.aspx");
        }

        private void LoadImages()
        {
            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Data")))
            {
                ImageButton imageButton = new ImageButton();
                FileInfo fi = new FileInfo(strfile);
                imageButton.ImageUrl = "~/Data/" + fi.Name;
                imageButton.Height = Unit.Pixel(100);
                imageButton.Style.Add("padding", "5px");
                imageButton.Width = Unit.Pixel(100);
                imageButton.Click += new ImageClickEventHandler(imageButton_Click);
                Panel1.Controls.Add(imageButton);
            }
        }

        protected void imageButton_Click(object sender, ImageClickEventArgs e)
        { Response.Redirect("WebForm2.aspx?ImageURL=" + ((ImageButton)sender).ImageUrl); }
    }
}