/*
 * Created by SharpDevelop.
 * User: luis_nikolai
 * Date: 19.02.2018
 * Time: 20:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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