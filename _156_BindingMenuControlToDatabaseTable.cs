using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace _156_BindingMenuControlToDatabaseTable
{
    /*MENU CONTROL'ü VERİTABANINDAN GELEN BİLGİLERLE DOLDURMA
     
     Relations.Add(): STORED PROCEDURE ile doldurulan DATASET'e 2 veya daha fazla tablo geliyorsa ve bu tablolar birlirleri ile ilişkili ise bu methodu kullanıyoruz.
     STORED PROCEDURE'de tabloların çalışma sırasına göre Tables[] INDEX'ini kullanarak tabloları buluyoruz..
     Bu methodun yaptığı iş birinci tabloda bir sütundaki değerler ile 2. tabloda bir sütundaki değerleri eşleştirip eşleşen 2. tablodaki satırı almaktır.
     Yani 2. tablodaki satırlar birinci tablodakilerin Child i oldu.
     
     STORED PROCEDURE'da JOIN ile de yapabilirdik. Galiba
     
     Şimdi Menu nesnelerini MENU CONTROL'e ekleyebiliriz. Nesne sayısı birden fazla olabileceği için FOREACH kullanıyoruz.
     Biz yukarıda birinci tablodaki bir değere göre  2. tablodan bir satırı belirttik.
     FOREACH ile birinci tablo nesnelerini ekliyoruz.
     2. düzey nesneleri eklemek için Relations.Add() metohundan aldığımız satırları GetChildRows methoduna parametre olarak eklıyoruz.
     
     */
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetMenuItems();
        }

        private void GetMenuItems()
        {
            string cs = string.Empty;
            try
            {
                cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            }
            catch (Exception)
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("spGetMenuData", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);

            ds.Relations.Add("ChildRows", ds.Tables[0].Columns["ID"], ds.Tables[1].Columns["ParentId"]);

            foreach (DataRow level1DataRow in ds.Tables[0].Rows)
            {
                MenuItem item = new MenuItem();
                item.Text = level1DataRow["MenuText"].ToString();
                item.NavigateUrl = level1DataRow["NavigateURL"].ToString();

                DataRow[] level2DataRows = level1DataRow.GetChildRows("ChildRows");
                foreach (DataRow level2DataRow in level2DataRows)
                {
                    MenuItem childItem = new MenuItem();
                    childItem.Text = level2DataRow["MenuText"].ToString();
                    childItem.NavigateUrl = level2DataRow["NavigateURL"].ToString();
                    item.ChildItems.Add(childItem);
                }
                Menu1.Items.Add(item);
            }
        }
        private void Check(MenuItem item)
        {
            if (item.NavigateUrl.Equals(Request.AppRelativeCurrentExecutionFilePath,
                StringComparison.InvariantCultureIgnoreCase))
            {
                item.Selected = true;
            }
            else if (item.ChildItems.Count > 0)
            {
                foreach (MenuItem menuItem in item.ChildItems)
                {
                    Check(menuItem);
                }
            }
        }

        protected void Menu1_PreRender(object sender, EventArgs e)
        {
            foreach (MenuItem item in Menu1.Items)
            {
                Check(item);
            }
        }
    }
}