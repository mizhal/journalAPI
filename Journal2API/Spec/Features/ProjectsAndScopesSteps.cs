using System;
using TechTalk.SpecFlow;

namespace Journal2API.Spec.Features
{
    [Binding]
    public class ProjectsAndScopesSteps
    {
        [Given(@"the project I select is not in a finished status")]
        public void GivenTheProjectISelectIsNotInAFinishedStatus()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have put a project on focus")]
        public void GivenIHavePutAProjectOnFocus()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I choose remove project focus")]
        public void GivenIChooseRemoveProjectFocus()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I choose action focus")]
        public void WhenIChooseActionFocus()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a new hashtag will be created for the project to allow referencing")]
        public void ThenANewHashtagWillBeCreatedForTheProjectToAllowReferencing()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a new global unique identifier will be assigned to the project to enable external tracking")]
        public void ThenANewGlobalUniqueIdentifierWillBeAssignedToTheProjectToEnableExternalTracking()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the current user filter is overriden by a new filter for this project")]
        public void ThenTheCurrentUserFilterIsOverridenByANewFilterForThisProject()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"all listings of quests, tasks and enclosures will show only elements related with the project I have selected\.")]
        public void ThenAllListingsOfQuestsTasksAndEnclosuresWillShowOnlyElementsRelatedWithTheProjectIHaveSelected_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the current user filter is removed")]
        public void ThenTheCurrentUserFilterIsRemoved()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"all listings will show unfiltered")]
        public void ThenAllListingsWillShowUnfiltered()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
