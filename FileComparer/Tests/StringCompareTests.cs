using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class StringCompareTests
    {
        [TestMethod]
        public void StringCompareWhenDifferentEntries()
        {
            string text = "dsasdasdsda";
            string text2 = "dsadewew";

            Assert.IsFalse(string.CompareOrdinal(text, text2) == 0);
        }

        [TestMethod]
        public void StringCompareWhenIgnoreCaseTest()
        {
            string text = "oiuytre";
            string text2 = "oiuyTre";

            Assert.IsTrue(string.Compare(text,text2,StringComparison.OrdinalIgnoreCase) == 0);
        }

        [TestMethod]
        public void StringCompareWithoutIgnoreCaseTest()
        {
            string text = "oiuytre";
            string text2 = "oiuyTre";

            Assert.IsFalse(string.CompareOrdinal(text, text2) == 0);
        }

        [TestMethod]
        public void TrimEntryTest()
        {
            string text = "oiuytre\r\t".Trim();
            string text2 = "oiuytre";

            Assert.IsTrue(String.CompareOrdinal(text, text2) == 0);
        }
    }
}
