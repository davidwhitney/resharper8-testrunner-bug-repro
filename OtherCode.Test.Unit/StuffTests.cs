using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace OtherCode.Test.Unit
{
    [TestFixture]
    [Category("Fast")]
    public class StuffTests
    {
        [Test]
        public void Test2()
        {
            var classs = new Stuff();

            classs.Thing();
        }

    }
}
