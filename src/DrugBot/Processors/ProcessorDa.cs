﻿using System;
using System.Collections.Generic;
using DrugBot.Bot;
using DrugBot.Common;

namespace DrugBot.Processors;

[Processor]
public class ProcessorDa : AbstractProcessor
{
    private readonly List<string> _keys = new()
    {
        "да",
    };

    public override string Description => "Напиши \"Да\"";
    public override IReadOnlyList<string> Keys => _keys;

    public override string Name => "Да";

    public override bool HasTrigger<TMessage>(TMessage message, string[] sentence) =>
        string.Equals(message.Text.TrimEnd(), "да", StringComparison.CurrentCultureIgnoreCase);

    protected override void OnProcessMessage<TUser, TMessage>(IBot<TUser, TMessage> bot, TMessage message)
    {
        bot.SendMessage(message.CreateResponse("Пизда"));
    }
}