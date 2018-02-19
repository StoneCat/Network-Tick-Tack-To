/*
 * User: 
 * Date: 29.01.2018
 * Time: 20:01
 */
using System;
using System.Windows.Forms;

namespace Network_Tick_Tack_To
{
	public partial class MainForm : Form
	{
		TClient client;
		
		public MainForm()
		{
			InitializeComponent();
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
                // sonst direktes Schreiben möglich
            	textBox1.Text = textBox1.Text + "\n\r" + msg;
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
		
		private void schalteX(Label clickLabel) {
			client.sendMessage(clickLabel.Text + "; X");
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			this.schalteX((Label) sender);
		}
		void Label2Click(object sender, EventArgs e)
		{
			this.schalteX((Label) sender);
		}
		void Label3Click(object sender, EventArgs e)
		{
			this.schalteX((Label) sender);
		}
		void Label6Click(object sender, EventArgs e)
		{
			this.schalteX((Label) sender);
		}
		void Label5Click(object sender, EventArgs e)
		{
			this.schalteX((Label) sender);
		}
		void Label4Click(object sender, EventArgs e)
		{
			this.schalteX((Label) sender);
		}
		void Label9Click(object sender, EventArgs e)
		{
			this.schalteX((Label) sender);
		}
		void Label8Click(object sender, EventArgs e)
		{
			this.schalteX((Label) sender);
		}
		void Label7Click(object sender, EventArgs e)
		{
			this.schalteX((Label) sender);
		}
	}
}
