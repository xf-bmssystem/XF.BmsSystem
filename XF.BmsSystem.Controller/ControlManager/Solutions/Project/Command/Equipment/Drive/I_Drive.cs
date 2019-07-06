using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XF.BmsSystem.Controller.ParamModels;

namespace XF.BmsSystem.Controller.ControlManager.Solutions.Project.Command.Equipment.Drive
{
   public abstract class I_Drive
    {
        public abstract bool OpenConn(ref SolutionsModel sm);

        public abstract void CloseConn(ref SolutionsModel sm);
    }
}
