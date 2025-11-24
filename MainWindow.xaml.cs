using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.IO;
using System.Text;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            PersonCollection workers = new PersonCollection();
            var xmlWriter = new XmlTextWriter("struct213.xml", Encoding.UTF8);
            xmlWriter.IndentChar = '\t';
            xmlWriter.Indentation = Convert.ToInt32(true);
            xmlWriter.Formatting = Formatting.Indented;
            string[] lines = File.ReadAllLines(@"G:\person.txt");
            string[,] strings = new string[100,5];
            
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < 5; j++)
                    strings[i,j] = lines[i].Split('+')[j];
            }
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("rootNode");
            xmlWriter.WriteAttributeString("text", "Компания");
            xmlWriter.WriteAttributeString("id", "0");
            
            xmlWriter.WriteStartElement("node");
            xmlWriter.WriteAttributeString("text", "Центральный");
            xmlWriter.WriteAttributeString("id", "1");
            
            xmlWriter.WriteStartElement("node");
            xmlWriter.WriteAttributeString("text", "Бухгалтерия");
            xmlWriter.WriteAttributeString("id", "1_1");
            xmlWriter.WriteEndElement();
            
            xmlWriter.WriteStartElement("node");
            xmlWriter.WriteAttributeString("text", "Кадры");
            xmlWriter.WriteAttributeString("id", "1_2");
            xmlWriter.WriteEndElement();
            
            xmlWriter.WriteStartElement("node");
            xmlWriter.WriteAttributeString("text", "Производство");
            xmlWriter.WriteAttributeString("id", "1_3");
            xmlWriter.WriteEndElement();
            
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("node");
            xmlWriter.WriteAttributeString("text", "Южный");
            xmlWriter.WriteAttributeString("id", "2");

            xmlWriter.WriteStartElement("node");
            xmlWriter.WriteAttributeString("text", "Кадры");
            xmlWriter.WriteAttributeString("id", "2_1");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("node");
            xmlWriter.WriteAttributeString("text", "Производство");
            xmlWriter.WriteAttributeString("id", "2_2");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("node");
            xmlWriter.WriteAttributeString("text", "Северный");
            xmlWriter.WriteAttributeString("id", "3");

            xmlWriter.WriteStartElement("node");
            xmlWriter.WriteAttributeString("text", "Бухгалтерия");
            xmlWriter.WriteAttributeString("id", "3_1");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("node");
            xmlWriter.WriteAttributeString("text", "Кадры");
            xmlWriter.WriteAttributeString("id", "3_2");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("node");
            xmlWriter.WriteAttributeString("text", "Производство");
            xmlWriter.WriteAttributeString("id", "3_3");
            xmlWriter.WriteStartElement("node");
            xmlWriter.WriteAttributeString("text", "Производство(цех #1)");
            xmlWriter.WriteAttributeString("id", "3_3_1");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement();
            foreach (var worker in workers)
            {
                
            }
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            var doc = new XmlDocument();
            doc.Load("struct.xml");
            XmlNode root = doc.DocumentElement;

            TreeViewItem rootNode = new TreeViewItem();
            rootNode.Header = root.Attributes.Item(0).Value;
            //rootNode.ImageIndex = Convert.ToInt32(root.Attributes.Item(1).Value);
            //rootNode.SelectedImageIndex = Convert.ToInt32(root.Attributes.Item(1).Value);
            rootNode.Tag = root.Attributes.Item(1).Value;
            rootNode.IsExpanded = true;
            WorkersTree.Items.Add(rootNode);

            if ((root.ChildNodes != null) && (root.ChildNodes.Count > 0))
            {
                RecursiveTreeBuilder(rootNode, root);
            }
            rootNode.IsSelected = true;
        }
        private void RecursiveTreeBuilder(TreeViewItem tvi, XmlNode xn)
        {
            foreach (XmlNode c in xn.ChildNodes)
            {
                TreeViewItem childNode = new TreeViewItem();
                childNode.Header = c.Attributes.Item(0).Value;
                //childNode.ImageIndex = Convert.ToInt32(c.Attributes.Item(1).Value);
                //childNode.SelectedImageIndex = Convert.ToInt32(c.Attributes.Item(1).Value);
                childNode.Tag = c.Attributes.Item(1).Value;
                tvi.Items.Add(childNode);

                if ((c.ChildNodes != null) && c.ChildNodes.Count > 0)
                {
                    RecursiveTreeBuilder(childNode, c);
                }
            }
        }
    }
}