using Microsoft.Playwright;

namespace Ui.Automation.Project.Pages
{
	public class CartPage : BasePage
	{
		public CartPage(IPage page) : base(page) { }

		public ILocator ProductInCart(string productName) =>
			_page.Locator($".cart .product-name:has-text('{productName}')");

		public ILocator TermsOfServiceCheckbox => _page.Locator("#termsofservice");
		public ILocator CheckoutButton => _page.Locator("#checkout");

		public async Task ProceedToCheckoutAsync()
		{
			await TermsOfServiceCheckbox.CheckAsync();
			await CheckoutButton.ClickAsync();
		}
	}
}
