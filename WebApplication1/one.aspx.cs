using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Schema;

namespace WebApplication1
{
    public partial class one : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string xmlFile = Server.MapPath("~/one.xml");

        string xsdFile = Server.MapPath("~/one.xsd");



        XmlTextReader textReader = new XmlTextReader(xmlFile);

        XmlValidatingReader validatingReader = new XmlValidatingReader(textReader);

        validatingReader.Schemas.Add(null, xsdFile);

        validatingReader.ValidationType = ValidationType.Schema;

        validatingReader.ValidationEventHandler += new ValidationEventHandler(validatingReader_ValidationEventHandler);



        while (validatingReader.Read())
        {

            if (validatingReader.NodeType == XmlNodeType.Element)
            {

                if (validatingReader.SchemaType is XmlSchemaComplexType)
                {

                    XmlSchemaComplexType complexType = (XmlSchemaComplexType)validatingReader.SchemaType;

                    Response.Write(validatingReader.Name + " " + complexType.Name);

                }

                else
                {

                    object innerText = validatingReader.ReadTypedValue();

                    Response.Write(validatingReader.Name + " : " + innerText.ToString() + " <br />");

                }

            }

        }

        validatingReader.Close();
    }

    public void validatingReader_ValidationEventHandler(object sender, ValidationEventArgs e)
    {

        Response.Write("Error Message : " + e.Message);

    }
    }
    
}