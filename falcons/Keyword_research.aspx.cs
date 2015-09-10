using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace falcons
{
    public partial class Keyword_research : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
               // AjaxControlToolkit.HTMLEditor.Editor editor_previous_content = (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("editor1");
               // editor_previous_content.Content = (String)(Session["my_editor_content"]);
            
           // AjaxControlToolkit.HTMLEditor.Editor editor_previous_content = (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("editor1");
           // editor_previous_content.Content = (String)(Session["my_editor_content"]);
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterAsyncPostBackControl(Button1);
            }

     

       // void Page_PreRender(object sender, EventArgs e)
       // {
       //AjaxControlToolkit.HTMLEditor.Editor editor_previous_content = (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("editor1");

       //     // Save PageArrayList before the page is rendered.
       //Session["my_editor_content"] = (String)(editor_previous_content.Content);
       // }
        protected void Keyword_research_button(object sender, EventArgs e)
        {

            if (searchEngineDW.SelectedValue == "1")
            {
                GoogleSearch google_search = new GoogleSearch();
                string userKeyword = TextBox2.Text;
                CustomsearchService customSearchService = new CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer() { ApiKey = google_search.apiKey });
                Google.Apis.Customsearch.v1.CseResource.ListRequest listRequest = customSearchService.Cse.List(userKeyword);
                listRequest.Cx = google_search.searchEngineId;
                Search search = listRequest.Execute();

                //GoogleSearch googlesearchobject = new GoogleSearch();

                //var result=googlesearchobject.GoogleKeywordGetter(userKeyword);
                //clear previous values
                TitleListBox.Items.Clear();
                UrlListBox.Items.Clear();
                ContentListBox.Items.Clear();
                
                foreach (var item in search.Items)
                {

                    //int index = search.Items.IndexOf(item);
                    TitleListBox.Items.Add(item.Title);
                    UrlListBox.Items.Add(item.Link);
                    ContentListBox.Items.Add(item.Snippet);
                    //ContentListBox.Attributes.Add()
                    

                }
                
            }




            // This is the query - or you could get it from args.
            if (searchEngineDW.SelectedValue == "2")
            {
                string query = TextBox2.Text;

                // Create a Bing container.

                string rootUri = "https://api.datamarket.azure.com/Bing/Search";

                var bingContainer = new Bing.BingSearchContainer(new Uri(rootUri));

                // Replace this value with your account key.
                string market = "en-us";
                string accountKey = "3OL0xieASOtqcyusoHZ447oH2wCJd/Mkz7gM/+ZjQF0";

                // Configure bingContainer to use your credentials.

                bingContainer.Credentials = new NetworkCredential(accountKey, accountKey);
                var webquery = bingContainer.Web(query, null, null, market, null, null, null, null);
                webquery = webquery.AddQueryOption("$top", 10);
                var webresults = webquery.Execute();
                //clear all previous items
                TitleListBox.Items.Clear();
                UrlListBox.Items.Clear();
                ContentListBox.Items.Clear();
               
                foreach (var results in webresults)
                {


                    TitleListBox.Items.Add(results.Title);
                    UrlListBox.Items.Add(results.Url);
                    ContentListBox.Items.Add(results.Description);
                    //ContentListBox.Attributes.Add()
                    
                }

            }


        }
    protected void keyword_repeater(object source,RepeaterCommandEventArgs e)
        {


        }

    
    
    }
}