using Microsoft.WindowsAPICodePack.ExtendedLinguisticServices;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFormDemo
{
    public partial class 翻译案例 : Form
    {
        private class DataItem : Object
        {
            public Guid guid { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public 翻译案例()
        {
            InitializeComponent();
        }

        private const string categoryTransliteration = "Transliteration";
        private MappingService[] transliterationServices = null;
        private Guid? guidService = null;

        private void 翻译案例_Load(object sender, EventArgs e)
        {
            transliterationServices = GetSpecifiedMappingServices(categoryTransliteration);
            if ((transliterationServices != null) && transliterationServices.Any())
            {
                foreach (MappingService ms in transliterationServices)
                {
                    comboBox1.Items.Add(new DataItem() { Name = ms.Description, guid = ms.Guid });
                }
                comboBox1.SelectedIndex = 0;
            }
        }

        private string LanguageConverter(Guid serviceGuid, string sourceContent)
        {
            string transliterated = null;
            if (!string.IsNullOrEmpty(sourceContent))
            {
                try
                {
                    MappingService mapService = new MappingService(serviceGuid);
                    using (MappingPropertyBag bag = mapService.RecognizeText(sourceContent, null))
                    {
                        transliterated = bag.GetResultRanges()[0].FormatData(new StringFormatter());
                    }
                }
                catch (LinguisticException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            return transliterated;
        }

        //获取所有翻译类别
        private MappingService[] GetSpecifiedMappingServices(string CategoryName)
        {
            MappingService[] transliterationServices = null;
            try
            {
                MappingEnumOptions enumOptions = new MappingEnumOptions() { Category = CategoryName };
                transliterationServices = MappingService.GetServices(enumOptions);
            }
            catch (LinguisticException exc)
            {
                MessageBox.Show(exc.Message);
            }
            return transliterationServices;
        }

        private void 翻译_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSource.Text))
                return;

            try
            {
                guidService = ((DataItem)comboBox1.SelectedItem).guid;
                string result = LanguageConverter(guidService.GetValueOrDefault(), txtSource.Text);
                if (!string.IsNullOrEmpty(result))
                {
                    txtResult.Text = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}