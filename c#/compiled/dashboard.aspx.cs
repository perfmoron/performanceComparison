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

        SqlCommand com = new SqlCommand("Search", con);
        com.CommandType = CommandType.StoredProcedure;
        SqlParameter p1 = new SqlParameter("query", query.Text);
        com.Parameters.Add(p1);
        try
        {
            con.Open();
            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                var myString = rd.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                // Do somthing with this rows string, for example to put them in to a list
                //listDeclaredElsewhere.Add(myString);
                Response.Write(myString);
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