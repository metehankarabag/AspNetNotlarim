using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Part30_FileuploadControlIn_Asp.Net
{
    /*FILE UPLOAD CONTROL
     FILE UPLOAD CONTROL'u sadece yüklenmek istedikleri dosyayı seçmek için kullanırlar.
     
     HASFILE: Özelliği Boolean değer döner. Kullanıldığı kontrolün bir dosyası varsa TRUE yoksa FALSE
     
     GetExtension():System.IO NAMESPACE'sindeki Path sınıfana ait olan bu metoh parametre olarak dosaya adı ister ve dosya adının uzantısını döner.
     
     PostedFile: Özelliği yüklenen dosya ile ilgili işlemler yapmak için kullanılır. PostedFile.ContentLength = doyanın boyutunu veririr.
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
                if (fileExtension.ToLower() != ".doc" && fileExtension.ToLower() != ".docx")
                {
                    lblMessage.Text = "Only file with .doc or .docx extencion are allowed";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    int filesize = FileUpload1.PostedFile.ContentLength;
                    if (filesize > 2097152)
                    {
                        lblMessage.Text = "Miximum file size (2 mb) exceeded";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                        lblMessage.Text = "File uploaded";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
            else
            {
                lblMessage.Text = "Please select a file to upload";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }           
        }
    }
}