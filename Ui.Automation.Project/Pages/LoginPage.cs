using Microsoft.Playwright;

namespace Ui.Automation.Project.Pages
{
	public class LoginPage : BasePage
	{
		public LoginPage(IPage page) : base(page) { }

		public ILocator EmailInput => _page.Locator("#Email");
		public ILocator PasswordInput => _page.Locator("#Password");
		public ILocator RememberMeCheckbox => _page.Locator("#RememberMe");
		public ILocator LoginButton => _page.Locator(".login-button");
		public ILocator ErrorMessageBlock => _page.Locator(".validation-summary-errors");
		// public ILocator ForgotPasswordLink => _page.Locator("a[href='/passwordrecovery']");

		public async Task LoginAsync(string email, string password)
		{
			await EmailInput.FillAsync(email);
			await PasswordInput.FillAsync(password);
			await LoginButton.ClickAsync();
		}
	}
}
