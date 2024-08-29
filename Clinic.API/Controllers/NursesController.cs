using AutoMapper;
using Clinic.API.Models;
using Clinic.Core.DTOs;
using Clinic.Core.Models;
using Clinic.Core.Services;
using Clinic.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class NursesController : ControllerBase
    {

        private readonly  INurseService _nurseService;
        private readonly IMapper _mapper;


        public NursesController(INurseService nurseService, IMapper mapper)
        {
            _nurseService = nurseService;
            _mapper = mapper;
        }



        // GET: api/<NursesController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _nurseService.GetAllAsync();
            var listDto = _mapper.Map<IEnumerable<NurseDto>>(list);
            return Ok(listDto);
        }


        // GET api/<NursesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var nurse = _nurseService.GetById(id);
            var nurseDto = _mapper.Map<NurseDto>(nurse);
            return Ok(nurseDto);
        }


        // POST api/<NursesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] NursePostModel newNurse)
        {
            var nurseToAdd = new Nurse { Name = newNurse.Name, PhoneNumber=newNurse.PhoneNumber, Salary=newNurse.Salary };
            var NurseNew = await _nurseService.PostNurseAsync(nurseToAdd);
            return Ok(NurseNew);
        }



        // PUT api/<NursesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] NursePostModel nurse)
        {
            var nurseToUpdate = new Nurse { Name = nurse.Name, Salary=nurse.Salary, PhoneNumber=nurse.PhoneNumber};
            var result = await _nurseService.PutNurseAsync(id, nurseToUpdate);
            return Ok(result);
        }




        // DELETE api/<NursesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var nurse = _nurseService.GetById(id);
            if (nurse is null)
            {
                return NotFound();
            }

            await _nurseService.DeleteNurseAsync(id);
            return NoContent();
        }
    }
}
