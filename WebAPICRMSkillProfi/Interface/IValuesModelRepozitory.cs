using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICRMSkillProfi.Interface
{
    public interface IValuesModelRepozitory<M>
    {
        Task AddAsync(M _item);
        Task DeleteAsync(string _id);
        Task EditAsync(string _idOldItem, M _itemEdit);
        Task<IEnumerable<M>> GetListAsync();
    }
}
