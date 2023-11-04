using Amir.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AvaloniaEdit;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;

namespace Amir.Pages;

public partial class BucketSortPage : ReactiveUserControl<BucketSortVm>
{
    public BucketSortPage()
    {
        InitializeComponent();

        var _registryOptions = new RegistryOptions(ThemeName.DarkPlus);

        //Initial setup of TextMate.
        var _textMateInstallation = editor.InstallTextMate(_registryOptions);
        _textMateInstallation.SetGrammar(_registryOptions.GetScopeByLanguageId(_registryOptions.GetLanguageByExtension(".cs").Id));

        editor.Text =
@"public override int[] Execute(int[] arr)
{
    if (arr == null || arr.Length == 0)
    {
        return Array.Empty<int>();
    }

    var minValue = arr.Min();
    var maxValue = arr.Max();

    var range = maxValue - minValue + 1;
    var count = new int[range];
    var output = new int[arr.Length];

    for (var i = 0; i < arr.Length; i++)
    {
        count[arr[i] - minValue]++;
    }

    for (var i = 1; i < count.Length; i++)
    {
        count[i] += count[i - 1];
    }

    for (var i = arr.Length - 1; i >= 0; i--)
    {
        output[count[arr[i] - minValue] - 1] = arr[i];
        count[arr[i] - minValue]--;
    }
            
    return output;
}";
    }
}