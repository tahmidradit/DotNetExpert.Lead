using DotNetExpert.Lead.Library.Models;
using DotNetExpert.Lead.Service.IService;
using DotNetExpert.Lead.ViewModel.Category;
using Microsoft.AspNetCore.Components;

namespace DotNetExpert.Lead.Pages.Category
{
    public class IndexModel : ComponentBase
    {
        [Inject]
        protected ICategoryService categoryService { get; set; }
        protected List<CategoryViewModel> viewModels = new List<CategoryViewModel>();
        protected CategoryViewModel viewModel = new CategoryViewModel();
        protected string SearchString { get; set; }
        protected int page = 0;
        protected int limit = 10;
        protected int count = 0;
        protected double pages = 0;
        protected int skip = 0;

        protected override async Task OnInitializedAsync()
        {
            if (page < 1)
            {
                page = 1;
            }
            skip = (page - 1) * limit;
            await GetAllAsync(SearchString, skip, limit);

        }

        protected async Task GetAllAsync(string search, int skip, int limit)
        {
            if (string.IsNullOrEmpty(search))
            {
                var viewModels = await categoryService.GetAllAsync(skip, limit);
                this.viewModels = viewModels.ToList();

                this.count = await this.categoryService.CountAsync();
                this.pages = Math.Ceiling((double)count / limit);
            }
            else
            {
                var viewModels = await categoryService.SearchAsync(search, skip, limit);
                this.viewModels = viewModels.ToList();

                this.count = await this.categoryService.CountAsync(search);
                this.pages = Math.Ceiling((double)count / limit);
            }

        }

        protected async Task Filter()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                skip = 0;
                page = 1;
                await GetAllAsync(SearchString, skip, limit);
            }
        }

        protected async Task Paging(int number)
        {
            if (number == 0)
            {
                return;
            }

            page = number - 1;

            if (pages >= number)
            {
                skip = page * limit;
                await GetAllAsync(SearchString, skip, limit);
                page += 1;
            }
        }

        protected void DeleteConfirm(int Id)
        {
            viewModel = viewModels.FirstOrDefault(x => x.Id == Id);
        }

        protected async Task Delete(int Id)
        {
            await Task.Run(() =>
            {
                var viewModel = this.categoryService.GetById(Id);
                if (viewModel != null)
                {
                    this.categoryService.Delete(viewModel);
                }
            });

            if (viewModels.Count() == 1)
            {
                this.skip = Common.Skip(skip, limit);
                this.page -= 1;
            }

            await GetAllAsync(SearchString, skip, limit);
        }
    }
}
