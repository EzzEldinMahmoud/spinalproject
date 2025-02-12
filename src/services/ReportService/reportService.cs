using AutoMapper;
using Microsoft.EntityFrameworkCore;
using spinalproject.src.appointDbContext;
using spinalproject.src.Profiles;

public class ReportService
{
    // add interface in place of the actual class implementation
    private readonly appointDbContext _reportRepository;
    private IMapper _mapper;
    public ReportService(appointDbContext appointmentcontext, IMapper mapper)
    {
        _reportRepository = appointmentcontext;
        _mapper = mapper;
    }
    public ReportEntity createReport(Guid userId, ReportDTO reportDetails)
    {
        //diagnosis
        //notes
        //status
        //cab_angle
        //patient_id
        //create report
        var createReport = ReportConvertToEntity(reportDetails);
        var newReport = _reportRepository.Add(createReport);
        SaveChanges();
        return createReport;
    }
    public ReportEntity findReport(Guid userId, Guid reportId)
    {
        var related_User = _reportRepository.Users.FirstOrDefaultAsync(user => user.id == userId).Result;
        if (related_User != null)
        {
            var findReport = _reportRepository.Reports.FirstOrDefaultAsync(report => report.id == reportId && report.patient_id == userId).Result;
            if(findReport == null)
            {
                throw new Exception("Report not found");
            }
            return findReport;
        } else
        {
            throw new Exception("User not found");
        }
    }
    public void deleteReport(Guid userId, Guid reportId)
    {
        var related_User = _reportRepository.Users.FirstOrDefaultAsync(user => user.id == userId).Result;
        if (related_User != null)
        {
            var findReport = _reportRepository.Reports.FirstOrDefaultAsync(report => report.id == reportId && report.patient_id == userId).Result;
            if (findReport == null)
            {
                throw new Exception("Report not found");
            }
            _reportRepository.Remove(findReport);
            SaveChanges();
        }
        else
        {
            throw new Exception("User not found");
        }
    }

    public List<ReportDTO> getAll_report(Guid userId)
    {
        var related_user = _reportRepository.Users.FirstOrDefaultAsync(user => user.id == userId).Result;
        if (related_user != null)
        {
            var all_reports = _reportRepository.Reports.Where(report => report.patient_id == userId).ToList();
            return _mapper.Map<List<ReportDTO>>(all_reports);
        }
        else
        {
            throw new Exception("User not found");
        }
    }
    // needs to add partial update here!!!
    public void SaveChanges()
    {
        _reportRepository.SaveChanges();
        _reportRepository.Dispose();

    }
    public ReportEntity ReportConvertToEntity(ReportDTO reportDetails)
    {
        return _mapper.Map<ReportEntity>(reportDetails);
    }
    public ReportDTO ReportConvertToDTO(ReportEntity reportDetails)
    {
        return _mapper.Map<ReportDTO>(reportDetails);
    }
}