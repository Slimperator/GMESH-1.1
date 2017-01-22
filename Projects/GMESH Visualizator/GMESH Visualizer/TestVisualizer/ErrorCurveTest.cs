using Errors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Geometry;

namespace TestVisualizer
{
    
    
    /// <summary>
    ///Это класс теста для ErrorCurveTest, в котором должны
    ///находиться все модульные тесты ErrorCurveTest
    ///</summary>
    [TestClass()]
    public class ErrorCurveTest
    {


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

        #region Дополнительные атрибуты теста
        // 
        //При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        //ClassInitialize используется для выполнения кода до запуска первого теста в классе
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //TestInitialize используется для выполнения кода перед запуском каждого теста
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //TestCleanup используется для выполнения кода после завершения каждого теста
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Тест для getInfo
        ///</summary>
        [TestMethod()]
        public void getInfoTest()
        {
            int errorId = 0; // TODO: инициализация подходящего значения
            string errorMasage = string.Empty; // TODO: инициализация подходящего значения
            ICurve errorCurve = null; // TODO: инициализация подходящего значения
            ErrorCurve target = new ErrorCurve(errorId, errorMasage, errorCurve); // TODO: инициализация подходящего значения
            string expected = string.Empty; // TODO: инициализация подходящего значения
            string actual;
            actual = target.getInfo();
            Assert.AreEqual(expected, actual);
            
        }
    }
}
