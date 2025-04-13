using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.IService
{
    public interface ISubCategoriesService
    {
        //read
        public Task<IEnumerable<SubCategoryRDTO>> GetAllAsync(bool trackChanges);
        public Task<SubCategoryRDTO> GetByTitleAsync(string title, bool trackChanges);
        public Task<SubCategoryRDTO> GetByIdAsync(int id, bool trackChanges);

        //write
        public Task<SubCategoryRDTO> CreateAsync(SubCategoryCDTO subCategory);
        public Task<SubCategoryRDTO> UpdateAsync(SubCategoryUDTO subCategory);

        //
        public Task DeleteAsync(int id);
        Task<IEnumerable<SubCategoryRDTO>> GetByCategoryIdAsync(int categoryId, bool trackChanges);

    }
}
