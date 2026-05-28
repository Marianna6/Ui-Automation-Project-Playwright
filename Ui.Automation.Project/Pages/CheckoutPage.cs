using Microsoft.Playwright;

namespace Ui.Automation.Project.Pages
{
	public class CheckoutPage : BasePage
	{
		public CheckoutPage(IPage page) : base(page) { }

		public ILocator BillingAddressButton => _page.Locator("#billing-buttons-container .new-address-next-step-button");
		public ILocator ShippingAddressButton => _page.Locator("#shipping-buttons-container .new-address-next-step-button");
		public ILocator ShippingMethodButton => _page.Locator("#shipping-method-buttons-container .shipping-method-next-step-button");
		public ILocator PaymentMethodButton => _page.Locator("#payment-method-buttons-container .payment-method-next-step-button");
		public ILocator PaymentInfoButton => _page.Locator("#payment-info-buttons-container .payment-info-next-step-button");
		public ILocator ConfirmOrderButton => _page.Locator("#confirm-order-buttons-container .confirm-order-next-step-button");

		public ILocator ThankYouHeader => _page.Locator(".page.checkout-completed-page h1");

		public async Task CompleteCheckoutFlowAsync()
		{
			await BillingAddressButton.ClickAsync();
			await ShippingAddressButton.ClickAsync();
			await ShippingMethodButton.ClickAsync();
			await PaymentMethodButton.ClickAsync();
			await PaymentInfoButton.ClickAsync();
			await ConfirmOrderButton.ClickAsync();
		}
	}
}
