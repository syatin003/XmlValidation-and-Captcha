using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Schema;

namespace WebApplication1
{
    public partial class prac : System.Web.UI.Page
    {
        private int nErrors = 0;
        private string strErrorMsg = string.Empty;
        public string Errors { get { return strErrorMsg; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            grd_bind();
        }
        protected void grd_bind()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("prac.xml"));
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!IsValidXml(@"http://localhost:1469/prac.xml", @"http://localhost:1469/prac.xsd"))
            {
                Label1.Text = Errors;
            }
            else
            {
                #region save
                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.Load(Server.MapPath("prac.xml"));

                XmlNode RootNode = xmlDoc.SelectSingleNode("BookStore");

                XmlNode BookNode = RootNode.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Book", ""));
                BookNode.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Title", "")).InnerText = txttitle.Text;

                BookNode.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Author", "")).InnerText = txtauthor.Text;

                BookNode.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Year", "")).InnerText = txtyear.Text;

                BookNode.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Price", "")).InnerText = txtprice.Text;

                BookNode.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Email", "")).InnerText = txtemail.Text;


                xmlDoc.Save(Server.MapPath("prac.xml"));
                #endregion

                Label1.Text = string.Format("Success");
                grd_bind();

            }

        }



        public bool IsValidXml(string xmlPath, string xsdPath)
        {
            bool bStatus = false;
            try
            {
                // Declare local objects
                XmlReaderSettings rs = new XmlReaderSettings();
                rs.ValidationType = ValidationType.Schema;
                rs.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation | XmlSchemaValidationFlags.ReportValidationWarnings;
                // Event Handler for handling exception & this will be called whenever any mismatch between XML & XSD
                rs.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);
                rs.Schemas.Add(null, XmlReader.Create(xsdPath));
                // reading xml
                using (XmlReader xmlValidatingReader = XmlReader.Create(xmlPath, rs))
                { while (xmlValidatingReader.Read()) { } }
                ////Exception if error.
                if (nErrors > 0)
                {
                    throw new Exception(strErrorMsg);
                }
                else { bStatus = true; }//Success
            }
            catch (Exception error) { bStatus = false; }
            return bStatus;
        }


        void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning) strErrorMsg += "WARNING: ";
            else strErrorMsg += "ERROR: ";
            nErrors++;
            if (e.Exception.Message.Contains("'Email' element is invalid"))
            {
                strErrorMsg = strErrorMsg + getErrorString("Provided Email data is Invalid", "CAPIEMAIL007") + "\r\n";
            }
            if (e.Exception.Message.Contains("The element 'book' has invalid child element"))
            {
                strErrorMsg = strErrorMsg + getErrorString("Provided XML contains invalid child element", "CAPINVALID005") + "\r\n";
            }
            else
            {
                strErrorMsg = strErrorMsg + e.Exception.Message + "\r\n";
            }
        }



        string getErrorString(string erroString, string errorCode)
        {
            StringBuilder errXMl = new StringBuilder();
            errXMl.Append("<MyError> <errorString> ERROR_STRING </errorString> <errorCode> ERROR_CODE </errorCode> </MyError>");
            errXMl.Replace("ERROR_STRING", erroString);
            errXMl.Replace("ERROR_CODE", errorCode);
            return errXMl.ToString();

        }

    }
}