using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.BmsSystem.Models
{
    /// <summary>
    /// Menu_Manage:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Menu_Manage
    {
        public Menu_Manage()
        { }
        #region 属性
        private string _menu_id;
        private string _menu_name;
        private string _menu_address;
        private string _menu_newname;
        private string _menu_parentid;
        private string _menu_ico;
        private int _menu_data_state;
        private DateTime _create_datetime;
        private DateTime? _update_datetime;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public string Menu_ID
        {
            set { _menu_id = value; }
            get { return _menu_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Menu_Name
        {
            set { _menu_name = value; }
            get { return _menu_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Menu_Address
        {
            set { _menu_address = value; }
            get { return _menu_address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Menu_NewName
        {
            set { _menu_newname = value; }
            get { return _menu_newname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Menu_ParentID
        {
            set { _menu_parentid = value; }
            get { return _menu_parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Menu_Ico
        {
            set { _menu_ico = value; }
            get { return _menu_ico; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Menu_Data_State
        {
            set { _menu_data_state = value; }
            get { return _menu_data_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Create_DateTime
        {
            set { _create_datetime = value; }
            get { return _create_datetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Update_DateTime
        {
            set { _update_datetime = value; }
            get { return _update_datetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model


    }
}
