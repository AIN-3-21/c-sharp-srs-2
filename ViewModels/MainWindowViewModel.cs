using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Amir.ViewModels;
public class MainWindowViewModel : ReactiveObject, IScreen
{
    public RoutingState Router
    {
        get;
    } = new();

    public ReactiveCommand<string, IRoutableViewModel> GoTo
    {
        get;
    }

    public MainWindowViewModel()
    {
        GoTo = ReactiveCommand.CreateFromObservable<string, IRoutableViewModel>(page =>
        {
            var pageVm = GetPage(page);


            return Router.Navigate.Execute(pageVm ?? new NotFoundVm(this));
        });
    }

    private IRoutableViewModel? GetPage(string page)
    {
        var type = Type.GetType($"Amir.ViewModels.{page}Vm");

        if (type == null)
        {
            return null;
        }

        return Activator.CreateInstance(type, this) as IRoutableViewModel;
    }
}
