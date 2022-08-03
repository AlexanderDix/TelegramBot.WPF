﻿using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TelegramBot.Services;
using TelegramBot.ViewModels;

namespace TelegramBot;

public partial class App
{
    private static IHost? _host;
    private static IHost Host => _host ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

    public static IServiceProvider? Services => _host?.Services;

    private static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
        .AddServices()
        .AddViewModels();

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices);

    protected override async void OnStartup(StartupEventArgs e)
    {
        IHost host = Host;

        base.OnStartup(e);

        await host.StartAsync();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);

        using (Host) await Host.StopAsync();
    }
}
