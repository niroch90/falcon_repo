using GoogleImage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace falcons
{
    public partial class Image_seo : System.Web.UI.Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void btnUpload_Click(object sender, System.EventArgs e)
        {
            // Initialize variables
            string sSavePath;
            string sThumbExtension;
            int intThumbWidth;
            int intThumbHeight;

            // Set constant values
            sSavePath = "images/";
            sThumbExtension = "_thumb";
            intThumbWidth = 160;
            intThumbHeight = 120;

            // If file field isn’t empty
            if (filUpload.PostedFile != null)
            {
                // Check file size (mustn’t be 0)
                HttpPostedFile myFile = filUpload.PostedFile;
                int nFileLen = myFile.ContentLength;
                if (nFileLen == 0)
                {
                    lblOutput.Text = "There wasn't any file uploaded.";
                    return;
                }

                // Check file extension (must be JPG)
                if (System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".jpg")
                {
                    lblOutput.Text = "The file must have an extension of JPG";
                    return;
                }

                // Read file into a data stream
                byte[] myData = new Byte[nFileLen];
                myFile.InputStream.Read(myData, 0, nFileLen);

                // Make sure a duplicate file doesn’t exist.  If it does, keep on appending an incremental numeric until it is unique
                string sFilename = System.IO.Path.GetFileName(myFile.FileName);

                // Save the stream to disk
                System.IO.FileStream newFile = new System.IO.FileStream(Server.MapPath(sSavePath + sFilename), System.IO.FileMode.Append);
                newFile.Write(myData, 0, myData.Length);
                newFile.Close();

                // Check whether the file is really a JPEG by opening it
                System.Drawing.Image.GetThumbnailImageAbort myCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                Bitmap myBitmap;
                try
                {
                    myBitmap = new Bitmap(Server.MapPath(sSavePath + sFilename));


                    string sThumbFile = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) + sThumbExtension + "." + System.IO.Path.GetExtension(myFile.FileName);

                    // Save thumbnail and output it onto the webpage
                    System.Drawing.Image myThumbnail = myBitmap.GetThumbnailImage(intThumbWidth, intThumbHeight, myCallBack, IntPtr.Zero);
                    myThumbnail.Save(Server.MapPath(sSavePath + sThumbFile));
                    imgPicture.ImageUrl = sSavePath + sThumbFile;

                    GoogleImageSearchResult result = new GoogleImage.GoogleImageUpload().GetGoogleUplaodImageByImageResult(Server.MapPath(sSavePath + sFilename), System.IO.Path.GetExtension(myFile.FileName));
                   
                    if (result != null)
                    {

                        imgPictureBestKnowas.Visible = false;
                        if (result.BestGuessImage != null) {
                            imgPictureBestKnowas.Visible = true;
                            imgPictureBestKnowas.Text = "<b>Best Guess Image :</b>" + result.BestGuessImage;
                        } 

                        if (result.SearchResults != null && result.SearchResults.Count() > 0)
                        {
                            TitleListBox.Items.Clear();
                            UrlListBox.Items.Clear();
                            ContentListBox.Items.Clear();

                            foreach (var item in result.SearchResults)
                            {

                                //int index = search.Items.IndexOf(item);
                                TitleListBox.Items.Add(item.Title);
                                UrlListBox.Items.Add(item.Link);
                                ContentListBox.Items.Add(item.Discription);
                                //ContentListBox.Attributes.Add()


                            }
                        }
                    }
                   


                    // Displaying success information
                    lblOutput.Text = "File uploaded successfully!<br><br>";

                   

                    // Destroy objects
                    myThumbnail.Dispose();
                    myBitmap.Dispose();
                }
                catch (ArgumentException errArgument)
                {
                    // The file wasn't a valid jpg file
                    lblOutput.Text = "The file wasn't a valid jpg file.";
                    System.IO.File.Delete(Server.MapPath(sSavePath + sFilename));
                }
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
    }
}