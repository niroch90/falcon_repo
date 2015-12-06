using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;


namespace falcons
{
    /// <summary>
    /// Summary description for FalconsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FalconsService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public string SaveToSession(string editorContent,string title)
        {
            string result;
            string EditorContent = editorContent;
            string Title = title;
            if ((EditorContent !="") && (Title!=""))
            {
                HttpContext.Current.Session.Add("editor_content", (String)EditorContent);
                HttpContext.Current.Session.Add("content_title", title);
                //Session["editor_content"] = (String)(EditorContent);
               // Session["content_title"] = title;
                result = "content saved";
            }
            else if ((EditorContent !="") && (Title== ""))
            {
                HttpContext.Current.Session.Add("editor_content", (String)EditorContent);
                //Session["editor_content"] = (String)(EditorContent);
                result = "edior content saved!! no title found!! add title too...";
            }
            else if((EditorContent == "") && (Title!=""))
            {
                HttpContext.Current.Session.Add("content_title", title);
              //Session["content_title"] = title;
              result = "no content found in editor";
            }

            //else if ((EditorContent == null) && (Title == null))
            //{
            //    result="nothing found";
            //}

            else
            {
                 result="nothing found";
            }

            return result;
        }

        
    }
}
