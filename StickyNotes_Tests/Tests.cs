using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StickyNoteApplication.Logic;
using StickyNoteApplication.Models;

namespace StickyNotes_Tests
{
    [TestFixture]
    public class DebugLoggerTest
    {
        [Test]
        public void LogTest1()
        {
            DebugLogger logger = new DebugLogger(true);
            logger.Log("Hi");
            logger.Log("Beans");
        }

        [Test]
        public void LogTest2()
        {
            DebugLogger logger = new DebugLogger(false);
            logger.Log("Hi");
            logger.Log("Beans");
        }

    }
}
