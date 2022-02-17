using DotNetExpert.Lead.Library.Models;
using DotNetExpert.Lead.Repository.Data;
using DotNetExpert.Lead.Repository.UnitOfWork;
using DotNetExpert.Lead.Service.IService;
using DotNetExpert.Lead.Service.Service;
using DotNetExpert.Lead.ViewModel.Category;
using DotNetExpert.Lead.ViewModel.Leads;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace DotNetExpert.Lead.Pages.Lead
{
	public class NewEditModel : ComponentBase
	{
		[Inject]
		protected ILeadsService leadsService { get; set; }

        [Inject]
        protected IUnitOfWork _unitOfWork { get; set; }

        [Inject]
		protected LeadService leadService { get; set; }

		[Inject]
		protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

		[Inject]
		public NavigationManager UrlNavigationManager { get; set; }
		[Parameter]
		public int id { get; set; }
		protected string Title = "New";
		public LeadsViewModel viewModel = new LeadsViewModel();
		
		protected List<LeadsViewModel> viewModels = new List<LeadsViewModel>();

        protected override async Task OnParametersSetAsync()
		{
			
			if (id != 0)
			{
				Title = "Edit";
				var countryLookup = await this.leadsService.GetByIdAsync(id);
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
				await leadsService.UpdateAsync(viewModel);
			}
			else
			{
				viewModel.IsActive = true;
				viewModel.DateCreated = DateTime.Now;
				viewModel.CreatedByUserId = User.FirstOrDefault().Value;
				await leadsService.InsertAsync(viewModel);
			}
			Redirect(Common.Entity.Leads.ToString());
		}
		public void Redirect(string entity)
		{
			UrlNavigationManager.NavigateTo("/" + entity + "/Index");
		}
	}
}
