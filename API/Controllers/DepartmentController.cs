
using API.Controllers.Base;
using AutoMapper;
using Domain.Domain.Departments;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : CrudControllerBase<Department>
    {
        private readonly IDepartmentDomain _departmentDomain;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentDomain departmentDomain, IMapper mapper) : base(departmentDomain)
        {
            _departmentDomain = departmentDomain;
            _mapper = mapper;
        }

        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] Department model)
        {
            var validator = new DepartmentValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await _departmentDomain.AddAsync(model);

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }
        
        [HttpPut("{id}")]
        public override async Task<IActionResult> Update([FromBody] Department model)
        {
            var validator = new DepartmentValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await _departmentDomain.Update(model);

            return NoContent();
        }
    }
}
