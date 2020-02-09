using System;
using System.Collections.Generic;
using System.IO;

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

        public String toString()
        {
            //Return a todoQuarters list formatted to string
            String outputString = "";
            String quarterAsString = "";
            foreach (TodoQuarter quarter in todoQuarters.Values)
            {
                quarterAsString += quarter.toString();
                outputString += String.Format("{0}\n", quarterAsString);
            }
            return outputString;
        }

        // public void saveItemsToFile(String filename)
        // {
        //     //Add items from mat to file by format:
        //     // title|day-month|is_important
        //     String dataToSave = "";
        //     String unconvertData = "";
        //     foreach(Map.Entry<String, TodoQuarter> entry in todoQuarters.entrySet()){
        //         unconvertData = entry.getValue().toString().toString();
        //         if(unconvertData == ""){
        //             continue;
        //         }

        //         if(entry.getKey().equals("IU") | entry.getKey().equals("IN")){
        //             dataToSave += createStringToSave(entry, true);
        //         }
        //         else{
        //             dataToSave += createStringToSave(entry, false);
        //         }
        //     }       
        //     saveToFile(dataToSave, filename);
        // }
        

        public static StreamReader OpenFile(string filename)
        {
            StreamReader data = null;

            try 
            {
                data = new StreamReader(filename);
            }
            catch ( IOException e) 
            {
                Console.WriteLine("Sorry but I was unable to open your data file");
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
            return data;
        }
    }

}