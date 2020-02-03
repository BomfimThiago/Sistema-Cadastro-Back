using API.Controllers.Base;
using API.ViewModels.Departments;
using AutoMapper;
using Domain.Domain.Departments;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{   
    [Authorize]
    [Route("api/[controller]")]
    public class DepartmentController : CrudControllerBase<Department, DepartmentViewModelCadastro>
    {
        private readonly IDepartmentDomain _departmentDomain;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentDomain departmentDomain, IMapper mapper) : base(departmentDomain, mapper)
        {
            _departmentDomain = departmentDomain;
            _mapper = mapper;
        }

        
        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] DepartmentViewModelCadastro model)
        {
            var departmentToCreate = _mapper.Map<DepartmentViewModelCadastro, Department>(model);
            
            var validator = new DepartmentValidator();
            
            var validationResult = await validator.ValidateAsync(departmentToCreate);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await _departmentDomain.AddAsync(departmentToCreate);

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }
        
        [HttpPut("{id}")]
        public override async Task<IActionResult> Update([FromBody] DepartmentViewModelCadastro model)
        {
            var departmentToUpdate = _mapper.Map<DepartmentViewModelCadastro, Department>(model);
            
            var validator = new DepartmentValidator();
            var validationResult = await validator.ValidateAsync(departmentToUpdate);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await _departmentDomain.Update(departmentToUpdate);

            return NoContent();
        }
    }
}
