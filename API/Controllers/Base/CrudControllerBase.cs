using AutoMapper;
using Domain.Domain.Base;
using Domain.Entities.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Controllers.Base
{
    public class CrudControllerBase<T, TViewModelCadastro, TViewModel> : 
        ControllerBase 
        where T : Entity
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
            var objectToGet = await _domain.GetAllAsync();
            return Ok( _mapper.Map<List<TViewModel>>(objectToGet));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual IActionResult GetById(Guid id)
        {
            var objectToGet = _domain.GetById(id);

            return Ok(_mapper.Map<TViewModel>(objectToGet));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] TViewModelCadastro model)
        {
            var objectToCreate = _mapper.Map<TViewModelCadastro, T>(model);
            
            await _domain.AddAsync(objectToCreate);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update([FromBody] TViewModel model)
        {
            var objectToUpdate = _mapper.Map<TViewModel, T>(model);
            
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
