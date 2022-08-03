using TelegramBot.ViewModels.Base;

namespace TelegramBot.ViewModels.WindowViewModels;

internal class MainWindowViewModel : ViewModel
{
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
}