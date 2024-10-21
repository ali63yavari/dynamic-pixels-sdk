

using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.ModuleFramework.Messaging;
using DynamicPixels.GameService.Services.Chat;
using DynamicPixels.GameService.Services.Chat.Models;
using DynamicPixels.GameService.Services.Chat.Repositories;

namespace adapters.services.table.services
{

    public partial class MessageType
    {
        public const string ChatSendPrivate = "chat:send";
        public const string ChatSendGroup = "chat:group:send";
        public const string ChatSubscribe = "chat:subscribe";
        public const string ChatUnsubscribe = "chat:unsubscribe";
        public const string ChatMessageEdit = "chat:message:edit";
        public const string ChatMessageDelete = "chat:message:delete";
        public const string ChatMessagePurge = "chat:message:purge";
        public const string ChatMessageDeleteAll = "chat:group:delete";
    }
    
    public class ChatService: IChat
    {
        // dependencies
        private IChatRepository _repository;
        private readonly IWebSocketService _socketAgent;
        
        public ChatService(IWebSocketService socketAgent)
        {
            _repository = new ChatRepository();
            _socketAgent = socketAgent;


            // TODO: Realtime
            //DynamicPixels.Agent.OnMessageReceived += OnMessage;
        }

        private void OnMessage(object source, Request packet)
        {
            switch (packet.Method)
            {
                case MessageType.ChatSendPrivate:
                    Send(new SendParams{});
                    break;
                case MessageType.ChatSendGroup:
                    Send(new SendParams{});
                    break;
                case MessageType.ChatSubscribe:
                    Subscribe(new SubscribeParams{});
                    break;
                case MessageType.ChatUnsubscribe:
                    Unsubscribe(new UnsubscribeParams{});
                    break;
                case MessageType.ChatMessageEdit:
                    EditMessage(new EditMessageParams{});
                    break;
                case MessageType.ChatMessageDelete:
                    DeleteMessage(new DeleteMessageParams{});
                    break;
                case MessageType.ChatMessagePurge:
                    
                    break;
                case MessageType.ChatMessageDeleteAll:
                    DeleteAllMessage(new DeleteAllMessageParams{});
                    break;
            }
        }

        
        // interactions
        public Task Send<T>(T param) where T : SendParams
        {
            _socketAgent.SendAsync(new Request
            {
                Method = param.Type == ConversationType.Private ? MessageType.ChatSendPrivate: MessageType.ChatSendGroup,
                ReceiverId = param.TargetUserId,
                Payload = new Payload
                {
                    TargetId = param.TargetUserId,
                    Message = param.Message
                }.ToString(),
            });
            
            return Task.CompletedTask;
        }

        public Task Subscribe<T>(T param) where T : SubscribeParams
        {
            _socketAgent.SendAsync(new Request
            {
                Method = MessageType.ChatSubscribe,
                Payload = new Payload
                {
                    TargetId = param.ConversationId,
                    Value = param.ConversationName,
                }.ToString(),
            });
            
            return Task.CompletedTask;
        }

        public Task Unsubscribe<T>(T param) where T : UnsubscribeParams
        {
            _socketAgent.SendAsync(new Request
            {
                Method = MessageType.ChatUnsubscribe,
                Payload = new Payload
                {
                    TargetId = param.ConversationId,
                }.ToString(),
            });
            
            return Task.CompletedTask;
        }
        
        public Task EditMessage<T>(T param) where T : EditMessageParams
        {
            _socketAgent.SendAsync(new Request
            {
                Method = MessageType.ChatMessageEdit,
                Payload = new Payload
                {
                    TargetId = param.ConversationId,
                    MessageId = param.MessageId,
                    Message = param.Message,
                }.ToString(),
            });
            
            return Task.CompletedTask;
        }

        public Task DeleteMessage<T>(T param) where T : DeleteMessageParams
        {
            _socketAgent.SendAsync(new Request
            {
                Method = MessageType.ChatMessageDelete,
                Payload = new Payload {
                    TargetId = param.ConversationId,
                    MessageId = param.MessageId,
                }.ToString(),
            });
            
            return Task.CompletedTask;
        }

        public Task DeleteAllMessage<T>(T param) where T : DeleteAllMessageParams
        {
            _socketAgent.SendAsync(new Request
            {
                Method = MessageType.ChatMessageDeleteAll,
                Payload = new Payload
                {
                    TargetId = param.ConversationId,
                    SubTargetId = param.TargetUserId,
                }.ToString(),
            });
            
            return Task.CompletedTask;
        }
        
        // https
        public async Task<List<Conversation>> GetSubscribedConversations<T>(T param) where T : GetSubscribedConversationsParams
        {
            var conversations = await this._repository.GetSubscribedConversations(param);
            return conversations.List;
        }

        public async Task<List<Message>> GetConversationMessages<T>(T param) where T : GetConversationMessagesParams
        {
            var messages = await this._repository.GetConversationMessages(param);
            return messages.List;
        }

        public async Task<List<ConversationMember>> GetConversationMembers<T>(T param) where T : GetConversationMembersParams
        {
            var members = await this._repository.GetConversationMembers(param);
            return members.List;
        }

    }
}