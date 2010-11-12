using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace GameLibrary.WPF.Model
{
    public class CommandResult : IResult
    {
        private readonly ICommand _command;

        public CommandResult(ICommand command)
        {
            _command = command;
        }

        [Import]
        public IBackend Bus { get; set; }

        public void Execute(ActionExecutionContext context)
        {
            Bus.Send(_command);
            Completed(this, new ResultCompletionEventArgs());
        }

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };
    }
}