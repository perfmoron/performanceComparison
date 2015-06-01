using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strcon = "Data Source=Win2012-2;Initial Catalog=CompareTest;Integrated Security=True";
        SqlConnection con = new SqlConnection(strcon);

        SqlCommand com = new SqlCommand("CheckUser", con);
        com.CommandType = CommandType.StoredProcedure;
        SqlParameter p1 = new SqlParameter("email", username.Text);
        SqlParameter p2 = new SqlParameter("passwords", password.Text);
        com.Parameters.Add(p1);
        com.Parameters.Add(p2);
        try
        {
            con.Open();
            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                Response.Redirect("dashboard.aspx");
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Login');", true);
                //Labelinfo.Text = "Login successful.";
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('NOT Login');", true);

            }
        }
        finally
        {
            con.Close();
        }
    }
}