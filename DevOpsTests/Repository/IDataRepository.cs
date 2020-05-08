using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOpsTests.Repository
{
    interface IDataRepository<T> where T: class
    {
        public List<T> GetAll();
    }
}
