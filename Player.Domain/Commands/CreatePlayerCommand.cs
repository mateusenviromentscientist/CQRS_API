using Flunt.Notifications;
using Flunt.Validations;

namespace Player.Domain.Commands
{
    public class CreatePlayerCommand  : Notifiable, Todo.Domain.Commands.Contracts.ICommand
    {
        public CreatePlayerCommand(){}
        public CreatePlayerCommand(string name, int assists, int goals)
        {
            Name = name;
            Assists = assists;
            Goals = goals;
        }

        public string Name { get;  set; }
        public int Assists {get ;  set;}
        public int Goals { get;  set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Name, 3, "Name", "Por favor insira um nome")
                .HasLen(Assists.ToString(), 2, "Assists", "Ponha um número")
                .HasLen(Goals.ToString(), 2, "Goals", "Ponha um número")
            );

        }
    }
}