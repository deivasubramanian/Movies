using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Repositories
{
    public interface IGet<Movie, T>
    {
        T GetByID(int MovieID);
        IEnumerable<T> GetAll();
    }
}
