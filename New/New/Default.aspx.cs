using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
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

    //İlk çıkan sayfadaki bölüm dropdownlisti için bağlama kısmı
    protected void Drop()
    {
        try
        {
            baglanti.Open();
            string sorgu = "SELECT DepIdNo , DepName FROM Dep";

            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            DropDownList1.DataSource = cmd.ExecuteReader();

            DropDownList1.DataTextField = "DepName";
            DropDownList1.DataValueField = "DepIdNo";
            DropDownList1.DataBind();
        }
        catch {   /*ltlmes.Text = "diikatdd";*/  }
        finally {  baglanti.Close();  }
    }

    //Girilen bilgilerin alındığı kısım
    protected void InsertInfo()
    {
        string ad = txtname.Text;
        string soyisim = txtsurname.Text;
        string id = txtid.Text;
        string bolum = DropDownList1.SelectedValue;
        string imgfile = Path.GetFileName(FileImageSave.PostedFile.FileName);
        

        try
        {

            string query = "INSERT INTO StudentInfo (Name,Surname,Number,DepID,ImagePath) VALUES (@Name,@Surname,@Number,@DepID,@ImagePath)";
            using (SqlCommand cmd = new SqlCommand(query, baglanti))
            {
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = ad;
                cmd.Parameters.Add("@Surname", SqlDbType.NVarChar, 50).Value = soyisim;
                cmd.Parameters.Add("@Number", SqlDbType.Char, 11).Value = id;
                cmd.Parameters.Add("@DepID", SqlDbType.Int).Value = bolum;
                cmd.Parameters.Add("@ImagePath", SqlDbType.NVarChar, 500).Value = "Images/" + imgfile;

                if (fileCheck() == 1 && DropDownList1.SelectedValue != "0")
                {
                    baglanti.Open();
                    cmd.ExecuteNonQuery();

                    lblerror.Text = "Kaydınız başarıyla alındı.";
                }
                else if (fileCheck() == 2)
                {
                    lblerror.Text = "Dosya boyutu maximum 4MB olmalıdır.";
                }
                else if (fileCheck() == 3)
                {
                    lblerror.Text = "Sadece jpeg / jpg / png uzantılı dosyalar yüklenebilir.";
                }
                else if (fileCheck() == 4)
                {
                    lblerror.Text = "Lütfen dosya seçiniz.";
                }
                else
                    lblerror.Text = "Lütfen bölümünüzü seçiniz.";
            }
        }
        catch (Exception hata)
        {
            lblerror.Text = "Bağlantıda hata oluştu veri kaydedilemedi." + hata;
        }
        finally
        {
            baglanti.Close();
        }  
    }

    protected void btncard_Click(object sender, EventArgs e)
    {
        Response.Redirect("Card.aspx");
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        InsertInfo();
    }

    protected int fileCheck()
    {
        if (FileImageSave.HasFile)
        {
            if (FileImageSave.PostedFile.ContentType == "image/jpeg" || FileImageSave.PostedFile.ContentType == "image/jpg" || FileImageSave.PostedFile.ContentType == "image/png")
            {
                if (FileImageSave.PostedFile.ContentLength < 4096000)
                {
                    FileImageSave.SaveAs(Server.MapPath("~/Images/") + Path.GetFileName(FileImageSave.PostedFile.FileName));
                    return 1;
                }
                else return 2;
            }
            else return 3;
        }
        else return 4;
    }
}