using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Card : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["baglantim"].ConnectionString;
    SqlConnection baglanti = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Drop();
        }


    }

    protected void Drop()
    {
        try
        {
            baglanti.Open();
            string sorgu = "SELECT (Name + ' ' + Surname) FullName , Number FROM StudentInfo";

            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            DropDownList1.DataSource = cmd.ExecuteReader();

            DropDownList1.DataTextField = "FullName";
            DropDownList1.DataValueField = "Number";
            DropDownList1.DataBind();

        }
        catch (Exception hata)
        {
            //ltlmes.Text = "diikat" + hata;
        }
        finally
        {
            baglanti.Close();
        }
    }

    protected void getInfo()
    {
        try
        {
            baglanti.Open();
            string sorgu = "SELECT *FROM StudentInfo INNER JOIN Dep ON StudentInfo.DepID = Dep.DepIdNo WHERE Number = '" + DropDownList1.SelectedItem.Value + "'";
            //ltlname.Text = DropDownList1.SelectedItem.Value;
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            SqlDataReader cikti = cmd.ExecuteReader();

            if (cikti.Read())
            {
                txtname.Text = cikti["Name"].ToString(); 
                txtsurname.Text = cikti["Surname"].ToString();
                txtnumber.Text = cikti["Number"].ToString();
                txtdep.Text = cikti["DepName"].ToString();
                image.ImageUrl = cikti["ImagePath"].ToString();
            }
            else
            {
                // ltlmes.Text = "Kayıt Bulunamadı!";
            }
        }
        catch (Exception hata)
        {
            //ltlmes.Text = "diikat" + hata;
        }
        finally
        {
            baglanti.Close();
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        getInfo();

    }


    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}