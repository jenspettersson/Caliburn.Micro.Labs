using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace MicroManagement.Desktop.Model
{
    public class CommandResult : IResult
    {
        private readonly ICommand _command;

        [Import]
        public IBackend Bus { get; set; }

        public CommandResult(ICommand command)
        {
            _command = command;
        }

        public void Execute(ActionExecutionContext context)
        {
            Bus.Send(_command);
            Completed(this, new ResultCompletionEventArgs());
        }

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };
    }
}