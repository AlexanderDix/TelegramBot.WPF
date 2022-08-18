using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Infrastructure;
using TelegramBot.Models;

namespace TelegramBot.Services;

internal class BotManager
{

    #region Fields

    private readonly CancellationTokenSource _cts = new();
    private readonly MessageManager _messageManager;
    private readonly ITelegramBotClient _botClient;

    #endregion

    #region Properties



    #endregion

    #region Commands



    #endregion

    #region Methods

    private async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
    {
        if (update.Type == UpdateType.Message)
        {
            Message? message = update.Message;

            if (message?.Text is null) return;

            if (message.Text.ToLower() == "/start")
            {
                await bot.SendTextMessageAsync(message.Chat, "Добро пожаловать 🖖", cancellationToken: cancellationToken);
            }
        }
    }

    private async Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
    {
        await Task.Run(() => MessageBox.Show($"Ошибка:\n{exception}"), cancellationToken);
        _cts.Cancel();
    }

    public async void SendMessageAsync(Sender selectedSender, string message)
    {
        _messageManager.AddMessage(selectedSender, message);
        await _botClient.SendTextMessageAsync(selectedSender.ChatId, message);
    }

    #endregion

    #region Constructors

    public BotManager(MessageManager messageManager)
    {
        _messageManager = messageManager;

        _botClient = new TelegramBotClient(Configuration.Token);
        CancellationToken cancellationToken = _cts.Token;
        var receiverOptions = new ReceiverOptions()
        {
            AllowedUpdates = { }
        };

        _botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cancellationToken);
    }

    #endregion
}