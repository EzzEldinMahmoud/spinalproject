using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace spinalproject.src.controllers.appointment
{
    [Route("api/appoint/")]
    [ApiController]
    public class appointmentController : ControllerBase
    {
        private readonly appointmentService _appointmentService;
        public appointmentController(appointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpGet("{userId}/{appointmentId}")]
        public ActionResult<AppointmentDTO> getOne(Guid userId , Guid appointmentId)
        {
            try
            {
                
                var foundAppointment = _appointmentService.getAppointment(userId, appointmentId);
                return Ok(foundAppointment);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<AppointmentDTO>> getAll(Guid userId)
        {
            try
            {

                var foundAppointment = _appointmentService.getAllAppointment(userId);
                return Ok(foundAppointment);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("create/{userId}")]
        public ActionResult<AppointmentDTO> create(Guid userId , [FromBody] AppointmentDTO appointmentDetails )
        {
            try
            {
                

                var foundAppointment = _appointmentService.createAppointment(userId, appointmentDetails);
                return Ok(foundAppointment);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPatch("update/{userId}/{appointmentId}")]

        public ActionResult<AppointmentDTO> update(Guid userId, Guid appointmentId, [FromBody] JsonPatchDocument<AppointmentEntity> patchDocAppointmentDetails) {

            try
            {
                var findAppointment = _appointmentService.getAppointment(userId, appointmentId);
                 if (findAppointment == null || patchDocAppointmentDetails == null)
                {
                    return BadRequest("Appointment not found!");
                }
                else
                {
                    
                    patchDocAppointmentDetails.ApplyTo(findAppointment, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    _appointmentService.SaveChanges();
                    return Ok(findAppointment);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpDelete("delete/{userId}/{appointmentId}")]
        public ActionResult deleteAppointment(Guid userId,Guid appointmentId) {

            var deleteOperation = _appointmentService.deleteAppointment(userId, appointmentId);
            if (deleteOperation) return NoContent();
            else return BadRequest();
        }

    }
}
