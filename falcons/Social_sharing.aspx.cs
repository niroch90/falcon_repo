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
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
namespace falcons
{
    public partial class Social_sharing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // AjaxControlToolkit.HTMLEditor.Editor editor_previous_content = (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("editor1");
            // editor_previous_content.Content = (String)(Session["my_editor_content"]);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            AjaxControlToolkit.HTMLEditor.Editor master_editor = (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("editor1");
            var masterpage_content = master_editor.Content;
            var doc = new HtmlDocument();
            doc.LoadHtml(masterpage_content);

            var list = doc.DocumentNode.SelectNodes("//meta");
            foreach (var node in list)
            {
                string content = node.Attributes["property"].Value;
                OgtagLbox.Items.Add(content);
            }
        }
    }
}

