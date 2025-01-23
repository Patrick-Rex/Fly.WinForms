using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.UI.Helpers
{

    /// <summary>
    /// 异常处理
    /// </summary>
    public class CustomObservableExceptionHandler : IObserver<Exception>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Exception value)
        {
            throw new NotImplementedException();
        }
    }
}
