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
		public MainForm()
		{
			InitializeComponent();
		}
		
		private void schalteX(Label clickLabel) {
			clickLabel.Text = "X";
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
