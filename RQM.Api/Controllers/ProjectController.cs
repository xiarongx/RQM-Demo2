using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RQM.Data.Model;
using RQM.Data.Request;

namespace RQM.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Project")]
    public class ProjectController : Controller
    {
        // logging
        private readonly ILogger _logger;
        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
        }

        // Global ReadProject class
        ReadProject readProject = new ReadProject();

        // Global WriteProject clss
        WriteProject writeProject = new WriteProject();

        // GET: api/Project
        [HttpGet]
        public JsonResult Get()
        {

            List<Project> projectList = new List<Project>();
            try
            {
                _logger.LogInformation("Getting project list");
                // workaround
                // projectList = readProject.getProjects();
                Project project1 = new Project();
                project1.Name = "CICD";
                Project project2 = new Project();
                project2.Name = "ACRedit";
                Project project3 = new Project();
                project3.Name = "TaxBook";
                projectList.Add(project1);
                projectList.Add(project2);
                return Json(projectList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        // GET: api/Project/Admin
        // name convention: pascal
        [HttpGet("{groupTypeName}", Name = "Get")]
        public JsonResult Get(string groupTypeName)
        {
            List<Project> projectList = new List<Project>();
            try
            {
                _logger.LogInformation("Getting project list by group type name: {groupTypeName}", groupTypeName);
                projectList = readProject.getProjectsByAccessGroupTypeName(groupTypeName);
                return Json(projectList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        // POST: api/Project
        // Need Authentication?
        [HttpPost]
        public void Post([FromBody] ProjectSelection projectSelection)
        {

            try
            {
                _logger.LogInformation("Creating new project selection: {p.PojectListID}", projectSelection.ProjectListID);
                // CreatedBy and UpdatedBy are the same for creating Project_Selection
                writeProject.InsertProjectSelection(projectSelection.ProjectListID, projectSelection.CreatedBy, projectSelection.UpdatedBy, DateTime.Now);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }

        }
        
        // PUT: api/Project/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
