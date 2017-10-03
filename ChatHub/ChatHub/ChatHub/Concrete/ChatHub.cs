using System.Collections.Concurrent;
using System.Threading.Tasks;
using ChatHub.ChatHub.Abstract;
using ChatHub.ChatHub.Models;
using Microsoft.AspNet.SignalR;

namespace ChatHub.ChatHub.Concrete
{
    public class ChatHub : Hub<IChat>
    {
        public void Send(MessageModel model)
        {
            Clients.All.ShowMessage(model);
        }

        public void Send(MessageModel model, string groupName)
        {
            Clients.Group(groupName).ShowMessage(model);
        }

        public Task JoinGroup(string name)
        {
            return Groups.Add(Context.ConnectionId, name);
        }

        public Task LeaveGroup(string name)
        {
            return Groups.Remove(Context.ConnectionId, name);
        }
    }
}