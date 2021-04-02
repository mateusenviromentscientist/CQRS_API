using System;
using Todo.Domain.Commands.Contracts;
using Flunt.Validations;
using Player.Domain.Entities;
using Flunt.Notifications;

namespace Player.Domain.Commands
{
    public class UpdatePlayerCommand :Notifiable, ICommand
    {
        public UpdatePlayerCommand()
        {

        }



        public UpdatePlayerCommand(string name, Guid id, string goals, string assists)
        {
            Name = name;
            Id = id;
            Goals = goals;
            Assists = assists;
        }

        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Goals { get; set; }
        public string Assists { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Name, 3, "Name", "Por favor insira um nome")
                .IsNotEmpty(Id, "Id", "insira um id correto")
                .HasLen(Goals, 2, "Goals", "Insira um número")
                .HasLen(Assists, 2,"Assists", "ponha um dígito")
            );

        }
    }
}