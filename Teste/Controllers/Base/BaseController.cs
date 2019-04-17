using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste.Contracts;
using Teste.Models;
using Teste.Services.Base;

namespace Teste.Controllers
{
    [Route("/api/[controller]")]
    public abstract class BaseController<T> : ControllerBase where T : BaseModel
    {
        private readonly IBaseService<T> _service;

        public BaseController(IBaseService<T> service)
        {
            this._service = service;
        }

        [HttpGet("")]
        public virtual async Task<ActionResult<List<T>>> GetAsync()
        {
            var models = await this._service.ListAsync();
            return models;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> GetAsync(int id)
        {
            var model = await this._service.GetByIdAsync(id);
            return model;
        }

        [HttpPost]
        public async Task<ActionResult<T>> PostAsync([FromBody]T item)
        {
            item = await this._service.AddAsync(item);
            return Created(nameof(item), new { id = item.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, T item)
        {
            await this._service.UpdateAsync(id, item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this._service.DeleteAsync(id);
            return NoContent();
        }
    }
}