using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StickyNoteApplication.Logic;

namespace StickyNotes_Tests
{
    [TestFixture]
    class Has4CapitalLettersInARowTests
    {
        [Test]
        public void Test4InARow_1()
        {
            Assert.That(StringUtil.Has4CapitalLettersInARow("haha") == false);
        }

        [Test]
        public void Test4InARow_2()
        {
            Assert.That(StringUtil.Has4CapitalLettersInARow("HaHa") == false);
        }

        [Test]
        public void Test4InARow_3()
        {
            Assert.That(StringUtil.Has4CapitalLettersInARow("Haa HH a") == false);
        }

        [Test]
        public void Test4InARow_4()
        {
            Assert.That(StringUtil.Has4CapitalLettersInARow("HHHaH") == false);
        }

        [Test]
        public void Test4InARow_5()
        {
            Assert.That(StringUtil.Has4CapitalLettersInARow("HHHH") == true);
        }

        [Test]
        public void Test4InARow_6()
        {
            Assert.That(StringUtil.Has4CapitalLettersInARow("aaaa") == false);
        }

        [Test]
        public void Test4InARow_7()
        {
            Assert.That(StringUtil.Has4CapitalLettersInARow("AAAAA") == true);
        }

        [Test]
        public void Test4InARow_8()
        {
            Assert.That(StringUtil.Has4CapitalLettersInARow("1111") == false);
        }

        [Test]
        public void Test4InARow_9()
        {
            Assert.That(StringUtil.Has4CapitalLettersInARow("_CPEG 222") == true);
        }

        [Test]
        public void Test4InARow_10()
        {
            Assert.That(StringUtil.Has4CapitalLettersInARow("    > MATH 222") == true);
        }
    }


}
