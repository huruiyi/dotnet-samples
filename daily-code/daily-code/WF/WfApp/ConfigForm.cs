using System;
using System.Windows.Forms;
using System.Xml;

namespace WfApp
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private String configurationFile = "ApplicationConfiguration.xml";

        private void ClearFields_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(configurationFile))
            {
                UpdateXmlDocument.Enabled = false;
                LoadXmlTextReader.Enabled = false;
                LoadXmlDocument.Enabled = false;
            }
        }

        private void CreateConfigurationFile_Click(object sender, EventArgs e)
        {
            try
            {
                XmlTextWriter applicationConfiguration = new XmlTextWriter(configurationFile, System.Text.Encoding.UTF8);

                applicationConfiguration.Formatting = Formatting.Indented;

                applicationConfiguration.WriteStartDocument();

                applicationConfiguration.WriteStartElement("configuration");

                // Write the General child element (Line 3).
                applicationConfiguration.WriteStartElement("general");

                // Write the Toolbar and Logging elements (Lines 4 and 5).
                applicationConfiguration.WriteElementString("toolbar", "true");
                applicationConfiguration.WriteElementString("logging", "false");

                // Close the General element (Line 6).
                applicationConfiguration.WriteEndElement();

                // Write the Search child element (Line 7).
                applicationConfiguration.WriteStartElement("search");

                // Write the Server, Timeout, and MaxRecords elements (Lines 8, 9, and 10).
                applicationConfiguration.WriteElementString("server", "Test Server");
                applicationConfiguration.WriteElementString("timeout", "60");
                applicationConfiguration.WriteElementString("maxRecords", "100");

                // Close the Search element (Line 11).
                applicationConfiguration.WriteEndElement();

                // Close the Configuration element (Line 12).
                applicationConfiguration.WriteEndElement();

                // Close the Document.
                applicationConfiguration.WriteEndDocument();

                // Write the XML to the File and close the XmlTextWriter.
                applicationConfiguration.Close();

                // Now that the configuration file exists, enable the Update and Load buttons.
                UpdateXmlDocument.Enabled = true;
                LoadXmlTextReader.Enabled = true;
                LoadXmlDocument.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception: " + exception.ToString());
            }
        }

        private void UpdateXmlDocument_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument applicationConfiguration = new XmlDocument();

                applicationConfiguration.Load(configurationFile);

                XmlNode toolbarNode = applicationConfiguration.SelectSingleNode("configuration/general/toolbar");
                XmlNode loggingNode = applicationConfiguration.SelectSingleNode("configuration/general/logging");
                XmlNode serverNode = applicationConfiguration.SelectSingleNode("configuration/search/server");
                XmlNode timeoutNode = applicationConfiguration.SelectSingleNode("configuration/search/timeout");
                XmlNode recordsNode = applicationConfiguration.SelectSingleNode("configuration/search/maxRecords");

                toolbarNode.InnerText = toolBarIsVisible.Checked.ToString();
                loggingNode.InnerText = loggingIsEnabled.Checked.ToString();
                serverNode.InnerText = serverName.Text;
                timeoutNode.InnerText = timeoutPeriod.Value.ToString();
                recordsNode.InnerText = maximumRecords.Value.ToString();

                applicationConfiguration.Save(configurationFile);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception: " + exception.ToString());
            }
        }

        private void LoadXmlTextReader_Click(object sender, EventArgs e)
        {
            XmlTextReader applicationConfiguration = new XmlTextReader(configurationFile);

            try
            {
                while (!applicationConfiguration.EOF)
                {
                    if (applicationConfiguration.MoveToContent() == XmlNodeType.Element)

                        switch (applicationConfiguration.Name)
                        {
                            case "toolbar":
                                toolBarIsVisible.Checked = Boolean.Parse(applicationConfiguration.ReadElementString());
                                break;

                            case "logging":
                                loggingIsEnabled.Checked = Boolean.Parse(applicationConfiguration.ReadElementString());
                                break;

                            case "server":
                                serverName.Text = applicationConfiguration.ReadElementString();
                                break;

                            case "timeout":
                                timeoutPeriod.Value = int.Parse(applicationConfiguration.ReadElementString());
                                break;

                            case "maxRecords":
                                maximumRecords.Value = int.Parse(applicationConfiguration.ReadElementString());
                                break;

                            default:
                                applicationConfiguration.Read();
                                break;
                        }
                    else
                        applicationConfiguration.Read();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception: " + exception.ToString());
            }
            finally
            {
                if (applicationConfiguration != null)
                    applicationConfiguration.Close();
            }
        }

        private void LoadXmlDocument_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument applicationConfiguration = new XmlDocument();

                applicationConfiguration.Load(configurationFile);

                XmlNode toolbarNode = applicationConfiguration.SelectSingleNode("configuration/general/toolbar");
                XmlNode loggingNode = applicationConfiguration.SelectSingleNode("configuration/general/logging");
                XmlNode serverNode = applicationConfiguration.SelectSingleNode("configuration/search/server");
                XmlNode timeoutNode = applicationConfiguration.SelectSingleNode("configuration/search/timeout");
                XmlNode recordsNode = applicationConfiguration.SelectSingleNode("configuration/search/maxRecords");

                toolBarIsVisible.Checked = (toolbarNode != null) ? (Boolean.Parse(toolbarNode.InnerText)) : (false);
                loggingIsEnabled.Checked = (loggingNode != null) ? (Boolean.Parse(loggingNode.InnerText)) : (false);
                serverName.Text = (serverNode != null) ? (serverNode.InnerText) : ("");
                timeoutPeriod.Value = (timeoutNode != null) ? (int.Parse(timeoutNode.InnerText)) : (30);
                maximumRecords.Value = (recordsNode != null) ? (int.Parse(recordsNode.InnerText)) : (100);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception: " + exception.ToString());
            }
        }
    }
}