using System;
using TelegramBot.Models.Interfaces;

namespace TelegramBot.Models;

internal class SenderMessage : IEntity
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public DateTime Date { get; set; }
    public bool? IsBot { get; set; } = true;
}