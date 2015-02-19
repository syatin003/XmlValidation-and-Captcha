using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace WebApplication1
{
    public partial class eg : System.Web.UI.Page
    {
        private int nErrors = 0;
        private string strErrorMsg = string.Empty;
        public string Errors { get { return strErrorMsg; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsValidXml(@"http://localhost:1469/eg.xml", @"http://localhost:1469/eg.xsd"))
            {
                Label1.Text = Errors;
            }
            else
            {
                Label1.Text = string.Format("Success");

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
            if (e.Exception.Message.Contains("The element 'Person' has invalid child element"))
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