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

        public MainWindow()
        {
            InitializeComponent();
            PersonCollection workers = new PersonCollection();
            //var xmlWriter = new XmlTextWriter("struct.xml", null);
            //xmlWriter.Formatting = Formatting.Indented;
            //xmlWriter.IndentChar = '\t';
            //xmlWriter.Indentation = 1;
            //xmlWriter.WriteStartElement("rootNode");
            //xmlWriter.WriteStartElement("node");
            //xmlWriter.WriteStartAttribute("name");
            //xmlWriter.WriteString("Центральный");

            //xmlWriter.WriteStartDocument();
            //xmlWriter.WriteEndElement();
            //xmlWriter.WriteEndDocument();
            //xmlWriter.Close();
            //workers["15"] = "das";
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

                if ((c.ChildNodes != null) && c.ChildNodes.Count > 0)
                {
                    RecursiveTreeBuilder(childNode, c);
                }
            }
        }
    }
}