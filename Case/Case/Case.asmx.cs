using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Web.Services.Protocols;
using System.Text.RegularExpressions;

namespace Case
{
    /// <summary>
    /// Summary description for Case
    /// </summary>

    //If you want to run it from VS:
    //[WebService(Namespace = "http://localhost:65275//Case")]
    //If you want to publish it:
    [WebService(Namespace = "http://localhost//TextService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Case : System.Web.Services.WebService
    {
        private const string logFile = "C:\\SOA_A3\\Case.txt";

        [WebMethod]
        public string CaseConvert(string incoming, uint flag)
        {
            myLogging.Write(logFile, "CaseConvert() was called. Parameter value(s): " + incoming + ", " + flag);
            string toReturn = "";

            if (!Regex.IsMatch(incoming, @"^[a-zA-Z]+$"))
            {
                myLogging.Write(logFile, "**ERROR**: Invalid value for parameter 'incoming'");
                throw new SoapException("**ERROR**: Invalid value for parameter 'incoming'", SoapException.ClientFaultCode);
            }

            if (flag == 1)
            {
                toReturn = incoming.ToUpper();
            }
            else if (flag == 2)
            {
                toReturn = incoming.ToLower();
            }
            else
            {
                myLogging.Write(logFile, "**ERROR**: Invalid value for parameter 'flag'");
                throw new SoapException("**ERROR**: Invalid value for parameter 'flag'", SoapException.ClientFaultCode);
            }

            return toReturn;
        }


        //public void throwSoap(string uri, string details, string varType, string varName, string varVal)
        //{

        //    // Build the detail element of the SOAP fault.
        //    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        //    System.Xml.XmlNode node = doc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

        //    // Build specific details for the SoapException.
        //    // Add first child of detail XML element.
        //    System.Xml.XmlNode detailsNode1 = doc.CreateNode(XmlNodeType.Element, "details1", uri);
        //    System.Xml.XmlNode detailsChild = doc.CreateNode(XmlNodeType.Element, details, uri);
        //    detailsNode1.AppendChild(detailsChild);

        //    // Add second child of detail XML element with an attribute.
        //    System.Xml.XmlNode detailsNode2 = doc.CreateNode(XmlNodeType.Element, "mySpecialInfo2", uri);
        //    XmlAttribute attr = doc.CreateAttribute(varType, varName, uri);
        //    attr.Value = varVal;
        //    detailsNode2.Attributes.Append(attr);

        //    // Append the two child elements to the detail node.
        //    node.AppendChild(detailsNode1);
        //    node.AppendChild(detailsNode2);

        //    //Throw the exception    
        //    SoapException se = new SoapException("Fault occurred", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, node);

        //    throw se;
        //}
    }
}
