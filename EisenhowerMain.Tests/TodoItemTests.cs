using System;
using Xunit;
using EisenhowerCore;

namespace EisenhowerMain.Tests
{
    public class TodoItemTests
    {
        [Fact]
        public void TestItemConstructorParseExpectedData()
        {
            var expectedTitle = "implement ToDoItem class";
            var expectedDeadline = DateTime.Parse("2015-05-16");
            
            var toDoItem = new TodoItem(expectedTitle, expectedDeadline);

            Assert.Equal(expectedTitle, toDoItem.Title);
            Assert.Equal(expectedDeadline, toDoItem.Deadline);   
        }

        [Fact]
        public void TestMarkItem() {
            var TargetItem = new TodoItem("Check if test work", DateTime.Now);
            TargetItem.Mark(); 

            Assert.True(TargetItem.IsDone);   
        }
        [Fact]
        public void TestUnMarkItem() {
            var TargetItem = new TodoItem("Check if test work", DateTime.Now);

            TargetItem.UnMark();
            Assert.False(TargetItem.IsDone);
        }

        [Fact]
        public void TestItemToStringResult() {
            var expectedItemFormat = "[ ] 4-6 Check if test work";
            var TargetItem = new TodoItem("Check if test work", DateTime.Parse("4-6"));

            Assert.Equal(expectedItemFormat, TargetItem.ToString());

            TargetItem.Mark();

            var expectedItemMarkedFormat = "[x] 4-6 Check if test work";
            Assert.Equal(expectedItemMarkedFormat, TargetItem.ToString());

        }
    }
}