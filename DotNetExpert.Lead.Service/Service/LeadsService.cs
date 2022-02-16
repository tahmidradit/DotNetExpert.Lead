using DotNetExpert.Lead.Repository.Data;
using DotNetExpert.Lead.Repository.UnitOfWork;
using DotNetExpert.Lead.Service.IService;
using DotNetExpert.Lead.ViewModel.Leads;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.Service.Service
{
    public class LeadsService : ILeadsService
    {
		private readonly IUnitOfWork _unitOfWork;

        private readonly ApplicationDbContext context;

        public LeadsService(IUnitOfWork unitOfWork, ApplicationDbContext context)
		{
			this._unitOfWork = unitOfWork;
            this.context = context;
        }

		public async Task<int> CountAsync()
		{
			return await this._unitOfWork.Leads.CountAsync();
		}

		public async Task<int> CountAsync(string search)
		{
			return await this._unitOfWork.Leads.CountAsync(search);
		}

		public void Delete(LeadsViewModel viewModel)
		{
			this._unitOfWork.Leads.Remove(LeadsDTO.ConvertToEntity(viewModel));
			this._unitOfWork.Commit();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(LeadsViewModel viewModel)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<LeadsViewModel> GetAll()
		{
			return LeadsDTO.ConvertToViewModelList(context.Leads.Include(x => x.Category).ToList());
		}

		public IEnumerable<LeadsViewModel> GetAll(int skipt, int limit)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<LeadsViewModel>> GetAllAsync()
		{
			return LeadsDTO.ConvertToViewModelList(await _unitOfWork.Leads.GetAllAsync());
		}

		public async Task<IEnumerable<LeadsViewModel>> GetAllAsync(int skip, int limit)
		{
			return LeadsDTO.ConvertToViewModelList(await _unitOfWork.Leads.GetAllAsync(skip, limit));
		}

		public LeadsViewModel GetById(int id)
		{
			return LeadsDTO.ConvertToViewModel(_unitOfWork.Leads.GetById(id));
		}

		public async ValueTask<LeadsViewModel> GetByIdAsync(int id)
		{
			return LeadsDTO.ConvertToViewModel(await this._unitOfWork.Leads.GetByIdAsync(id));
		}

		public int Insert(LeadsViewModel viewModel)
		{
			throw new NotImplementedException();
		}

		public async Task<int> InsertAsync(LeadsViewModel viewModel)
		{
			int id = await this._unitOfWork.Leads.InsertAsync(LeadsDTO.ConvertToEntity(viewModel));

			await this._unitOfWork.CommitAsync();

			return id;
		}

		public async Task<IEnumerable<LeadsViewModel>> SearchAsync(string search, int skip, int limit)
		{
			return LeadsDTO.ConvertToViewModelList(await _unitOfWork.Leads.SearchAsync(search, skip, limit));
		}

		public void Update(LeadsViewModel viewModel)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateAsync(LeadsViewModel viewModel)
		{
			await this._unitOfWork.Leads.UpdateAsync(LeadsDTO.ConvertToEntity(viewModel));
			await this._unitOfWork.CommitAsync();
		}
	}
}
