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

    public static class BackendUIExtensions
    {
        public static QueryResult<TResponse> AsResult<TResponse>(this IQuery<TResponse> query)
        {
            return new QueryResult<TResponse>(query);
        }

        public static CommandResult AsResult(this ICommand command)
        {
            return new CommandResult(command);
        }
    }

    public class QueryResult<TResponse> : IResult
    {
        private readonly IQuery<TResponse> _query;

        public QueryResult(IQuery<TResponse> query)
        {
            _query = query;
        }

        public TResponse Response { get; set; }

        [Import]
        public IBackend Bus { get; set; }

        public void Execute(ActionExecutionContext context)
        {
            Action<TResponse> replyAction =
                resultOfWork =>
                {
                    Response = resultOfWork;
                    Caliburn.Micro.Execute.OnUIThread(
                        () => Completed(this, new ResultCompletionEventArgs()));
                };

            Bus.Send(_query, replyAction);
        }

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };
    }
}