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
    public class AppointmentsController : ControllerBase
    {

        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;


        public AppointmentsController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }


        // GET: api/<AppointmentsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _appointmentService.GetAllAsync();
            var listDto = _mapper.Map<IEnumerable<AppointmentDto>>(list);
            return Ok(listDto);
        }



        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var appointment = _appointmentService.GetById(id);
            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
            return Ok(appointmentDto);
        }



        // POST api/<AppointmentsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AppointmentPostModel newAppointment)
        {
            var appointmentToAdd= new Appointment {Title=newAppointment.Title, Day=newAppointment.Day, Hour=newAppointment.Hour, BabyId=newAppointment.BabyId, NurseId=newAppointment.NurseId };
            var appointmentNew = await _appointmentService.PostAppointmentAsync(appointmentToAdd);
            return Ok (appointmentNew);
        }



        // PUT api/<AppointmentsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AppointmentPostModel appointment)
        {
            var appointmentToUpdate = new Appointment {Day = appointment.Day, Title = appointment.Title, Hour=appointment.Hour };
            var result = await _appointmentService.PutAppointmentAsync(id, appointmentToUpdate);
            return Ok(result);
        }





        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var appointment = _appointmentService.GetById(id);
            if (appointment is null)
            {
                return NotFound();
            }

            await _appointmentService.DeleteAppointmentAsync(id);
            return NoContent();
        }
    }
}
