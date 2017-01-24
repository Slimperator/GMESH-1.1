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
    /// Сводное описание для TestWayofFile
    /// </summary>
    [TestClass]
    public class TestWayofFile
    {
        public TestWayofFile()
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
        public void TestwayofFile()
        {
            //Start generator's program
            ProcessStartInfo processprop = new ProcessStartInfo();
            // Прописать путь до GMESH Generator.exe и заменить  \ на // !!!
            processprop.FileName = "D://Project//GMESH-1.1//Projects//GMESH Generator//GMESH Generator//bin//Debug//GMESH Generator.exe";
            processprop.Arguments = "-o \"C://Users//klim2//Desktop//newtest//4.xml\"";
            Process process = new Process();
            process = Process.Start(processprop);
            process.CloseMainWindow();
            Assert.AreEqual(true, File.Exists("C://Users//klim2//Desktop//newtest//4.xml"));

        }
    }
}
