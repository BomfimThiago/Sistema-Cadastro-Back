using API.ViewModels.Base;
using AutoMapper;
using Domain.Domain.Base;
using Domain.Entities.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace API.Controllers.Base
{

    public class CrudControllerBase<T, TViewModelCadastro> : 
        ControllerBase 
        where T : Entity
        where TViewModelCadastro : EntityViewModel
    {
        private readonly IBaseDomain<T> _domain;
        private readonly IMapper _mapper;

        public CrudControllerBase(IBaseDomain<T> domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _domain.GetAllAsync());
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual IActionResult GetById(Guid id)
        {
            return Ok( _domain.GetById(id));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] TViewModelCadastro model)
        {
            var objectToCreate = _mapper.Map<TViewModelCadastro, T>(model);
            
            await _domain.AddAsync(objectToCreate);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update([FromBody] TViewModelCadastro model)
        {
            var objectToUpdate = _mapper.Map<TViewModelCadastro, T>(model);
            
            await _domain.Update(objectToUpdate);

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
