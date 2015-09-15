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
        
            
          
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
          
           
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
           
        }
        protected void editor_content_load(object sender, EventArgs e)
        {
            if (contentCallEvent != null)
                contentCallEvent(this, EventArgs.Empty);

        }
        public event EventHandler contentCallEvent;
     
     }
}