using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using spinalproject.src.appointDbContext;

public class appointmentService
{
    // add interface in place of the actual class implementation
    private readonly appointDbContext _appointmentRepository;
    private IMapper _mapper;
    public appointmentService(appointDbContext appointmentcontext,IMapper mapper)
    {
        _appointmentRepository = appointmentcontext;
        _mapper = mapper;
    }
    public AppointmentEntity createAppointment(Guid userId , AppointmentDTO appointmentDetails)
    {
        //patient status
        //patient id
        //appointment time
        //report id?
        //create appointment
        
        var validDate = DateTime.ParseExact(appointmentDetails.appointment_time, "yyyy-MM-dd HH:mm", null);

        if (validDate < DateTime.Now)
        {
            throw new Exception("Choose a present or next date.");
        }
        
        var createAppointment = new AppointmentEntity
        {
            status = appointmentDetails.status,
            patient_id = appointmentDetails.patient_id,
            appointment_time = validDate,
            reportDetails = appointmentDetails.reportDetails,
            appointmentDetails = appointmentDetails.appointmentDetails
        };
        var newAppointment = _appointmentRepository.Add(createAppointment);
        _appointmentRepository.SaveChanges();
        _appointmentRepository.Dispose();
        return createAppointment;

    }
    public bool deleteAppointment(Guid userId, Guid appointId)
    {
        var findAppointment = _appointmentRepository.Appointments.FirstOrDefaultAsync(app => app.id == appointId && app.patient_id == userId.ToString()).Result;
        if (findAppointment == null)
        {
            throw new Exception("Appointment not found");

        }
        else
        {
            _appointmentRepository.Remove(findAppointment);
            _appointmentRepository.SaveChanges();
            return true;
        }
    }
    public AppointmentEntity getAppointment(Guid userId, Guid appointId)
    {
        var findAppointment = _appointmentRepository.Appointments.FirstOrDefaultAsync(app => app.id == appointId && app.patient_id == userId.ToString()).Result;

        if (findAppointment == null)
        {
            throw new Exception("Appointment not found");
        }
        else
        {
            return findAppointment;
        }
    }
    public IEnumerable<AppointmentEntity> getAllAppointment(Guid userId)
    {
        var findAppointment = _appointmentRepository.Appointments.AsNoTracking().Where(app => app.patient_id == userId.ToString()).ToListAsync().Result;
        if (findAppointment.Count == 0)
        {
            throw new Exception("Appointments not found");
        }
        else
        {
            return findAppointment;
        }
    }
    // needs to add partial update here!!!
    public void SaveChanges()
    {
        _appointmentRepository.SaveChanges();
        _appointmentRepository.Dispose();

    }
    public AppointmentEntity AppointmentConvertToEntity(AppointmentDTO appoint)
    {
        return _mapper.Map<AppointmentEntity>(appoint);
    }
}