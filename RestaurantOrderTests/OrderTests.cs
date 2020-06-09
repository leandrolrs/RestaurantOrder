using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantOrder.Utils;

namespace Order.Tests
{
    [TestClass()]
    public class OrderTests
    {

        [TestInitialize]
        public void IntitializeTestObject()
        {

        }

        [TestMethod()]
        public void GetOrder_Morning_OneOfEach_EntreeSideDrink_Test()
        {
            string[] inputOrder = new string[] { "morning", "2", "1", "3" };

            OrderUtils agent = new OrderUtils();

            string result = agent.GetOrderOutput(inputOrder);

            Assert.AreEqual("eggs,toast,coffee", result);
        }

        [TestMethod()]
        public void GetOrder_Morning_MultpleOrdersOfEntree_Test()
        {
            string[] inputOrder = new string[] { "morning", "1", "1", "3" };

            OrderUtils agent = new OrderUtils();

            string result = agent.GetOrderOutput(inputOrder);

            Assert.AreEqual("eggs,error", result);
        }

        [TestMethod()]
        public void GetOrder_Morning_GetErrorForDessertOrder_Test()
        {
            string[] inputOrder = new string[] { "morning", "1", "2", "3", "4" };

            OrderUtils agent = new OrderUtils();

            string result = agent.GetOrderOutput(inputOrder);

            Assert.AreEqual("eggs,toast,coffee,error", result);
        }

        [TestMethod()]
        public void GetOrder_Morning_MultipleOrderOfDrink_Test()
        {
            string[] inputOrder = new string[] { "morning", "1", "2", "3", "3", "3" };

            OrderUtils agent = new OrderUtils();

            string result = agent.GetOrderOutput(inputOrder);

            Assert.AreEqual("eggs,toast,coffee(x3)", result);
        }

        [TestMethod()]
        public void GetOrder_Night_OneOfEach_EntreeSideDrinkDessert_Test()
        {
            string[] inputOrder = new string[] { "night", "1", "2", "3", "4" };

            OrderUtils agent = new OrderUtils();

            string result = agent.GetOrderOutput(inputOrder);

            Assert.AreEqual("steak,potato,wine,cake", result);
        }

        [TestMethod()]
        public void GetOrder_Night_MultipleOrdersOfPotato_Test()
        {
            string[] inputOrder = new string[] { "night", "1", "2", "2", "4" };

            OrderUtils agent = new OrderUtils();

            string result = agent.GetOrderOutput(inputOrder);

            Assert.AreEqual("steak,potato(x2),cake", result);
        }

        [TestMethod()]
        public void GetOrder_Night_InvalidOrder_Test()
        {
            string[] inputOrder = new string[] { "night", "1", "2", "3", "5" };

            OrderUtils agent = new OrderUtils();

            string result = agent.GetOrderOutput(inputOrder);

            Assert.AreEqual("steak,potato,wine,error", result);
        }

        [TestMethod()]
        public void GetOrder_Night_ErrorForMultipleOrdersOfEntree_Test()
        {
            string[] inputOrder = new string[] { "night", "1", "1", "2", "3", "5" };

            OrderUtils agent = new OrderUtils();

            string result = agent.GetOrderOutput(inputOrder);

            Assert.AreEqual("steak,error", result);
        }
    }
}