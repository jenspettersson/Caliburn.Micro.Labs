using System;

namespace MicroManagement.Desktop.Model
{
    public interface IBackend
    {
        void Send(ICommand command);
        void Send<TResponse>(IQuery<TResponse> query, Action<TResponse> reply);
    }
}