using System;
using Xunit;
using EisenhowerCore;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EisenhowerMain.Tests
{
    public class TodoMatrixTests {

        [Fact]
        public void TestAddItem()
        {
            var TestMatrix = new TodoMatrix();

            DateTime today = DateTime.Now;
            DateTime dateUrgent = today.AddDays(1);
            DateTime dateNotUrgent = today.AddDays(30);

            TestMatrix.AddItem("UrgentImportant", dateUrgent, true);
            TestMatrix.AddItem("UrgentNotImportant", dateUrgent, false);
            TestMatrix.AddItem("NotUrgentImportant", dateNotUrgent, true);
            TestMatrix.AddItem("NotUrgentNotImportant", dateNotUrgent, false);

            var UrgentImportantItem = TestMatrix.Quarters["IU"].items[0];
            Assert.Equal("UrgentImportant", UrgentImportantItem.Title);

            var UrgentNotImportantItem = TestMatrix.Quarters["NU"].items[0];
            Assert.Equal("UrgentNotImportant", UrgentNotImportantItem.Title);

            var NotUrgentImportant = TestMatrix.Quarters["IN"].items[0];
            Assert.Equal("NotUrgentImportant", NotUrgentImportant.Title);

            var NotUrgentNotImportant = TestMatrix.Quarters["NN"].items[0];
            Assert.Equal("NotUrgentNotImportant", NotUrgentNotImportant.Title);

        }


        [Fact]
        public void TestArchiveAllQuarters()
        {
            var TestMatrix = new TodoMatrix();

            DateTime today = DateTime.Now;
            DateTime dateUrgent = today.AddDays(1);
            DateTime dateNotUrgent = today.AddDays(30);

            TestMatrix.AddItem("UrgentImportant", dateUrgent, true);
            TestMatrix.AddItem("UrgentNotImportant", dateUrgent, false);
            TestMatrix.AddItem("NotUrgentImportant", dateNotUrgent, true);
            TestMatrix.AddItem("NotUrgentNotImportant", dateNotUrgent, false);

            foreach (var quarter in TestMatrix.Quarters.Values)
            {
                quarter.items.ForEach(item => item.Mark());
            }

            TestMatrix.ArchiveItems();

            foreach (var quarter in TestMatrix.Quarters.Values)
            {
                Assert.True(quarter.items.Count == 0);
            }
        }

        [Fact]
        public void TestSaveItemsToFile()
        {   
            var TestMatrix = new TodoMatrix();

            string fileIn = "todo_items_read_test.csv";
            string fileOut = "todo_items_save_test.csv";

            TestMatrix.AddItemsFromFile(fileIn);
            TestMatrix.SaveItemsToFile(fileOut);

            var testList = new List<string>();

            testList.Add("make a coffee  |14-10| important");
            testList.Add("read about OOP  |15-10| important");
            testList.Add("give mentors a feedback  |23-10| important");

            using(StreamReader reader = new StreamReader(fileOut)) {
                var resultString = new StringBuilder();
                string singleline;
                int i = 0;
                while ((singleline = reader.ReadLine()) != null) {
                    Assert.True(singleline == testList[i]);
                }
            
            }

        }


    }

}