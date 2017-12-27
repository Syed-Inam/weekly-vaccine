using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace Application
{
    public partial class page : System.Web.UI.Page
    {

         

        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        //string connstring = "Data Source=F48604;Initial Catalog=Vaccine; User ID=sa; password=123; Integrated Security=False";
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["aabb"] = "1";

            txtdss.Focus();            
            if (Session["User"] != null)
            {
                Label1.Text = Convert.ToString(Session["User"]);
            }
            else
                Response.Redirect("login.aspx");
        }

       
        protected void submitbtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            try
            {
                SqlDataAdapter adpt = new SqlDataAdapter();
                string SelectStatement = "Select * from Form where Card_No='" + txtcard.Text + "' ";
                SqlCommand cmd = new SqlCommand(SelectStatement, conn);
                adpt.SelectCommand = new SqlCommand(SelectStatement, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows == true)
                {
                    Response.Redirect("UpdateForm.aspx?ID=" + this.txtdss.Text + "&Card=" + this.txtcard.Text);
                }
                else
                {
                    Response.Redirect("Form.aspx?ID=" + this.txtdss.Text + "&Card=" + this.txtcard.Text);
                }
            }
            catch (System.Threading.ThreadAbortException) {
            }
            catch (SystemException ex)
            {
                string msg = "";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}