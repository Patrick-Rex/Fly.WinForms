using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.UI.ViewModel
{
    public class ShellViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }


        public ShellViewModel()
        {
            Router = new RoutingState();
        }

    }
}
