using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Drawing;

namespace LWClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Commands
        {
            [DataMember]
            public string ct;

            [DataMember]
            public string bg;

            [DataMember]
            public int cl;

            [DataMember]
            public bool sv;
        }

        [DataContract]
        public class EventJoin
        {
            [DataMember]
            public string mobileStartAt;

            [DataMember]
            public string _winnerId;

            [DataMember]
            public string _showId;

            [DataMember]
            public string _user_location_Id;

            [DataMember]
            public string mobileTimeOffset;

            [DataMember]
            public string mobileTime;

            [DataMember]
            public string _id;

            [DataMember]
            public Commands[] commands;
        }

        [DataContract]
        public class ULResult
        {
            [DataMember]
            public int logicalRow;

            [DataMember]
            public int logicalCol;

            [DataMember]
            public string _eventId;

            [DataMember]
            public string userKey;

            [DataMember]
            public string _id;
        }

        [DataContract]
        public class EJ
        {
            [DataMember]
            public string mobileTime;
        }

        [DataContract]
        public class UL
        {
            //   "{ \"userKey\": \"9F2A87E8-9458-494B-9637-EdB54B15519CfTT\", \"userSeat\": { \"level\": \"floor\", \"section\": \"101\", \"row\": \"22\", \"seat\": \"23\" } }
            [DataMember]
            public string userKey;

            [DataMember]
            public userSeat userSeat;
        }

        [DataContract]
        public class userSeat
        {
            [DataMember]
            public string level;

            [DataMember]
            public string section;

            [DataMember]
            public string row;

            [DataMember]
            public string seat;
        }

        static public Stack<string> ulStack = new Stack<string>();

        static public Stack<EventJoin> commandsStack = new Stack<EventJoin>();

        static public bool inShow = false;

        static public int currentRow = 1;

        static public int currentSeat = 1;

        static string MakeWebCall(string url, bool isPost = false, UL userLocationToRegister = null, EJ eventJoin = null)
        {
            try
            {
                using (var client = new WebClient())
                {
                    // New code:
                    //client.BaseAddress = new Uri("http://main-1156949061.us-west-2.elb.amazonaws.com/");
                    //client.BaseAddress = "http://www.litewaveinc.com/";
                    client.BaseAddress = "http://127.0.0.1:3000/";
                    //client.Headers.Add("Accept: application/json");
                    client.Headers.Add("Content-Type", "application/json");

                    string response = null;
                    if (isPost)
                    {
                        MemoryStream ms = new MemoryStream();
                        DataContractJsonSerializer jsonSer;
                        if (userLocationToRegister != null)
                        {
                            //Create a Json Serializer for our type
                            jsonSer = new DataContractJsonSerializer(typeof(UL));

                            // use the serializer to write the object to a MemoryStream
                            jsonSer.WriteObject(ms, userLocationToRegister);
                        }
                        else if (eventJoin != null)
                        {
                            //Create a Json Serializer for our type
                            jsonSer = new DataContractJsonSerializer(typeof(EJ));

                            // use the serializer to write the object to a MemoryStream
                            jsonSer.WriteObject(ms, eventJoin);
                        }
                        ms.Position = 0;

                        // use a Stream reader to construct the StringContent (Json)
                        StreamReader sr = new StreamReader(ms);
                        //StringContent theContent = new StringContent(sr.ReadToEnd(), System.Text.Encoding.UTF8, "application/json");

                        string data = sr.ReadToEnd();
                        byte[] postArray = Encoding.ASCII.GetBytes(data);
                        byte[] responseArray = client.UploadData(url, "POST", postArray);
                        response = Encoding.ASCII.GetString(responseArray);
                    }
                    else
                    {
                        Stream data = client.OpenRead(url);
                        StreamReader reader = new StreamReader(data);
                        response = reader.ReadToEnd();
                    }

                    if (response != null)
                    {
                        if (isPost && userLocationToRegister != null)
                        {
                            ULResult ulResult = new ULResult();
                            DataContractJsonSerializer jsonSer;
                            jsonSer = new DataContractJsonSerializer(typeof(ULResult));

                            byte[] byteArray = Encoding.ASCII.GetBytes(response);
                            MemoryStream stream = new MemoryStream(byteArray);
                            ulResult = (ULResult)jsonSer.ReadObject(stream);
                            ulStack.Push(ulResult._id);
                        }
                        else if (isPost && eventJoin != null)
                        {
                            EventJoin ej = new EventJoin();
                            DataContractJsonSerializer jsonSer;
                            jsonSer = new DataContractJsonSerializer(typeof(EventJoin));

                            byte[] byteArray = Encoding.ASCII.GetBytes(response);
                            MemoryStream stream = new MemoryStream(byteArray);
                            ej = (EventJoin)jsonSer.ReadObject(stream);
                            commandsStack.Push(ej);
                        }

                        return response;
                    }
                }
            }
            catch (WebException webEx)
            {
                HttpWebResponse response = (System.Net.HttpWebResponse)webEx.Response;
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    System.Diagnostics.Debug.WriteLine("Not found!");
                }
            }

            return null;
        }

        // NOTE: these aren't needed to test a show, BUT would be good to call and parse as a test (separate project really)
        public void CallGetLevelOne()
        {
            MakeWebCall("api/stadiums/55de78afa1d569ec11646bc9/levels/one");
        }

        public void CallGetLevelTwo()
        {
            MakeWebCall("api/stadiums/55de78afa1d569ec11646bc9/levels/two");
        }

        public void CallGetLevelThree()
        {
            MakeWebCall("api/stadiums/55de78afa1d569ec11646bc9/levels/three");
        }

        public void CallGetClient()
        {
            MakeWebCall("api/stadiums/client/5260316cbf80240000000001");
        }

        public void CallGetEventsAPI()
        {
            MakeWebCall("api/clients/5260316cbf80240000000001/events/");
        }

        public string CallPostUL(string section)
        {
            if (inShow)
            {
                // we are in a show, users can't join anymore.
                return null;
            }

            Guid g = Guid.NewGuid();
            UL userLocation = new UL();

            userLocation.userSeat = new userSeat();
            // Generate unique id and save result for EJ.
            userLocation.userKey = g.ToString();
            userLocation.userSeat.level = "floor1";
            userLocation.userSeat.section = section;
            userLocation.userSeat.row = currentRow.ToString();
            userLocation.userSeat.seat = DateTime.Now.Ticks.ToString();   // currentSeat.ToString();
            currentRow++;
            currentSeat++;

            // PROD 
            //RunAsync("api/events/5704a152182753c925df18f0/user_locations", true, userLocation).Wait(1120000);
            //return MakeWebCall("api/events/57e029eaa4cfb00f1f9a79e4/user_locations", true, userLocation);
            return MakeWebCall("api/events/55f4ba853451c8bc227664ff/user_locations", true, userLocation);
        }

        public void CallPostEJ()
        {
            EJ eventJoin = new EJ();

            // Introduce some variability - add or subtract Xms from the time.
            eventJoin.mobileTime = new DateTime(DateTime.Now.Ticks).ToString();

            int ulCount = ulStack.Count;
            int index = 1;

            while (index <= ulCount)
            {
                // Get next UL from stack and join show.
                string api = "api/user_locations/" + ulStack.Pop() + "/event_joins";
                if (MakeWebCall(api, true, null, eventJoin) == null)
                {
                    break;
                }

                index++;
            }
        }

        private void executePhoneCmd(EventJoin ej)
        {
            DateTime startShowTime = Convert.ToDateTime(ej.mobileStartAt);

            while (DateTime.Now.Ticks < startShowTime.Ticks)
            {
                // Wait here until time to start the show
            }

            string black = "0,0,0";
            string red = "216,19,37";
            //string white = "162,157,176";
            int length = ej.commands.Length;
            int index = 0;
            Commands cmds = null;

            while (index < length)
            {
                cmds = ej.commands[index];
                if (cmds.bg != null)
                {
                    if (cmds.bg == black)
                    {
                        textBox1.BackColor = Color.FromName("Black");
                    }
                    else if (cmds.bg == red)
                    {
                        textBox1.BackColor = Color.FromName("Red");
                    }
                    else
                    {
                        textBox1.BackColor = Color.FromName("White");
                    }
                }
                else //if (cmds.ct =="w")
                {
                    textBox1.BackColor = Color.FromName("Purple");
                }

                DateTime currentTime = new DateTime(DateTime.Now.Ticks);
                int currentTimeInMs = currentTime.Millisecond;
                int waitTimeInMs = currentTime.Millisecond + cmds.cl;
                while (currentTimeInMs < waitTimeInMs)
                {
                    // Wait here until time to execute the next command.
                    currentTimeInMs++;
                }

                index++;
            }
        }

        private void startShow_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.FromName("Purple");

            ulStack.Clear();
            commandsStack.Clear();

            // TODO: 
            // Need to create a method for returning the seat info for the next logical section.
            // Need a generic parse command method to update UI elements

            // Need to set up an array of vPhones to do the following:
            // Call CallGetEventsAPI to get the event
            // Call CallPostUL to join that event. 
            // Admin needs to create a Show to join.
            // Once show is created Call CallPostEJ to get the commands
            // Parse the commands and update the UI accordingly.

            //        CallGetClient();

            int section = 101;

            while (section < 124)
            {
                if (CallPostUL(section.ToString()) == null)
                {
                    break;
                }

                section++;

                if (section == 121)
                {
                    // There is no section 121.
                    section++;
                }
            }

            CallPostEJ();

            textBox1.BackColor = Color.FromName("Purple");

            executePhoneCmd(commandsStack.Pop());
        }
    }



}
