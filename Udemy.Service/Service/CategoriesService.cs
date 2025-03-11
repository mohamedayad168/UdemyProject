using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{
    public class CategoriesService(IRepositoryManager repository, IMapper mapper) : ICategoriesService
    {
        public async Task<IEnumerable<CategoryRDTO>> GetAllAsync(bool trackChanges)
        {
            var categorys = await repository.Categories.FindAll(trackChanges).ToListAsync();

            return categorys is null ? [] : mapper.Map<IEnumerable<CategoryRDTO>>(categorys);
        }

        public async Task<CategoryRDTO> GetByIdAsync(int id, bool trackChanges)
        {
            var category = await repository.Categories
                .FindByCondition(c => c.Id == id, trackChanges)
                .FirstOrDefaultAsync();

            return category is null ?
                throw new NotFoundException($"Category with id: {id} doesn't exist")
                : mapper.Map<CategoryRDTO>(category);
        }

        public async Task<CategoryRDTO> GetByTitleAsync(string title, bool trackChanges)
        {
            var category = await repository.Categories
                .FindByCondition(e => e.Name == title, trackChanges)
                .FirstOrDefaultAsync();

            return category is null ?
                throw new NotFoundException($"Category with title: {title} doesn't exist")
                : mapper.Map<CategoryRDTO>(category);
        }

        public async Task<CategoryRDTO> CreateAsync(CategoryCDTO categoryDto)
        {
            var categoryWithSameTitle = await GetByTitleAsync(categoryDto.Name, false);

            //check if same title exists
            if (categoryWithSameTitle is not null)
                throw new BadRequestException($"title: {categoryDto.Name} already exists");

            var category = mapper.Map<Category>(categoryDto);

            repository.Categories.Create(category);

            try
            {
                await repository.SaveAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at create category");
            }

            return mapper.Map<CategoryRDTO>(category);

        }

        public async Task<CategoryRDTO> UpdateAsync(CategoryUDTO categoryDto)
        {
            var categoryWithSameTitle = await GetByTitleAsync(categoryDto.Name, false);

            //check if same new title exists BUT can rename same category with same title
            if (categoryWithSameTitle is not null && categoryDto.Id != categoryWithSameTitle.Id)
                throw new BadRequestException($"title: {categoryDto.Name} already exists");


            var category = mapper.Map<Category>(categoryDto);

            repository.Categories.Update(category);

            try
            {
                await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at create update");
            }

            return mapper.Map<CategoryRDTO>(category);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await repository.Categories.FindByCondition(e => e.Id == id, false)
                .FirstOrDefaultAsync() ?? throw new NotFoundException($"category with id: {id} doesn't exist");

            repository.Categories.Delete(category);

            try
            {
                await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at category delete with id: " + id);
            }
        }
    }
}
