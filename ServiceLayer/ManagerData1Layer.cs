using System;

namespace ServiceLayer
{
    [RequestReponse]
    public class ManagerData1Layer : IManagerData1Layer
    {
        private readonly IManagerData1Repository _managerData1Repository;

        public ManagerData1Layer(IManagerData1Repository managerData1Repository)
        {
            _managerData1Repository = managerData1Repository;
        }

        public string GetData1()
        {
            return "hello";
        }

        public string GetData2()
        {
            return _managerData1Repository.GetData2();
        }
    }
}
