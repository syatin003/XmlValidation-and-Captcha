using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1
{
    public partial class CRUD : System.Web.UI.Page
    {
        string xmlfile = @"http://localhost:1469/CRUD.xml";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }


        protected void LoadData()
        {
            DataSet ds = new DataSet();
            DataTable table = new DataTable();
            ds.ReadXml(xmlfile);
            lvBook.DataSource = ds;
            lvBook.DataBind();
        }

        protected void lvBook_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            TextBox txtIdTextBox = (TextBox)lvBook.InsertItem.FindControl("txtID");
            TextBox txtTitleTextBox = (TextBox)lvBook.InsertItem.FindControl("txtTitle");
            TextBox txtAuthorTextBox = (TextBox)lvBook.InsertItem.FindControl("txtAuthor");
            TextBox txtYearTextBox = (TextBox)lvBook.InsertItem.FindControl("txtYear");
            TextBox txtPriceTextBox = (TextBox)lvBook.InsertItem.FindControl("txtPrice");
            TextBox txtEmailTextBox = (TextBox)lvBook.InsertItem.FindControl("txtEmail");
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(Server.MapPath("CRUD.xml"));

            //XmlNode RootNode = xdoc.SelectSingleNode("BookStore");
            //XmlNode CNode = RootNode.AppendChild(xdoc.CreateNode(XmlNodeType.Element, "Book",""));
            //CNode.AppendChild(xdoc.CreateNode(XmlNodeType.Element, "ID", "")).InnerText = txtidTextBox.Text;
            //CNode.AppendChild(xdoc.CreateNode(XmlNodeType.Element, "Name", "")).InnerText = txtnameTextBox.Text;
            //xdoc.Save(Server.MapPath("CRUD.xml"));


            XmlElement xelement = xdoc.CreateElement("Book");

            XmlElement xID = xdoc.CreateElement("ID");
            xID.InnerText = txtIdTextBox.Text;
            xelement.AppendChild(xID);



            XmlElement xTitle = xdoc.CreateElement("Title");
            xTitle.InnerText = txtTitleTextBox.Text;
            xelement.AppendChild(xTitle);

            XmlElement xAuthor = xdoc.CreateElement("Author");
            xAuthor.InnerText = txtTitleTextBox.Text;
            xelement.AppendChild(xAuthor);

            XmlElement xYear = xdoc.CreateElement("Year");
            xYear.InnerText = txtTitleTextBox.Text;
            xelement.AppendChild(xYear);

            XmlElement xPrice = xdoc.CreateElement("Price");
            xPrice.InnerText = txtTitleTextBox.Text;
            xelement.AppendChild(xPrice);


            XmlElement xEmail = xdoc.CreateElement("Email");
            xEmail.InnerText = txtTitleTextBox.Text;
            xelement.AppendChild(xEmail);


            xdoc.DocumentElement.AppendChild(xelement);
            xdoc.Save(Server.MapPath("CRUD.xml"));
            //xdoc.Save(xmlfile);
            LoadData();
        }
        static Int16 i = 0;
        protected void lvBook_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            lvBook.EditIndex = e.NewEditIndex;
            i = Convert.ToInt16(lvBook.EditIndex);


            Label lblId = (Label)lvBook.EditItem.FindControl("lblID");
            Label lblTitle = (Label)lvBook.EditItem.FindControl("lblTitle");
            Label lblAuthor = (Label)lvBook.EditItem.FindControl("lblAuthor");
            Label lblYear = (Label)lvBook.EditItem.FindControl("lblYear");
            Label lblPrice = (Label)lvBook.EditItem.FindControl("lblPrice");
            Label lblEmail = (Label)lvBook.EditItem.FindControl("lblEmail");


            TextBox txtIdTextBox = (TextBox)lvBook.InsertItem.FindControl("txtID");
            TextBox txtTitleTextBox = (TextBox)lvBook.InsertItem.FindControl("txtTitle");
            TextBox txtAuthorTextBox = (TextBox)lvBook.InsertItem.FindControl("txtAuthor");
            TextBox txtYearTextBox = (TextBox)lvBook.InsertItem.FindControl("txtYear");
            TextBox txtPriceTextBox = (TextBox)lvBook.InsertItem.FindControl("txtPrice");
            TextBox txtEmailTextBox = (TextBox)lvBook.InsertItem.FindControl("txtEmail");
            txtIdTextBox.Text = lblId.Text;
            txtIdTextBox.Visible = false;
            txtTitleTextBox.Text = lblTitle.Text;
            txtAuthorTextBox.Text = lblAuthor.Text;
            txtYearTextBox.Text = lblYear.Text;
            txtPriceTextBox.Text = lblPrice.Text;
            txtEmailTextBox.Text = lblEmail.Text;
        }

        protected void lvBook_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            Label lblId = (lvBook.Items[e.ItemIndex].FindControl("lblID")) as Label;
            Label lblTitle = (lvBook.Items[e.ItemIndex].FindControl("lblName")) as Label;
            Label lblAuthor = (lvBook.Items[e.ItemIndex].FindControl("lblID")) as Label;
            Label lblYear = (lvBook.Items[e.ItemIndex].FindControl("lblName")) as Label;
            Label lblPrice = (lvBook.Items[e.ItemIndex].FindControl("lblID")) as Label;
            Label lblEmail = (lvBook.Items[e.ItemIndex].FindControl("lblName")) as Label;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlfile);
            XmlNodeList newXMLNodes = xmlDoc.SelectNodes("/BookStore/Book");

            // here i am searching based on id and name.So i am concatenating data into one string variable.
            string value = lblId.Text + lblTitle.Text + lblAuthor.Text + lblYear.Text + lblPrice.Text + lblEmail.Text;

            // code to remove child node from xml based on selection(matches all the data in xml file)
            //when a match is found removes that childnode from root node.
            foreach (XmlNode newXMLNode in newXMLNodes)
            {
                if (newXMLNode.InnerText == value)
                {
                    newXMLNode.ParentNode.RemoveChild(newXMLNode);
                }
            }

            xmlDoc.Save(xmlfile);
            xmlDoc = null;
            LoadData();
        }

        protected void lvBook_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            TextBox txtIdTextBox = (TextBox)lvBook.InsertItem.FindControl("txtID");
            TextBox txtTitleTextBox = (TextBox)lvBook.InsertItem.FindControl("txtTitle");
            TextBox txtAuthorTextBox = (TextBox)lvBook.InsertItem.FindControl("txtAuthor");
            TextBox txtYearTextBox = (TextBox)lvBook.InsertItem.FindControl("txtYear");
            TextBox txtPriceTextBox = (TextBox)lvBook.InsertItem.FindControl("txtPrice");
            TextBox txtEmailTextBox = (TextBox)lvBook.InsertItem.FindControl("txtEmail");
            txtIdTextBox.Text = string.Empty;
            txtTitleTextBox.Text = string.Empty;
            txtAuthorTextBox.Text = string.Empty;
            txtYearTextBox.Text = string.Empty;
            txtPriceTextBox.Text = string.Empty;
            txtEmailTextBox.Text = string.Empty;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            Label lblId = (Label)lvBook.EditItem.FindControl("lblID");
            Label lblTitle = (Label)lvBook.EditItem.FindControl("lblTitle");
            Label lblAuthor = (Label)lvBook.EditItem.FindControl("lblAuthor");
            Label lblYear = (Label)lvBook.EditItem.FindControl("lblYear");
            Label lblPrice = (Label)lvBook.EditItem.FindControl("lblPrice");
            Label lblEmail = (Label)lvBook.EditItem.FindControl("lblEmail");

            TextBox txtIdTextBox = (TextBox)lvBook.InsertItem.FindControl("txtID");
            TextBox txtTitleTextBox = (TextBox)lvBook.InsertItem.FindControl("txtTitle");
            TextBox txtAuthorTextBox = (TextBox)lvBook.InsertItem.FindControl("txtAuthor");
            TextBox txtYearTextBox = (TextBox)lvBook.InsertItem.FindControl("txtYear");
            TextBox txtPriceTextBox = (TextBox)lvBook.InsertItem.FindControl("txtPrice");
            TextBox txtEmailTextBox = (TextBox)lvBook.InsertItem.FindControl("txtEmail");


            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlfile);



            XmlNode xmlnode = xmldoc.DocumentElement.ChildNodes.Item(i);
            xmlnode["ID"].InnerText = lblId.Text;
            xmlnode["Title"].InnerText = txtTitleTextBox.Text;
            xmlnode["Author"].InnerText = txtAuthorTextBox.Text;
            xmlnode["Year"].InnerText = txtYearTextBox.Text;
            xmlnode["Price"].InnerText = txtPriceTextBox.Text;
            xmlnode["Email"].InnerText = txtEmailTextBox.Text;

            xmldoc.Save(Server.MapPath("CRUD.xml"));
            LoadData();
        }
    }
}