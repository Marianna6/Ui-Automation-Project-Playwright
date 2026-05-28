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
			await _container.HomePage.Header.LoginLink.ClickAsync();
			await _container.LoginPage.LoginAsync(user.Email, user.Password);
			await _container.HomePage.SideMenuLink(mainCategory).ClickAsync();
			await _container.CategoryPage.SubcategoryLink(subCategory).ClickAsync();
			await _container.CategoryPage.AddToCartButton(productName).ClickAsync();
			await _container.ProductDetailsPage.ConfigureAndAddToCartAsync(computer);
			await _container.HomePage.Header.CartLink.ClickAsync();
			await _container.CartPage.ProceedToCheckoutAsync();
			await _container.CheckoutPage.CompleteCheckoutFlowAsync();

			await Assertions.Expect(_container.CheckoutPage.ThankYouHeader).ToBeVisibleAsync();
			await Assertions.Expect(_container.CheckoutPage.ThankYouHeader).ToHaveTextAsync("Thank you");
		}
	}
}
