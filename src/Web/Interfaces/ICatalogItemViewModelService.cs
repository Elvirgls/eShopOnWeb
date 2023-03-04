using System.Threading.Tasks;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Interfaces;

public interface ICatalogItemViewModelService
{
    List<CatalogItemViewModel> AddToWishList(CatalogItemViewModel item);
    Task UpdateCatalogItem(CatalogItemViewModel viewModel);
}
