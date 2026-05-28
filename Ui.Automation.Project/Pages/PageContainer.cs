using Microsoft.Playwright;

namespace Ui.Automation.Project.Pages
{
	public class PageContainer
	{
		public HomePage HomePage { get; }
		public CategoryPage CategoryPage { get; }
		public ProductDetailsPage ProductDetailsPage { get; }
		public CartPage CartPage { get; }
		public LoginPage LoginPage { get; }
		public CheckoutPage CheckoutPage { get; }
		public RegisterPage RegisterPage { get; }

		public PageContainer(IPage page)
		{
			HomePage = new HomePage(page);
			CategoryPage = new CategoryPage(page);
			ProductDetailsPage = new ProductDetailsPage(page);
			CartPage = new CartPage(page);
			LoginPage = new LoginPage(page);
			CheckoutPage = new CheckoutPage(page);
			RegisterPage = new RegisterPage(page);
		}
	}
}
