using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
	public enum ObserverEvent
	{
		ParticipationAdded
	}
	public class ObserverEventArgs
	{
		private readonly ObserverEvent observerEvent;
		private readonly Object data;
		public ObserverEventArgs(ObserverEvent observerEvent, Object data)
		{
			this.observerEvent = observerEvent;
			this.data = data;
		}
		public ObserverEvent ObserverEvent { get {  return observerEvent; } }
		public Object Data { get { return data; } }
	}
}
