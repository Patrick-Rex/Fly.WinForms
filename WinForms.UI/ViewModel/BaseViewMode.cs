using Serilog;
using ReactiveUI;

namespace WinForms.UI.ViewModel
{
    public abstract class BaseViewModel : ReactiveObject
    {
        protected readonly ILogger Logger;

        protected BaseViewModel(ILogger logger)
        {
            Logger = logger;
        }
    }
}
