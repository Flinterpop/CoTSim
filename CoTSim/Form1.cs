using Google.Protobuf;

using Atakmap.Commoncommo.Protobuf.V1;
using System.Net.Sockets;
using System.Net;
using System.Xml;
using System.Text;

namespace CoTSim
{

    public partial class Form1 : Form
    {
        TakMessage? myTakMessage;

        public Form1()
        {
            InitializeComponent();
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
            string IP = TB_IP.Text;
            int port =  Int32.Parse(TB_Port.Text);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port); 
            client.Connect(ep);
            client.Send(ret, ret.Length);
        }


        private void pme(string s)
        {
            rtb_Debug.AppendText(s);
            rtb_Debug.AppendText("\r\n");
            rtb_Debug.Select(rtb_Debug.Text.Length - 1, 0);
            rtb_Debug.ScrollToCaret();
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
            CoT_PLI_Msg cm = new CoT_PLI_Msg();  //pre-canned PLI
            SendCoTUDP(cm.takMessage);
            //pme(cm.ToString());
        }

        private void bn_SendPLI_Click(object sender, EventArgs e)
        {
            CreateCoT_PLI_Message();
            SendCoTUDP(myTakMessage);
            //pme(myTakMessage.ToString());

            //pme("\r\n\r\n");

            byte[] buffer = myTakMessage.ToByteArray();
            var parsedMsg = TakMessage.Parser.ParseFrom(buffer);

            //parsedMsg.CotEvent.ToString()
            //pme("###############" + parsedMsg.CotEvent.ToString());

            //buildXMLTree();
        }

        private void CreateCoT_PLI_Message()
        {
            //First build components of <detail> node
            PrecisionLocation location = new PrecisionLocation() { Altsrc = "MODEA", Geopointsrc = "PTF" };

            Group myGroup = new Group();
            myGroup.Name = cb_Team.Text;
            myGroup.Role = "Team Member";

            Contact myContact = new Contact() { Callsign = "G23A" };//, Endpoint = "192.168.1.101:4242:tcp" };
            Status myStatus = new Status() { Battery = 92 };
            Takv myTakv = new Takv() { Device = "MAC", Os = "Win32", Platform = "WinTAK-CAN", Version = "4.9.0.156" };
            //Track myTrack = new Track() { Course = 34, Speed = 2.0 };
            Detail myDetail = new Detail() { Group = myGroup, Contact = myContact, Takv = myTakv };//, Status = myStatus };//, Track = myTrack };

            //Now create <event> node of which <detail> is a component
            CotEvent myCot = new CotEvent()
            {
                How = "h-e",
                Access = "Undefined",
                Detail = myDetail,
                Uid = "3453",
                Lat = 45.211,
                Lon = -75.3,
                Hae = 120,
                Ce = 9999999,
                Le = 9999999,
                Type = "a-f-G-U-C-A-T"
            };

            //now add the time attributes (now, start, stale)
            ulong milliseconds = (ulong)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalMilliseconds;
            myCot.StartTime = milliseconds;
            myCot.SendTime = milliseconds;
            int delta = 60;
            int newDelta;
            if (Int32.TryParse(tb_StaleMinutes.Text, out newDelta)) delta = newDelta;
            delta = delta * 60000;
            myCot.StaleTime = milliseconds + (ulong)delta;  //3.6 million milliseconds is one hour


            //TakControl myTakControl = new TakControl() { ContactUid = "34344", };
            //TakMessage myTakMessage = new TakMessage() { CotEvent = myCot, TakControl = myTakControl };
            myTakMessage = new TakMessage() { CotEvent = myCot };
        }

        private void CreateCoT_Contact_Message()
        {
            //First build components of <detail> node
            PrecisionLocation location = new PrecisionLocation() { Altsrc = "GPS", Geopointsrc = "GPS" };

            Group myGroup = new Group();
            myGroup.Name = cb_Team.Text;
            myGroup.Role = "Team Leader";

            Contact myContact = new Contact() { Callsign = "T12D" };//, Endpoint = "192.168.1.101:4242:tcp" };
            Status myStatus = new Status() { Battery = 92 };
            Takv myTakv = new Takv() { Device = "MAC", Os = "Win32", Platform = "WinTAK-CAN", Version = "4.9.0.156" };
            Track myTrack = new Track() { Course = 34, Speed = 2.0 };
            Detail myDetail = new Detail() { Group = myGroup, Contact = myContact, Takv = myTakv };//, Status = myStatus };//, Track = myTrack };

            //Now create <event> node of which <detail> is a component
            CotEvent myCot = new CotEvent()
            {
                How = "h-e",
                Access = "Undefined",
                Detail = myDetail,
                Uid = "6624",
                Lat = 46.000,
                Lon = -75.2,
                Hae = 120,
                Ce = 9999999,
                Le = 9999999,
                Type = "a-f-G-U-C-A-T"
            };

            //now add the time attributes (now, start, stale)
            ulong milliseconds = (ulong)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalMilliseconds;
            myCot.StartTime = milliseconds;
            myCot.SendTime = milliseconds;
            int delta = 60;
            int newDelta;
            if (Int32.TryParse(tb_StaleMinutes.Text, out newDelta)) delta = newDelta;
            delta = delta * 60000;
            myCot.StaleTime = milliseconds + (ulong)delta;  //3.6 million milliseconds is one hour


            //TakControl myTakControl = new TakControl() { ContactUid = "34344", };
            //TakMessage myTakMessage = new TakMessage() { CotEvent = myCot, TakControl = myTakControl };
            myTakMessage = new TakMessage() { CotEvent = myCot };
        }

        private void BN_SendContact_Click(object sender, EventArgs e)
        {
            SendCoTXMLUDP();
        }


        private void SendCoTXMLUDP()
        {
            //Byte[] sendBytes = Encoding.ASCII.GetBytes("<event version=\"2.0\" uid=\"417d800c-b4df-40b3-a572-5752aeed2de6\" type=\"a-f-G-U-C-A-T-H---E-C\" time=\"2024-02-03T01:46:57.64Z\" start=\"2024-02-03T01:46:57.64Z\" stale=\"2024-02-03T01:51:57.64Z\" how=\"h-g-i-g-o\" access=\"Undefined\"><point lat=\"45.309969\" lon=\"-75.4508853\" hae=\"47.416\" ce=\"3.0\" le=\"9999999\" /><detail><status readiness=\"true\" /><archive /><usericon iconsetpath=\"COT_MAPPING_2525C/a-f/a-f-G\" /><link uid=\"ANDROID-3c56d6302641fcf5\" production_time=\"2024-02-03T01:29:23.875Z\" type=\"a-f-G-U-C\" parent_callsign=\"BRICKWALL\" relation=\"p-p\" /><remarks /><color argb=\"-1\" /><height value=\"7.315200000000001\" /><archive /><ce_human_input>true</ce_human_input><contact callsign=\"T12C\" /><precisionlocation geopointsrc=\"USER\" altsrc=\"DTED0\" /></detail></event>");
            //Byte[] sendBytes = Encoding.ASCII.GetBytes("<event version=\"2.0\" uid=\"417d800c-b4df-40b3-a572-5752aeed2de6\" type=\"a-f-G-U-C-A-T-W-R-E-C\" time=\"2024-02-03T01:46:57.64Z\" start=\"2024-02-03T01:46:57.64Z\" stale=\"2024-02-03T01:51:57.64Z\" how=\"h-g-i-g-o\" access=\"Undefined\"><point lat=\"45.309969\" lon=\"-75.4508853\" hae=\"47.416\" ce=\"3.0\" le=\"9999999\" /><detail><status readiness=\"true\" /><archive /><usericon iconsetpath=\"COT_MAPPING_2525C/a-f/a-f-G\" /><link uid=\"ANDROID-3c56d6302641fcf5\" production_time=\"2024-02-03T01:29:23.875Z\" type=\"a-f-G-U-C\" parent_callsign=\"BRICKWALL\" relation=\"p-p\" /><remarks /><color argb=\"-1\" /><height value=\"7.315200000000001\" /><archive /><ce_human_input>true</ce_human_input><contact callsign=\"T12C\" /><precisionlocation geopointsrc=\"USER\" altsrc=\"DTED0\" /></detail></event>");
            //Byte[] sendBytes = Encoding.ASCII.GetBytes("<event version=\"2.0\" uid=\"417d800c-b4df-40b3-a572-5752aeed2de6\" type=\"a-f-G-E-V-A-L-----M-P\" time=\"2024-02-03T01:46:57.64Z\" start=\"2024-02-03T01:46:57.64Z\" stale=\"2024-02-03T01:51:57.64Z\" how=\"h-g-i-g-o\" access=\"Undefined\"><point lat=\"45.309969\" lon=\"-75.4508853\" hae=\"47.416\" ce=\"3.0\" le=\"9999999\" /><detail><status readiness=\"true\" /><archive /><usericon iconsetpath=\"COT_MAPPING_2525C/a-f/a-f-G\" /><link uid=\"ANDROID-3c56d6302641fcf5\" production_time=\"2024-02-03T01:29:23.875Z\" type=\"a-f-G-U-C\" parent_callsign=\"BRICKWALL\" relation=\"p-p\" /><remarks /><color argb=\"-1\" /><height value=\"7.315200000000001\" /><archive /><ce_human_input>true</ce_human_input><contact callsign=\"T12C\" /><precisionlocation geopointsrc=\"USER\" altsrc=\"DTED0\" /></detail></event>");
            Byte[] sendBytes = Encoding.ASCII.GetBytes("<event version=\"2.0\" uid=\"417d800c-b4df-40b3-a572-5752aeed2de7\" type=\"a-f-G-E-V-A-L\" time=\"2024-02-03T01:46:57.64Z\" start=\"2024-02-03T01:46:57.64Z\" stale=\"2024-02-03T01:51:57.64Z\" how=\"h-g-i-g-o\" access=\"Undefined\"><point lat=\"45.409969\" lon=\"-75.4608853\" hae=\"47.416\" ce=\"3.0\" le=\"9999999\" /><detail><status readiness=\"true\" /><archive /><usericon iconsetpath=\"COT_MAPPING_2525C/a-f/a-f-G\" /><link uid=\"ANDROID-3c56d6302641fcf5\" production_time=\"2024-02-03T01:29:23.875Z\" type=\"a-f-G-U-C\" parent_callsign=\"BRICKWALL\" relation=\"p-p\" /><remarks /><color argb=\"-1\" /><height value=\"7.315200000000001\" /><archive /><ce_human_input>true</ce_human_input><contact callsign=\"T12C\" /><precisionlocation geopointsrc=\"USER\" altsrc=\"DTED0\" /></detail></event>");

            var client = new UdpClient();
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.1.255"), 6969); // endpoint where server is listening
            client.Connect(ep);
            client.Send(sendBytes);
        }

        private void BN_Listen_Click(object sender, EventArgs e)
        {
            int listenPort = 6969;
            IPAddress ListenIPAddress = System.Net.IPAddress.Parse("239.2.3.1");
            //IPAddress localSourceIPAddress = "192.168.1.99"; // (IPAddress)cb_ListenIPs.SelectedItem;

            IPEndPoint ListenEP;
            ListenEP = new IPEndPoint(IPAddress.Any, listenPort);

            //if (cb_AnyPort.Checked) ListenEP = new IPEndPoint(IPAddress.Any, listenPort);
            //else ListenEP = new IPEndPoint(localSourceIPAddress, listenPort);


            bool ListenIsMultiCast = true;
            bool Listening = true;
            bool LongTermDebug = true;
            int PacketsRead = 0;

            pme("Listening:");
            Task.Run(async () =>
            {
            using (var udpClient = new UdpClient(ListenEP))
            {
                    udpClient.MulticastLoopback = true;
                    //udpClient.ExclusiveAddressUse = false;
                    pme("Exclusive:" + udpClient.ExclusiveAddressUse.ToString());

                    if (ListenIsMultiCast == true) //if its a multicast listen IP then have to join the multicast group
                        udpClient.Client.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, 
                            new MulticastOption(ListenIPAddress, IPAddress.Any));

                    //THIS IS THE MAIN LOOP
                    while (Listening == true)
                    {
                        //IPEndPoint object will allow us to read datagrams sent from any source.
                        var receivedResults = await udpClient.ReceiveAsync();
                        byte[] packet_buffer;
                        packet_buffer = receivedResults.Buffer;

                        pme(string.Format("Rx Packet. Size {0}", receivedResults.Buffer.Length));

                        //if (LongTermDebug == true)

                        ++PacketsRead;

                        //****************************PERFORMANCE ISSUE**************************
                        //if (quietMode == false) tb_PacketsRead.Text = PacketsRead.ToString();//THIS COULD BE SLOW - Updates to UI should be in separate thread


                    }//end while (true)

                    //bn_listen.Text = "Start Listening";

                }//end using
            });//end Task.Run...
            
        }
    }



    public class CoT_PLI_Msg
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

        public CoT_PLI_Msg()
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