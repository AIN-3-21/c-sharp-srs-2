using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace Amir;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }
        base.OnFrameworkInitializationCompleted();
    }

    public static int[] GenerateRandomIntArray(int minLength = 3, int maxLength = 11)
    {
        return GenerateRandomIntArray(Random.Shared.Next(minLength, maxLength));
    }

    public static int[] GenerateRandomIntArray(int length)
    {
        var randomArray = new int[10];
        //var randomArray = new int[length];

        for (var i = 0; i < length; i++)
        {
            randomArray[i] = Random.Shared.Next(-20, 20);
        }

        return randomArray;
    }
}