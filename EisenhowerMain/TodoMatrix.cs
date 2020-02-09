using System;
using System.Collections.Generic;

namespace EisenhowerCore
{
    public class TodoMatrix {
        Dictionary<string, TodoQuarter> todoQuarters = new Dictionary<string, TodoQuarter>();
        

        public void AddItem(String title, DateTime deadline, bool isImportant)
        {
            //Add new item to map
            DateTime today = DateTime.Now;
            TimeSpan urgent = deadline - today;
            if (urgent.Days <= 3){
                if(isImportant){
                    todoQuarters["IU"].AddItem(title, deadline);
                }
                else{
                    todoQuarters["NU"].AddItem(title, deadline);
                }
            }
            else{
                if(isImportant){
                    todoQuarters["IN"].AddItem(title, deadline);
                }
                else{
                    todoQuarters["NN"].AddItem(title, deadline);
                }
            }
        }

        public void ArchiveItems()
        {
            //Removes all TodoItem object with parametr isDone from list todoItems
            foreach (TodoQuarter quarter in todoQuarters.Values){
                quarter.ArchiveItems();
            }
        }
        
    }

}