using Microsoft.Extensions.DependencyInjection;
using TelegramBot.ViewModels.WindowViewModels;

namespace TelegramBot.ViewModels;

internal class ViewModelLocator
{
    public static MainWindowViewModel? MainWindowModel => App.Services?.GetRequiredService<MainWindowViewModel>();
}