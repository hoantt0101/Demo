# **A demo framework using specflow C**

## **Framework structure**
```plaintext
├── DemoTesting_Elsa
    ├── Dependencies  
    ├── Common
    ├── Driver          
    ├── Features/
    │    ├── Login.feature
    │    └── CreateNewAcc.feature       
    ├── Hooks  
    │    └── ScenarioHooks.cs
    ├── PageObject
    │   ├── Base
    │       └── Page.cs
    │   ├── CreateNewAcc.cs
    │   └── HomePage.cs
    │   └── LoginPage.cs
    ├── StepDefinitions 
    │   ├── CreateNewAccSteps.cs
    │   └── HomePageStep.cs
    │   └── LoginSteps.cs
    ├── App.config         #Contains the configuration settings for Specflow
    └── AssemblyInfo.cs    #Setup run parallel testing
```    
**Feature Files** contain Gherkin syntax, which is written in a natural language format (Given/When/Then). These files define the scenarios and behavior you want to test. SpecFlow reads these files to understand the test cases.

**Step Definitions** are where you bind the Gherkin steps (from your feature files) to actual code. For each step written in Gherkin, you'll write a matching method in C# that implements the logic for that step.

**PageObject** are where you can see the element locator and method to interact with the element on page

**Hooks** allow you to add setup and teardown logic around your tests. You can run code before or after every scenario or feature. This is useful for initializing data, starting/stopping web drivers, or other necessary actions like logging in before a test.    

**Drive** includes utilities for browser setup, configuration settings, or any code that should be used across multiple step definitions or hooks.

## **How to run the test**

1. Install Visual Studio
2. Install .NET SDK
3. Clone this repo
4. Open it by Visual Studio then select the test which you want to run

