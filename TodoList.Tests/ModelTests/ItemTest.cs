using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest
  {

  [TestMethod]
  public void GetDescription_SetDescription_String()
  {
    //Arrange
    string description = "Walk the dog.";
    Item newItem = new Item(description);
    description = "Do the dishes";
    //Act
    newItem.SetDescription(description);
    string result = newItem.GetDescription();

    //Assert
    Assert.AreEqual(description, result);
  }
  }
}
