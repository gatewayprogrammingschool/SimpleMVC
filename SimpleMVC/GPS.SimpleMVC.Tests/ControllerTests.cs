using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using GPS.SimpleMVC.Tests.ControllerImplementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GPS.SimpleMVC.Tests
{
    /// <summary>
    /// Summary description for ControllerTests
    /// </summary>
    [TestClass]
    public class ControllerTests
    {
        public ControllerTests()
        {
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
        public void TestViewLoadByUID()
        {
            var view = new TestView();
            view.DataBound += (sender, eventArgs) =>
            {
                Assert.AreEqual("TestModel", view.Name);
                Assert.AreEqual("Loaded by GUID", view.Value);
            };

            var controller = new TestController();

            if (controller.AddView(view))
            {
                controller.Initialize();

                view.InvokeLoadData(Guid.NewGuid());
            }
            else
            {
                Assert.Fail("Controller did not accept the view.");
            }
        }

    }
}
