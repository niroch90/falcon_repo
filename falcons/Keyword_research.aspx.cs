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
using System.Data;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Text;
using System.IO;

namespace falcons
{
    public partial class Keyword_research : System.Web.UI.Page
    {
        string importantWord;
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
        protected void Keyword_research_button(object sender, EventArgs e )
        {
            //string contentword=importantWord;

            if (searchEngineDW.SelectedValue == "1")
            {
                GoogleSearch google_search = new GoogleSearch();

                string searchtboxValue=TextBox2.Text;
                string userKeyword = (importantWord != null) ? importantWord : searchtboxValue;
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
                DataTable dt = new DataTable();
                dt.Columns.Add("imageUrl", typeof(string));
                foreach (var item in search.Items)
                {

                    //int index = search.Items.IndexOf(item);
                    TitleListBox.Items.Add(item.Title);
                    UrlListBox.Items.Add(item.Link);
                    ContentListBox.Items.Add(item.Snippet);
                    //ContentListBox.Attributes.Add()
                 // var keysforimages = item.Pagemap["cse_image"];
                    
                    //var keyforSingleImage = keysforimages; 
                    //var keyforsingleimage;
                    if(item.Pagemap != null)
                    {
                        foreach (var keysforimages in item.Pagemap.Keys)
                        {
                            if (keysforimages == "cse_image")
                            {
                                var singleImageKey = item.Pagemap["cse_image"];
                                foreach (var images in singleImageKey)
                                {

                                    if (images.ContainsKey("src"))
                                    {
                                        var imagepath = images["src"];


                                        dt.Rows.Add(imagepath);
                                      
                                    
                                       // dt.Rows.Add(imagepath);
                                    }

                                }
                            }
                        }

                    }
                   
                

                }
                Repeater1.DataSource = dt;
                Repeater1.DataBind();

              
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

    protected void kwExtractorbtn_Click(object sender, EventArgs e)
    {
        AjaxControlToolkit.HTMLEditor.Editor master_editor_content = (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("Editor1");
        String editortext = master_editor_content.Content;
        //string cs = ConfigurationManager.ConnectionStrings["falcon_cs"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(cs))
        //{
        //    SqlDataAdapter sda = new SqlDataAdapter("SELECT word FROM StopWordsList", con);

        //    //cmd.CommandText="SELECT word FROM StopWordsList";
        //    //cmd.CommandType=System.Data.CommandType.Text;

        //    //cmd.ExecuteNonQuery();
        //    DataSet ds = new DataSet();
        //    sda.Fill(ds, "StopWordsList");
        //    List<string> stopwords = new List<string>();
        //    foreach (DataRow row in ds.Tables["StopWordsList"].Rows)
        //    {
        //        stopwords.Add(row["word"].ToString());
        //    }


        //    HashSet<string> stopWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        //    string[] lines = stopwords.ToArray();
        //    foreach (string s in lines)
        //    {
        //        stopWords.Add(s); // Assuming that each line contains one stop word.
        //    }
        //    HtmlDocument doc = new HtmlDocument();
        //    doc.LoadHtml(master_editor_content.Content);
        //    var root = doc.DocumentNode;
        //    var sb = new StringBuilder();
        //    //DescendantNodesAndSelf()
        //    foreach (var node in root.DescendantNodesAndSelf())
        //    {
        //        if (!node.HasChildNodes)
        //        {
        //            string text = node.InnerText;
        //            if (!string.IsNullOrEmpty(text))
        //                sb.AppendLine(text.Trim());
        //        }
        //    }
        //    string[] editorWords = sb.ToString().Split(' ');
        //    List<string> keywordList = new List<string>();
        //    foreach(string word in editorWords)
        //    {
        //        MatchCollection matches = Regex.Matches(word, "[a-z]([:']?[a-z])*",
        //                                RegexOptions.IgnoreCase);
        //        foreach (Match match in matches)
        //        {
        //            if (!stopWords.Contains(match.Value))
        //            {
        //                keywordList.Add(match.Value);
        //               // editorKeywordsLbox.Items.Add(match.Value);
        //                //ProcessKeyword(match.Value); // Do whatever you need to do here
        //            }
        //        }

        //    }
        //    List<string> noDuplicateKeys = keywordList.Distinct().ToList();
        //    foreach (string keyword in noDuplicateKeys)
        //    {
        //          if(!keyword.EndsWith("ing") && !keyword.EndsWith("ed") && !keyword.Contains("nbsp"))
        //          {
        //              editorKeywordsLbox.Items.Add(keyword);
        //          }

        //    }


        //}
        HashSet<string> stopWordsHset = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        string StopwordFile = Server.MapPath("StopWords/stopwords.txt");
        StreamReader reader = File.OpenText(StopwordFile);
        string stopwordString = reader.ReadToEnd();
        string[] stopwords = stopwordString.Replace(" ", "").Split(',');
        foreach(string s in stopwords){
            stopWordsHset.Add(s);

        }

        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(master_editor_content.Content);
        var root = doc.DocumentNode;
        var sb = new StringBuilder();
        //DescendantNodesAndSelf()
        foreach (var node in root.DescendantNodesAndSelf())
        {
            if (!node.HasChildNodes)
            {
                string text = node.InnerText;
                if (!string.IsNullOrEmpty(text))
                    sb.AppendLine(text.Trim());
            }
        }
        string[] editorWords = sb.ToString().Split(' ');
        List<string> keywordList = new List<string>();
        foreach (string word in editorWords)
        {
            MatchCollection matches = Regex.Matches(word, "[a-z]([:']?[a-z])*",
                                    RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                if (!stopWordsHset.Contains(match.Value))
                {
                    keywordList.Add(match.Value);
                    // editorKeywordsLbox.Items.Add(match.Value);
                    //ProcessKeyword(match.Value); // Do whatever you need to do here
                }
            }

        }
        // we used RegeX for this operation
        List<string> noDuplicateKeys = keywordList.Distinct().ToList();
        foreach (string keyword in noDuplicateKeys)
        {
            if (!keyword.EndsWith("ing") && !keyword.EndsWith("ed") && !keyword.Contains("nbsp"))
            {
                editorKeywordsLbox.Items.Add(keyword);
            }

        }

    }

    protected void editorKeywordsLbox_SelectedIndexChanged(object sender, EventArgs e)
    {
        string lboxSelectedTxt = editorKeywordsLbox.SelectedValue.ToString();
        importantWord = lboxSelectedTxt;
        Keyword_research_button(sender,e);
    }

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Image imagefield = new Image();
        //        if (imagefield != null)
        //        {
        //            imagefield.ImageUrl=;
        //        }
        //    }
        //}

    
    
    }
}