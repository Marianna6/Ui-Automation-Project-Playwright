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

		public ILocator RemoveCheckbox => _page.Locator("input[name='removefromcart']");
		public ILocator UpdateCartButton => _page.Locator(".update-cart-button");
		public ILocator EmptyCartMessage => _page.Locator(".order-summary-content");

		public async Task RemoveProductFromCartAsync()
		{
			int count = await RemoveCheckbox.CountAsync();

			for (int i = 0; i < count; i++)
			{
				await RemoveCheckbox.Nth(i).ClickAsync();
			}

			await UpdateCartButton.ClickAsync();
		}
	}
}
