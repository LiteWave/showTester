using System;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Threading;

namespace LWClient
{
  public partial class Form1 : Form
  {
    //private BackgroundWorker[] backgroundWorkerArray;
    private BackgroundWorker backgroundWorker1;
    private BackgroundWorker backgroundWorker2;
    private BackgroundWorker backgroundWorker3;
    private BackgroundWorker backgroundWorker4;
    private BackgroundWorker backgroundWorker5;
    private BackgroundWorker backgroundWorker6;
    private BackgroundWorker backgroundWorker7;
    private BackgroundWorker backgroundWorker8;
    private BackgroundWorker backgroundWorker9;
    private BackgroundWorker backgroundWorker10;
    private BackgroundWorker backgroundWorker11;
    private BackgroundWorker backgroundWorker12;
    private BackgroundWorker backgroundWorker13;
    private BackgroundWorker backgroundWorker14;
    private BackgroundWorker backgroundWorker15;
    private BackgroundWorker backgroundWorker16;
    private BackgroundWorker backgroundWorker17;
    private BackgroundWorker backgroundWorker18;
    private BackgroundWorker backgroundWorker19;
    private BackgroundWorker backgroundWorker20;
    private BackgroundWorker backgroundWorker21;
    private BackgroundWorker backgroundWorker22;

    public Form1()
    {
      InitializeComponent();

      InitThreads();
    }

    public void InitThreads()
    {
      backgroundWorker1 = new BackgroundWorker();
      backgroundWorker1.WorkerReportsProgress = true;
      backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
      backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);

      backgroundWorker2 = new BackgroundWorker();
      backgroundWorker2.WorkerReportsProgress = true;
      backgroundWorker2.DoWork += new DoWorkEventHandler(backgroundWorker2_DoWork);
      backgroundWorker2.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker2_ProgressChanged);

      backgroundWorker3 = new BackgroundWorker();
      backgroundWorker3.WorkerReportsProgress = true;
      backgroundWorker3.DoWork += new DoWorkEventHandler(backgroundWorker3_DoWork);
      backgroundWorker3.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker3_ProgressChanged);

      backgroundWorker4 = new BackgroundWorker();
      backgroundWorker4.WorkerReportsProgress = true;
      backgroundWorker4.DoWork += new DoWorkEventHandler(backgroundWorker4_DoWork);
      backgroundWorker4.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker4_ProgressChanged);

      backgroundWorker5 = new BackgroundWorker();
      backgroundWorker5.WorkerReportsProgress = true;
      backgroundWorker5.DoWork += new DoWorkEventHandler(backgroundWorker5_DoWork);
      backgroundWorker5.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker5_ProgressChanged);

      backgroundWorker6 = new BackgroundWorker();
      backgroundWorker6.WorkerReportsProgress = true;
      backgroundWorker6.DoWork += new DoWorkEventHandler(backgroundWorker6_DoWork);
      backgroundWorker6.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker6_ProgressChanged);

      backgroundWorker7 = new BackgroundWorker();
      backgroundWorker7.WorkerReportsProgress = true;
      backgroundWorker7.DoWork += new DoWorkEventHandler(backgroundWorker7_DoWork);
      backgroundWorker7.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker7_ProgressChanged);

      backgroundWorker8 = new BackgroundWorker();
      backgroundWorker8.WorkerReportsProgress = true;
      backgroundWorker8.DoWork += new DoWorkEventHandler(backgroundWorker8_DoWork);
      backgroundWorker8.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker8_ProgressChanged);

      backgroundWorker9 = new BackgroundWorker();
      backgroundWorker9.WorkerReportsProgress = true;
      backgroundWorker9.DoWork += new DoWorkEventHandler(backgroundWorker9_DoWork);
      backgroundWorker9.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker9_ProgressChanged);

      backgroundWorker10 = new BackgroundWorker();
      backgroundWorker10.WorkerReportsProgress = true;
      backgroundWorker10.DoWork += new DoWorkEventHandler(backgroundWorker10_DoWork);
      backgroundWorker10.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker10_ProgressChanged);

      backgroundWorker11 = new BackgroundWorker();
      backgroundWorker11.WorkerReportsProgress = true;
      backgroundWorker11.DoWork += new DoWorkEventHandler(backgroundWorker11_DoWork);
      backgroundWorker11.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker11_ProgressChanged);

      backgroundWorker12 = new BackgroundWorker();
      backgroundWorker12.WorkerReportsProgress = true;
      backgroundWorker12.DoWork += new DoWorkEventHandler(backgroundWorker12_DoWork);
      backgroundWorker12.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker12_ProgressChanged);

      backgroundWorker13 = new BackgroundWorker();
      backgroundWorker13.WorkerReportsProgress = true;
      backgroundWorker13.DoWork += new DoWorkEventHandler(backgroundWorker13_DoWork);
      backgroundWorker13.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker13_ProgressChanged);

      backgroundWorker14 = new BackgroundWorker();
      backgroundWorker14.WorkerReportsProgress = true;
      backgroundWorker14.DoWork += new DoWorkEventHandler(backgroundWorker14_DoWork);
      backgroundWorker14.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker14_ProgressChanged);

      backgroundWorker15 = new BackgroundWorker();
      backgroundWorker15.WorkerReportsProgress = true;
      backgroundWorker15.DoWork += new DoWorkEventHandler(backgroundWorker15_DoWork);
      backgroundWorker15.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker15_ProgressChanged);

      backgroundWorker16 = new BackgroundWorker();
      backgroundWorker16.WorkerReportsProgress = true;
      backgroundWorker16.DoWork += new DoWorkEventHandler(backgroundWorker16_DoWork);
      backgroundWorker16.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker16_ProgressChanged);

      backgroundWorker17 = new BackgroundWorker();
      backgroundWorker17.WorkerReportsProgress = true;
      backgroundWorker17.DoWork += new DoWorkEventHandler(backgroundWorker17_DoWork);
      backgroundWorker17.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker17_ProgressChanged);

      backgroundWorker18 = new BackgroundWorker();
      backgroundWorker18.WorkerReportsProgress = true;
      backgroundWorker18.DoWork += new DoWorkEventHandler(backgroundWorker18_DoWork);
      backgroundWorker18.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker18_ProgressChanged);

      backgroundWorker19 = new BackgroundWorker();
      backgroundWorker19.WorkerReportsProgress = true;
      backgroundWorker19.DoWork += new DoWorkEventHandler(backgroundWorker19_DoWork);
      backgroundWorker19.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker19_ProgressChanged);

      backgroundWorker20 = new BackgroundWorker();
      backgroundWorker20.WorkerReportsProgress = true;
      backgroundWorker20.DoWork += new DoWorkEventHandler(backgroundWorker20_DoWork);
      backgroundWorker20.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker20_ProgressChanged);

      backgroundWorker21 = new BackgroundWorker();
      backgroundWorker21.WorkerReportsProgress = true;
      backgroundWorker21.DoWork += new DoWorkEventHandler(backgroundWorker21_DoWork);
      backgroundWorker21.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker21_ProgressChanged);

      backgroundWorker22 = new BackgroundWorker();
      backgroundWorker22.WorkerReportsProgress = true;
      backgroundWorker22.DoWork += new DoWorkEventHandler(backgroundWorker22_DoWork);
      backgroundWorker22.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker22_ProgressChanged);
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

    static public string[] ulStack = new string[100];

    static public EventJoin[] commandsStack = new EventJoin[100];

    static public int ULCount = 0;

    static public int EJCount = 0;

    static public bool inShow = false;

    static public int currentRow = 1;

    static public int currentSeat = 1;

    static string MakeWebCall(string url, bool isPost = false, UL userLocationToRegister = null, EJ eventJoin = null, int index = 0)
    {
      try
      {
        using (var client = new WebClient())
        {
          // New code:
          //client.BaseAddress = new Uri("http://main-1156949061.us-west-2.elb.amazonaws.com/");
          client.BaseAddress = "http://www.litewaveinc.com/";
          //client.BaseAddress = "http://127.0.0.1:3000/";
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
              ulStack[ULCount] = ulResult._id;
              ULCount++;
            }
            else if (isPost && eventJoin != null)
            {
              EventJoin ej = new EventJoin();
              DataContractJsonSerializer jsonSer;
              jsonSer = new DataContractJsonSerializer(typeof(EventJoin));

              byte[] byteArray = Encoding.ASCII.GetBytes(response);
              MemoryStream stream = new MemoryStream(byteArray);
              ej = (EventJoin)jsonSer.ReadObject(stream);
              commandsStack[index] = ej;
              EJCount++;
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
      //userLocation.userSeat.section = "101";
      userLocation.userSeat.row = currentRow.ToString();
      //userLocation.userSeat.row = "1";
      userLocation.userSeat.seat = DateTime.Now.Ticks.ToString();   // currentSeat.ToString();
      //userLocation.userSeat.seat = "1";   // currentSeat.ToString();
      currentRow++;
      currentSeat++;

      // PROD 
      return MakeWebCall("api/events/57f4856cc15516d90fe4e5e1/user_locations", true, userLocation);

      // Local
      //return MakeWebCall("api/events/55f4ba853451c8bc227664ff/user_locations", true, userLocation);
    }

    public bool CallPostEJ(int index, double randomDiff = 0)
    {
      System.Diagnostics.Debug.WriteLine("index=" + index.ToString());

      EJ eventJoin = new EJ();

      // Introduce some variability - add or subtract Xms from the time.
      DateTime Now = new DateTime(DateTime.Now.Ticks);
      eventJoin.mobileTime = Now.AddMinutes(randomDiff).ToString();

      // Get next UL from stack and join show.
      string api = "api/user_locations/" + ulStack[index] + "/event_joins";
      bool result = MakeWebCall(api, true, null, eventJoin, index) != null;
      return result;
    }

    // This event handler deals with the results of the
    // background operation.
    private void backgroundWorker1_RunWorkerCompleted(
        object sender, RunWorkerCompletedEventArgs e)
    {
      // First, handle the case where an exception was thrown.
      if (e.Error != null)
      {
        MessageBox.Show(e.Error.Message);
      }
      else if (e.Cancelled)
      {
        // Next, handle the case where the user canceled 
        // the operation.
        // Note that due to a race condition in 
        // the DoWork event handler, the Cancelled
        // flag may not have been set, even though
        // CancelAsync was called.
      }
      else
      {
        // Finally, handle the case where the operation 
        // succeeded.
      }
    }

    public bool executePhoneCmd(int cmdIndex, BackgroundWorker worker, DoWorkEventArgs e)
    {
      EventJoin ej = commandsStack[cmdIndex];
      DateTime startShowTime = Convert.ToDateTime(ej.mobileStartAt);

      while (DateTime.Now.Ticks < startShowTime.Ticks)
      {
        // Wait here until time to start the show
        Thread.Sleep(50);
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
            worker.ReportProgress(1, "Black");
            //textBox1.BackColor = Color.FromName("Black");
          }
          else if (cmds.bg == red)
          {
            worker.ReportProgress(1, "Red");
            //textBox1.BackColor = Color.FromName("Red");
          }
          else
          {
            worker.ReportProgress(1, "White");
            //textBox1.BackColor = Color.FromName("White");
          }
        }
        else //if (cmds.ct =="w")
        {
          worker.ReportProgress(1, "White");
          //textBox1.BackColor = Color.FromName("Purple");
        }

        Thread.Sleep(cmds.cl);

        index++;
      }

      return true;
    }

    private void startShow_Click(object sender, EventArgs e)
    {
      ULCount = 0;
      EJCount = 0;

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
    }

    private void joinShow_Click(object sender, EventArgs e)
    {
      if (ulStack[0] == null)
      {
        return;
      }

      // Start the asynchronous operation.
      //int sleepTime = 10;
      backgroundWorker1.RunWorkerAsync(0);
      //Thread.Sleep(sleepTime);
      backgroundWorker2.RunWorkerAsync(1);
      //Thread.Sleep(sleepTime);
      backgroundWorker3.RunWorkerAsync(2);
      //Thread.Sleep(sleepTime);
      backgroundWorker4.RunWorkerAsync(3);
      //Thread.Sleep(sleepTime);
      backgroundWorker5.RunWorkerAsync(4);
      //Thread.Sleep(sleepTime);
      backgroundWorker6.RunWorkerAsync(5);
      //Thread.Sleep(sleepTime);
      backgroundWorker7.RunWorkerAsync(6);
      //Thread.Sleep(sleepTime);
      backgroundWorker8.RunWorkerAsync(7);
      //Thread.Sleep(sleepTime);
      backgroundWorker9.RunWorkerAsync(8);
      //Thread.Sleep(sleepTime);
      backgroundWorker10.RunWorkerAsync(9);
      //Thread.Sleep(sleepTime);
      backgroundWorker11.RunWorkerAsync(10);
      //Thread.Sleep(sleepTime);
      backgroundWorker12.RunWorkerAsync(11);
      //Thread.Sleep(sleepTime);
      backgroundWorker13.RunWorkerAsync(12);
      //Thread.Sleep(sleepTime);
      backgroundWorker14.RunWorkerAsync(13);
      //Thread.Sleep(sleepTime);
      backgroundWorker15.RunWorkerAsync(14);
      //Thread.Sleep(sleepTime);
      backgroundWorker16.RunWorkerAsync(15);
      //Thread.Sleep(sleepTime);
      backgroundWorker17.RunWorkerAsync(16);
      //Thread.Sleep(sleepTime);
      backgroundWorker18.RunWorkerAsync(17);
      //Thread.Sleep(sleepTime);
      backgroundWorker19.RunWorkerAsync(18);
      //Thread.Sleep(sleepTime);
      backgroundWorker20.RunWorkerAsync(19);
      //Thread.Sleep(sleepTime);
      backgroundWorker21.RunWorkerAsync(20);
      backgroundWorker22.RunWorkerAsync(21);
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;

      if (!CallPostEJ(0)) return;

      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(1, 1)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(2, -1)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(3, -5)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(4, 5)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(5)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker7_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(6)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker8_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(7)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker9_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(8)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker10_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(9)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker11_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(10)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker12_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(11)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker13_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(12)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker14_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(13)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker15_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(14)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker16_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(15)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker17_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(16)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker18_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(17)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker19_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(18)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker20_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(19, -10)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker21_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(20, 10)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    private void backgroundWorker22_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      if (!CallPostEJ(21)) return;
      e.Result = executePhoneCmd((int)e.Argument, worker, e);
    }

    // This event handler updates the progress.
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox1.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox2.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox3.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker4_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox4.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker5_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox5.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker6_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox6.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker7_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox7.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker8_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox8.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker9_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox9.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker10_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox10.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker11_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox11.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker12_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox12.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker13_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox13.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker14_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox14.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker15_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox15.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker16_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox16.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker17_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox17.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker18_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox18.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker19_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox19.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker20_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox20.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker21_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox21.BackColor = Color.FromName(e.UserState.ToString());
    }

    // This event handler updates the progress.
    private void backgroundWorker22_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      textBox22.BackColor = Color.FromName(e.UserState.ToString());
    }
  }
}