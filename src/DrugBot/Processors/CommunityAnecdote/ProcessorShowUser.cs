﻿using System.Collections.Generic;
using System.Threading;
using Anecdotes.CommunityAnecdotes.Repositories.Interfaces;
using DrugBot.Core.Bot;
using DrugBot.Core.Common;

namespace DrugBot.Processors.CommunityAnecdote;

[Processor]
public class ProcessorShowUser : AbstractProcessor
{
    private readonly List<string> _keys = new()
    {
        "/анек-п-п"
    };
    
    public override string Description => $"Показать анекдот от кого-то конкретного. Команды: {string.Join(' ', _keys)}";
    public override string Name  => "Лучшие хохмы от \"вставте имя юмориста\"";

    public override IReadOnlyList<string> Keys => _keys;
    
    private readonly IAnecdoteProvider _anecdoteProvider;

    public ProcessorShowUser(IAnecdoteProvider anecdoteProvider)
    {
        _anecdoteProvider = anecdoteProvider;
    }

    protected override void OnProcessMessage<TUser, TMessage>(IBot<TUser, TMessage> bot, TMessage message, CancellationToken token)
    {
        if (!int.TryParse(message.Text.Remove(0, message.Text.IndexOf(' ') + 1), out var userId))
        {
            bot.SendMessage(message.CreateResponse("На данный момент можно искать только по ID"));
            return;
        }
        
        var anecdote = _anecdoteProvider.GetRandomAnecdoteFromUser(userId);

        if (anecdote == null)
        {
            bot.SendMessage(message.CreateResponse("Этот юморист еще не создал ни одного анекдота."));
            return;
        }
        
        bot.SendMessage(message.CreateResponse(anecdote.Anecdote));
    }
}