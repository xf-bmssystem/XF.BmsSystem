using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XF.BmsSystem.Controller.ControlManager.Solutions.Project.Command;
using XF.BmsSystem.Controller.ParamModels;

namespace XF.BmsSystem.Controller.ControlManager.Solutions.Project
{
  internal  class ProjectManager
    {
        private CommandManager _command = null;

        internal void ExecuteProject(ref SolutionsModel solution)
        {
            if (_command == null)
                _command = new CommandManager();

            Dictionary<string, CommandModel> dicCommands = solution.SolProjects[solution.CurrProjectName].ProCommands;

            if (dicCommands != null)
            {
                foreach (string css in dicCommands.Keys)
                {
                    solution.CurrCommandName = css;
                    solution = _command.ExecuteCommand(solution);

                }
            }

            
        }
    }
}
