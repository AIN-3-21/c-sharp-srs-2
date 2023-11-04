using Amir.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;

namespace Amir.Pages;

public partial class TranspositionSortPage : ReactiveUserControl<TranspositionSortVm>
{
    public TranspositionSortPage()
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
        return Array.Empty<int>();
    }

    var n = arr.Length;
    bool swapped;

    do
    {
        swapped = false;
        for (var i = 1; i < n; i++)
        {
            if (arr[i - 1] > arr[i])
            {
                (arr[i], arr[i - 1]) = (arr[i - 1], arr[i]);
                swapped = true;
            }
        }
        n--; 
    } while (swapped);

    return arr;
}";
    }
}