﻿using System.Collections.Generic;
using System.IO;
using Memes;
using DrugBot.Processors;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using VkNet;
using VkNet.Model;
using Image = SixLabors.ImageSharp.Image;

namespace DrugBot.Processors;

public class MemesProssessor : AbstractProcessor
{
    private readonly List<string> _keys = new()
    {
        "/мем",
        "/mem",
        "/memes",
        "/мемы",
        "/кек"
    };

    public override string Description => $"Выдать случайный мем, для вызова используйте {string.Join(' ', _keys)}";
    public override IReadOnlyList<string> Keys => _keys;
    public override string Name => "Сборник баянов";

    protected override void OnProcessMessage(VkApi vkApi, Message message, string[] sentence)
    {
        MemesGenerator generator = sentence.Length > 1
            ? new MemesGenerator(message.Text.GetHashCode())
            : new MemesGenerator();

        BotHandler.SendMessage(vkApi, message.PeerId, "", generator.GetMeme().Meme);
    }
}