using lcManage.Models;
using lcManage.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lcManage.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("all")]
        public async Task<List<Subject>> AllAsync()
        {
            return await _subjectService.GetListAsync();
        }

        [HttpGet("{id}/detail")]
        public async Task<Subject> DetailsAsync(int id)
        {
            return await _subjectService.DetailsAsync(id);
        }

        [HttpPost]
        public async Task<Subject> CreateAsync([FromBody] Subject reqModel)
        {
            return await _subjectService.CreateAsync(reqModel);
        }

        [HttpPut]
        public async Task<Subject> UpdateAsync([FromBody] Subject reqModel)
        {
            return await _subjectService.UpdateAsync(reqModel);
        }

    }
}
