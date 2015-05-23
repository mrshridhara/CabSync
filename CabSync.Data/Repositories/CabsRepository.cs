using Simple.Data;
using System;
using System.Collections.Generic;

namespace CabSync.Data.Repositories
{
    public sealed class CabsRepository : IRepository<Cab>
    {
        public Cab Create(Cab entiry)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cab> Read()
        {
            var db = Database.Open();
            return db.Cabs.All();
        }

        public void Update(Cab entiry)
        {
            throw new NotImplementedException();
        }
    }
}