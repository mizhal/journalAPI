using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Journal2API.Models;
using Journal2API.Models.Auth;

namespace Journal2API.Tests.Areas.Auth
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UserUnitTest
    {
        public UserUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CRUD()
        {
            var repo = new IdentityContext();
            var login = "user1";
            var email = "name@name.es";
            var user = repo.Users
                .Where(x => x.Login == login)
                .FirstOrDefault()
                ;
            if(user != null)
            {
                repo.Users.Remove(user);
            }
            repo.SaveChanges();
            repo.Dispose();
            repo = new IdentityContext();

            var user2 = new User(login)
            {
                FullName = "Name",
                Email = email,
                Password = "abc123"
            };
            user2.Claims.Add(new Claim(user2.Id, "login", user.Login));
            user2.Claims.Add(new Claim(user2.Id, "email", email));

            repo.Users.Add(user2);
            repo.SaveChanges();

            Assert.IsTrue(repo.Users.Count() > 0, "No hemos creado usuarios");
        }
    }
}
