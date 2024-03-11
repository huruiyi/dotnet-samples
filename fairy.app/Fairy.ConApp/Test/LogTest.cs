using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fairy.ConApp.Utils;

namespace Fairy.ConApp.Test
{
    public class LogTest
    {
        public static void Test()
        {
            LogHelper.Debug("Debug.....");
            LogHelper.Info("Info.....");
            LogHelper.Warn("Warn.....");
            LogHelper.Error("Error.....");
        }
    }
}