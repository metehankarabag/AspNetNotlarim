using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace _162_BindingTreeViewControlToDatabaseTable
{
    /*TreeView Control
     DATABASE ile MENU CONTROL öğelerini eklerken 2 tablo kullanmıştık.
     Şimdi tek tablo kullanıyoruz aşağıdaki Relations.Add() methodu self join gibi çalışıyor.
     
     böyle yaptığımız için child olması gereken öğeler hem child hemde root gibi muamele görüyor.
     Bunu düzeltmek için FOREACH içinde ROOT öğeleri aldığımız yerde İF kullanıyoruz.
     
      
     Relations da yaptığımız işlem bir eşleşme olduğu için eşleşemeyen ROOT öğeler sorun çıkartmıyor.
     
     Vari tabanında bir child öğeye child öğe eklediğimizde bunu TREVIEW'den alamıyoruz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { if (!IsPostBack)GetTreeViewItems(); }

        private void GetTreeViewItems()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("spGetTreeViewItems", con);//parametre istemediği için parametre nesnesini oluşturmuyoruz.
            DataSet ds = new DataSet();
            da.Fill(ds);

            ds.Relations.Add("ChildRows", ds.Tables[0].Columns["ID"], ds.Tables[0].Columns["ParentId"]);

            foreach (DataRow level1DataRow in ds.Tables[0].Rows)
            {
                if (string.IsNullOrEmpty(level1DataRow["ParentId"].ToString()))
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = level1DataRow["TreeViewText"].ToString();
                    treeNode.NavigateUrl = "/Aspx159" + (level1DataRow["NavigateURL"].ToString().Remove(0,1));

                    DataRow[] level2DataRows = level1DataRow.GetChildRows("ChildRows");
                    foreach (DataRow level2DataRow in level2DataRows)
                    {
                        TreeNode childTreeNode = new TreeNode();
                        childTreeNode.Text = level2DataRow["TreeViewText"].ToString();
                        childTreeNode.NavigateUrl = "/Aspx159" + (level1DataRow["NavigateURL"].ToString().Remove(0, 1));
                        treeNode.ChildNodes.Add(childTreeNode);
                    }
                    TreeView1.Nodes.Add(treeNode);
                }
            }
        }
    }
}