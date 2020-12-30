using Banco.Baiano.Context;
using Banco.Baiano.Interface;
using System;
using System.Linq;

namespace Banco.Baiano.Repository
{
    public class MyRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MyContext _context;

        public MyRepository(MyContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> All => _context.Set<TEntity>().AsQueryable();

        public void Alterar(params TEntity[] obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(params TEntity[] obj)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(int key)
        {
            throw new NotImplementedException();
        }

        public void Incluir(params TEntity[] obj)
        {
            _context.Set<TEntity>().AddRange(obj);
            _context.SaveChanges();
        }
    }
}
