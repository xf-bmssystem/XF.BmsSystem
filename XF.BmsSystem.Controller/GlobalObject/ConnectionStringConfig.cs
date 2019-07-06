using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.BmsSystem.Controller.GlobalObject
{
    public static class ConnectionStringConfig
    {
        private static string _SqliteSystemConfig = null;
        private static string _SqlserverDataManager = null;


        /// <summary>
        /// 本地sqlite系统基础配置数据库
        /// </summary>
        public static string SqliteSystemConfig
        {
            get {

                if (string.IsNullOrEmpty(_SqliteSystemConfig))
                    _SqliteSystemConfig = GetConfigConnectionStrings("SqliteSystemConfig").Replace("[FileAddress]", System.Windows.Forms.Application.StartupPath);

                return _SqliteSystemConfig;
            }
        }

        /// <summary>
        /// sqlserver数据存储数据库
        /// 判定数据
        /// </summary>
        public static string SqlserverDataManager
        {
            get {
                if (string.IsNullOrEmpty(_SqlserverDataManager))
                    _SqlserverDataManager = GetConfigConnectionStrings("SqlserverDataManager");

                return _SqlserverDataManager;
            }
        }




        private static string GetConfigConnectionStrings(string strKey)
        {
            try
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[strKey].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }

}
