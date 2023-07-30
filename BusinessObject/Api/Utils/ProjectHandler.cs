using Api.BusinessObject.Steps;
using BusinessObject.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Api.Utils
{
    public class ProjectHandler
    {
        public static List<int> projectCodes = new List<int>();

        public static void AddProjectIdForDelete(int id)
        {
            projectCodes.Add(id);
        }

        public static void DeleteProjects()
        {
            var apiProjectSteps = new ProjectService();

            foreach (var project in projectCodes)
            {
                apiProjectSteps.DeleteProjectById(project);
            }
        }
    }
}
