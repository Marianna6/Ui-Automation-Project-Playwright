# Demo Web Shop: UI Automation Project

Automated UI testing for the Demo Web Shop e-commerce platform.

## Project Structure
* **Pages**: Implements the Page Object Model (POM) pattern. Classes like `HomePage`, `LoginPage`, `CartPage`, `CheckoutPage`, and `CategoryPage` encapsulate UI interaction logic and hide Playwright locators. Inherits from a centralized `BasePage`.
* **Components**: Dedicated sub-layers (`HeaderComponent`, `FooterComponent`) managing reusable layout elements visible across multiple pages.
* **Containers**: Uses a `PageContainer` factory class to initialize and manage single-entry access to all page instances within a given test context.
* **Models**: Strongly-typed Data Transfer Objects (`UserModel`, `ComputerModel`) ensuring type safety and encapsulation of test entities.
* **Fixtures**: `UiFixture` manages the global Playwright lifecycle, browser state initialization, and automatic resource cleanup via `IAsyncLifetime`.
* **Data**: `MemberData.cs` provides centralized storage for parameterizing data-driven test scenarios.
* **Configuration (appsettings.json)**: Centralized management of environment variables such as base application URL and browser execution properties.
* **Tests**: Functional E2E and integration test suites structured according to the AAA pattern.

## Test Strategy
* **E2E Flow**: Complete shopping cycle validation from user authentication and custom configuration of items to multi-step checkout execution.
* **Data-Driven Testing**: Leverages xUnit `[Theory]` combined with `[MemberData]` to run multi-parameter test variations for authentication flows (e.g., negative login validations).
* **State Management**: Isolation of test cases by passing clean browser contexts through `UiFixture`, mitigating side effects and state leakage.

## Technology Stack
* **Language**: C# (.NET 9)
* **Core Framework**: Playwright for .NET
* **Test Runner**: xUnit
* **Assertions**: Playwright Native Assertions (`Assertions.Expect`)



Configuration Note:For security reasons, sensitive credentials are not hardcoded in this repository.
To run the tests locally, you must provide a `.runsettings` file in the root of the test project containing `TEST_EMAIL` and `TEST_PASSWORD` environment variables. Ensure the file properties are set to "Copy Always to Output Directory" so the test runner can access it.