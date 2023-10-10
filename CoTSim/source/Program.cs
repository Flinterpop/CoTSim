using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

using System.Net.NetworkInformation;


using Google.Protobuf;


using Atakmap.Commoncommo.Protobuf.V1;
using System.IO;

namespace CoTSharpTest
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("In Proto buf test");

            PrecisionLocation location = new PrecisionLocation() { Altsrc ="MODEA", Geopointsrc = "PTF"  };

            Group myGroup= new Group() {  Name="Cyan", Role = "Team Member"} ;
            Contact myContact = new Contact() { Callsign="CSHARP", Endpoint = "192.168.1.101:4242:tcp" };
            Status myStatus = new Status() { Battery = 92 };
            Takv myTakv = new Takv() { Device = "MAC", Os= "Win32", Platform ="WinTAK-CAN", Version="4.9.0.156" };
            Track myTrack = new Track() { Course =34, Speed=2.0 };
            Detail myDetail= new Detail() { Group=myGroup, Contact=myContact, Takv= myTakv, Status= myStatus, Track=myTrack};
            //CotEvent myCot = new CotEvent() { How ="h-e", Access="Undefined", Detail=myDetail, Uid = "23234", Lat =45.111,Lon=-75.2, Hae = 100 , Ce = 9999999 , Le = 9999999, Type = "a-f-G-U-C-I", SendTime= 1696854260000, StaleTime = 1696854260000, StartTime = 1696854260000 };
            CotEvent myCot = new CotEvent() { How = "h-e", Access = "Undefined", Detail = myDetail, Uid = "23234", Lat = 45.111, Lon = -75.2, Hae = 100, Ce = 9999999, Le = 9999999, Type = "a-f-G-U-C-I"};
            myCot.StartTime =1696854260000;
            myCot.SendTime = 1696854260000;
            myCot.StaleTime= 1696859960000;

            TakControl myTakControl = new TakControl() { ContactUid = "34344",  };
            //TakMessage myTakMessage = new TakMessage() { CotEvent = myCot, TakControl = myTakControl };
            TakMessage myTakMessage = new TakMessage() { CotEvent = myCot};




            //store bytes
            byte[] CotEventBytes;

            // Write to a stream
            using (MemoryStream stream = new MemoryStream())
            {
                myTakMessage.WriteTo(stream);
                CotEventBytes = stream.ToArray();
            }
            // Read from a stream bytes
            CotEvent.Parser.ParseFrom(CotEventBytes);


            // Write to a file
            using (Stream output = File.OpenWrite("myCOTdata.data"))
            {
                var sentinel = new byte[] { 0xbf, 0x01, 0xbf};
                output.Write(sentinel, 0,3);
                //var ba = myTakMessage.ToByteArray();
                myTakMessage.WriteTo(output);
            }


            // Read from a data file//won't work until we strip out the first 3 bytes (sentinel)
            using (Stream output = File.OpenRead("myCOTdata.data"))
            {
                //var CoTFromFile = CotEvent.Parser.ParseFrom(output);
              
            }

            var file = new FileStream("myCOTdata.data", FileMode.Open);
            var mem = new MemoryStream();
            file.CopyTo(mem);
            // getting the internal buffer (no additional copying)
            byte[] buffer = mem.GetBuffer();
            //long length = mem.Length; // the actual length of the data 
                                      // (the array may be longer)

            // if you need the array to be exactly as long as the data
            //byte[] truncated = mem.ToArray(); // makes another copy


            var client = new UdpClient();
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.1.255"), 6969); // endpoint where server is listening
            client.Connect(ep);

            client.Send(buffer, (int)mem.Length );






        }
    }
}
