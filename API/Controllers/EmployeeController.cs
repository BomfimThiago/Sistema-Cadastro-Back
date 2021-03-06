﻿using API.Controllers.Base;
using API.ViewModels;
using API.ViewModels.Employees;
using AutoMapper;
using Domain.Domain.Employees;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EmployeeController : CrudControllerBase<Employee, EmployeeViewModelCadastro, 
        EmployeeViewModel>
    {
        private readonly IEmployeeDomain _domain;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeDomain domain, IMapper mapper) : base(domain, mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }
        
        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<IActionResult> Search(string q, Guid? departmentId)
        {
           var employees = await _domain.Search(q, departmentId);
           return Ok( _mapper.Map<List<Employee>, List<EmployeeViewModelSimplificada>>(employees));
                    
        }

        [AllowAnonymous]
        [HttpGet("search/{departmentId}")]
        public async Task<IActionResult> GetEmployeesByDepartmentId(Guid departmentId)
        {
            var employees = await _domain.GetEmployeesByDepartmentId(departmentId);
            return Ok(_mapper.Map<List<Employee>, List<EmployeeViewModelSimplificada>>(employees));
        }

        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] EmployeeViewModelCadastro model)
        {
            var employeeToCreate = _mapper.Map<EmployeeViewModelCadastro, Employee>(model);
            
            var validator = new EmployeeValidator();
            var validationResult = await validator.ValidateAsync(employeeToCreate);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _domain.AddAsync(employeeToCreate);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public override async Task<IActionResult> Update([FromBody] EmployeeViewModel model)
        {
            var employeeToUpdate = _mapper.Map<EmployeeViewModel, Employee>(model);

            var validator = new EmployeeValidator();
            var validationResult = await validator.ValidateAsync(employeeToUpdate);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            
            await _domain.Update(employeeToUpdate);

            return NoContent();
        }
    }
}
