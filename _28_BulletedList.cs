using System.Web.UI.WebControls;

namespace _28_BulletedList
{
    /*Bulleted List
     
     BulletStyle: var sayılan olarak ayar yoktur. Numbered şçildiği zaman VIEW SOURCEDE ORDERED LIST ile görünür.
     FistBulletNumber: Liste NUMBERED olarak şeçilmişse, başlangıç numarasını belirlemek için kullanabiliriz.
     BULLETIMAGEURL: ile yerim gösterebiliriz.
     DISPLAYMODE: yanızın görünüm modunu belirleyebiliriz. Varsayılan text fakat HYPERLINK ve LINK BUTTON'da var.
     
     
     
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void BulletedList2_Click(object sender, BulletedListEventArgs e)
        {
            ListItem li = BulletedList2.Items[e.Index];
            Response.Write("Text = " + li.Text + "<br/>");
            Response.Write("Value = " + li.Value + "<br/>");
            Response.Write("Index = " + e.Index.ToString());

        }
    }
}