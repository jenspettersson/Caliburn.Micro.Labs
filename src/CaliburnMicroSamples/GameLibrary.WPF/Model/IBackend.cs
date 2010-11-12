using System;
using System.Windows.Input;

namespace GameLibrary.WPF.Model
{
    public interface IBackend
    {
        void Send(ICommand command);
        void Send<TResponse>(IQuery<TResponse> query, Action<TResponse> reply);
    }
}