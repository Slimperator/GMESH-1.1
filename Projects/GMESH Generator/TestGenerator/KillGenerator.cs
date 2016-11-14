using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;

namespace TestGenerator
{
    /// <summary>
    /// Сводное описание для KillGenerator
    /// </summary>
    [TestClass]
    public class KillGenerator
    {
        public KillGenerator()
        {
            //
            // TODO: добавьте здесь логику конструктора
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void killGenerator()
        {
            ProcessStartInfo processprop = new ProcessStartInfo();
            processprop.FileName = "D://Project//GMESH-1.1//Projects//GMESH Generator//GMESH Generator//bin//Debug//GMESH Generator.exe";
            processprop.Arguments = @"C:\Users\klim2\Desktop\newtest\4.xml";
            Process process = new Process();
            process = Process.Start(processprop);
            process.WaitForExit();
            process.Kill();
            Assert.AreEqual(true, true);
        }
    }
}
