using CatAggregatorApp.DTO;
using CatAggregatorApp.Processor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CatAggregatorApp.Tests
{
    [TestClass]
    public class HTMLProcessorTests
    {
        [TestMethod]
        public void ShouldFormatWhenNullObjectIsPassed()
        {
            string expected = "<html><body>data missing...</body></html>";
            CatNamesByOwnerGender viewModel = new CatNamesByOwnerGender();
            viewModel = null;
            string actual = HTMLProcessor.FormatHTML(viewModel);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldFormatWhenNonNullObjectIsPassed()
        {
            string expected = "<html><body><h5>a</h5><ul><li>apple</li><li>apricots</li></ul></body></html>";
            CatNamesByOwnerGender viewModel = new CatNamesByOwnerGender();
            viewModel.Add("a", new List<string> { "apple", "apricots" });
            string actual = HTMLProcessor.FormatHTML(viewModel);

            Assert.AreEqual(expected, actual);
        }
    }
}
