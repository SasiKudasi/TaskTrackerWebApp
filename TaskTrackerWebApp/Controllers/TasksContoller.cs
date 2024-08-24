using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Task.Core.Abstraction;
using Task.Core.Models;
using TaskTrackerWebApp.Contracts;

namespace TaskTrackerWebApp.Controllers
{
	[ApiController]
	[Route("tasks")]
	public class TasksContoller : ControllerBase
	{
		private readonly ITaskService _service;
		public TasksContoller(ITaskService service)
		{
			_service = service;
		}
		[HttpGet]
		public async Task<ActionResult<List<TasksResponce>>> GetTasks()
		{
			var tasks = await _service.GetAllTasks();
			var responce = tasks.Select(t => new TasksResponce(t.Id, t.Title, t.Description, t.Date)).OrderBy(t=> t.Date);
			return Ok(responce);
		}
		[HttpGet ("sort")]
        public async Task<ActionResult<List<TasksResponce>>> GetSortedTasks(string sort)
		{
            var tasks = await _service.GetAllTasks();
            var responce = tasks.Select(t => new TasksResponce(t.Id, t.Title, t.Description, t.Date)).OrderBy(t => t.Date);
			if (sort == "desc")
				responce = responce.OrderByDescending(x => x.Date);
            return Ok(responce);
        }


        [HttpPost]
		public async Task<ActionResult<Guid>> CreateTask([FromBody] TaskRequest taskRequest)
        {
			var entity = Tasks.Create(Guid.NewGuid(),
				taskRequest.Title,
				taskRequest.Description,
				taskRequest.Date);
			
			var tasks = await _service.CreateNewTask(entity);
			return Ok(tasks);
		}
	}
}

