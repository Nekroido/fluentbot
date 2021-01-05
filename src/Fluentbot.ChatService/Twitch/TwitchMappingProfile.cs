using System;
using AutoMapper;
using Fluentbot.ChatService.Extensions;
using Fluentbot.Contracts.Messages.Chat;
using Fluentbot.Contracts.Messages.Lifetime.Service;
using Fluentbot.Contracts.Messages.Stream;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.PubSub.Events;
using HostingStarted = Fluentbot.Contracts.Messages.Stream.HostingStarted;

namespace Fluentbot.ChatService.Twitch
{
    public class TwitchMappingProfile : Profile
    {
        public TwitchMappingProfile()
        {
            CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
            CreateMap<string, Guid?>().ConvertUsing(s => s.ToGuid());

            #region service lifetime

            CreateMap<OnConnectedArgs, ServiceConnected>();
            CreateMap<OnDisconnectedArgs, ServiceDisconnected>();

            #endregion

            #region stream lifetime

            CreateMap<OnBeingHostedArgs, HostingReceived>()
                .ForMember(d => d.Channel, a => a.MapFrom(s => s.BeingHostedNotification.Channel))
                .ForMember(d => d.HostedByChannel, a => a.MapFrom(s => s.BeingHostedNotification.HostedByChannel))
                .ForMember(d => d.IsAutoHosted, a => a.MapFrom(s => s.BeingHostedNotification.IsAutoHosted))
                .ForMember(d => d.Viewers, a => a.MapFrom(s => s.BeingHostedNotification.Viewers));
            CreateMap<OnRaidGoArgs, RaidReceived>()
                .ForMember(d => d.ChannelId, a => a.MapFrom(s => s.ChannelId))
                .ForMember(d => d.RaidedByChannel, a => a.MapFrom(s => s.TargetLogin))
                .ForMember(d => d.RaidedByChannelId, a => a.MapFrom(s => s.TargetChannelId))
                .ForMember(d => d.Viewers, a => a.MapFrom(s => s.ViewerCount));

            CreateMap<OnHostingStartedArgs, HostingStarted>()
                .ForMember(d => d.HostingChannel, a => a.MapFrom(s => s.HostingStarted.HostingChannel))
                .ForMember(d => d.TargetChannel, a => a.MapFrom(s => s.HostingStarted.TargetChannel))
                .ForMember(d => d.Viewers, a => a.MapFrom(s => s.HostingStarted.Viewers));
            CreateMap<OnHostingStoppedArgs, HostingEnded>()
                .ForMember(d => d.HostingChannel, a => a.MapFrom(s => s.HostingStopped.HostingChannel))
                .ForMember(d => d.Viewers, a => a.MapFrom(s => s.HostingStopped.Viewers));

            CreateMap<OnStreamUpArgs, StreamStarted>()
                .ForMember(d => d.PlayDelay, a => a.MapFrom(s => s.PlayDelay))
                .ForMember(d => d.StartedAt, a => a.MapFrom(s => s.ServerTime.UnixTimestampToDateTime()));
            CreateMap<OnStreamDownArgs, StreamEnded>()
                .ForMember(d => d.EndedAt, a => a.MapFrom(s => s.ServerTime.UnixTimestampToDateTime()));

            #endregion

            #region chat events

            CreateMap<OnJoinedChannelArgs, ChannelJoined>()
                .ForMember(d => d.Channel, o => o.MapFrom(s => s.Channel));
            CreateMap<OnLeftChannelArgs, ChannelLeft>()
                .ForMember(d => d.Channel, o => o.MapFrom(s => s.Channel));

            CreateMap<OnUserJoinedArgs, UserJoined>()
                .ForPath(d => d.User.Username, o => o.MapFrom(s => s.Username))
                .ForMember(d => d.ChannelName, o => o.MapFrom(s => s.Channel))
                .ForMember(d => d.JoinedAt, o => o.MapFrom(s => DateTime.Now));
            CreateMap<OnUserLeftArgs, UserLeft>()
                .ForPath(d => d.User.Username, o => o.MapFrom(s => s.Username))
                .ForMember(d => d.ChannelName, o => o.MapFrom(s => s.Channel))
                .ForMember(d => d.LeftAt, o => o.MapFrom(s => DateTime.Now));

            CreateMap<OnUserBannedArgs, UserBanned>()
                .ForPath(d => d.User.Username, o => o.MapFrom(s => s.UserBan.Username))
                .ForMember(d => d.Reason, o => o.MapFrom(s => s.UserBan.BanReason))
                .ForMember(d => d.BannedAt, o => o.MapFrom(s => DateTime.Now));
            CreateMap<OnUserTimedoutArgs, UserMuted>()
                .ForPath(d => d.User.Username, o => o.MapFrom(s => s.UserTimeout.Username))
                .ForMember(d => d.Reason, o => o.MapFrom(s => s.UserTimeout.TimeoutReason))
                .ForMember(d => d.Duration, o => o.MapFrom(s => TimeSpan.FromSeconds(s.UserTimeout.TimeoutDuration)))
                .ForMember(d => d.MutedAt, o => o.MapFrom(s => DateTime.Now));

            CreateMap<OnUnbanArgs, UserUnbanned>()
                .ForPath(d => d.User.Id, o => o.MapFrom(s => s.UnbannedUserId))
                .ForPath(d => d.User.Username, o => o.MapFrom(s => s.UnbannedUser))
                .ForPath(d => d.UnbannedBy.Id, o => o.MapFrom(s => s.UnbannedByUserId))
                .ForPath(d => d.UnbannedBy.Username, o => o.MapFrom(s => s.UnbannedBy))
                .ForMember(d => d.UnbannedAt, o => o.MapFrom(s => DateTime.Now));
            CreateMap<OnUntimeoutArgs, UserUnmuted>()
                .ForPath(d => d.User.Id, o => o.MapFrom(s => s.UntimeoutedUserId))
                .ForPath(d => d.User.Username, o => o.MapFrom(s => s.UntimeoutedUser))
                .ForPath(d => d.UnmutedBy.Id, o => o.MapFrom(s => s.UntimeoutedByUserId))
                .ForPath(d => d.UnmutedBy.Username, o => o.MapFrom(s => s.UntimeoutedBy))
                .ForMember(d => d.UnmutedAt, o => o.MapFrom(s => DateTime.Now));

            CreateMap<OnMessageReceivedArgs, MessageReceived>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.ChatMessage.Id))
                .ForMember(d => d.ReceivedAt, o => o.MapFrom(s => DateTime.Now))
                .ForPath(d => d.Message.Body, o => o.MapFrom(s => s.ChatMessage.Message))
                .ForPath(d => d.Message.IsMeHighlight, o => o.MapFrom(s => s.ChatMessage.IsMe))
                .ForPath(s => s.Author.Id, o => o.MapFrom(s => s.ChatMessage.UserId))
                .ForPath(s => s.Author.DisplayName, o => o.MapFrom(s => s.ChatMessage.DisplayName));

            CreateMap<OnWhisperReceivedArgs, WhisperReceived>()
                .ForMember(d => d.Id, a => a.MapFrom(s => s.WhisperMessage.MessageId))
                .ForMember(d => d.ReceivedAt, a => a.MapFrom(s => DateTime.Now))
                .ForPath(d => d.Message.Body, o => o.MapFrom(s => s.WhisperMessage.Message))
                .ForPath(s => s.Author.Id, o => o.MapFrom(s => s.WhisperMessage.UserId))
                .ForPath(s => s.Author.DisplayName, o => o.MapFrom(s => s.WhisperMessage.DisplayName));

            #endregion
        }
    }
}