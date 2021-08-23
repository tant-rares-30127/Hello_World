using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace HelloWorldWeb.Services
{
    public class BroadcastService : IBroadcastServices
    {
        private readonly IHubContext<MessageHub> messageHub;

        public BroadcastService(IHubContext<MessageHub> messageHub)
        {
            this.messageHub = messageHub;
        }

        public void DeleteTheTeamMember(int id)
        {
            this.messageHub.Clients.All.SendAsync("DeleteTheTeamMember", id);
        }

        public void EditTheTeamMember(int id, string name)
        {
            this.messageHub.Clients.All.SendAsync("EditTheTeamMember", id, name);
        }

        public void NewTeamMemberAdded(string name, int id)
        {
            this.messageHub.Clients.All.SendAsync("NewTeamMemberAdded", name, id);
        }
    }
}
