using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XF.BmsSystem.Controller.ControlManager.Solutions.Project.Command;

namespace XF.BmsSystem.Controller.GlobalObject.Event
{
  public  static class CommandEvent
    {
        public static event Action<CommandRetValue> RealDataEvent;

        public static void ExecuteRealDataEvent(CommandRetValue crv)
        {
            if (RealDataEvent != null)
            {
                try
                {
                    RealDataEvent.BeginInvoke(crv, null, null);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }


    }
}
