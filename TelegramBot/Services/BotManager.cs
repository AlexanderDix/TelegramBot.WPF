using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ConsoleTelegramBot;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Services;

internal class BotManager
{
    #region Fields

    private readonly CancellationTokenSource _cts = new();

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

    private void Start()
    {
        ITelegramBotClient botClient = new TelegramBotClient(Configuration.Token);
        CancellationToken cancellationToken = _cts.Token;
        var receiverOptions = new ReceiverOptions()
        {
            AllowedUpdates = { }
        };

        botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cancellationToken);
    }

    #endregion

    #region Constructors

    public BotManager()
    {
        Start();
    }

    #endregion
}