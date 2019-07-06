using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.BmsSystem.Controller.ParamModels
{
    public partial class SolutionsModel
    {
        internal CommandModel GetCommand(string projectName, string commandName)
        {
            if (this.SolProjects.ContainsKey(projectName))
                if (this.SolProjects[projectName].ProCommands.ContainsKey(commandName))
                    return this.SolProjects[projectName].ProCommands[commandName];

            return null;
        }
    }
}
