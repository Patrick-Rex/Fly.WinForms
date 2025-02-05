using ReactiveUI;
using Serilog;

namespace WinForms.UI.ViewModel
{
    public class ShellViewModel : BaseViewModel, IScreen
    {
        public RoutingState Router { get; }


        public ShellViewModel(ILogger logger) : base(logger)
        {
            Router = new RoutingState();
        }

    }
}
