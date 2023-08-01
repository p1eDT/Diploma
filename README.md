# Project Title

Diploma project for the course "Automated testing in C#"

Topic: [TestMonitor](https://www.testmonitor.com/)

Performers: Alexander Onosov, Nikita Yagovkin
## Checklist

**UiTests:**

* LoginUser
* LoginAsFakeUser
* LoginWithEmptyUser
* CreateTestCaseTest
* DurationValidTest
* СreateTestSuiteTest
* DeleteTCWithCreatedTestCasesTest
* DeleteTSTest

**ApiTests:**

* CreateUserTest
* GetSingleUserTest
* DeleteUserTest
* GetDeletedUserTest
* AdminPrivilegesTest
* GetProjects
* UpdateTestCase
* CreateTestCaseWithRandomName
## Tech Stack

The solution uses a number of nuget packages:

[Allure.NUnit](https://www.nuget.org/packages/Allure.NUnit/2.9.5-preview.1) - NUnit attributes extenstions for Allure

[Faker.Net](https://www.nuget.org/packages/Faker.Net) - C# port of the Ruby Faker gem (http://faker.rubyforge.org/) and is used to easily generate fake data: names, addresses, phone numbers, etc.

[NLog](https://www.nuget.org/packages/NLog) - NLog is a logging platform for .NET with rich log routing and management capabilities. NLog supports traditional logging, structured logging and the combination of both.

[NUnit](https://www.nuget.org/packages/NUnit) - NUnit features a fluent assert syntax, parameterized, generic and theory tests and is user-extensible.

[RestSharp](https://www.nuget.org/packages/RestSharp/110.2.1-alpha.0.10) - Simple REST and HTTP API Client

[Selenium.WebDriver](https://www.nuget.org/packages/Selenium.WebDriver) - Selenium is a set of different software tools each with a different approach to supporting browser automation.


And different approaches to developing frameworks and tests:

Driver Factory
Browser
Page Object
Page Steps
Wrappers
Builder for model
Chain of invocation
Faker
## Installation

Install my-project with npm

 - Register in https://www.testmonitor.com/ and activate your account with email.
 - [API documentation](https://docs.testmonitor.com/#section/About-the-TestMonitor-API)
 - Clone repository [Diploma](https://github.com/sanyalyao/Diploma) tests repository.
 - Open solution in Visual studio (or other for C#).
 - Create solution build configurations.
 - Edit appsettings.json Set your values.
 - Buid solution.
## Roadmap

- Solve the problem of entities with the same names. 
- Solve the problem of running UI tests in parallel. 
- Increase coverage.
