using System.Collections.Generic;
using System.Collections.ObjectModel;
using TelegramBot.Models.Interfaces;

namespace TelegramBot.Models;

internal class Sender : IEntity
{
    public int Id { get; set; }
    public long ChatId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public ICollection<SenderMessage> Messages { get; } = new ObservableCollection<SenderMessage>();
}