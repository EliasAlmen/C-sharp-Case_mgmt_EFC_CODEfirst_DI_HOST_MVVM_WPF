using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Helpers
{
    internal class ActionCommand : BaseCommand
    {
        private readonly Action<object> _action;
        private readonly Func<object, bool> _canExecute;

        public ActionCommand(Action<object> action) : this (action, null)
        {
            
        }

        public ActionCommand(Action<object> action, Func<object, bool> canExectue)
        {
            _action = action ?? throw new ArgumentNullException("action", "??");
            _canExecute = canExectue;
        }

        public override void Execute(object? parameter)
        {
            _action(parameter);
        }
    }
}
