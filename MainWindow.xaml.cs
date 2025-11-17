using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        }
        public MainWindow()
        {
            InitializeComponent();
            PersonCollection workers = new PersonCollection();
            var xmlWriter = new XmlTextWriter("struct.xml",  null);
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.IndentChar = '\t';
            xmlWriter.Indentation = 1;
            xmlWriter.WriteStartElement("rootNode");
            xmlWriter.WriteStartElement("node");
            xmlWriter.WriteStartAttribute("name");
            xmlWriter.WriteString("Центральный");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            //workers["15"] = "das";
            var doc = new XmlDocument();
            doc.Load("struct.xml");
            XmlNode root;
        }
            
    }
}