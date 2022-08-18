﻿using System.Collections.ObjectModel;
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
    private string? _title = "Заголовок";

    ///<summary>Заголовок окна</summary>
    public string? Title
    {
        get => _title;
        set => Set(ref _title, value);
    }

    #region SelectedSender : Sender - Выбранный отправитель

    private Sender? _selectedSender;

    public Sender? SelectedSender
    {
        get => _selectedSender;
        set => Set(ref _selectedSender, value);
    }

    #endregion

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