using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using Task.Application.Commands.CreateTask;
using Task.Application.Shared;
using Task.Core.Abstraction;
using Task.Core.Models;
using TaskTrackerWebApp.Contracts;

namespace TaskTrackerWebApp.Controllers
{
	[ApiController]
	[Route("tasks")]
	public class TasksContoller(ICommandHandler<CreateTaskCommand> createTask) : ControllerBase
	{
		//private readonly ITaskService _service;
		//public TasksContoller(ITaskService service)
		//{
		//	_service = service;
		//}
		//[HttpGet]
		//public async Task<ActionResult<List<TasksResponce>>> GetTasks()
		//{
		//	var tasks = await _service.GetAllTasks();
		//	var responce = tasks.Select(t => new TasksResponce(t.Id, t.Title, t.Description, t.Date)).OrderBy(t=> t.Date);
		//	return Ok(responce);
		//}
		//[HttpGet ("sort")]
		//      public async Task<ActionResult<List<TasksResponce>>> GetSortedTasks(string sort)
		//{
		//          var tasks = await _service.GetAllTasks();
		//          var responce = tasks.Select(t => new TasksResponce(t.Id, t.Title, t.Description, t.Date)).OrderBy(t => t.Date);
		//	if (sort == "desc")
		//		responce = responce.OrderByDescending(x => x.Date);
		//          return Ok(responce);
		//      }


		[HttpPost]
		public async Task<ActionResult<Guid>> CreateTask([FromBody] TaskRequest taskRequest, CancellationToken token)
		{
			var cmd = new CreateTaskCommand(Guid.NewGuid(), taskRequest.Title, taskRequest.Description);
			await createTask.HandleAsync(cmd, token);
            return Ok(cmd.TaskID);
		}
	}
}

