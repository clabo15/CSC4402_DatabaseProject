using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDBProj.Interfaces;
using TestDBProj.Repository.Interfaces;

namespace TestDBProj.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context) {  _context = context; }

        //private IBostonBikeRepository _bostonbikes;
        //public IBostonBikeRepository BostonBikes => _bostonbikes ??= new 

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
