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
		
		private void changeValue(JSONMessage msg) {
			msg.PositionValue = "X";
			msg.Type = "FieldChange";
			client.sendMessage(JsonConvert.SerializeObject(msg));
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			//TopLeft
			this.changeValue(new JSONMessage("TL"));
		}
		void Label2Click(object sender, EventArgs e)
		{
			//TopMid
			this.changeValue(new JSONMessage("TM"));
		}
		void Label3Click(object sender, EventArgs e)
		{
			//TopRight
			this.changeValue(new JSONMessage("TR"));
		}
		void Label6Click(object sender, EventArgs e)
		{
			//MidLeft
			this.changeValue(new JSONMessage("ML"));
		}
		void Label5Click(object sender, EventArgs e)
		{
			//MidMid
			this.changeValue(new JSONMessage("MM"));
		}
		void Label4Click(object sender, EventArgs e)
		{
			//MidRight
			this.changeValue(new JSONMessage("MR"));
		}
		void Label9Click(object sender, EventArgs e)
		{
			//BottomLeft
			this.changeValue(new JSONMessage("BL"));
		}
		void Label8Click(object sender, EventArgs e)
		{
			//BottomMid
			this.changeValue(new JSONMessage("BM"));
		}
		void Label7Click(object sender, EventArgs e)
		{
			//BottomRight
			this.changeValue(new JSONMessage("BR"));
		}
	}
}
