using AutoMapper;
using Clinic.API.Models;
using Clinic.Core;
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
    public class BabysController : ControllerBase
    {

        private readonly IBabyService _babyService;
        private readonly IMapper _mapper;


        public BabysController(IBabyService babyService, IMapper mapper)
        {
            _babyService = babyService;
            _mapper = mapper;
        }



        // GET: api/<BabysController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            //כתיבה ללוג עם requestId (middleware) 
            //var requestId = HttpContext.Items["requestId"];

            var list = await _babyService.GetAllAsync();
            var listDto=_mapper.Map<IEnumerable<BabyDto>>(list);
            return Ok(listDto);
        }



        // GET api/<BabysController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var baby = _babyService.GetById(id);
            var babyDto =_mapper.Map<BabyDto>(baby);
            return Ok(babyDto);
        }



        // POST api/<BabysController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BabyPostModel newBaby)
        {
            var babyToAdd = new Baby {Name = newBaby.Name, Age = newBaby.Age};
            var babyNew = await _babyService.PostBabyAsync(babyToAdd);
            return Ok(babyNew);
        }


        // PUT api/<BabysController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BabyPostModel baby)
        {
            var babyToUpdate = new Baby { Name = baby.Name, Age = baby.Age };
            var result = await _babyService.PutBabyAsync(id, babyToUpdate);
            return Ok(result);
        }


        // DELETE api/<BabysController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var baby=_babyService.GetById(id);
            if(baby is null)
            {
                return NotFound();
            }

            await _babyService.DeleteBabyAsync(id);
            return NoContent(); 
        }
    }
}
