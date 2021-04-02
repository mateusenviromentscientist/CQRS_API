using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Player.Domain.Command;
using Player.Domain.Commands;
using Player.Domain.Handlers;
using Player.Domain.Repositories;

namespace Player.Domain.Api.Controlller
{
    [ApiController]
    [Route("v1/players")]
    public class PlayerController : ControllerBase
    {
        [Route("")]
        [HttpGet] // para criar é necessário receber um command e um handler
        public IEnumerable<Player.Domain.Entities.Player> GetAll(
            [FromServices] IPlayerRepository repository
        )
        {
            return repository.GetAllGoals(30);
        }

        [Route("")]
        [HttpGet] // para criar é necessário receber um command e um handler
        public IEnumerable<Player.Domain.Entities.Player> GetAssists(
            [FromServices] IPlayerRepository repository
        )
        {
            return repository.GetAllAssists(10);
        }

        [Route("")]
        [HttpPost] // para criar é necessário receber um command e um handler
        public GenericCommandResult Create(
            [FromBody] CreatePlayerCommand command,
            [FromServices]PlayerHandler handler)
        {
            command.Name = "bidaij";
            return (GenericCommandResult)handler.Handle(command);
        }
         [Route("")]
        [HttpPut] // para criar é necessário receber um command e um handler
        public IEnumerable<Player.Domain.Entities.Player> Update(
            [FromBody] UpdatePlayerCommand command,
            [FromServices]PlayerHandler handler)
        {
            command.Name ="jean";
            return (IEnumerable<Entities.Player>)(GenericCommandResult)handler.Handle(command);
        }
    }
}