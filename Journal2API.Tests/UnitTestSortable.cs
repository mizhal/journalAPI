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

        JournalContext ctx; 

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
            ctx = new JournalContext();
            CreateState();
        }

        [TestCleanup]
        public void Cleanup()
        {
            ctx.Dispose();
        }

        [TestMethod]
        public void TestOrder()
        {
            var repo = new JournalRepo();

            var quest = ctx.Quests.Create();
            quest.Title = "Quest 1";
            quest.Position = 1;
            quest.State = GetState();

            var quest2 = ctx.Quests.Create();

            quest2.Title = "Quest2";
            quest2.Position = 2;
            quest2.State = GetState();

            repo.InitSortable(quest);
            repo.InitSortable(quest2);

            repo.Flush();

            Assert.AreEqual(quest.Id, repo.Previous(quest2).Id);
        }

        [TestMethod]
        public void TestLoadSave()
        {
            var quest = ctx.Quests.First();

            Console.WriteLine(quest.State.Name);

            ctx.Quests.Add(quest);
            ctx.SaveChanges();
        }

        [TestMethod]
        public void TestInsertion()
        {
            var repo = new JournalRepo();

            ulong quest2_id = 0, quest3_id = 0;

            var quest = new Quest()
            {
                Title = "Quest1",
                Position = 1,
                State = GetState()
            };

            var quest2 = new Quest();
            quest2.Title = "Quest2";
            quest2.Position = 2;
            quest2.State = GetState();

            var quest3 = new Quest();
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
                var wf = ctx.Workflows.Create();
                wf.Name = "WF0";
                var state = ctx.WorkflowStates.Create();
                state.Name = "ST0";
                wf.States.Add(state);
                ctx.Workflows.Add(wf);
                ctx.SaveChanges();
            }
        }

        WorkflowState GetState()
        {
            if(ctx.WorkflowStates.Count() > 0)
            {
                return ctx.WorkflowStates.First();
            } else
            {
                return null;
            }
        }
    }
}