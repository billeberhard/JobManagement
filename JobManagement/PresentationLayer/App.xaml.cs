using System;
using DataLayer.Repository;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer.Core;
using PresentationLayer.Services;
using PresentationLayer.ViewModels;

namespace PresentationLayer;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddSingleton(provider => new MainWindow
        {
            DataContext = provider.GetRequiredService<MainViewModel>()
        });
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<CustomerGridViewModel>();
        services.AddSingleton<ArticleGridViewModel>();
        services.AddSingleton<ArticleGroupGridViewModel>();
        services.AddSingleton<OrderGridViewModel>();
        services.AddSingleton<INavigationService, NavigationService>();

        services.AddSingleton<CustomerDetailsViewModel>(); 
        services.AddSingleton<ArticleDetailsViewModel>(); 
        services.AddSingleton<ArticleGroupDetailsViewModel>();
        services.AddSingleton<OrderDetailsViewModel>();

        services.AddSingleton<Func<Type, ViewModel>>(serviceProvider =>
            viewModelType => (ViewModel) serviceProvider.GetRequiredService(viewModelType));

        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
        base.OnStartup(e);
    }
}
