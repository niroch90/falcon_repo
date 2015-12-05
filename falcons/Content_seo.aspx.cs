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
using System.Data;

namespace falcons
{
    public partial class Content_seo : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
           

           // Button1_Click();
        }
        //protected void Page_PreInit(object sender,EventArgs e)
        //{
        //    // Create an event handler for the master page's contentCallEvent event
        //    Master.contentCallEvent += new EventHandler(Button1_Click);
        //}

        protected void ValidateBtnClick(object sender, EventArgs e)
        {
            AjaxControlToolkit.HTMLEditor.Editor master_editor_content = (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("Editor1");
            //content_lable.Text = master_editor_content.Content;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(master_editor_content.Content);
            IEnumerable<HtmlNode> links = doc.DocumentNode.Descendants("a").Where(x => x.Attributes.Contains("href"));
            if(links.Count()!=0)
            {
               // Aval_links_Tbox.Text = "Available Links</br>-----------------------</br>";
                foreach (var link in links)
                {

                    //Console.WriteLine(string.Format("Link href={0}, link text={1}", link.Attributes["href"].Value, link.InnerText));
                    Aval_links_Tbox.Text += link.Attributes["href"].Value + Environment.NewLine;


                }
               
                }
            else 
            {
                Aval_links_Tbox.Text = "No Links Available in the Content";
            }
            //select all header tags
            string xpathQuery = "//*[starts-with(name(),'h') and string-length(name()) = 2 and number(substring(name(), 2)) <= 6]";
            var tags = doc.DocumentNode.SelectNodes(xpathQuery);
            if (tags != null  )
            {
                //Aval_Heading_Tbox.Text = "Available Headings</br>";
               // StringBuilder headings=new StringBuilder();
                foreach (var headertag in tags)
                {
                   // if(headertag.ChildNodes.Count==0)
                    //{
                        Aval_Heading_Tbox.Text += headertag.InnerText+Environment.NewLine;
                            //headertag.Attributes["H1"].Value + Environment.NewLine + headertag.Attributes["H2"].Value + Environment.NewLine + headertag.Attributes["H3"].Value + Environment.NewLine + headertag.Attributes["H4"].Value + Environment.NewLine + headertag.Attributes["H5"].Value + Environment.NewLine + headertag.Attributes["H6"].Value + Environment.NewLine;
                   // }
                    //else
                 
                    //{
                    //    break;
                    //}
                   }
              //  Aval_Heading_Tbox.Text = headings.Length == 0 ? "No Headings available" : headings.ToString();
               
            }
            else
            {
                Aval_Heading_Tbox.Text = "No Headings Available in the Content!!!."+Environment.NewLine+"Try to put atleast one heading....";  
            }

            var paragraphs = doc.DocumentNode.SelectNodes("//p");
            if(paragraphs != null){
                int count=0;
                foreach(var paranodes in paragraphs)
                {
                    count = count + 1;

                }
                Aval_Para_Tbox.Text = count.ToString() + "Paragraphs Found"; 

            }
            else
            {
                Aval_Para_Tbox.Text = "No Parahaph Found" + Environment.NewLine + "To improve SEO put atleast 3 parah";
            }

        }

        //code for fix all uncloased html tags
        
        public static string AutoCloseHtmlTags(string inputHtml)
        {
            var regexStartTag = new Regex(@"<(!--\u002E\u002E\u002E--|!DOCTYPE|a|abbr|" +
                  @"acronym|address|applet|area|article|aside|audio|b|base|basefont|bdi|bdo|big" +
                  @"|blockquote|body|br|button|canvas|caption|center|cite|code|col|colgroup|" +
                  @"command|datalist|dd|del|details|dfn|dialog|dir|div|dl|dt|em|embed|fieldset|" +
                  @"figcaption|figure|font|footer|form|frame|frameset|h1> to <h6|head|" +
                  @"header|hr|html|i|iframe|img|input|ins|kbd|keygen|label|legend|li|link|" +
                  @"map|mark|menu|meta|meter|nav|noframes|noscript|object|ol|optgroup|option|" +
                  @"output|p|param|pre|progress|q|rp|rt|ruby|s|samp|script|section|select|small|" +
                  @"source|span|strike|strong|style|sub|summary|sup|table|tbody|td|textarea|" +
                  @"tfoot|th|thead|time|title|tr|track|tt|u|ul|var|video|wbr)(\s\w+.*(\u0022|'))?>");
            var startTagCollection = regexStartTag.Matches(inputHtml);
            var regexCloseTag = new Regex(@"</(!--\u002E\u002E\u002E--|!DOCTYPE|a|abbr|" +
                  @"acronym|address|applet|area|article|aside|audio|b|base|basefont|bdi|bdo|" +
                  @"big|blockquote|body|br|button|canvas|caption|center|cite|code|col|colgroup|" +
                  @"command|datalist|dd|del|details|dfn|dialog|dir|div|dl|dt|em|embed|fieldset|" +
                  @"figcaption|figure|font|footer|form|frame|frameset|h1> to <h6|head|header" +
                  @"|hr|html|i|iframe|img|input|ins|kbd|keygen|label|legend|li|link|map|mark|menu|" +
                  @"meta|meter|nav|noframes|noscript|object|ol|optgroup|option|output|p|param|pre|" +
                  @"progress|q|rp|rt|ruby|s|samp|script|section|select|small|source|span|strike|" +
                  @"strong|style|sub|summary|sup|table|tbody|td|textarea|tfoot|th|thead|" +
                  @"time|title|tr|track|tt|u|ul|var|video|wbr)>");
            var closeTagCollection = regexCloseTag.Matches(inputHtml);
            var startTagList = new List<string>();
            var closeTagList = new List<string>();
            var resultClose = "";
            foreach (Match startTag in startTagCollection)
            {
                startTagList.Add(startTag.Value);
            }
            foreach (Match closeTag in closeTagCollection)
            {
                closeTagList.Add(closeTag.Value);
            }
            startTagList.Reverse();
            for (int i = 0; i < closeTagList.Count; i++)
            {
                if (startTagList[i] != closeTagList[i])
                {
                    int indexOfSpace = startTagList[i].IndexOf(
                             " ", System.StringComparison.Ordinal);
                    if (startTagList[i].Contains(" "))
                    {
                        startTagList[i].Remove(indexOfSpace);
                    }
                    startTagList[i] = startTagList[i].Replace("<", "</");
                    resultClose += startTagList[i] + ">";
                    resultClose = resultClose.Replace(">>", ">");
                }
            }
            return inputHtml + resultClose;
        }

        protected void html_fix_button_Click(object sender, EventArgs e)
        {
            AjaxControlToolkit.HTMLEditor.Editor master_editor_content = (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("editor1");
            master_editor_content.Content = AutoCloseHtmlTags(master_editor_content.Content);
        }

        protected void metatagbtn_Click(object sender, EventArgs e)
        {
            Generate_meta_tags(titletbox.Text, descriptiontbox.Text, keywordstbox.Text);
        } 

        protected void Generate_meta_tags(String title,String description,String keywords)
        {
            String metatitle = "<title>" + title + "</title>";
            String metadescription = "<meta name=\"Description\" content=\"" + description + "\">";
            String metakeywords = "<meta name=\"Keywords\" content=\"" + keywords + "\">";
            metaresulttbox.Text = "Copy below tags and paste within the header tag"+"\n"+metatitle + "\n" + metadescription + "\n" + metakeywords;
        }

        //analyse the rank in google
        public static int GetPosition(Uri url, string searchTerm)
      { 
      string raw = "http://www.google.lk/search?num=39&q={0}&btnG=Search"; 
      string search = string.Format(raw,HttpUtility.UrlEncode(searchTerm)); HttpWebRequest request = (HttpWebRequest)WebRequest.Create(search); 
      using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
      { 
       using (StreamReader reader = new StreamReader(response.GetResponseStream(),Encoding.ASCII)) 
       { 
        string html = reader.ReadToEnd(); 
           return FindPosition(html,url); 
       } 
      } 
        } 
        /// <summary> /// Examinsthe search result and retrieves the position. /// </summary> 
        private static int FindPosition(string html,Uri url) 
        { 
         string lookup = "(<h2 class=r><a href=\")(\\w+[a-zA-Z0-9.-?=/]*)";
      MatchCollection matches = Regex.Matches(html,
      lookup); for (int i = 0;
      i < matches.Count;
      i++) { string match = matches[i].Groups[2].Value; if (match.Contains(url.Host)) return i + 1;
      } return 0;
      }

        protected void url_search_btn_Click(object sender, EventArgs e)
        {
            String searched_url=url_tbox.Text;
            String searched_term = search_term.Text;
            Uri url = new Uri(searched_url);
            int position = GetPosition(url, searched_term);
            url_search_result.InnerText = "your website position is:" + position.ToString();
        }

        //word count
       protected void countwords_btnclick(object sender,EventArgs e)
        {
            AjaxControlToolkit.HTMLEditor.Editor master_editor= (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("Editor1");
            String mastereditor_content = master_editor.Content;
            bool tagsplit = true;
            int wordresult = CountWords(mastereditor_content,tagsplit);
            double word_percentage = ((double)(wordresult) / 700.00) * 100;
            wordResult.Text = "no of words in the content:"+wordresult.ToString();
           // progress_text.Visible = true;
           //progress_block.Visible = true;
            //progress_text.Style.Add("display", "block");
            string word_count_string = word_percentage.ToString("F2") + "%";
           // word_percentage_div.Style.Add("display", "block");
            progress_block.Style.Add("display", "block");
            progress_text.Style.Add("display", "block");
            word_percentage_div.Style.Add("width", word_count_string);
            WordCountText = "strength"+word_count_string;

         }


       public string WordCountText
       {
           get;
           set;
       }
       //public string Word_count_text
       //{
       //    get { return word_count_text; }
       //    set { word_count_text = value; }
       //}
        public static int CountWords(string strText, bool stripTags)
        {
            // Declare and initialize the variable holding the number of counted words
            int countedWords = 0;

            // If the stripTags argument was passed as false
            if (stripTags == false)
            {
                // Simply count the words in the string by splitting them wherever a space is found
                countedWords = strText.Split(' ').Length;
            }
            else
            {
                // If the user wants to strip tags, first define the tag form
                Regex tagMatch = new Regex("<[^>]+>");
                // Replace the tags with an empty string so they are not considered in count
                strText = tagMatch.Replace(strText, "");
                // Count the words in the string by splitting them wherever a space is found
                countedWords = strText.Split(' ').Length;
            }
            // Return the number of words that were counted
            return countedWords;
        }
        DataTable tagdataTable = new DataTable();
        public void getKeywordTags(object sender, EventArgs e)
        {
            AjaxControlToolkit.HTMLEditor.Editor master_editor = (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("Editor1");
            String editorcontent = master_editor.Content;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(editorcontent);
            var root = doc.DocumentNode;
            var sb = new StringBuilder();
            //DescendantNodesAndSelf()
            foreach (var node in root.DescendantNodesAndSelf())
            {
                if (!node.HasChildNodes)
                {
                    string text = node.InnerText;
                    if (!string.IsNullOrEmpty(text))
                        sb.AppendLine(Regex.Replace(text, @"\t|\n|\r|[|]|(|)|{|}", ""));
                    //sb.AppendLine(text.Trim(new char[] { ' ', '\t', '\n', '\r', '[', ']', '(', ')', '{', '}' }));
                }
            }

            string[] editorWords = sb.ToString().Split(new Char[] { ',', '\n', ' ', '\r', ';' });

            //string connString ="falcon_cs";
            string query = "SELECT * FROM Categorytbl INNER JOIN KeywordCattbl ON Categorytbl.Category_ID = KeywordCattbl.KeywordCat_ID ";

            string cs = ConfigurationManager.ConnectionStrings["falcon_cs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(tagdataTable);

            }
            List<string> tagslist = new List<string>();
            List<string> categorylist = new List<string>();
            foreach (string eword in editorWords)
            {
                string noHTML = Regex.Replace(eword, @"<[^>]+>|&nbsp;", "").Trim();
                string noHTMLNormalised = Regex.Replace(noHTML, @"\s{2,}", " ");
                string finaleword = noHTMLNormalised.Replace("\'","");
                DataRow[] foundkeyword = tagdataTable.Select("Keyword_Name ='" + finaleword + "'");
                if(foundkeyword!= null)
                {
                    foreach(DataRow row in foundkeyword)
                    {
                        string keywordintagtbl = row[3].ToString();
                        string categoryintagtbl = row[1].ToString();
                        tagslist.Add(keywordintagtbl);
                        categorylist.Add(categoryintagtbl);
                    }
                }
            }
            tagsrepeater.DataSource = tagslist.Distinct();
            tagsrepeater.DataBind();
            categoryRepeater.DataSource = categorylist.Distinct();
            categoryRepeater.DataBind();

        }

       
    }
}