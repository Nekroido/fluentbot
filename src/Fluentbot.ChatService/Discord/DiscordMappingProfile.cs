using AutoMapper;
using Discord.WebSocket;
using Fluentbot.Contracts.Messages.Chat;

namespace Fluentbot.ChatService.Discord
{
    public class DiscordMappingProfile : Profile
    {
        public DiscordMappingProfile()
        {
            CreateMap<SocketMessage, MessageReceived>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForPath(d => d.Message.Body, o => o.MapFrom(s => s.Content))
                .ForPath(d => d.Author.Id, o => o.MapFrom(s => s.Author.Id))
                .ForPath(d => d.Author.Username, o => o.MapFrom(s => s.Author.Mention))
                .ForPath(d => d.Author.DisplayName, o => o.MapFrom(s => s.Author.Username));
        }
    }
}