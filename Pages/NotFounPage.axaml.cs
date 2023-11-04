using Amir.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace Amir.Pages;

public partial class NotFounPage : ReactiveUserControl<NotFoundVm>
{
    public NotFounPage()
    {
        InitializeComponent();
    }
}