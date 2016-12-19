using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;

namespace TestVisualizer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void killVisualizer()
        {
            ProcessStartInfo processprop = new ProcessStartInfo();
            processprop.FileName = "D://Project//GMESH-1.1//Projects//GMESH Visualizator//GMESH Visualizer//GMESH Visualizer//bin//Debug//GMESH Visualizer.exe";
            processprop.Arguments = @"C:\Users\klim2\Desktop\newtest\4.xml";
            Process process = new Process();
            process = Process.Start(processprop);
            process.WaitForExit();
            process.Kill();
            Assert.AreEqual(true, true);
        }
    }
}
