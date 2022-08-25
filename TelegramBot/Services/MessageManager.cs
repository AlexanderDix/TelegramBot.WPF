using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;
using Telegram.Bot.Types;
using TelegramBot.Infrastructure;
using TelegramBot.Models;

namespace TelegramBot.Services;

internal class MessageManager
{
    #region Fields

    private readonly Dispatcher _dispatcher = Dispatcher.CurrentDispatcher; 

    #endregion

    #region Properties

    public ObservableCollection<Sender?> Senders { get; private set; }
    public ObservableCollection<SenderMessage?> Messages { get; } = new();

    #endregion

    #region Commands



    #endregion

    #region Methods

    /// <summary>
    /// Добавление сообщения в список, и его сериализация
    /// </summary>
    /// <param name="message">Сообщение отправленное пользователем</param>
    public void AddMessage(Message message)
    {
        User? from = message.From;
        Sender? sender = Senders.FirstOrDefault(s => s?.UserName == from?.Username);
        TimeZoneInfo timeZoneLocal = TimeZoneInfo.Local;

        var senderMsg = new SenderMessage
        {
            Text = message.Text,
            Date = TimeZoneInfo.ConvertTime(message.Date, timeZoneLocal),
            IsBot = from?.IsBot
        };

        if (sender is null)
        {
            sender = new Sender
            {
                ChatId = message.Chat.Id,
                FirstName = from?.FirstName,
                LastName = from?.LastName,
                UserName = from?.Username
            };

            _dispatcher.Invoke(() => Senders.Add(sender));
        }

        _dispatcher.Invoke(() => sender.Messages.Add(senderMsg));
        Messages.Add(senderMsg);

        Serializator.Serialize(Senders);
    }

    /// <summary>
    /// Перегрузка метода, добавление сообщения в список,и его сериализация
    /// </summary>
    /// <param name="selectedSender">Выбранный контакт, которому отправляется сообщение</param>
    /// <param name="message">Сообщение от бота</param>
    public void AddMessage(Sender selectedSender, string message)
    {
        Sender? sender = Senders.FirstOrDefault(s => s?.UserName == selectedSender.UserName);
        var msg = new SenderMessage
        {
            Text = message,
            Date = DateTime.Now
        };

        if (sender is null) return;

        _dispatcher.Invoke(() => sender.Messages.Add(msg));
        Messages.Add(msg);

        Serializator.Serialize(Senders);
    }

    public void AddMessage(User? from, string message)
    {
        Sender? sender = Senders.FirstOrDefault(s => s?.UserName == from?.Username);
        var msg = new SenderMessage()
        {
            Text = message,
            Date = DateTime.Now
        };

        if (sender is null) return;

        _dispatcher.Invoke(() => sender.Messages.Add(msg));
        Messages.Add(msg);

        Serializator.Serialize(Senders);
    }

    #endregion

    #region Constructors

    public MessageManager()
    {
        Senders = Serializator.Deserialize<ObservableCollection<Sender?>>();
    }

    #endregion
}