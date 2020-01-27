using API.Controllers.Base;
using API.ViewModels;
using API.ViewModels.Employees;
using AutoMapper;
using Domain.Domain.Employees;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : CrudControllerBase<Employee>
    {
        private readonly IEmployeeDomain _domain;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeDomain domain, IMapper mapper) : base(domain)
        {
            _domain = domain;
            _mapper = mapper;
        }
        

        [HttpGet("search")]
        public async Task<IActionResult> Search(string q, Guid? departmentId)
        {
            var employees = await _domain.Search(q, departmentId);
           return Ok( _mapper.Map<List<Employee>, List<EmployeeViewModelSimplificada>>(employees));
                    
        }

        [HttpGet("search/{departmentId}")]
        public async Task<IActionResult> GetEmployeesByDepartmentId(Guid departmentId)
        {
            return Ok(await _domain.GetEmployeesByDepartmentId(departmentId));
        }

        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] Employee model)
        {
            var validator = new EmployeeValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            
            {
                return BadRequest(validationResult.Errors);
            }
            await _domain.AddAsync(model);

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public override async Task<IActionResult> Update([FromBody] Employee model)
        {
            var validator = new EmployeeValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            
            await _domain.Update(model);

            return NoContent();
        }
    }
}
