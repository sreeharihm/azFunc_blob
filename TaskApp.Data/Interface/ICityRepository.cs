using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Data.Model;

namespace TaskApp.Data.Interface
{
    public interface ICityRepository
    {
        Task Create(City cities);

        Task<List<City>> GetAll(string date);
    }
}
