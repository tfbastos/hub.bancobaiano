﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco.Baiano.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All { get; }
        TEntity Find(int key);
        void Incluir(params TEntity[] obj);
        void Alterar(params TEntity[] obj);
        void Excluir(params TEntity[] obj);
    }
}
