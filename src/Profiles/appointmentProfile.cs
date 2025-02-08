using AutoMapper;

namespace spinalproject.src.Profiles
{
    public class appointmentProfile: Profile
    {
        public appointmentProfile()
        {
            CreateMap<AppointmentDTO, AppointmentEntity>();
            CreateMap<AppointmentEntity, AppointmentDTO>();
        }
    }
}
