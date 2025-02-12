using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace spinalproject.src.controllers.reportController
{
    [Route("api/report/")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;
        private readonly UserService _UserService;



        public ReportController(ReportService reportService,UserService userserv)
        {
            _reportService = reportService;
            _UserService = userserv;
        }

        [HttpPatch("update/{userId}/{reportId}")]

        public ActionResult<ReportDTO> update(Guid userId, Guid reportId, [FromBody] JsonPatchDocument<ReportEntity> patchDocReportDetails)
        {

            try
            {
                var findReport = _reportService.findReport(userId, reportId);
                if (findReport == null || patchDocReportDetails == null)
                {
                    return BadRequest("Report not found!");
                }
                else
                {

                    patchDocReportDetails.ApplyTo(findReport, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    _reportService.SaveChanges();
                    var patched_Report = _reportService.findReport(userId, reportId);
                    return Ok(patched_Report);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        
        [HttpPost("create/{userId}")]
        public ActionResult<ReportDTO> create_report(Guid userId, [FromBody]ReportDTO reportDetails)
        {
            try
            {
                var related_User = _UserService.getUser(userId);
                if (related_User == null)
                {
                    return BadRequest("User not found");
                }
                var createdReport = _reportService.createReport(userId, reportDetails);
                return Ok(createdReport);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("delete/{userId}/{reportId}")]
        public ActionResult deleteReport(Guid userId, Guid reportId)
        {
            try
            {
                _reportService.deleteReport(userId, reportId);
                return Ok("Report deleted!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("getall/{userId}")]
        public ActionResult<List<ReportDTO>> getAll_report(Guid userId)
        {
            try
            {
                var all_reports = _reportService.getAll_report(userId);
                return Ok(all_reports);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{userId}/{reportId}")]
        public ActionResult<ReportDTO> getReport(Guid userId, Guid reportId)
        {
            try
            {
                var findReport = _reportService.findReport(userId, reportId);
                return Ok(findReport);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
