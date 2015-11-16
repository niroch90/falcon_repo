using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoogleImage
{
    public class GoogleImageSearchResult
    {

        public string BestGuessImage { get; set; }
        public List<SearchUrl> SearchResults { get; set; }



    }


    public class SearchUrl
    {

        public string Title { get; set; }
        public string Link { get; set; }
        public string Discription { get; set; }


    }


    public class GoogleImageUpload
    {



        private static string HttpUploadFileHtml(string url, string file, string paramName, string contentType, NameValueCollection nvc)
        {
            string boundary = "----WebKitFormBoundary" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] boundarybytesF = System.Text.Encoding.ASCII.GetBytes("--" + boundary + "\r\n");  // the first time it itereates, you need to make sure it doesn't put too many new paragraphs down or it completely messes up poor webbrick.  


            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.AllowAutoRedirect = false;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
            wr.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            var nvc2 = new NameValueCollection();
            nvc2.Add("Accepts-Language", "en-us,en;q=0.5");
            wr.Headers.Add(nvc2);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;


            Stream rs = wr.GetRequestStream();

            bool firstLoop = true;
            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                if (firstLoop)
                {
                    rs.Write(boundarybytesF, 0, boundarybytesF.Length);
                    firstLoop = false;
                }
                else
                {
                    rs.Write(boundarybytes, 0, boundarybytes.Length);
                }
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, new FileInfo(file).Name, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);

                if (wresp.Headers["Location"] != null)
                {
                    return GetHtml(wresp.Headers["Location"].ToString());
                }
                else
                {
                    return reader2.ReadToEnd();
                }
               
            }
            catch (Exception ex)
            {
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }

            return null;
        }

        private string GetGoogleUploadImageUploadHtml(string path, string fileExtension)
        {


            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("image_url", "");
            parameters.Add("image_content", "");
            parameters.Add("filename", "");
            parameters.Add("h1", "en");
            parameters.Add("bih", "179");
            parameters.Add("biw", "1600");




            return HttpUploadFileHtml("https://www.google.co.in/searchbyimage/upload", path, "encoded_image", "image/" + fileExtension, parameters);
            
        
        }

        private string GetGoogleUploadImageUrlHtml(string image_url)
        {

            string address = string.Format("http://www.google.lk/searchbyimage?image_url={0}&encoded_image={1}&image_content={2}&filename={3}",
               Uri.EscapeDataString(image_url),
               Uri.EscapeDataString(""),
                Uri.EscapeDataString(""),
               Uri.EscapeDataString(""));

            return GetHtml(address);


           
        }

        private static string GetHtml(string url) {

            try
            {


                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;

                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36";
                webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

                HttpWebResponse WebResponse = (HttpWebResponse)webRequest.GetResponse();

                Stream responseStream = responseStream = WebResponse.GetResponseStream();
                if (WebResponse.ContentEncoding.ToLower().Contains("gzip"))
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                else if (WebResponse.ContentEncoding.ToLower().Contains("deflate"))
                    responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);

                StreamReader Reader = new StreamReader(responseStream, Encoding.UTF8);

                string html = Reader.ReadToEnd();

                WebResponse.Close();
                responseStream.Close();

                return html;


            }
            catch (WebException ex)
            {

            }
            catch (UriFormatException ex)
            {

            }

            return null;
        
        
        }


        public List<string> GetImageUrlFromWebPage(string url){

            HtmlDocument doc = new HtmlDocument();

            string html = GetHtml(url);

            if (html == null) return null;

            doc.LoadHtml(html);

            if (doc != null)
            {
                Uri x=new Uri(url);

                string base_url=x.Scheme+"://"+x.Host;

                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//img[starts-with(@src, '')]");

                 if (nodes != null)
                 {

                     List<string> urls = new List<string>();

                     foreach (HtmlNode img in nodes)
                     {
                         var r = img.GetAttributeValue("src", "");
                         if(r!="") {
                             Uri k=null;
                             if(Uri.TryCreate(r.ToString(),UriKind.Absolute,out k)){
                             urls.Add(r.ToString());
                             }else  urls.Add(base_url+r.ToString());
                         
                         
                         
                         }
                     
                     }

                     return urls;
                 
                 }


            
            }
            return null;
        
        }


        public GoogleImageSearchResult GetGoogleUplaodImageByImageResult(string image_path,string fileExtension) {

            return GetGoogleUplaodImageResult(image_path, true, fileExtension);
        
        }

        private GoogleImageSearchResult GetGoogleUplaodImageResult(string url, bool isUplaod, string fileExtension)
        {

            HtmlDocument doc = new HtmlDocument();

            string html = isUplaod ? GetGoogleUploadImageUploadHtml(url, fileExtension) : GetGoogleUploadImageUrlHtml(url);

            if (html == null) return null;

            doc.LoadHtml(html);

            if (doc != null)
            {

                GoogleImageSearchResult obj = new GoogleImageSearchResult();

                HtmlNode best = doc.GetElementbyId("topstuff").SelectSingleNode("//div[@class=\"_hUb\"]/a");

                if (best != null) obj.BestGuessImage = best.InnerText;

                List<SearchUrl> list = new List<SearchUrl>();

                HtmlNodeCollection nodes = doc.GetElementbyId("rso").SelectNodes("//div[@class=\"rc\"]");

                if (nodes != null)
                {

                    foreach (HtmlNode search in nodes)
                    {

                        HtmlNode ti = search.SelectSingleNode(".//h3[@class=\"r\"]/a");
                        HtmlNode dis = search.SelectSingleNode(".//span[@class=\"st\"]");




                        SearchUrl s = new SearchUrl()
                        {
                            Title = ti != null ? ti.InnerHtml : null,
                            Link = ti != null ? ti.GetAttributeValue("href", "") : null,
                            Discription = dis != null ? dis.InnerHtml : null
                        };

                        list.Add(s);

                    }

                    obj.SearchResults = list;

                    return obj;


                }



            }

            return null;
        }

        public GoogleImageSearchResult GetGoogleUplaodImageByUrlResult(string url)
        {

            return GetGoogleUplaodImageResult(url, false,null);

        }



    }
}