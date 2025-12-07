using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Dtos;
using ToDoList.Application.Services.IServices;

namespace ToDoListApi.Controllers.TaskController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;
        public TasksController(ITaskService service)
        {
            _service = service;

        }
        [HttpGet("AllTask")]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _service.GetAllAsync();
            return Ok(tasks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var task = await _service.GetByIdAsync(id);
            if (task == null) 
                return NotFound();
            return Ok(task);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Create([FromBody] TaskCreateDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new {id = created.Id}, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TaskUpdateDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound();


            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();

        }
    }
}
