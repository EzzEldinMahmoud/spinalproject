using AutoMapper;
using System.Collections.Generic;

namespace spinalproject.src.Profiles
{
    public class ReportProfile: Profile
    {
       public ReportProfile() {
            CreateMap<ReportEntity, ReportDTO>();
            CreateMap<ReportDTO, ReportEntity>();
            CreateMap<ReportEntity, List < ReportDTO >> ();

        }

    }
}
