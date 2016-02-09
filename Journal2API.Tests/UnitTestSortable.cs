using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Journal2API.Models;

namespace Journal2API.Tests
{
    [TestClass]
    public class UnitTestSortable
    {
        JournalRepo repo; 

        [ClassInitialize]
        public static void BeforeAll(TestContext ctx)
        {
        }

        [ClassCleanup]
        public static void AfterAll()
        {
        }

        [TestInitialize]
        public void Initialize()
        {
            repo = new JournalRepo();
            CreateState();
        }

        [TestCleanup]
        public void Cleanup()
        {
            repo.Dispose();
        }

        [TestMethod]
        public void TestOrder()
        {
            var current_quest_count = repo.All<Quest>().Count();

            var quest = repo.Create<Quest>();
            quest.Title = "Quest 1";
            quest.Position = 1;
            quest.State = GetState();
            quest.Description = "";
            repo.SaveOrUpdate(quest);

            var quest2 = repo.Create<Quest>();

            quest2.Title = "Quest2";
            quest2.Position = 2;
            quest2.State = GetState();
            quest2.Description = "";
            repo.SaveOrUpdate(quest2);

            repo.InitSortable(quest);
            repo.InitSortable(quest2);

            repo.SaveOrUpdate(quest);
            repo.SaveOrUpdate(quest2);

            repo.Flush();

            Assert.IsTrue(repo.All<Quest>().Count() == current_quest_count + 2, "We have unexpectedly duplicated objects");

            quest = repo.Get<Quest>(quest.Id);
            quest2 = repo.Get<Quest>(quest2.Id);

            Assert.AreEqual(quest.Id, repo.Previous(quest2).Id);
        }

        [TestMethod]
        public void TestLoadSave()
        {
            var quest = repo.All<Quest>().First();

            Console.WriteLine(quest.State.Name);

            repo.Save(quest);
        }

        [TestMethod]
        public void TestInsertion()
        {
            var repo = new JournalRepo();

            long quest2_id = 0, quest3_id = 0;

            var quest = repo.Create<Quest>();
            quest.Title = "Quest1";
            quest.Position = 1;
            quest.State = GetState();

            var quest2 = repo.Create<Quest>();
            quest2.Title = "Quest2";
            quest2.Position = 2;
            quest2.State = GetState();

            var quest3 = repo.Create<Quest>();
            quest3.Title = "Quest3";
            quest3.Position = 3;
            quest3.State = GetState();

            repo.Save(quest);
            repo.Save(quest2);
            repo.Save(quest3);

            quest2_id = quest2.Id;

            repo.InsertAfter(quest3, quest);
            repo.Save(quest3);

            quest3_id = quest3.Id;

            repo.Flush();

            var quest2_ = repo.Get<Quest>(quest2_id);
            var quest3_ = repo.Get<Quest>(quest3_id);
            var prev = repo.Previous(quest2_);
            
            Assert.AreEqual(prev, quest3_);

        }

        void CreateState()
        {
            if (GetState() == null)
            {
                var wf = repo.Create<Workflow>();
                wf.Name = "WF0";
                var state = repo.Create<WorkflowState>();
                state.Name = "ST0";
                wf.States.Add(state);
                repo.Save(wf);
            }
        }

        WorkflowState GetState()
        {
            if(repo.All<WorkflowState>().Count() > 0)
                return repo.All<WorkflowState>().First();
            else
                return null;
        }
    }
}