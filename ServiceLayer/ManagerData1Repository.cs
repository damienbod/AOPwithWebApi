using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    [DataAccess]
    public class ManagerData1Repository : IManagerData1Repository
{
        public string GetData1()
        {
            ServiceLayerEvents.Log.LogInfoMessage("ManagerData1Repository GetData1 repo");
            return "ManagerData1Repository GetData1 repo";
        }

        public string GetData2()
        {
            ServiceLayerEvents.Log.LogInfoMessage("ManagerData1Repository GetData2 repo");
            return "ManagerData1Repository GetData2 repo";
        }
}
}
