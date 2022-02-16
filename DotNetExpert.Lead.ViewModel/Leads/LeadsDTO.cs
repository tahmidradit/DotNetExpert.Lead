using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.ViewModel.Leads
{
	public static class LeadsDTO
	{
		public static Data.Entity.Leads ConvertToEntity(LeadsViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new Data.Entity.Leads
			{
				Id = viewModel.Id,
				FirstName = viewModel.FirstName,
				LastName = viewModel.LastName,
				Email = viewModel.Email,
				Phone = viewModel.Phone,
				Category = viewModel.Category,
				CategoryId = viewModel.CategoryId,
				//IsForMaterial = viewModel.IsForMaterial,
				IsActive = viewModel.IsActive,
				DateCreated = viewModel.DateCreated,
				DateUpdated = viewModel.DateUpdated,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId
			};
		}

		public static LeadsViewModel ConvertToViewModel(Data.Entity.Leads dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new LeadsViewModel
			{
				Id = dataEntity.Id,
				FirstName = dataEntity.FirstName,
				LastName = dataEntity.LastName,
				Email = dataEntity.Email,
				Phone = dataEntity.Phone,
				Category = dataEntity.Category,
				CategoryId = dataEntity.CategoryId,
				//IsForMaterial = viewModel.IsForMaterial,
				IsActive = dataEntity.IsActive,
				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId
			};
		}

		public static IEnumerable<LeadsViewModel> ConvertToViewModelList(IEnumerable<Data.Entity.Leads> dataEntityList)
		{
			if (dataEntityList == null)
				yield break;

			foreach (var item in dataEntityList)
			{
				yield return ConvertToViewModel(item);
			}
		}
	}
}
