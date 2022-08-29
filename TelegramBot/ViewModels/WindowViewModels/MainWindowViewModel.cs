using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using TelegramBot.Models;
using TelegramBot.Services;
using TelegramBot.ViewModels.Base;

namespace TelegramBot.ViewModels.WindowViewModels;

internal class MainWindowViewModel : ViewModel
{
    #region Fields

    private readonly BotManager _botManager;
    private readonly MessageManager _messageManager;

    #endregion

    #region Properties

    /// <summary>
    /// Коллекция отправителей
    /// </summary>
    public ObservableCollection<Sender?> Senders => _messageManager.Senders;

    /// <summary>
    /// Коллекция сообщений от отправителей
    /// </summary>
    public ObservableCollection<SenderMessage?> Messages => _messageManager.Messages;

    #region Title : string - Заголовок окна

    ///<summary>Заголовок окна</summary>
    private string? _title = "TelegramBotUI";

    ///<summary>Заголовок окна</summary>
    public string? Title
    {
        get => _title;
        set => Set(ref _title, value);
    }

    #endregion

    #region SelectedSender : Sender - Выбранный отправитель

    private Sender? _selectedSender;

    public Sender? SelectedSender
    {
        get => _selectedSender;
        set
        {
            Set(ref _selectedSender, value);
            VisibilityMessages = Visibility.Visible;
        }
    }

    #endregion

    #region VisibilityMessages : Visibility - Отображение блока сообщений

    ///<summary>Отображение блока сообщений</summary>
    private Visibility _visibilityMessages = Visibility.Hidden;

    ///<summary>Отображение блока сообщений</summary>
    public Visibility VisibilityMessages
    {
        get => _visibilityMessages;
        set => Set(ref _visibilityMessages, value);
    }

    #endregion

    #endregion

    #region Commands



    #endregion

    #region Methods



    #endregion

    #region Constructors

    public MainWindowViewModel(BotManager botManager, MessageManager messageManager)
    {
        _botManager = botManager;
        _messageManager = messageManager;
    }

    #endregion
}