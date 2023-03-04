using System;
using BlazorShared.Models;
using Microsoft.eShopWeb.UnitTests.Web.Catalog.WishList.TestData;
using Microsoft.eShopWeb.Web.Interfaces;
using Microsoft.eShopWeb.Web.Services;
using Microsoft.eShopWeb.Web.ViewModels;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.Web.Catalog.WishList
{
    public class WishListTests
    {
        private readonly ICatalogItemViewModelService _catalogItemViewModelService;

        public WishListTests(ICatalogItemViewModelService catalogItemViewModelService)
        {
            _catalogItemViewModelService = catalogItemViewModelService;
        }
        [Fact]
        public void AddCatalogItem_ShouldAddCatalogItemToWishList()
        {
            // Arrange

            var item = new CatalogItemViewModel { Id = 1 };

            // Act
            List<CatalogItemViewModel> list = _catalogItemViewModelService.AddToWishList(item);

            // Assert
            Assert.Contains(item, list);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void AddCatalogItem_ShouldAddToWishList(int catalogItemId)
        {
            // Arrange
            var item = new CatalogItemViewModel { Id = catalogItemId };
            var mockLogger = new Mock<ILogger<List<CatalogItemViewModel>>>();

            // Act
            List<CatalogItemViewModel> list = _catalogItemViewModelService.AddToWishList(item);
            // Assert
            Assert.Contains(item, list);
            mockLogger.Verify(
                l => l.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => o.ToString().Contains($"Item '{catalogItemId}' added to wish list.")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }

        [Theory]
        [ClassData(typeof(WishListTestData))]
        public void AddCatalogItem_ShouldAddToWishListClsassData(int catalogItemId)
        {
            // Arrange
            var item = new CatalogItemViewModel { Id = catalogItemId };
            var mockLogger = new Mock<ILogger<List<CatalogItemViewModel>>>();

            // Act
            List<CatalogItemViewModel> list = _catalogItemViewModelService.AddToWishList(item);
            // Assert
            Assert.Contains(item, list);
        }
        [Theory]
        [MemberData(nameof(WishListTestMemberData))]
        public void AddCatalogItem_ShouldAddToWishListMemberData(int catalogItemId)
        {
            // Arrange
            var item = new CatalogItemViewModel { Id = catalogItemId };
            var mockLogger = new Mock<ILogger<List<CatalogItemViewModel>>>();

            // Act
            List<CatalogItemViewModel> list = _catalogItemViewModelService.AddToWishList(item);
            // Assert
            Assert.Contains(item, list);
        }
        public static IEnumerable<object[]> WishListTestMemberData =>
                                    new List<object[]>
                                    {
                                                        new Object[] { 1 },
                                                        new object[] { 2 },
                                                        new object[] { 3 }
                                    };

    }

}


