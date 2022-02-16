using DotNetExpert.Lead.Library.Models;
using DotNetExpert.Lead.Service.IService;
using DotNetExpert.Lead.ViewModel.Category;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace DotNetExpert.Lead.Pages.Category
{
    public class NewEditModel : ComponentBase
    {
        [Inject]
		protected ICategoryService categoryService { get; set; }

		[Inject]
		protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

		[Inject]
		public NavigationManager UrlNavigationManager { get; set; }
		[Parameter]
		public int id { get; set; }

		protected string Title = "New";
		public CategoryViewModel viewModel = new CategoryViewModel();
		protected List<CategoryViewModel> viewModels = new List<CategoryViewModel>();

		protected override async Task OnParametersSetAsync()
		{
			if (id != 0)
			{
				Title = "Edit";
				var countryLookup = await this.categoryService.GetByIdAsync(id);
				viewModel = countryLookup;
			}
		}

		protected async Task Save()
		{
			var User = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.Claims;
			viewModel.UpdatedByUserId = User.FirstOrDefault().Value;
			viewModel.DateUpdated = DateTime.Now;
			
			if (viewModel.Id != 0)
			{
				viewModel.UpdatedByUserId = User.FirstOrDefault().Value;
				await categoryService.UpdateAsync(viewModel);
			}
			else
			{
				viewModel.IsActive = true;
				viewModel.DateCreated = DateTime.Now;
				viewModel.CreatedByUserId = User.FirstOrDefault().Value;

				await categoryService.InsertAsync(viewModel);
			}
			Redirect(Common.Entity.Category.ToString());
		}

		public void Redirect(string entity)
		{
			UrlNavigationManager.NavigateTo("/" + entity + "/Index");
		}
    }
}
