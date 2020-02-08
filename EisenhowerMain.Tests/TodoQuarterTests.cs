using System;
using Xunit;
using System.Collections.Generic;
using EisenhowerCore;

namespace EisenhowerMain.Tests
{
    public class TodoQuarterTests {

        [Fact]
        public void TestConstructor() { 
            var testQuarter = new TodoQuarter();
            Assert.Empty(testQuarter.items);
        }

        [Fact]
        public void TestAddItem() { 
            var testQuarter = new TodoQuarter();
            var expectedTitle = "Implement Quarter class";
            var expectedDeadline = DateTime.Parse("2015-10-02");

            testQuarter.AddItem(expectedTitle, expectedDeadline);
            var testItem = testQuarter.items[0];

            Assert.Equal(expectedTitle, testItem.Title);
            Assert.Equal(expectedDeadline, testItem.Deadline);
        }

        [Fact]
        public void TestSortItems()
        {   
            var testQuarter = new TodoQuarter();
            var mockedTitle = "Implement quarter class";

            List<DateTime> dates = new List<DateTime>();
            dates.Add(DateTime.Parse("2017-06-14"));
            dates.Add(DateTime.Parse("2017-05-24"));
            dates.Add(DateTime.Parse("2017-06-04"));
            dates.Add(DateTime.Parse("2017-07-03")); 

            foreach (var date in dates)
            {
                testQuarter.AddItem(mockedTitle, date);
            }

            Assert.Equal(dates[1], testQuarter.items[0].Deadline);
            Assert.Equal(dates[2], testQuarter.items[1].Deadline);
            Assert.Equal(dates[0], testQuarter.items[2].Deadline);
            Assert.Equal(dates[4], testQuarter.items[3].Deadline);
            Assert.Equal(dates[3], testQuarter.items[4].Deadline);

        }


        [Fact]
        public void TestRemoveItem()
        {   
            var testQuarter = new TodoQuarter();

            string expectedTitleFirst = "Check out tests";
            DateTime deadline = DateTime.Parse("2017-07-07");
            testQuarter.AddItem(expectedTitleFirst, deadline);

            string expectedTitleSecond = "Make coffee";
            DateTime deadlineSecond = DateTime.Parse("2017-07-07");
            testQuarter.AddItem(expectedTitleSecond, deadlineSecond);

            string expectedTitleThird= "Code";
            DateTime deadlineThird = DateTime.Parse("2017-07-07");
            testQuarter.AddItem(expectedTitleThird, deadlineThird);

            testQuarter.RemoveItem(1);

            TodoItem fetchedSecondItem = testQuarter.items[1];

            Assert.Equal("Code", fetchedSecondItem.Title);
            Assert.True(testQuarter.items.Count == 2);
        }

        [Fact]
        public void TestArchiveItems()
        {   
            var testQuarter = new TodoQuarter();

            string expectedTitleFirst = "Check out tests";
            DateTime deadline = DateTime.Parse("2017-07-07");
            testQuarter.AddItem(expectedTitleFirst, deadline);

            string expectedTitleSecond = "Make coffee";
            DateTime deadlineSecond = DateTime.Parse("2017-07-07");
            testQuarter.AddItem(expectedTitleSecond, deadlineSecond);

            string expectedTitleThird= "Code";
            DateTime deadlineThird = DateTime.Parse("2017-07-07");
            testQuarter.AddItem(expectedTitleThird, deadlineThird);

            testQuarter.items[0].Mark();
            testQuarter.ArchiveItems();

            TodoItem fetchedItem = testQuarter.items[0];

            Assert.Equal("Make coffee", fetchedItem.Title);
            Assert.True(testQuarter.items.Count == 2);
        }

        [Fact]
        public void TestPrintQuarter()
        {   
            var testQuarter = new TodoQuarter();

            string expectedTitleFirst = "Check out tests";
            DateTime deadline = DateTime.Parse("2017-07-07");
            testQuarter.AddItem(expectedTitleFirst, deadline);

            string expectedTitleSecond = "Make coffee";
            DateTime deadlineSecond = DateTime.Parse("2017-08-08");
            testQuarter.AddItem(expectedTitleSecond, deadlineSecond);

            string expectedTitleThird= "Code";
            DateTime deadlineThird = DateTime.Parse("2017-09-09");
            testQuarter.AddItem(expectedTitleThird, deadlineThird);

            testQuarter.items[0].Mark();
            string expected = "1. [x] 7-7 Check out tests\n2. [ ] 8-8 Make coffee\n3. [ ] 9-9 Code\n";

            Assert.Equal(expected, testQuarter.ToString());
            
        }

        

    }
}