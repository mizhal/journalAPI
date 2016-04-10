using System;
using TechTalk.SpecFlow;

namespace Journal2API.Spec.Features
{
    [Binding]
    public class ProjectsAndScopesSteps
    {
        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have created at least one project")]
        public void GivenIHaveCreatedAtLeastOneProject()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the project I select is in a finished status")]
        public void GivenTheProjectISelectIsInAFinishedStatus()
        {
            ScenarioContext.Current.Pending();
        }
        
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
        
        [When(@"I create a new project with name")]
        public void WhenICreateANewProjectWithName()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I select some project for deletion")]
        public void WhenISelectSomeProjectForDeletion()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the project I have chosen doesn't have any dependent quest, task or enclosure")]
        public void WhenTheProjectIHaveChosenDoesnTHaveAnyDependentQuestTaskOrEnclosure()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I confirm deletion")]
        public void WhenIConfirmDeletion()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the project I have chosen has some dependent quest, task or enclosures")]
        public void WhenTheProjectIHaveChosenHasSomeDependentQuestTaskOrEnclosures()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I select that project")]
        public void WhenISelectThatProject()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I choose to archive that project")]
        public void WhenIChooseToArchiveThatProject()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I select a project")]
        public void WhenISelectAProject()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I update some of its data")]
        public void WhenIUpdateSomeOfItsData()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I save the changes")]
        public void WhenISaveTheChanges()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I choose action focus")]
        public void WhenIChooseActionFocus()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the project must appear in project listings")]
        public void ThenTheProjectMustAppearInProjectListings()
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
        
        [Then(@"the project is completely removed from the system")]
        public void ThenTheProjectIsCompletelyRemovedFromTheSystem()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it can't be recovered any way")]
        public void ThenItCanTBeRecoveredAnyWay()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the API notifies deletion error")]
        public void ThenTheAPINotifiesDeletionError()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the project remains untouched")]
        public void ThenTheProjectRemainsUntouched()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the project status is set to archived status")]
        public void ThenTheProjectStatusIsSetToArchivedStatus()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the project must record the time and date of archiving")]
        public void ThenTheProjectMustRecordTheTimeAndDateOfArchiving()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the project won't be shown in common lists and searches")]
        public void ThenTheProjectWonTBeShownInCommonListsAndSearches()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the project cannot be selected for actions other than ""(.*)""")]
        public void ThenTheProjectCannotBeSelectedForActionsOtherThan(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the project status and resources cannot be updated")]
        public void ThenTheProjectStatusAndResourcesCannotBeUpdated()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the change of project status is recorded as a new entry in General Log / Journal")]
        public void ThenTheChangeOfProjectStatusIsRecordedAsANewEntryInGeneralLogJournal()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the API notifies archiving error")]
        public void ThenTheAPINotifiesArchivingError()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the project must record the time and date of change")]
        public void ThenTheProjectMustRecordTheTimeAndDateOfChange()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the project must appear in listings with its data updated")]
        public void ThenTheProjectMustAppearInListingsWithItsDataUpdated()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the detail of the project must reflect the changes as well")]
        public void ThenTheDetailOfTheProjectMustReflectTheChangesAsWell()
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
