using System;
using Caliburn.Micro;

namespace Login.Framework.Results
{
    public class OpenChildResult<TChild> : IResult
    {
        private readonly Func<ActionExecutionContext, TChild> _locateChild =
            c => IoC.Get<TChild>();

        private Func<ActionExecutionContext, IConductor> _locateParent;
        private Action<TChild> _onConfigure;

        public OpenChildResult()
        {
        }

        public OpenChildResult(TChild child)
        {
            _locateChild = c => child;
        }

        #region IResult Members

        public void Execute(ActionExecutionContext context)
        {
            if (_locateParent == null)
                _locateParent = c => (IConductor)c.Target;

            IConductor parent = _locateParent(context);
            TChild child = _locateChild(context);

            if (_onConfigure != null)
                _onConfigure(child);

            parent.ActivateItem(child);
            Completed(this, new ResultCompletionEventArgs());
        }


        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };

        #endregion

        public OpenChildResult<TChild> In<TParent>()
            where TParent : IConductor
        {
            _locateParent = c => IoC.Get<TParent>();
            return this;
        }

        public OpenChildResult<TChild> In(IConductor parent)
        {
            _locateParent = c => parent;
            return this;
        }

        public OpenChildResult<TChild> Configured(Action<TChild> configure)
        {
            _onConfigure = configure;
            return this;
        }

    }
}