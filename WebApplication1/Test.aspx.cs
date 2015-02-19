using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace WebApplication1
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap obj = new System.Drawing.Bitmap(150, 50);
            Graphics objGraphics = System.Drawing.Graphics.FromImage(obj);
            objGraphics.Clear(Color.LightGray);
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            Font objFont = new Font("Arial", 25, FontStyle.Italic | FontStyle.Strikeout);



            Random r = new Random();
            int startIndex = r.Next(1, 5);
            int length = r.Next(4, 7);

            String randomStr = Guid.NewGuid().ToString().Replace("-", "0").Substring(startIndex, length);

            Session.Add("randomStr", randomStr);


            objGraphics.DrawString(randomStr, objFont, Brushes.DodgerBlue, 5, 5);


            Response.ContentType = "image/GIF";
            obj.Save(Response.OutputStream, ImageFormat.Gif);

            objFont.Dispose();
            objGraphics.Dispose();
            obj.Dispose();
        }
    }
}