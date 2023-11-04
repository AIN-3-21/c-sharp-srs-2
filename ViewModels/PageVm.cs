using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Amir.ViewModels;
public class PageVm : ReactiveObject, IRoutableViewModel
{
    public PageVm(IScreen hostScreen)
    {
        HostScreen = hostScreen;

        SortCommand = ReactiveCommand.Create(() =>
        {
            var arr = App.GenerateRandomIntArray();
            SourceArray = string.Join(",", arr);

            var result = Execute(arr);
            ResultArray = string.Join(",", result);
        });

        SortCommand.ThrownExceptions.Subscribe(x => ResultArray = x.ToString());
    }

    public string? UrlPathSegment
    {
        get;
    }
    public IScreen HostScreen
    {
        get;
    }

    public ReactiveCommand<Unit,Unit> SortCommand
    {
        get;
    }


    [Reactive]
    public int? OperationsCount
    {
        get; set;
    }
    [Reactive]
    public int? MemoryAlocate
    {
        get; set;
    }
    [Reactive]
    public string SourceArray
    {
        get; set;
    }
    [Reactive]
    public string ResultArray
    {
        get; set;
    }

    public virtual int[] Execute(int[] arr)
    {
        return Array.Empty<int>();
    }
}
