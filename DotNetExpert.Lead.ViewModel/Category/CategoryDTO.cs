using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.ViewModel.Category
{
    public static class CategoryDTO
    {
		public static Data.Entity.Category ConvertToEntity(CategoryViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new Data.Entity.Category
			{
				Id = viewModel.Id,
				Name = viewModel.Name,
				//IsForMaterial = viewModel.IsForMaterial,
				IsActive = viewModel.IsActive,
				DateCreated = viewModel.DateCreated,
				DateUpdated = viewModel.DateUpdated,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId
			};
		}

		public static CategoryViewModel ConvertToViewModel(Data.Entity.Category dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new CategoryViewModel
			{
				Id = dataEntity.Id,
				Name = dataEntity.Name,
				//IsForMaterial = dataEntity.IsForMaterial,
				IsActive = dataEntity.IsActive,
				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId
			};
		}

		public static IEnumerable<CategoryViewModel> ConvertToViewModelList(IEnumerable<Data.Entity.Category> dataEntityList)
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
