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
            var quest = ctx.Quests.Create();
            quest.Title = "Quest 1";
            quest.Position = 1;
            quest.State = GetState();

            var quest2 = ctx.Quests.Create();

            quest2.Title = "Quest2";
            quest2.Position = 2;
            quest2.State = GetState();

            quest.InitSortable();
            quest2.InitSortable();

            Assert.AreEqual(quest.Id, quest2.Previous().Id);
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
            int quest2_id = 0, quest3_id = 0;

            using (var ctx = new JournalContext())
            {
                var quest = ctx.Quests.Create();
                quest.Title = "Quest1";
                quest.Position = 1;
                quest.State = GetState();

                var quest2 = ctx.Quests.Create();
                quest2.Title = "Quest2";
                quest2.Position = 2;
                quest2.State = GetState();

                var quest3 = ctx.Quests.Create();
                quest3.Title = "Quest3";
                quest3.Position = -1;
                quest3.State = GetState();

                ctx.Quests.Add(quest);
                ctx.Quests.Add(quest2);
                ctx.Quests.Add(quest3);
                ctx.SaveChanges();

                quest2_id = quest2.Id;

                quest3.InsertAfter(quest);
                ctx.Quests.Add(quest3);
                ctx.SaveChanges();

                quest3_id = quest3.Id;
            }

            using (var ctx = new JournalContext())
            {
                var quest2 = ctx.Quests.Find(quest2_id);
                var quest3 = ctx.Quests.Find(quest3_id);
                var prev = quest2.Previous();
                Assert.AreEqual(prev, quest3);
            }   

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