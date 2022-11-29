using System;
using System.IO;
using System.IO.Packaging;
using System.Text;
using System.Xml;

namespace Net.Tools.Http
{
    internal class HtmlToDocxHelper
    {
        public static void CreateFileFromHTML(string HTMLString, string DOCXSavePath)
        {
            SaveDOCX(DOCXSavePath, HTMLString, true);
        }

        public static void CreateFileFromText(string PlainText, string DOCXSavePath)
        {
            SaveDOCX(DOCXSavePath, PlainText, false);
        }

        private static void SaveDOCX(string fileName, string BodyText, bool IncludeHTML)
        {
            string WordprocessingML = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

            var pkgOutputDoc = Package.Open(fileName, FileMode.Create, FileAccess.ReadWrite);

            XmlDocument xmlStartPart = new XmlDocument();
            XmlElement tagDocument = xmlStartPart.CreateElement("w:document", WordprocessingML);
            xmlStartPart.AppendChild(tagDocument);
            XmlElement tagBody = xmlStartPart.CreateElement("w:body", WordprocessingML);
            tagDocument.AppendChild(tagBody);
            if (IncludeHTML)
            {
                string relationshipNamespace = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";
                XmlElement tagAltChunk = xmlStartPart.CreateElement("w:altChunk", WordprocessingML);
                XmlAttribute RelID = tagAltChunk.Attributes.Append(xmlStartPart.CreateAttribute("r:id", relationshipNamespace));
                RelID.Value = "rId2";
                tagBody.AppendChild(tagAltChunk);
            }
            else
            {
                XmlElement tagParagraph = xmlStartPart.CreateElement("w:p", WordprocessingML);
                tagBody.AppendChild(tagParagraph);
                XmlElement tagRun = xmlStartPart.CreateElement("w:r", WordprocessingML);
                tagParagraph.AppendChild(tagRun);
                XmlElement tagText = xmlStartPart.CreateElement("w:t", WordprocessingML);
                tagRun.AppendChild(tagText);
                XmlNode nodeText = xmlStartPart.CreateNode(XmlNodeType.Text, "w:t", WordprocessingML);
                nodeText.Value = BodyText;
                tagText.AppendChild(nodeText);
            }

            Uri docuri = new Uri("/word/document.xml", UriKind.Relative);
            PackagePart docpartDocumentXML = pkgOutputDoc.CreatePart(docuri, "application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml");
            StreamWriter streamStartPart = new StreamWriter(docpartDocumentXML.GetStream(FileMode.Create, FileAccess.Write));
            xmlStartPart.Save(streamStartPart);
            streamStartPart.Close();
            pkgOutputDoc.Flush();

            pkgOutputDoc.CreateRelationship(docuri, TargetMode.Internal, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument", "rId1");
            pkgOutputDoc.Flush();

            Uri uriBase = new Uri("/word/document.xml", UriKind.Relative);
            PackagePart partDocumentXML = pkgOutputDoc.GetPart(uriBase);

            Uri uri = new Uri("/word/websiteinput.html", UriKind.Relative);

            string html = string.Concat("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\"><html><head><title></title></head><body>", BodyText, "</body></html>");
            byte[] Origem = Encoding.UTF8.GetBytes(html);
            PackagePart altChunkpart = pkgOutputDoc.CreatePart(uri, "text/html");
            using (Stream targetStream = altChunkpart.GetStream())
            {
                targetStream.Write(Origem, 0, Origem.Length);
            }
            Uri relativeAltUri = PackUriHelper.GetRelativeUri(uriBase, uri);

            partDocumentXML.CreateRelationship(relativeAltUri, TargetMode.Internal, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/aFChunk", "rId2");

            pkgOutputDoc.Close();
        }
    }
}
