using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XF.BmsSystem.Controller.ControlManager.Solutions.Project.Command.Equipment.Drive;
using XF.BmsSystem.Controller.ControlManager.Solutions.Project.Command.Judge;
using XF.BmsSystem.Controller.GlobalObject.Event;
using XF.BmsSystem.Controller.ParamModels;

namespace XF.BmsSystem.Controller.ControlManager.Solutions.Project.Command
{
   internal class CommandManager
    {
        /// <summary>
        /// 单指令判定
        /// </summary>
        private CommandJudge _commandJudge = null;
        private CommandModel _currCommand = null;
        private SolutionsModel _solution = null;
        /// <summary>
        /// 当前工作线程状态消息
        /// 单指令结束时间
        /// </summary>
        private CancellationTokenSource _cancelTokenSource = null;

        private System.Reflection.MethodInfo _executeMethod = null;
        private I_Drive _drive = null;




        internal SolutionsModel ExecuteCommand(SolutionsModel solution)
        {
            _solution = solution;

            _cancelTokenSource = new CancellationTokenSource();
            _currCommand = _solution.GetCommand(_solution.CurrProjectName, _solution.CurrCommandName);

            if (GetFunction(_currCommand.ClassName, _currCommand.FunName, new Type[] { typeof(SolutionsModel) }))
                RunCurrOneCommandThread(_currCommand);

            return _solution;
        }

        private bool GetFunction(string classFullName, string funName, Type[] params_type)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            try
            {
                Type currType = assembly.GetType(classFullName);
                _drive = assembly.CreateInstance(classFullName) as I_Drive;
                _executeMethod = currType.GetMethod(funName, params_type);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private void RunCurrOneCommandThread( CommandModel command)
        {
            _commandJudge = new CommandJudge();
            _currCommand.SleepTime = _currCommand.SleepTime > 1 ? _currCommand.SleepTime : 100;

            Task task = Task.Factory.StartNew(ProcessOneFunCommand, _solution, _cancelTokenSource.Token);
            task.ContinueWith(OneCommandFinishEvent, _solution);

            try
            {
                task.Wait();
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void ProcessOneFunCommand<T>(T t)
        {
            if (_drive.OpenConn(ref _solution))
            {
                while (!_cancelTokenSource.IsCancellationRequested)
                {
                    System.Threading.Thread.Sleep(_currCommand.SleepTime);

                    CommandRetValue crv  = null;
                    try
                    {
                        crv = _executeMethod.Invoke(_drive, new object[] { _solution })as CommandRetValue;
                    }
                    catch (Exception ex)
                    {
                        XF.BmsSystem.Log.LogManager.WriteControllerLog("反射执行函数报错", null, ex);
                        continue;
                    }

                    if (crv.ComRetState == Command.CommandRetState.Stop)
                        break;

                    _commandJudge.JudgeCommandParams(_solution, _currCommand, crv);
                    CommandEvent.ExecuteRealDataEvent(crv);
                }

                _drive.CloseConn(ref _solution);
            }
        }



      


        private void OneCommandFinishEvent<T1, T2>(T1 arg1, T2 arg2)
        {
     
        }


    }
}
