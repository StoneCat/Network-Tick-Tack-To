using System;
using System.Windows.Forms;
using Network_Tick_Tack_To.JSONObjects;
using Newtonsoft.Json;

namespace Network_Tick_Tack_To
{
	public partial class MainForm : Form
	{
		TClient client;
		
		public MainForm()
		{
			InitializeComponent();
			//Install-Package Newtonsoft.Json -Version 3.5.8 
			string creditApplicationJson = JsonConvert.SerializeObject(new JSONMessage());
			textBox1.Text = creditApplicationJson;
		}
		
		// Delegat-Typ für Thread-übergreifenden Methodenaufruf
        delegate void InvokeDelegate (string s);

        // Diese Methode wird aus dem Thread aufgerufen
        public void showClientMessage(string msg)
        {
            // Wenn unsicherer Zustand
            if (InvokeRequired)
                BeginInvoke(new InvokeDelegate(showClientMessage), msg);
            else
            {
            	if (msg.Contains("{")) {
            		JSONMessage msgBack = JsonConvert.DeserializeObject<JSONMessage>(msg);
            		textBox1.Text = textBox1.Text + msgBack.PositionClick;
            		//TODO: Add Text Change in GameLogic Class
            	}
            }

        }
        
        void Button1Click(object sender, EventArgs e)
		{
        	client = new TClient(this, "127.0.0.1");
        	button1.Enabled = false;
        	button2.Enabled = true;
		}

		void Button2Click(object sender, EventArgs e)
		{
			textBox1.Text = textBox1.Text + "\n\rClosing ...";
            if (client != null)
            {
                client.sendMessage("<q>");
                button2.Enabled = false;
                button1.Enabled = true;
            }
		}
		
		public void sendServerMassage(JSONMessage msg) {
			client.sendMessage(JsonConvert.SerializeObject(msg));
		}
	}
}
