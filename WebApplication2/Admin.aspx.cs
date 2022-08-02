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
        public string veri;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            DropDownList1.Visible = false;
            DropDownList2.Visible = false;
            Button5.Visible = false;
            if (!IsPostBack)
            {
                
                grid();
            }
           
        }
        void grid()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ZEYNEP\TEW_SQLEXPRESS;Initial Catalog=MOSDemoDB;Integrated Security=True");
            conn.Open();
            SqlCommand tablo = new SqlCommand("SELECT  TBLUSERS.ID,TBLUSERS.USERNAME,PASSWORD,TBLUSERS.USERTYPE,TBLUSERS.RECDATE,STUFF((SELECT '-' + FONKSIYON as [text()] FROM TBLAUTH where TBLUSERS.ID = TBLAUTH.USERID FOR XML PATH('')), 1, 1, '') AS Result FROM TBLUSERS LEFT JOIN TBLAUTH ON TBLUSERS.ID = TBLAUTH.USERID ", conn);
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

            
            //string sql1 = "Insert into TBLAUTH (RECDATE) values('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            //SqlCommand kayit1 = new SqlCommand(sql1, conn);

            //kayit1.ExecuteNonQuery();

            //Response.Redirect("Admin.aspx");
            //conn.Close();

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
                
            }catch { }
            if (DropDownList2.Text.Equals("YETKİSİZ"))
            {
                try
                {
                    conn.Open();
                string sql = "DELETE  TBLAUTH where USERID= '" +TextBox1.Text + "'";
                SqlCommand kayit = new SqlCommand(sql, conn);

                kayit.ExecuteNonQuery();
                conn.Close();
                   

                }
                catch { }
            }
            else
            {
                 conn.Open();
                    string sql2 = "Insert into TBLAUTH (USERID,FONKSIYON,RECDATE) values('" + TextBox1.Text + "', '" + DropDownList2.SelectedValue + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    SqlCommand kayit2 = new SqlCommand(sql2, conn);

                    kayit2.ExecuteNonQuery();
                    conn.Close();
            }
            Response.Redirect("Admin.aspx");
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            DropDownList1.Visible = true;
            DropDownList2.Visible = true;
            Button5.Visible = true;
            int secili;
            secili = GridView1.SelectedIndex;
            GridViewRow row = GridView1.Rows[secili];
            TextBox1.Text = row.Cells[1].Text;
            TextBox2.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
            
            TextBox3.Text = row.Cells[3].Text;
            DropDownList1.Text = row.Cells[4].Text;
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            TextBox1.Visible = false;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            DropDownList1.Visible = true;
            DropDownList2.Visible = true;
            Button5.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            DropDownList1.Visible = false;
            DropDownList2.Visible = false;
            Button5.Visible= false;
        }
       
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}