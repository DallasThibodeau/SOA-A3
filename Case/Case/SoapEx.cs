using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using System.Xml;

public class ThrowSoapException : WebService
{
    // This Web service method throws a SOAP client fault code.
    [WebMethod]
    public void throwSoap(string uri, string details, string varType, string varName, string varVal)
    {

        // Build the detail element of the SOAP fault.
        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        System.Xml.XmlNode node = doc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

        // Build specific details for the SoapException.
        // Add first child of detail XML element.
        System.Xml.XmlNode detailsNode1 = doc.CreateNode(XmlNodeType.Element, "details1", uri);
        System.Xml.XmlNode detailsChild = doc.CreateNode(XmlNodeType.Element, details, uri);
        detailsNode1.AppendChild(detailsChild);

        // Add second child of detail XML element with an attribute.
        System.Xml.XmlNode detailsNode2 = doc.CreateNode(XmlNodeType.Element, "mySpecialInfo2", uri);
        XmlAttribute attr = doc.CreateAttribute(varType, varName, uri);
        attr.Value = varVal;
        detailsNode2.Attributes.Append(attr);

        // Append the two child elements to the detail node.
        node.AppendChild(detailsNode1);
        node.AppendChild(detailsNode2);

        //Throw the exception    
        SoapException se = new SoapException("Fault occurred", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, node);

        throw se;
    }
}