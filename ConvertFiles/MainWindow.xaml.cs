using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DateSearchDLL;
using DataValidationDLL;
using System.Xml;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace ConvertFiles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //setting up the classes
        WPFMessagesClass TheMessagesClass = new WPFMessagesClass();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        DateSearchClass TheDateSearchClass = new DateSearchClass();        

        //setting up variables
        XmlDocument gxmlFileName = new XmlDocument();
        XmlDocument gxmlFormattedDocument = new XmlDocument();
        string gstrJSONDocument;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            TheMessagesClass.CloseTheProgram();
        }

        private void btnLoadFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = "Document"; // Default file name

                // Show open file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    // Open document
                    string filename = dlg.FileName;
                }
                                
                gxmlFileName.Load(dlg.FileName);                
                XmlNodeList node = gxmlFileName.SelectNodes("Root");

                TheMessagesClass.InformationMessage("The XML File Has Been Uploaded");               

                txtFileData.Text = gxmlFileName.InnerXml;

            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }

        private void btnConverJSON_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gstrJSONDocument = JsonConvert.SerializeXmlNode(gxmlFileName);

                txtFileData.Text = gstrJSONDocument;
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

        }
    }
}
