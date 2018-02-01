using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HitCounter
{
	[HubName("HitCounter")]
	public class HitCounterHub : Hub
	{
		static int _hitCount = 0;

		public override Task OnConnected()
		{
			_hitCount += 1;
			base.Clients.All.hitReceived(_hitCount);
			return base.OnConnected();
		}

		public override Task OnDisconnected(bool stopCalled)
		{
			_hitCount -= 1;
			base.Clients.All.hitReceived(_hitCount);
			return base.OnDisconnected(stopCalled);
		}
	}
}