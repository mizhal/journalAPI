﻿using System;
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
    }
}
