using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using WindowsOrders.BLL.ApiServices;
using WindowsOrders.BLL.ApiServices.Extensions;
using WindowsOrders.BLL.Repos.Dtos;

namespace WindowsOrders.Web.Client.Pages
{
    public partial class NewOrder
    {

        #region Injects 
        [Inject]
        private IJSRuntime jsRuntime { get; set; }

        [Inject]
        private NavigationManager navigationManager { get; set; }

        [Inject]
        private IApiService apiService { get; set; }

        [Inject]
        private ISessionStorageService sessionStorage { get; set; }
        #endregion


        [Parameter]
        public int id { get; set; }

        private OrderDto orderDto { get; set; } = new OrderDto();
        protected override async Task OnInitializedAsync()
        {
            if (id > 0)
            {
                this.orderDto = await this.apiService.GetOrderAsync(this.id);
                if (this.orderDto == null || this.orderDto.id == 0)
                {
                    this.navigationManager.NavigateTo("/OrderNotFound");
                }
                else
                {
                    if (orderDto.windows != null)
                    {
                        this.windowsOrders = this.orderDto.windows.ToList();
                    }
                    
                }
            }           
        }


        private List<OrderWindowDto> windowsOrders = new List<OrderWindowDto>();

        public int idForDeletion
        {
            get => this._idForDeletion; set
            {
                this.windowsOrders.RemoveAll(x => x.id == value);
                this._idForDeletion = value;

            }
        }

        private int _idForDeletion = 0;


        private void AddWindow()
        {
            int id = 0;
            if (windowsOrders.Count() > 0)
            {
                id = this.windowsOrders.Select(x => x.id).Max();
            }

            this.windowsOrders.Add(new OrderWindowDto() { id = (id + 1), isNew = true });
        }

        private async Task SubmitBtnClicked()
        {
            var result = await jsRuntime.InvokeAsync<string>("GetAllValues");
            if (result != null)
            {
                await sessionStorage.SetItemAsync("NewOrder", result);
                navigationManager.NavigateTo("/SaveOrder");
            }
        }
    }
}
