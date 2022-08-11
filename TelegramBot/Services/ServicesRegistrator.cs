using Microsoft.Extensions.DependencyInjection;
using TelegramBot.Services.Interfaces;

namespace TelegramBot.Services;

internal static class ServicesRegistrator
{
    public static IServiceCollection AddServices(this IServiceCollection services) => services
        .AddTransient<IUserDialog, UserDialogService>()
        .AddSingleton<BotManager>();
}