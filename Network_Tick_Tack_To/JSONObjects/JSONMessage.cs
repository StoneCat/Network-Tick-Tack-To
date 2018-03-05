using System;

namespace Network_Tick_Tack_To.JSONObjects
{
	public class JSONMessage
	{
		public JSONMessage() {
			//Not implemented yet
		}
		
		public JSONMessage(string postionClick) {
			this.PositionClick = postionClick;
		}
		
		public string Type { get; set; }
		
		public string PositionClick { get; set; }
		
		public string PositionValue { get; set; }
	}
}