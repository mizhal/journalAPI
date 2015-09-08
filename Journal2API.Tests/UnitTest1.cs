using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Journal2API.Controllers;
using Journal2API.Models;

namespace Journal2API.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTests()
        {
            var todo = new TodoItem
            {
                Title = "Todo 1"
            };

            Assert.AreEqual(todo.Title, "Todo 1", "Title is equal");
            Assert.AreEqual(todo.Title, "xxx", "Made up to fail"); 
        }

        [TestMethod]
        public void TestSortable()
        {
            using (var ctx = new JournalContext())
            {

                var wf = ctx.Workflows.Create();
                wf.Name = "WF0";
                var state = ctx.WorkflowStates.Create();
                state.Name = "ST0";
                wf.States.Add(state);
                ctx.Workflows.Add(wf);

                var quest = new Quest { Title = "Quest1", Position = 1, State = state};
                var quest2 = new Quest { Title = "Quest2", Position = 2, State = state };

                ctx.Quests.Add(quest);
                ctx.Quests.Add(quest2);
                ctx.SaveChanges();

                Assert.AreEqual(quest.Id, quest2.Previous().Id);
            }
        }
    }
}
