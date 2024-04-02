using System;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace SearchApp
{
    /// <summary>
    /// 操作xml的类
    /// </summary>
    public class XmlOperate
    {

        /// <summary>
        /// 读取加密xml
        /// </summary>
        /// <returns>返回是否存在key</returns>
        public bool xmlReadKey()
        {
            if (File.Exists("key"))
            {
                byte[] pkey = { 88, 55, 103, 24, 98, 46, 67, 29, 94, 19, 57, 118, 104, 15, 121,
                                67, 93, 86, 24, 55, 102, 74, 98, 26, 67, 29, 19, 20, 49, 69, 73, 92 };
                byte[] IV ={ 22, 76, 82, 77, 84, 31, 74, 47, 55, 102, 24, 98, 26, 67, 29, 99 };
                RijndaelManaged myRijndael = new RijndaelManaged();
                FileStream fsOut = File.Open("key", FileMode.Open, FileAccess.Read);
                CryptoStream csDecrypt = new CryptoStream(fsOut, myRijndael.CreateDecryptor(pkey, IV),
                    CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(csDecrypt);

                XmlTextReader textReader = new XmlTextReader(sr);
                try
                {
                    textReader.Read();
                    while (textReader.Read())
                    {
                        if (textReader.NodeType == XmlNodeType.Element)
                        {
                            if (textReader.LocalName == "Name")
                            {
                                MyRegCode.RegName = textReader.ReadString();
                            }
                            if (textReader.LocalName == "Email")
                            {
                                MyRegCode.Email = textReader.ReadString();
                            }
                            if (textReader.LocalName == "MachineCode")
                            {
                                MyRegCode.MachineCode = textReader.ReadString();
                            }
                            if (textReader.LocalName == "RegCode")
                            {
                                MyRegCode.RegCode = textReader.ReadString();
                            }
                            if (textReader.LocalName == "RegDate")
                            {
                                MyRegCode.RegDate = textReader.ReadString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (textReader != null)
                    {
                        textReader.Close();
                    }
                }
                sr.Close();
                fsOut.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 读取config
        /// </summary>
        public void xmlLoadConfig()
        {
            XmlTextReader Reader;
            if (File.Exists("Config.xml"))
            {
                Reader = new XmlTextReader("Config.xml");
            }
            else
            {
                Assembly asm = Assembly.GetEntryAssembly();
                Stream sm = asm.GetManifestResourceStream("SearchApp.Config.xml");
                Reader = new XmlTextReader(sm);
            }
            try
            {
                Reader.Read();
                while (Reader.Read())
                {
                    if (Reader.NodeType == XmlNodeType.Element)
                    {
                        if (Reader.LocalName == "webIndex")
                        {
                            MyRegCode.WebIndex = Reader.ReadString();
                        }
                        if (Reader.LocalName == "snikID")
                        {
                            MyRegCode.SkinId = Reader.ReadString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Reader != null)
                {
                    Reader.Close();
                }
            }
        }

        /// <summary>
        /// 保存Config
        /// </summary>
        public void xmlSaveConfig()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Config></Config>");
            XmlNode root = doc.SelectSingleNode("Config");

            XmlElement xelWebIndex = doc.CreateElement("webIndex");
            xelWebIndex.InnerText= MyRegCode.WebIndex;
            root.AppendChild(xelWebIndex);

            XmlElement xelSnikID = doc.CreateElement("snikID");
            xelSnikID.InnerText = MyRegCode.SkinId;
            root.AppendChild(xelSnikID);

            doc.Save("Config.xml");
        }
    }
}

