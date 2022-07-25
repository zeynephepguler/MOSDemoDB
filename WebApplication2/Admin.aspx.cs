using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grid();
            }
        }
        void grid()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ZEYNEP\TEW_SQLEXPRESS;Initial Catalog=MOSDemoDB;Integrated Security=True");
            conn.Open();
            SqlCommand tablo = new SqlCommand("Select * From TBLUSERS", conn);
            SqlDataAdapter da = new SqlDataAdapter(tablo);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            conn.Close();
        }
            SqlConnection conn = new SqlConnection(@"Data Source=ZEYNEP\TEW_SQLEXPRESS;Initial Catalog=MOSDemoDB;Integrated Security=True");
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "Insert into TBLUSERS (USERNAME,PASSWORD,USERTYPE,RECDATE) values('" + TextBox2.Text + "', '" + int.Parse(TextBox3.Text) + "', '" + DropDownList1.SelectedValue + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                SqlCommand kayit = new SqlCommand(sql, conn);

                kayit.ExecuteNonQuery();
                
                Response.Redirect("Admin.aspx");
                
              
                
            }
            catch { }

            
            string sql1 = "Insert into TBLAUTH (RECDATE) values('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            SqlCommand kayit1 = new SqlCommand(sql1, conn);

            kayit1.ExecuteNonQuery();

            Response.Redirect("Admin.aspx");
            conn.Close();

        }

        
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "UPDATE  TBLUSERS set USERNAME = '" + TextBox2.Text + "', PASSWORD = '" + int.Parse(TextBox3.Text) + "', USERTYPE = '" + DropDownList1.SelectedValue + "', RECDATE = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where ID= '" + int.Parse(TextBox1.Text) + "'";
                SqlCommand kayit = new SqlCommand(sql, conn);

                kayit.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("Admin.aspx");
            }catch { }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try { 
            conn.Open();
            string sql = "DELETE  TBLUSERS where ID= '" + int.Parse(TextBox1.Text) + "'";
            SqlCommand kayit = new SqlCommand(sql, conn);

            kayit.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Admin.aspx");
            }catch {}
        }
    }
}