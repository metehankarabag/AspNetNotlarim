using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _31_Adrotator
{
    /*ADROTATOR CONTROL
     Reklamlar için kullanılır.
     
     Bunun için bize bir xml dosyası lazım reklamları buraya ekleyeceğiz.
     
     IMAGEURL = gösterilecek resim
     NAVIGATEURL = Site adresi 
     ALTERNETINDEX = Resim bozulursa yazı
     KEYWORD = Yüzlerce reklam sayfası olabilir biz bir sayfada sadece birini göstermek istiyorsa bunu kullanıyoruz.
     IMPRESSION = Reklamların görünme sıklığını belirleyen sayıyı alır.
     Bur reklamın bu özellikler sahip olması gerekiyor.
      
     
     ADVERTISEMENTFILE ve KEYWORDFILTER özelliklerine gelen değerler çalışma zamanıda değiştirilebilir. 
     Bu çok kullanışlı olabilir örneğin bir MASTER PAGE'de ADROTATOR kontrolü olduğunda, her içerik sayfası için farklı bir KEYWORDFILTER kullanmak istiyorsan çalışma zamanında yaparsın.

     
     
     */

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdRotator1.KeywordFilter = "";
        }
    }
}