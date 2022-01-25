using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Repositories
{
    //would use this generic pattern for a more complex system
    public interface IGet<Movie, T>
    {
        T GetByID(int MovieID);
        IEnumerable<T> GetAll();
    }
}
