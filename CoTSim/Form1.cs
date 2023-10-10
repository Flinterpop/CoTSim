using Google.Protobuf;

using Atakmap.Commoncommo.Protobuf.V1;
using System.Net.Sockets;
using System.Net;
using System.Xml;

namespace CoTSim
{

    public partial class Form1 : Form
    {
        TakMessage? myTakMessage;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateCoTMessage()
        {
            PrecisionLocation location = new PrecisionLocation() { Altsrc = "MODEA", Geopointsrc = "PTF" };

            Group myGroup = new Group();
            myGroup.Name = cb_Team.Text;
            myGroup.Role = "Team Member";
            Contact myContact = new Contact() { Callsign = "CSHARP", Endpoint = "192.168.1.101:4242:tcp" };
            Status myStatus = new Status() { Battery = 92 };
            Takv myTakv = new Takv() { Device = "MAC", Os = "Win32", Platform = "WinTAK-CAN", Version = "4.9.0.156" };
            Track myTrack = new Track() { Course = 34, Speed = 2.0 };
            Detail myDetail = new Detail() { Group = myGroup, Contact = myContact, Takv = myTakv, Status = myStatus, Track = myTrack };
            CotEvent myCot = new CotEvent() { How = "h-e", Access = "Undefined", Detail = myDetail, Uid = "23234", Lat = 45.111, Lon = -75.2, Hae = 100, Ce = 9999999, Le = 9999999, Type = "a-f-G-U-C-I" };

            ulong milliseconds = (ulong)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalMilliseconds;
            pme("seconds" + milliseconds.ToString());

            myCot.StartTime = milliseconds;
            myCot.SendTime = milliseconds;
            int delta = 60;
            int newDelta;
            pme(tb_StaleMinutes.Text);
            if (Int32.TryParse(tb_StaleMinutes.Text, out newDelta)) delta = newDelta;
            delta = delta * 60000;
            myCot.StaleTime = milliseconds + (ulong)delta;  //3.6 million milliseconds is one hour


            //TakControl myTakControl = new TakControl() { ContactUid = "34344", };
            //TakMessage myTakMessage = new TakMessage() { CotEvent = myCot, TakControl = myTakControl };
            myTakMessage = new TakMessage() { CotEvent = myCot };
        }
        private void SendCoTUDP(TakMessage myTakMessage)
        {
            byte[] buffer = myTakMessage.ToByteArray();
            int bufLen = myTakMessage.CalculateSize();
            var ba = myTakMessage.ToByteArray();

            var sentinel = new byte[] { 0xbf, 0x01, 0xbf };

            byte[] ret = new byte[buffer.Length + sentinel.Length];
            Buffer.BlockCopy(sentinel, 0, ret, 0, sentinel.Length);
            Buffer.BlockCopy(buffer, 0, ret, sentinel.Length, buffer.Length);

            var client = new UdpClient();
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.1.255"), 6969); // endpoint where server is listening
            client.Connect(ep);

            //client.Send(buffer, bufLen);
            client.Send(ret, ret.Length);
        }
        private void bn_Test_Click(object sender, EventArgs e)
        {
            CreateCoTMessage();
            SendCoTUDP(myTakMessage);
            pme(myTakMessage.ToString());

            pme("\r\n\r\n");

            byte[] buffer = myTakMessage.ToByteArray();
            var parsedMsg = TakMessage.Parser.ParseFrom(buffer);

            //parsedMsg.CotEvent.ToString()
            pme("###############" + parsedMsg.CotEvent.ToString());

            //buildXMLTree();
        }


        private void pme(string s)
        {
            rtb_Debug.AppendText(s);
            rtb_Debug.AppendText("\r\n");
        }


        private void buildXMLTree()
        {
            tree_Xml.Nodes.Clear();
            // Load the XML Document
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(myTakMessage.CotEvent.ToString());

                //doc.LoadXml("<books><A property='a'><B>text</B><C>textg</C><D>99999</D></A></books>");
                //doc.Load("");
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
                return;
            }

            ConvertXmlNodeToTreeNode(doc, tree_Xml.Nodes);
            tree_Xml.Nodes[0].ExpandAll();
        }

        private void ConvertXmlNodeToTreeNode(XmlNode xmlNode, TreeNodeCollection treeNodes)
        {

            TreeNode newTreeNode = treeNodes.Add(xmlNode.Name);

            switch (xmlNode.NodeType)
            {
                case XmlNodeType.ProcessingInstruction:
                case XmlNodeType.XmlDeclaration:
                    newTreeNode.Text = "<?" + xmlNode.Name + " " +
                      xmlNode.Value + "?>";
                    break;
                case XmlNodeType.Element:
                    newTreeNode.Text = "<" + xmlNode.Name + ">";
                    break;
                case XmlNodeType.Attribute:
                    newTreeNode.Text = "ATTRIBUTE: " + xmlNode.Name;
                    break;
                case XmlNodeType.Text:
                case XmlNodeType.CDATA:
                    newTreeNode.Text = xmlNode.Value;
                    break;
                case XmlNodeType.Comment:
                    newTreeNode.Text = "<!--" + xmlNode.Value + "-->";
                    break;
            }

            if (xmlNode.Attributes != null)
            {
                foreach (XmlAttribute attribute in xmlNode.Attributes)
                {
                    ConvertXmlNodeToTreeNode(attribute, newTreeNode.Nodes);
                }
            }
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                ConvertXmlNodeToTreeNode(childNode, newTreeNode.Nodes);
            }
        }

        private void bn_Quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bn_Clear_Click(object sender, EventArgs e)
        {
            rtb_Debug.Clear();
        }

        private void bn_SendCoT2_Click(object sender, EventArgs e)
        {
            CoTMsg cm = new CoTMsg();
            SendCoTUDP(cm.takMessage);
            //pme(cm.ToString());

        }
    }


    public class CoTMsg
    {
        string Name = "Cyan";
        string Role = "Team Member";
        string Altsrc = "MODEA";
        string Geopointsrc = "PTF";
        string Callsign = "CSharp";
        string Endpoint = "192.168.1.101:4242:tcp";
        string Device = "MAC";
        string Os = "Win32";
        string Platform = "WinTAK-CAN";
        string Version = "4.9.0.156";
        int Course = 45;
        float Speed = 4.0F;

        string How = "h-e";
        string Access = "Undefined";
        string Uid = "23234";
        double Lat = 45.111;
        double Lon = -75.2;
        double Hae = 100;
        double Ce = 9999999;
        double Le = 9999999;
        string Type = "a-f-G-U-C-I";

        public TakMessage takMessage;

        public CoTMsg()
        {
            PrecisionLocation location = new PrecisionLocation() { Altsrc = "MODEA", Geopointsrc = "PTF" };

            Group myGroup = new Group();
            myGroup.Name = Name;
            myGroup.Role = Role;
            Contact myContact = new Contact() { Callsign = "CSHARP", Endpoint = "192.168.1.101:4242:tcp" };
            Status myStatus = new Status() { Battery = 92 };
            Takv myTakv = new Takv() { Device = "MAC", Os = "Win32", Platform = "WinTAK-CAN", Version = "4.9.0.156" };
            Track myTrack = new Track() { Course = 34, Speed = 2.0 };
            Detail myDetail = new Detail() { Group = myGroup, Contact = myContact, Takv = myTakv, Status = myStatus, Track = myTrack };
            CotEvent myCot = new CotEvent() { How = "h-e", Access = "Undefined", Detail = myDetail, Uid = "23234", Lat = 45.111, Lon = -75.2, Hae = 100, Ce = 9999999, Le = 9999999, Type = "a-f-G-U-C-I" };

            ulong milliseconds = (ulong)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalMilliseconds;
            myCot.StartTime = milliseconds;
            myCot.SendTime = milliseconds;
            int delta = 75;
            delta = delta * 60000;
            myCot.StaleTime = milliseconds + (ulong)delta;  //3.6 million milliseconds is one hour

            takMessage = new TakMessage() { CotEvent = myCot };
        }
    }




}