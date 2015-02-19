using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpeechLib;
using System.Speech;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtTest.Text.ToString() == Session["randomStr"].ToString())
            {
                Label1.Text = "Your Form is submitted";
            }
            else
            {
                Label1.Text = "Please enter input correctly";
            }
            txtTest.Text = string.Empty;
            txtTest.Focus();
        }

        protected void audiobtn_Click(object sender, ImageClickEventArgs e)
        {
            String sound = Session["randomStr"].ToString();
            SpVoice voice = new SpVoice();
            voice.Rate = -5;
            voice.Volume = 100;
            voice.Speak(sound, SpeechVoiceSpeakFlags.SVSFDefault);
        }
    }
}