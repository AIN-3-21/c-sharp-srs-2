using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amir.Pages;
using Amir.ViewModels;
using ReactiveUI;

namespace Amir;
public class RouterViewLocator : IViewLocator
{
    public IViewFor? ResolveView<T>(T? viewModel, string? contract = null) => viewModel switch
    {
        NotFoundVm vm => new NotFounPage { DataContext = vm },
        BucketSortVm vm => new BucketSortPage {  DataContext = vm },
        TranspositionSortVm vm => new TranspositionSortPage {  DataContext = vm },
        LowDensitySortVm vm => new LowDensitySortPage {  DataContext = vm },
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    };
}
