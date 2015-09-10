using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;

namespace falcons
{
    public partial class Falcons : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            Editor1.Content=(String)(Session["editor_content"]);
            //ClientScriptManager cs = Page.ClientScript;
            //cs.RegisterStartupScript(this.Page.GetType(), "TestKey", "set_cursor();", true);
    //        Editor1.SelectionStart
    //= Editor1.MaskedTextProvider.LastAssignedPosition + 1;
    //        Editor1.SelectionLength = 0;
            //String sessionID = HttpContext.Current.Session.SessionID;
            //String CS = ConfigurationManager.ConnectionStrings["falcon_cs"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(CS))
            //{
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandText = "SELECT Html_Content FROM Falcon_html_data where Session_ID=@session_ID";
            //    cmd.Parameters.AddWithValue("@session_ID", sessionID);
            //    cmd.Connection = con;
            //    con.Open();
            //    using (var reader = cmd.ExecuteReader())
            //    {

            //        if (reader.Read())
            //        {
            //            // AjaxControlToolkit.HTMLEditor.Editor editor_previous_content = (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("editor1");
            //            Editor1.Content = WebUtility.HtmlDecode(reader.GetString(reader.GetOrdinal("Html_Content")));
            //        }
            //    }
            //    con.Close();
            //}
            //AjaxControlToolkit.HTMLEditor.Editor editor_previous_content = (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("editor1");
          
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //Editor1.Content = HttpContext.Current.Session.SessionID;
                //(String)(Session["my_editor_content"]);
            //if(Page.IsPostBack)
            //{
            //   // Editor1.Content = (String)(Session["my_editor_content"]);
            //   // Session["editor_content"] = Editor1.Content;

            //}
           
        }

        protected void Menu1_DataBinding1(object sender, MenuEventArgs e)
        {
            if (SiteMap.CurrentNode != null)
            {
                if (e.Item.Text == SiteMap.CurrentNode.Title)
                {
                    if (e.Item.Parent != null)
                    {
                        e.Item.Parent.Selected = true;
                    }
                    else
                    {
                        e.Item.Selected = true;
                    }
                }
            }
        }

        

        //protected void Editor1_ContentChanged(object sender, EventArgs e)
        //{
        //    Session["my_editor_content"] = (String)Editor1.Content;
        //}

        //protected void btn_save_session(object sender, EventArgs e)
        //{
        //    Session["my_editor_content"] = (String)(Editor1.Content);
        //}
        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    Session["my_editor_content"] = (String)(Editor1.Content);
        //}
        protected void Home_redirect(object sender, EventArgs e)
        {
            //Session["my_editor_content"] = (String)Editor1.Content;
            Response.Redirect("Keyword_research.aspx");
            //LinkButton1.PostBackUrl=("~/Keyword_research.aspx");
        }

        protected void Content_seo_redirect(object sender, EventArgs e)
        {
           // Session["my_editor_content"] = (String)(Editor1.Content);
            Response.Redirect("Social_sharing.aspx");
            //LinkButton2.PostBackUrl = ("~/Content_seo.aspx");
        }

        protected void Social_media_redirect(object sender, EventArgs e)
        {
            // Session["my_editor_content"] = (String)(Editor1.Content);
            Response.Redirect("Image_seo.aspx");
            //LinkButton2.PostBackUrl = ("~/Content_seo.aspx");
        }

        protected void Image_seo_redirect(object sender, EventArgs e)
        {
            // Session["my_editor_content"] = (String)(Editor1.Content);
            Response.Redirect("Content_seo.aspx");
            //LinkButton2.PostBackUrl = ("~/Content_seo.aspx");
        }
        

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Session["editor_content"] = (String)(Editor1.Content);
            //string sessionID = HttpContext.Current.Session.SessionID;
            //string htmlEncoded = WebUtility.HtmlEncode(Editor1.Content);
            ////Session["my_editor_content"] = (String)(Editor1.Content);  
            //String CS = ConfigurationManager.ConnectionStrings["falcon_cs"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(CS))
            //{
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandText = "update dbo.Falcon_html_data set Html_Content=@sqlHtmlcnt where Session_ID=@sqlsessionID if @@ROWCOUNT=0 insert into dbo.Falcon_html_data values(@sqlsessionID,@sqlHtmlcnt)";
            //    cmd.Connection = con;
            //    cmd.Parameters.AddWithValue("@sqlHtmlcnt", htmlEncoded);
            //    cmd.Parameters.AddWithValue("@sqlsessionID", sessionID);
            //    con.Open();
            //    cmd.ExecuteReader();
            //    con.Close();
            //}
           // update_editor_content();
        }

        //protected void update_editor_content()
        //{
           
        //}
        
        
    }
}