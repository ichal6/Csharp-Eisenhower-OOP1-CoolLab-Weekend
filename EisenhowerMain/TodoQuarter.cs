using System;
using System.Collections.Generic;
using System.Text;

namespace EisenhowerCore { 

    public class TodoQuarter {
        public List<TodoItem> items = new List<TodoItem>();

        public TodoQuarter()
        {

        }

        public void AddItem(string title, DateTime deadLine)
        {
            //Append new item to List
            TodoItem newItem = new TodoItem(title, deadLine);
            items.Add(newItem);
            //todoItems.Sort(new DeadLine());
            //todoItems.Sort((x, y) => DateTime.Compare(x.Created, y.Created));
        }

        public void RemoveItem(int index)
        {
            //Remove object with index from list
            try
            {
                items.RemoveAt(index);
            }
            catch(Exception e)
            {
                Console.WriteLine("Wrong index! Nothing is erase. " + e);
            }
        }

        public void ArchiveItems()
        {
            //Remove all object with parametr isDone == true from list
            int arrayLength = items.Count;
            for(int index = 0; index < arrayLength; index++)
            {
                TodoItem item = items[index];
                if(item.getIsDone())
                {
                    items.Remove(item);
                    arrayLength--;
                }
            }

        
        }

        public TodoItem getItem(int index)
        {
            try
            {
                return items[index];
            }
            catch(Exception e){
                Console.WriteLine("Wrong index! Select first element in quarter." + e);
                return items[0];
            }
        }


        public List<TodoItem> getItems()
        { 
            //Return private field todoItems - It's uncertain
            return items;
        }

        public String ToString()
        {
            // Return formatted list to label 
            String outputString = "";
            String row = "";
            for (int index = 1; index <= items.Count; index++)
            {
                row = items[index-1].ToString();
                outputString += String.Format("{0}. {1}\n", index, row);
            }
            return outputString;
        }
    }

}