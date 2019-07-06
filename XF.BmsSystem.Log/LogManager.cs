using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace XF.BmsSystem.Log
{
    public class LogManager
    {

        private static readonly log4net.ILog _view = log4net.LogManager.GetLogger("View");
        private static readonly log4net.ILog _control = log4net.LogManager.GetLogger("Controller");

        private static object __viewFlag = new object();
        private static object _controlFlag = new object();




        public static void WriteViewLog(string strModeName, string strError, Exception se)
        {
            if (_view != null)
                if (_view.IsErrorEnabled)
                {
                    lock (__viewFlag)
                    {
                        if (!string.IsNullOrEmpty(strModeName) && !string.IsNullOrEmpty(strError))
                            _view.Error(strModeName + "-" + strError, se);
                        else
                        {
                            if (!string.IsNullOrEmpty(strModeName))
                                _view.Error(strModeName, se);
                        }
                    }
                }

        }
        public static void WriteControllerLog(string strModeName, string strError, Exception se)
        {
            if (_control != null)
                if (_control.IsErrorEnabled)
                {
                    lock (_controlFlag)
                    {
                        if (!string.IsNullOrEmpty(strModeName) && !string.IsNullOrEmpty(strError))
                            _control.Error(strModeName + "-" + strError, se);
                        else
                        {
                            if (!string.IsNullOrEmpty(strModeName))
                                _control.Error(strModeName, se);
                        }
                    }
                }
        }
    }
}
