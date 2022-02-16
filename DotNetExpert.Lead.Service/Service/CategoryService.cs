using DotNetExpert.Lead.Repository.UnitOfWork;
using DotNetExpert.Lead.Service.IService;
using DotNetExpert.Lead.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.Service.Service
{
    public class CategoryService : ICategoryService
    {
		private readonly IUnitOfWork _unitOfWork;
		public CategoryService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task<int> CountAsync()
		{
			return await this._unitOfWork.Category.CountAsync();
		}

		public async Task<int> CountAsync(string search)
		{
			return await this._unitOfWork.Category.CountAsync(search);
		}

		public void Delete(CategoryViewModel viewModel)
		{
			this._unitOfWork.Category.Remove(CategoryDTO.ConvertToEntity(viewModel));
			this._unitOfWork.Commit();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(CategoryViewModel viewModel)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<CategoryViewModel> GetAll()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<CategoryViewModel> GetAll(int skipt, int limit)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
		{
			return CategoryDTO.ConvertToViewModelList(await _unitOfWork.Category.GetAllAsync());
		}

		public async Task<IEnumerable<CategoryViewModel>> GetAllAsync(int skip, int limit)
		{
			return CategoryDTO.ConvertToViewModelList(await _unitOfWork.Category.GetAllAsync(skip, limit));
		}

		public CategoryViewModel GetById(int id)
		{
			return CategoryDTO.ConvertToViewModel(_unitOfWork.Category.GetById(id));
		}

		public async ValueTask<CategoryViewModel> GetByIdAsync(int id)
		{
			return CategoryDTO.ConvertToViewModel(await this._unitOfWork.Category.GetByIdAsync(id));
		}

		public int Insert(CategoryViewModel viewModel)
		{
			throw new NotImplementedException();
		}

		public async Task<int> InsertAsync(CategoryViewModel viewModel)
		{
			int id = await this._unitOfWork.Category.InsertAsync(CategoryDTO.ConvertToEntity(viewModel));

			await this._unitOfWork.CommitAsync();

			return id;
		}

		public async Task<IEnumerable<CategoryViewModel>> SearchAsync(string search, int skip, int limit)
		{
			return CategoryDTO.ConvertToViewModelList(await _unitOfWork.Category.SearchAsync(search, skip, limit));
		}

		public void Update(CategoryViewModel viewModel)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateAsync(CategoryViewModel viewModel)
		{
			await this._unitOfWork.Category.UpdateAsync(CategoryDTO.ConvertToEntity(viewModel));
			await this._unitOfWork.CommitAsync();
		}
	}
}
