using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Net;

namespace falcons
{
    public partial class Social_sharing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fbrow.Visible = false;
            twitterrow.Visible = false;
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
            if(nodes!=null){
                foreach (var node in nodes)
                {
                    if (node.Attributes["property"].Value != null || node.Attributes["content"].Value != null)
                    {
                        string propertyValue = node.Attributes["property"].Value;
                        string contentvalue = node.Attributes["content"].Value;
                        socialLbox.Items.Add(propertyValue + Environment.NewLine);
                        socialLbox.Items.Add(contentvalue);

                    }
                    else
                    {
                        socialLbox.Items.Add("No Og Tags Found!!!!" + Environment.NewLine + "Use Our Tool To Generate Og Tag...");
                    }
                }
            }

            else
            {

                socialLbox.Items.Add("No Meta Tags Found!!!!");
                socialLbox.Items.Add("Use Our Tool To Generate Meta Tag...");
            }
            

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static string GenerateOGTags(string title,string type,string url,string image)
        {
           //HtmlMeta ogTitle=new HtmlMeta();
           //HtmlMeta ogType = new HtmlMeta();
           //HtmlMeta ogUrl = new HtmlMeta();
           //HtmlMeta ogImage = new HtmlMeta();

           //ogTitle.Attributes.Add("property", "og:title");
           //ogTitle.Content = title;
           //ogType.Attributes.Add("property", "og:type");
           //ogType.Content = type;
           //ogUrl.Attributes.Add("property", "og:url");
           //ogUrl.Content = url;
           //ogImage.Attributes.Add("property", "og:image");
           //ogImage.Content = image;

            string ogTitle=@"<meta property=""og:title"" content="+title+" />";
            string ogType=@"<meta property=""og:type"" content="+type+" />";
            string ogUrl = @"<meta property=""og:url"" content=" + url + " />";
            string ogImage = @"<meta property=""og:image"" content=" + image + " />";

           String ogTags = ogTitle + Environment.NewLine + ogType + Environment.NewLine + ogUrl + Environment.NewLine + ogImage;

           return ogTags ;

        }

        protected void socialSearch_Click(object sender, EventArgs e)
        {
            string query = socialsearchtbox.Text;
            string queryfacebook = query + " " + "site:facebook.com";
            string querytwitter = query + " " + "site:twitter.com";

            // Create a Bing container.

            string rootUri = "https://api.datamarket.azure.com/Bing/Search";

            var bingContainer = new Bing.BingSearchContainer(new Uri(rootUri));

            // Replace this value with your account key.
            string market = "en-us";
            string accountKey = "3OL0xieASOtqcyusoHZ447oH2wCJd/Mkz7gM/+ZjQF0";

            // Configure bingContainer to use your credentials.

            bingContainer.Credentials = new NetworkCredential(accountKey, accountKey);
            var webqueryfacebook = bingContainer.Web(queryfacebook, null, null, market, null, null, null, null);
            webqueryfacebook = webqueryfacebook.AddQueryOption("$top", 10);
            var webresultsfacebook = webqueryfacebook.Execute();

            var webquerytwitter = bingContainer.Web(querytwitter, null, null, market, null, null, null, null);
            webquerytwitter = webquerytwitter.AddQueryOption("$top", 10);
            var webresulttwitter = webquerytwitter.Execute();
            DataTable facebookdt = new DataTable();
            facebookdt.Columns.Add("fbname", typeof(string));
            facebookdt.Columns.Add("fburl", typeof(string));

            DataTable twitterdt = new DataTable();
            twitterdt.Columns.Add("twittername",typeof(string));
            twitterdt.Columns.Add("twitterurl", typeof(string));

            //facebookurllst.Items.Clear();
            //twitterurllst.Items.Clear();

            foreach(var fbresult in webresultsfacebook)
            {
                facebookdt.Rows.Add(fbresult.Title, fbresult.Url);
            }

            foreach(var twitterresult in webresulttwitter)
            {
                twitterdt.Rows.Add(twitterresult.Title,twitterresult.Url);
            }

            facebookrepeater.DataSource = facebookdt;
            facebookrepeater.DataBind();
            twitterrepeater.DataSource = twitterdt;
            twitterrepeater.DataBind();

            fbrow.Visible = true;
            twitterrow.Visible = true;
        }
    }
}