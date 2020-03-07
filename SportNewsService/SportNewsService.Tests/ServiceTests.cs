using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SportNewsService.Tests
{
    public class ServiceTests
    {
        [Test]
        public void isSomethingThere()
        {
            DirectoryAssert.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Updates");
        }

        [Test]
        public void isSomethingInXml()
        {
            var text = AppDomain.CurrentDomain.BaseDirectory + "\\Updates\\Update_wszystkie.xml".ToString();
            Assert.AreNotEqual(text, null);
        }
    }
}
