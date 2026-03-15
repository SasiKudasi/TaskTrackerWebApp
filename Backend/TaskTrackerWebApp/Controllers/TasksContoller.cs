using Microsoft.AspNetCore.Mvc;
using Task.Application.Commands.CreateTask;
using Task.Application.Commands.DeleteTask;
using Task.Application.Commands.UpdateTask;
using Task.Application.Queries.GetTask;
using Task.Application.Queries.GetTasks;
using Task.Application.Shared;
using Task.Core.Models;
using Task.Shared.Contracts;
using TaskTrackerWebApp.Contracts;

namespace TaskTrackerWebApp.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TasksContoller(
        ICommandHandler<CreateTaskCommand> createTask,
        ICommandHandler<DeleteTaskCommand> deleteTask,
        ICommandHandler<UpdateTaskCommand> updateTask,
        IQueryHandler<GetTasksQuery, List<Tasks>> getTasksQuery,
        IQueryHandler<GetTaskQuery, Tasks> getTaskQuery) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<TasksResponce>>> GetTasks([FromBody] Specification specs, CancellationToken token)
        {
            var result = await getTasksQuery.HandleAsync(new GetTasksQuery(specs.PageSize, specs.PageNum, specs.Sorting), token);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            var tasks = result.Value;
            var response = tasks.Select(x => new TasksResponce(x.Id, x.Title, x.Description, x.Date));
            return Ok(response);
        }

        [HttpGet("{taskId:guid}")]
        public async Task<ActionResult<TasksResponce>> GetTaskById(Guid taskId, CancellationToken token)
        {
            var result = await getTaskQuery.HandleAsync(new GetTaskQuery(taskId), token);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            var tasks = result.Value;
            var response = new TasksResponce(tasks.Id, tasks.Title, tasks.Description, tasks.Date);
            return Ok(response);
        }

        [HttpDelete("{taskId:guid}")]
        public async Task<ActionResult> DeleteTask(Guid taskId, CancellationToken token)
        {
            var cmd = new DeleteTaskCommand(taskId);
            var res = await deleteTask.HandleAsync(cmd, token);
            if (res.IsFailure)
            {
                return BadRequest(res.Error);
            }
            return Ok();
        }

        [HttpPatch("{taskId:guid}")]
        public async Task<ActionResult> UpdateTask([FromBody] UpdateTaskRequest request, Guid taskId, CancellationToken token)
        {
            var cmd = new UpdateTaskCommand(taskId, request.Title, request.Description);
            var res = await updateTask.HandleAsync(cmd, token);
            if (res.IsFailure)
            {
                return BadRequest(res.Error);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateTask([FromBody] TaskRequest taskRequest, CancellationToken token)
        {
            var cmd = new CreateTaskCommand(Guid.NewGuid(), taskRequest.Title, taskRequest.Description);
            var res = await createTask.HandleAsync(cmd, token);
            if (res.IsFailure)
            {
                return BadRequest(res.Error);
            }
            return Ok(cmd.TaskID);
        }
    }
}

