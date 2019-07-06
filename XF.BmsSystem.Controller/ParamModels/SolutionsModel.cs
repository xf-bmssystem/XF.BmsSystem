using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.BmsSystem.Controller.ParamModels
{
    [Serializable]
  public  partial  class SolutionsModel
    {
        public string CurrID { get; set; }
       public string SolutionsName { get; set; }

        public Dictionary<string, SolProjectModel> SolProjects { get; set; }

        public string CurrProjectName { get; set; }

        public string CurrCommandName { get; set; }




       


    }
}
