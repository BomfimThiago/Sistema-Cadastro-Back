using Domain.Domain.Base;
using Domain.Entities.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers.Base
{

    public class CrudControllerBase<T> : ControllerBase where T : Entity
    {
        private readonly IBaseDomain<T> _domain;
        public CrudControllerBase(IBaseDomain<T> domain)
        {
            _domain = domain;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _domain.GetAllAsync());
        }

        [HttpGet("{id}")]
        public virtual IActionResult GetById(Guid id)
        {
            return Ok( _domain.GetById(id));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] T model)
        {
            await _domain.AddAsync(model);

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update([FromBody] T model)
        {
            await _domain.Update(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
                return BadRequest();
            
            await _domain.Delete(id);

            return NoContent();
        }
    }
}
