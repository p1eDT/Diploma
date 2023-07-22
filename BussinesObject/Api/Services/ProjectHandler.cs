using Api.BusinessObject.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObject.Api.Services
{
    public class ProjectHandler
    {
        public static List<string> projectCodes = new List<string>();

        public static void AddProjectCodeForDelete(string code)
        {
            projectCodes.Add(code);
        }

        public static void DeleteProjects()
        {
            var apiProjectSteps = new ApiProjectSteps();

            foreach (var project in projectCodes)
            {
                apiProjectSteps.DeleteProjectByCode(project);
            }
        }
    }
}
