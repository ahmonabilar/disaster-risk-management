using Drm.Data.Entities;
using System.Collections.Generic;

namespace Drm.Data.Repository
{
    public class TestRepository : IDrmRepository<Test>
    {
        private readonly DRMContext _ctx;

        public TestRepository(DRMContext ctx)
        {
            _ctx = ctx;
        }
        public void Delete(Test entity)
        {
            _ctx.Tests.Remove(entity);
        }

        public Test Get(int Id)
        {
            return _ctx.Tests.Find(Id);
        }

        public IEnumerable<Test> GetAll()
        {
            return _ctx.Tests;
        }

        public void Insert(Test entity)
        {
            _ctx.Tests.Add(entity);
        }

        public void Update(Test entity)
        {
            _ctx.Tests.Update(entity);
        }
        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
