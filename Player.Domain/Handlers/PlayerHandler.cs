using Flunt.Notifications;
using Player.Domain.Command;
using Player.Domain.Commands;
using Player.Domain.Commands.Contracts;
using Player.Domain.Handlers.Contracts;
using Player.Domain.Repositories;

namespace Player.Domain.Handlers
{
   
    public class PlayerHandler : Notifiable, IHandler<CreatePlayerCommand>, IHandler<UpdatePlayerCommand>
    {
        private readonly IPlayerRepository _repository;
    
        public PlayerHandler(IPlayerRepository repository)
        {   
            _repository = repository;
        }
        public ICommandResult Handle(CreatePlayerCommand command)
        {
            //fail fast Validation
            command.Validate();
            if(command.Invalid)
            {
                return new GenericCommandResult(false, "esse jogador não existe", command.Notifications);
            }

            //Create 
            var player = new Player.Domain.Entities.Player(command.Name, command.Assists, command.Goals);

            //Save
            _repository.Create(player);

            //return the value
            return new GenericCommandResult(true, "jogador criado", player);
        }

        public ICommandResult Handle(UpdatePlayerCommand command)
        {
            command.Validate();
            if(command.Invalid)
            {
                return new GenericCommandResult(false, "player não encontrdo",command.Name);              
            }
            //recuperar pelo id
            var player = _repository.GetById(command.Id, command.Name);

            player.UpdateName(command.Name);

            _repository.Update(player);

            return new GenericCommandResult(true,  "Jogador atualizado", player);

        }
    }
}