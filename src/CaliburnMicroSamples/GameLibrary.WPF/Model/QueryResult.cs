using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace GameLibrary.WPF.Model
{
    public class QueryResult<TResponse> : IResult
    {
        private readonly IQuery<TResponse> _query;

        public QueryResult(IQuery<TResponse> query)
        {
            _query = query;
        }

        [Import]
        public IBackend Bus { get; set; }

        public TResponse Response { get; set; }

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