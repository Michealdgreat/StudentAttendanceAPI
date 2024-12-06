using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace StuAttendanceAPI.Application.Communication
{
    public class LoginHub : Hub
    {
        public async Task SendTagIdToAllClients(string tagId)
        {

            var ConnectionId = Context.ConnectionId;

            await Clients.All.SendAsync("ReceiveTagId", tagId);
        }

    }
}