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
        DebugLogger logger = new DebugLogger();

        [Test]
        public void LogTest1()
        {
            logger.Log("Hi");
        }

    }
}
