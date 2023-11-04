using Amir.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;

namespace Amir.Pages;

public partial class LowDensitySortPage : ReactiveUserControl<LowDensitySortVm>
{
    public LowDensitySortPage()
    {
        InitializeComponent();
        var _registryOptions = new RegistryOptions(ThemeName.DarkPlus);

        //Initial setup of TextMate.
        var _textMateInstallation = editor.InstallTextMate(_registryOptions);
        _textMateInstallation.SetGrammar(_registryOptions.GetScopeByLanguageId(_registryOptions.GetLanguageByExtension(".cs").Id));

        editor.Text =
@"public override int[] Execute(int[] arr)
{
    if (arr == null || arr.Length <= 1)
    {
        return arr;
    }

    var n = arr.Length;
    var gap = n;
    var swapped = true;

    while (gap > 1 || swapped)
    {
        gap = Math.Max(1, (int)(gap / 1.3));

        swapped = false;

        for (int i = 0; i + gap < n; i++)
        {
            if (arr[i] > arr[i + gap])
            {
                (arr[i], arr[i + gap]) = (arr[i + gap], arr[i]);
                swapped = true;
            }
        }
    }

    return arr;
}";
    }
}