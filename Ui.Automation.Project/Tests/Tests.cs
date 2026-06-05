using Microsoft.Playwright;

using System.Threading.Tasks;

using Ui.Automation.Project.Fixture;
using Ui.Automation.Project.Models;
using Ui.Automation.Project.Pages;
using Ui.Automation.Project.Tests.TestData;

using Xunit;

namespace Ui.Automation.Project.Tests
{
	public class Tests : IClassFixture<UiFixture>
	{
		private readonly IPage _page;
		private readonly PageContainer _container;

		public Tests(UiFixture fixture)
		{
			_page = fixture.Page;
			_container = new PageContainer(_page);
		}

		[Theory]
		[MemberData(nameof(MemberData.OrderData), MemberType = typeof(MemberData))]
		public async Task ShouldPlaceOrderSuccessfully(UserModel user, ComputerModel computer, string mainCategory, string subCategory, string productName)
		{
			await _container.HomePage.Header.GoToLoginPageAsync();
			await _container.LoginPage.LoginAsync(user.Email, user.Password);
			await _container.HomePage.SelectMainCategoryAsync(mainCategory);
			await _container.CategoryPage.PickProductAsync(subCategory, productName);
			await _container.ProductDetailsPage.ConfigureAndAddToCartAsync(computer);
			await _container.HomePage.Header.GoToCartPageAsync();
			await _container.CartPage.ProceedToCheckoutAsync();
			await _container.CheckoutPage.CompleteCheckoutFlowAsync();

			await Assertions.Expect(_container.CheckoutPage.ThankYouHeader).ToBeVisibleAsync();
			await Assertions.Expect(_container.CheckoutPage.ThankYouHeader).ToHaveTextAsync("Thank you");

			await _container.HomePage.Header.LogoutAsync();
		}

		[Theory]
		[MemberData(nameof(MemberData.NegativeLoginData), MemberType = typeof(MemberData))]
		public async Task ShouldNotLoginWithInvalidCredentials(string email, string password, string expectedResult)
		{
			await _container.HomePage.Header.GoToLoginPageAsync();
			await _container.LoginPage.LoginAsync(email, password);

			await Assertions.Expect(_container.LoginPage.ErrorMessageBlock).ToContainTextAsync(expectedResult);
		}

		[Fact]
		public async Task ShouldRemoveProductFromCartSuccessfully()
		{
			await _container.HomePage.Header.GoToLoginPageAsync();
			await _container.LoginPage.LoginAsync("testmarisha@gmail.com", "123456");
			await _container.HomePage.SelectMainCategoryAsync("Computers");
			await _container.CategoryPage.PickProductAsync("Desktops", "Build your own computer");
			await _container.ProductDetailsPage.AddDefaultComputerToCartAsync();
			await _container.HomePage.Header.GoToCartPageAsync();
			await _container.CartPage.RemoveProductFromCartAsync();
			await Assertions.Expect(_container.CartPage.EmptyCartMessage).ToHaveTextAsync("Your Shopping Cart is empty!");
		}
	}
}
