using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;

namespace LWClient
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
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

    static public Stack<string> commandsStack = new Stack<string>();

    static public bool inShow = false;

    static public int currentRow = 1;

    static public int currentSeat = 1;

    static async Task<string> RunAsync(string url, bool isPost = false, UL userLocationToRegister = null, EJ eventJoin = null)
    {
      using (var client = new HttpClient())
      {
        // New code:
        //client.BaseAddress = new Uri("http://main-1156949061.us-west-2.elb.amazonaws.com/");
        client.BaseAddress = new Uri("http://www.litewaveinc.com/");
        //client.BaseAddress = new Uri("http://127.0.0.1:3000/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        client.Timeout = new TimeSpan(0, 0, 0, 0, 20000);

        HttpResponseMessage response = null;
        if (isPost)
        {
          MemoryStream ms = new MemoryStream();
          System.Runtime.Serialization.Json.DataContractJsonSerializer jsonSer;
          if (userLocationToRegister != null)
          {
            //Create a Json Serializer for our type
            jsonSer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(UL));

            // use the serializer to write the object to a MemoryStream
            jsonSer.WriteObject(ms, userLocationToRegister);
          }
          else if (eventJoin != null)
          {
            //Create a Json Serializer for our type
            jsonSer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(EJ));

            // use the serializer to write the object to a MemoryStream
            jsonSer.WriteObject(ms, eventJoin);
          }
          ms.Position = 0;

          // use a Stream reader to construct the StringContent (Json)
          StreamReader sr = new StreamReader(ms);
          StringContent theContent = new StringContent(sr.ReadToEnd(), System.Text.Encoding.UTF8, "application/json");

          response = await client.PostAsync(url, theContent);
        }
        else
        {
          response = await client.GetAsync(url);
        }

        if (response.IsSuccessStatusCode)
        {
          string s_response = response.ToString();
          string s_response_content = await response.Content.ReadAsStringAsync();

          if (isPost)
          {
            if (userLocationToRegister != null)
            {
              ULResult ulResult = new ULResult();
              System.Runtime.Serialization.Json.DataContractJsonSerializer jsonSer;
              jsonSer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(ULResult));
              Stream streamContent = await response.Content.ReadAsStreamAsync();
              ulResult = (ULResult)jsonSer.ReadObject(streamContent);
              ulStack.Push(ulResult._id);
            }
            else
            {
              commandsStack.Push(response.ToString());
            }
          }

          return response.ToString();
        }
        else
        {
          if (eventJoin != null)
          {
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
              inShow = false;
              return System.Net.HttpStatusCode.OK.ToString();
            }
            else
            {
              // if EJ returned successful we are in a show. Stop UL from joining.
              inShow = true;
            }
          }

          return response.ToString();
        }
      }
    }

    // NOTE: these aren't needed to test a show, BUT would be good to call and parse as a test (separate project really)
    public void CallGetLevelOne()
    {
      RunAsync("api/stadiums/55de78afa1d569ec11646bc9/levels/one").Wait(1120000);
    }

    public void CallGetLevelTwo()
    {
      RunAsync("api/stadiums/55de78afa1d569ec11646bc9/levels/two").Wait(1120000);
    }

    public void CallGetLevelThree()
    {
      RunAsync("api/stadiums/55de78afa1d569ec11646bc9/levels/three").Wait(1120000);
    }

    public void CallGetClient()
    {
      RunAsync("api/stadiums/client/5260316cbf80240000000001").Wait(1120000);
    }

    public void CallGetEventsAPI()
    {
      RunAsync("api/clients/5260316cbf80240000000001/events/").Wait(1120000);
    }

    public void CallPostUL(string section)
    {
      if (inShow)
      {
        // we are in a show, users can't join anymore.
        return;
      }

      Guid g = Guid.NewGuid();
      UL userLocation = new UL();

      userLocation.userSeat = new userSeat();
      // Generate unique id and save result for EJ.
      userLocation.userKey = g.ToString();
      userLocation.userSeat.level = "floor1";
      userLocation.userSeat.section = section;
      userLocation.userSeat.row = currentRow.ToString();
      userLocation.userSeat.seat = new DateTime(DateTime.Now.Ticks).ToString();   // currentSeat.ToString();
      currentRow++;
      currentSeat++;

      // PROD 
      //RunAsync("api/events/5704a152182753c925df18f0/user_locations", true, userLocation).Wait(1120000);
      RunAsync("api/events/57e029eaa4cfb00f1f9a79e4/user_locations", true, userLocation).Wait(1120000);
    }

    public void CallPostEJ()
    {
      EJ eventJoin = new EJ();
      eventJoin.mobileTime = new DateTime(DateTime.Now.Ticks).ToString();

      // Get next UL from stack and join show.
      string api = "api/user_locations/" + ulStack.Pop() + "/event_joins";
      RunAsync(api, true, null, eventJoin).Wait(1120000);
    }

    private void startShow_Click(object sender, EventArgs e)
    {
      // TODO: 
      // Need to create a method for returning the seat info for the next logical section.
      // Need a generic parse command method to update UI elements

      // Need to set up an array of vPhones to do the following:
      // Call CallGetEventsAPI to get the event
      // Call CallPostUL to join that event. 
      // Admin needs to create a Show to join.
      // Once show is created Call CallPostEJ to get the commands
      // Parse the commands and update the UI accordingly.

      int section = 101;

      while (section < 124)
      {
        CallPostUL(section.ToString());

        section++;

        if (section == 121)
        {
          // There is no section 121.
          section++;
        }
      }

      CallPostEJ();
    }
  }



}
