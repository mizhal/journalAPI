using System;
using TechTalk.SpecFlow;

namespace Journal2API.Spec.Features
{
    [Binding]
    public class LogInSteps
    {
        [Given(@"I have registered myself with the API")]
        public void GivenIHaveRegisteredMyselfWithTheAPI()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I never have registered an account with the API")]
        public void GivenINeverHaveRegisteredAnAccountWithTheAPI()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"My credentials are not registered yet")]
        public void GivenMyCredentialsAreNotRegisteredYet()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"my credentials are registered in the system")]
        public void GivenMyCredentialsAreRegisteredInTheSystem()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I provide correct credentials")]
        public void WhenIProvideCorrectCredentials()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I provide wrong credentials")]
        public void WhenIProvideWrongCredentials()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I provide some credentials")]
        public void WhenIProvideSomeCredentials()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I register with new credentials")]
        public void WhenIRegisterWithNewCredentials()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I register with the same credentials")]
        public void WhenIRegisterWithTheSameCredentials()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I have forgotten my credentials")]
        public void WhenIHaveForgottenMyCredentials()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I request the API to recover my account")]
        public void WhenIRequestTheAPIToRecoverMyAccount()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the API welcomes me")]
        public void ThenTheAPIWelcomesMe()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the API gives an error message")]
        public void ThenTheAPIGivesAnErrorMessage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the API notifies I am successfully registered")]
        public void ThenTheAPINotifiesIAmSuccessfullyRegistered()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the API provides an alternative method to recover credentials by means of another service account owned by me")]
        public void ThenTheAPIProvidesAnAlternativeMethodToRecoverCredentialsByMeansOfAnotherServiceAccountOwnedByMe()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
