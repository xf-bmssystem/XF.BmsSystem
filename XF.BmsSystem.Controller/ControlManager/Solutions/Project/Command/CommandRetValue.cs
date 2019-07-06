using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.BmsSystem.Controller.ControlManager.Solutions.Project.Command
{
    [Serializable]
  public   class CommandRetValue
    {
        public CommandRetState ComRetState { get; set; }

    }

    public enum CommandRetState
    {
        /// <summary>
        /// 立即停止执行单指令
        /// </summary>
        Stop
    }
}
