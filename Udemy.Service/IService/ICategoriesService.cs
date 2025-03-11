using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.IService
{
    public interface ICategoriesService
    {
        //read
        public Task<IEnumerable<CategoryRDTO>> GetAllAsync(bool trackChanges);
        public Task<CategoryRDTO> GetByTitleAsync(string title, bool trackChanges);
        public Task<CategoryRDTO> GetByIdAsync(int id, bool trackChanges);

        //write
        public Task<CategoryRDTO> CreateAsync(CategoryCDTO category);
        public Task<CategoryRDTO> UpdateAsync(CategoryUDTO category);

        //
        public Task DeleteAsync(int id);
    }
}
