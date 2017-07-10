using System;
using System.Threading.Tasks;
using GPS.SimpleMVC.Tests.ModelImplementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GPS.SimpleMVC.Tests
{
    [TestClass]
    public class AdapterTests
    {
        [TestMethod]
        public async Task LoadModelLong()
        {
            var model = await TestModel.LoadAsync(1L) as TestModel;

            Assert.IsNotNull(model);
            Assert.IsInstanceOfType(model,typeof(TestModel));
            Assert.AreEqual(1L, model.ID);
            Assert.AreEqual("Loaded by ID", model.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), AllowDerivedTypes = false)]
        public async Task LoadModelGuid()
        {
            var model = await TestModel.LoadAsync(Guid.Empty) as TestModel;
        }
    }
}
