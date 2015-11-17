using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using System.Data;

namespace falcons
{
    public partial class Social_sharing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // AjaxControlToolkit.HTMLEditor.Editor editor_previous_content = (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("editor1");
           // editor_previous_content.Content = (String)(Session["my_editor_content"]);
        }

        protected void SocialBtn_Click(object sender, EventArgs e)
        {
            AjaxControlToolkit.HTMLEditor.Editor editorContent = (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("Editor1");
            var html = new HtmlDocument();
            html.LoadHtml(editorContent.Content);
            var nodes = html.DocumentNode.SelectNodes("//meta");
            DataTable dt = new DataTable();
            foreach(var node in nodes){
                if (node.Attributes["property"].Value != null || node.Attributes["content"].Value != null)
                {
                    string propertyValue = node.Attributes["property"].Value;
                    string contentvalue = node.Attributes["content"].Value;
                    socialLbox.Items.Add(propertyValue+Environment.NewLine);
                    socialLbox.Items.Add(contentvalue);

                }
            }

        }
    }
}

