using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Network_Tick_Tack_To.JSONObjects;

namespace Network_Tick_Tack_To
{
	public class GamePitch
	{
		private List<List<Label>> _gamePitchLabels = new List<List<Label>>();
		private MainForm _mainGui;
		
		public GamePitch(MainForm aClientForm) {
			this._mainGui = aClientForm;
			this._definePitchLabels(2);
		}
		
		public GamePitch(MainForm aClientForm, int rows) {
			this._mainGui = aClientForm;
			this._definePitchLabels(rows);
		}
		
		private void _definePitchLabels (int rows) {
			// Define Default Values;
			int DrawingPointX = 17;
			int DrawingPointY = 160;
			
			for (int down = 0; down <= rows; down++) {
				List<Label> tmp_lst = new List<Label>();
				for (int left = 0; left <= rows; left++) {
					Label tmplbl = new Label();
					tmplbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
					tmplbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
					tmplbl.Location = new System.Drawing.Point(DrawingPointX, DrawingPointY);
					tmplbl.Name = down + "#" + left;
					tmplbl.Size = new System.Drawing.Size(75, 75);
					tmplbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
					tmplbl.Click += new System.EventHandler(this.PitchItemClick);
					tmp_lst.Add(tmplbl);
					
					DrawingPointX = DrawingPointX + 85;
				}
				this._gamePitchLabels.Add(tmp_lst);
				DrawingPointY = DrawingPointY + 85;
				DrawingPointX = 17; //Reset X
			}
		}
		
		public void PitchItemClick(object sender, EventArgs e) {
			String[] values = ((Label) sender).Name.Split('#');
			Label clickedLabel = (this._gamePitchLabels[int.Parse(values[0])])[int.Parse(values[1])];
			clickedLabel.Text = "X"; //TODO: Remove line and add change after server accept of change request
			JSONMessage clickServerMsg = new JSONMessage(((Label) sender).Name);
			clickServerMsg.PositionValue = "X";
			clickServerMsg.Type = "PitchItemChangeRequest";
			_mainGui.sendServerMassage(clickServerMsg);
		}
		
		public Label getPitchItem(int down, int left) {
			//TODO: Check if down/left in range
			return (this._gamePitchLabels[down])[left];
		}
		
	}
}