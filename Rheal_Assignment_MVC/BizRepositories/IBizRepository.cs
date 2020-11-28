using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rheal_Assignment_MVC.BizRepositories
{
    interface IBizRepository<TEntity, in TKey> where TEntity : class
    {
        List<TEntity> getData();

        TEntity getData(TKey id);

        TEntity create(TEntity entity);

        TEntity update(TKey id, TEntity entity);

        bool delete(TKey id);

    }
}
