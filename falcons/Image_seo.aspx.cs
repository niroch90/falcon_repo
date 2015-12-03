using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace falcons
{
    public partial class Image_seo : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            imgDetailspanel.Visible = false;
        }

        protected void ImageCheckBtn_Click(object sender, EventArgs e)
        {
            AjaxControlToolkit.HTMLEditor.Editor master_editor_content = (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("Editor1");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(master_editor_content.Content);
            var images = doc.DocumentNode.SelectNodes("//img");
            foreach(var img in images)
            {
                Imagelbox.Items.Add(img.Attributes["src"].Value);
            }
        }

        protected void Imagelbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            AjaxControlToolkit.HTMLEditor.Editor master_editor_content = (AjaxControlToolkit.HTMLEditor.Editor)Master.FindControl("Editor1");
             string selectedimage = Imagelbox.SelectedValue;
            HtmlDocument doc=new HtmlDocument();
            doc.LoadHtml(master_editor_content.Content);
            string xpath = "//img[@src='"+selectedimage+"']";
            var nodes = doc.DocumentNode.SelectSingleNode(xpath);
           // var imgnode = doc.DocumentNode.SelectSingleNode("//img");

            var src = nodes.Attributes["src"] != null ?nodes.Attributes["src"].Value : "no src value found" ;
            var alt =nodes.Attributes["alt"] !=null? nodes.Attributes["alt"].Value:"no alt value found";
            string imageUrl = src.ToString();
            //get image dimensions
            Stream str = null;
            HttpWebRequest wReq = (HttpWebRequest)WebRequest.Create(src.ToString());
            HttpWebResponse wRes = (HttpWebResponse)(wReq).GetResponse();
            str = wRes.GetResponseStream();
            var imageOrig = System.Drawing.Image.FromStream(str);
            int remoteimgheight = imageOrig.Height;
            int remoteimgwidth = imageOrig.Width;

            var width =nodes.Attributes["width"] !=null ? nodes.Attributes["width"].Value : remoteimgwidth.ToString();
            var height =nodes.Attributes["height"] != null ? nodes.Attributes["height"].Value : remoteimgheight.ToString();

            srclabel.Text = src.ToString();
            altlabel.Text = alt.ToString();
            imgwidthlabel.Text = width.ToString();
            imgheightlabel.Text = height.ToString();
            imgDetailspanel.Visible = true;
            


            //if (nodes.Attributes["src"] != null)
            //{
               
            //    srclabel.Text = src.ToString();
            //}

            //if (alt != null)
            //{
            //    altlabel.Text = alt.ToString();
            //}
            //else
            //{
            //    string srcattribute = src.ToString();
            //    srcattribute = srcattribute.Remove(srcattribute.Length - 4);
            //    srcattribute = srcattribute.Replace("-"," ");
            //    altlabel.Text = "No alt Attribute Found.Suggest Attribute:" + srcattribute;
            //}

            //if(width!=null)
            //{
            //    imgwidthlabel.Text = width.ToString();
            //}

            //else
            //{
            //    imgwidthlabel.Text = remoteimgwidth.ToString();
            //}


            //if (height != null)
            //{
            //    imgheightlabel.Text = height.ToString();
            //}

            //else
            //{
            //    imgheightlabel.Text = remoteimgheight.ToString();
            //}

            
        }


    }
}