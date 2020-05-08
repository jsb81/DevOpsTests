using DevOpsTests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOpsTests.Repository
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private DevOpsTestsContext _context;

        public DataRepository(DevOpsTestsContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return this._context.Set<T>().ToList();
        }
    }
}
