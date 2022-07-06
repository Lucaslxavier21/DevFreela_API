using DevFreela.API.Commands.CreateComment;
using DevFreela.API.Commands.CreateProject;
using DevFreela.API.Commands.DeleteProject;
using DevFreela.API.Commands.Finish;
using DevFreela.API.Commands.Start;
using DevFreela.API.Commands.UpdateProject;
using DevFreela.API.Models;
using DevFreela.API.Queries.GetAllProjects;
using DevFreela.API.Queries.GetProjectById;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
   
    public class ProjectsController : ControllerBase
    {
       
        private readonly IMediator _mediator;
        public ProjectsController(IMediator mediator)
        {
     
            _mediator = mediator;
        }

        // api/projects?query=net core
        [HttpGet]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProjectsQuery = new GetAllProjectsQuery(query);

                var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        // api/projects/2
        [HttpGet("{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
         
            // var id = _projectService.Create(inputModel);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        // api/projects/2
        [HttpPut("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
          
            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/3 DELETE
        [HttpDelete("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            
            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Start(int id, [FromBody] StartCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        // [Authorize(Roles = "client")]
        public async Task<IActionResult> Finish(int id, [FromBody] FinishCommand command)
        {
            command.Id = id;

            var result = await _mediator.Send(command);

            if (!result)
            {
                return BadRequest("O pagamento não pôde ser processado.");
            }

            return Accepted();
        }
    }
}
