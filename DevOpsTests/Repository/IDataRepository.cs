using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOpsTests.Repository
{
    public interface IDataRepository<T> where T: class
    {
        public List<T> ToList();

        public Task<T> FindAsync(int id);
    }
}
