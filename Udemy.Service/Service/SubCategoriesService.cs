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
    class SubCategoriesService(IRepositoryManager repository, IMapper mapper) : ISubCategoriesService
    {
        public async Task<SubCategoryRDTO> CreateAsync(SubCategoryCDTO subCategory)
        {
          //check if same title exists
            var subCategoryWithSameTitle = await repository.SubCategories.FindByCondition(cat => cat.Name == subCategory.Name, false).FirstOrDefaultAsync();

            if (subCategoryWithSameTitle is not null)
                throw new BadRequestException($"title: {subCategory.Name} already exists");
            //check if category exists
            var category = await repository.Categories.FindByCondition(cat => cat.Id == subCategory.CategoryId, false).FirstOrDefaultAsync() ?? throw new NotFoundException($"category with id: {subCategory.CategoryId} doesn't exist");
            //add subcategory
            var subCategoryToAdd = new SubCategory() { Name = subCategory.Name, CategoryId = subCategory.CategoryId };
            repository.SubCategories.Create(subCategoryToAdd);
            try
            {
                await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at create subcategory");
            }

            var subCategoryToReturn = new SubCategoryRDTO
            {
                Id = subCategoryToAdd.Id,
                Name = subCategoryToAdd.Name,
                Category = new CategoryRDTO()
                {
                    Name = category.Name,
                    Id = category.Id
                }
            };
            return subCategoryToReturn;
           
        }

        public async Task DeleteAsync(int id)
        {
            var subCategory = repository.SubCategories.FindByCondition(cat => cat.Id == id, false)
                .FirstOrDefault() ?? throw new NotFoundException($"subcategory with id: {id} doesn't exist");
            repository.SubCategories.Delete(subCategory);
            await repository.SaveAsync();
        }

        public async Task<IEnumerable<SubCategoryRDTO>> GetAllAsync(bool trackChanges)
        {
            var subCategories =await repository.SubCategories.FindAll(trackChanges).Include(cat => cat.Category)
                .Select(sc => new SubCategoryRDTO()
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    Category = new CategoryRDTO()
                    {
                        Id = sc.CategoryId,
                        Name = sc.Category.Name
                    }
                }).ToListAsync();

            return subCategories;
        }

        public async Task<SubCategoryRDTO> GetByIdAsync(int id, bool trackChanges)
        {
            var subCategory =await repository.SubCategories.FindByCondition(cat => cat.Id == id, trackChanges)
                .FirstOrDefaultAsync() ?? throw new NotFoundException($"subcategory with id: {id} doesn't exist");
            var subCategoryToReturn = new SubCategoryRDTO()
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                Category = new CategoryRDTO()
                {
                    Id = subCategory.CategoryId,
                    Name = subCategory.Category.Name
                }
            };

            return subCategoryToReturn;

        }

        public async Task<SubCategoryRDTO> GetByTitleAsync(string title, bool trackChanges)
        {
            var subCategory =await repository.SubCategories.FindByCondition(cat => cat.Name == title, trackChanges)
                .FirstOrDefaultAsync() ?? throw new NotFoundException($"subcategory with title: {title} doesn't exist");
            return new SubCategoryRDTO()
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                Category = new CategoryRDTO()
                {
                    Id = subCategory.CategoryId,
                    Name = subCategory.Category.Name
                }
            };
        }

        public async Task<SubCategoryRDTO> UpdateAsync(SubCategoryUDTO subCategory)
        {
            var subCategoryToUpdate = await repository.SubCategories
                                            .FindByCondition(cat => cat.Id == subCategory.Id, false)
                                            .Include(cat => cat.Category)
                                            .FirstOrDefaultAsync()
                                            ?? throw new NotFoundException($"subcategory with id: {subCategory.Id} doesn't exist");
            subCategoryToUpdate.Name = subCategory.Name;
            repository.SubCategories.Update(subCategoryToUpdate);
            try
            {
                await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at update subcategory");
            }

            return new SubCategoryRDTO()
            {
                Id = subCategoryToUpdate.Id,
                Name = subCategoryToUpdate.Name,
                Category = new CategoryRDTO()
                {
                    Id = subCategoryToUpdate.CategoryId,
                    Name = subCategoryToUpdate.Category.Name
                }
            };
        }
        
     
        
        
        
        
        }
    }

