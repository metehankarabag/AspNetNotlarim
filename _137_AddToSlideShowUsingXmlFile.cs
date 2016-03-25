using System;

namespace _137_AddToSlideShowUsingXmlFile
{ 
    //Bu derste Resimlerin yollarını XML dosyasından çekerek Resimlere ulaşmışız.
    /*
      XML dosyasındaki Resim isimlerini bir DATA SET'e aldık.
      XML, DATA SET'i nasıl oluşturdu. Ayarlar otomaik yapıldı. XML'den veri çemke ile ilgili bir ders görmüştü ama şimdi nasıl olduğunu hatırlamadım.
      XML'in ROOT elementinin adı                          DATA SET'in DataSetName PROPERTY'sini belirledi.
      ROOT nesnesinin altındaki elementlerın adları<image> DATA SET'in Tables PROPERTY'sini belirledi.(INDEX de olabilir.)
      <image> elementinin PROPERTY'leri                    DATA SET'in COLUMNS ARRAY'ına eklenir.
      
      
     */
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}
