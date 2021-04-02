using Player.Domain.Commands.Contracts;
using Todo.Domain.Commands.Contracts;

namespace Player.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}