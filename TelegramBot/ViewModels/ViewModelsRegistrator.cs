using Microsoft.Extensions.DependencyInjection;
using TelegramBot.ViewModels.WindowViewModels;

namespace TelegramBot.ViewModels;

internal static class ViewModelsRegistrator
{
    public static IServiceCollection AddViewModels(this IServiceCollection services) => services
        .AddSingleton<MainWindowViewModel>();
}