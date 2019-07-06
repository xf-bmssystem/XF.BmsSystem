using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.BmsSystem.Controller.ControlManager.Save
{
  internal abstract  class ISave
    {
        protected abstract string ConnString { get; set; }

        protected abstract string TabName { get; set; }


        protected DataTable _dTData = null;
        protected object _dTDataFlag = new object();

        /// <summary>
        /// 当前缓存数据表
        /// </summary>
        public DataTable DTData
        {
            get
            {
                lock (_dTDataFlag)
                    return _dTData;
            }
            set
            {
                lock (_dTDataFlag)
                    _dTData = value;
            }
        }

        public void UpdateConnectionString(string strConn)
        {
            ConnString = strConn;
        }




        public abstract bool InitDataTable();

        public abstract bool AddDataRows(object o);


        public abstract bool SaveData(object o);

        public abstract void ClearAllRowData();




        public DataTable QuerySqlServer(string sql)
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                try
                {
                    connection.Open();

                    using (SqlDataAdapter command = new SqlDataAdapter(sql, connection))
                    {
                        DataSet ds = new DataSet();
                        command.Fill(ds, "ds");
                        return ds.Tables[0];
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }



        protected bool SaveToDb()
        {
            bool retState = false;
            if (!string.IsNullOrEmpty(ConnString))
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlTransaction tran = conn.BeginTransaction())
                        {
                            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran))
                            {
                                lock (_dTDataFlag)
                                {
                                    bulkCopy.DestinationTableName = TabName;
                                    bulkCopy.BatchSize = _dTData.Rows.Count;
                                    bulkCopy.WriteToServer(_dTData);

                                    _dTData.Rows.Clear();
                                    tran.Commit();
                                    retState = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XF.BmsSystem.Log.LogManager.WriteControllerLog("将解析后内存中的临时表拷贝到服务器SQL server中的解析表错误", null, ex);
                    }
                }
            }
            return retState;
        }

        protected void DeleteDataRows(object o)
        {
            if (DTData != null)
                if (DTData.Rows.Count > 0)
                    DTData.Rows.Clear();
        }
    }
}
