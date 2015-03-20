using _2_1_galleriet.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2_1_galleriet
{
    public partial class Default : System.Web.UI.Page
    {
        private Gallery _gallery;

        public Gallery Gallery {
            get
            {
                return _gallery ?? (_gallery = new Gallery());
            }
        }
        private string Successmessage
        {
            get { return Session["successmessage"] as string; }
            set { Session["successmessage"] = value; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

            string imagePath = Request.Url.ToString();
            string fileName = Path.GetFileName(imagePath);



            if (fileName != "" && fileName != "Default.aspx")
            {
                FullImage.ImageUrl = "~/Content/Pics/" + fileName;
                ImagePlaceHolder.Visible = true;

            }
            else
            {
                FullImage.ImageUrl = "~/Content/Pics/Desert.jpg";
                ImagePlaceHolder.Visible = true;
            }


            if (Successmessage != null)
            {
                SuccessPlaceHolder.Visible = true;
                SuccessLabel.Text = Successmessage;
                Session.Remove("successmessage");
            }
        }

        public IEnumerable<_2_1_galleriet.Model.Images> Repeater1_GetData()
        {
            return Gallery.GetImagesNames();
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (PicFileUpload.HasFile)
                {
                    string file = Gallery.SaveImage(PicFileUpload.FileContent, PicFileUpload.FileName);
                    string filename = PicFileUpload.FileName;
                    Successmessage = String.Format("Bilden '{0}' laddades upp utan problem!", file);
                    Response.Redirect("Default.aspx/" + filename);
                    
                }
            }
        }

    }
}