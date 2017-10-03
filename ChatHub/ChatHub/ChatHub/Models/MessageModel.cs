using Newtonsoft.Json;

namespace ChatHub.ChatHub.Models
{
    public class MessageModel
    {
        [JsonProperty]
        public string UserName { get; set; }

        [JsonProperty]
        public string Message { get; set; }
    }
}