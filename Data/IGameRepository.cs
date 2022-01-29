using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IGameRepository: IRepository<Game>
    {
        Task<IEnumerable<Game>> FindByCategoryIdAsync(int id);
        Task<Game> AddCategoryForGameAsync(int id, Category category);
    }
}
