using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XF.BmsSystem.Controller.ControlManager.Solutions.Project;
using XF.BmsSystem.Controller.ParamModels;

namespace XF.BmsSystem.Controller.ControlManager.Solutions
{
 public    class SolutionManager
    {
        private SolutionsModel _solution = null;
        private ProjectManager _project = null;

        public object ExecuteSolution(SolutionsModel solution)
        {
            _solution = solution;

            if (_project == null)
                _project = new ProjectManager();
            
            foreach (string pn in solution.SolProjects.Keys)
            {
                solution.CurrProjectName = pn;
               _project.ExecuteProject(ref solution);
            }

            return solution;
        }

        public void DisposeSolution()
        {
            try
            {
                if (_solution != null)
                {
                    _solution = null;
                }


            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
