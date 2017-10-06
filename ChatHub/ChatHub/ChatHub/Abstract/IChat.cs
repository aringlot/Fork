using ChatHub.ChatHub.Models;

namespace ChatHub.ChatHub.Abstract
{
    /// <summary>
    /// Provides methods, that are avaliabe for chat to call on client side
    /// </summary>
    public interface IChat
    {
        void ShowMessage(MessageModel messageModel);
    }
}
