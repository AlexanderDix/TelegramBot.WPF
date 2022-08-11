using TelegramBot.Services;
using TelegramBot.ViewModels.Base;

namespace TelegramBot.ViewModels.WindowViewModels;

internal class MainWindowViewModel : ViewModel
{
    #region Fields

    private readonly BotManager _botManager;

    #endregion

    #region Properties

    #region Title : string - Заголовок окна

    ///<summary>Заголовок окна</summary>
    private string? _title = "Заголовок";

    ///<summary>Заголовок окна</summary>
    public string? Title
    {
        get => _title;
        set => Set(ref _title, value);
    }

    #endregion

    #endregion

    #region Commands



    #endregion

    #region Methods



    #endregion

    #region Constructors

    public MainWindowViewModel(BotManager botManager)
    {
        _botManager = botManager;
    }

    #endregion
}