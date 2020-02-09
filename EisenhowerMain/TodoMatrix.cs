using System;
using System.Collections.Generic;
using System.IO;

namespace EisenhowerCore
{
    public class TodoMatrix {
        public Dictionary<string, TodoQuarter> Quarters = new Dictionary<string, TodoQuarter>();
        
        public TodoMatrix()
        {
            Quarters.Add("IU", new TodoQuarter());
            Quarters.Add("NU", new TodoQuarter());
            Quarters.Add("IN", new TodoQuarter());
            Quarters.Add("NN", new TodoQuarter());
        }

        public void AddItem(String title, DateTime deadline, bool isImportant)
        {
            //Add new item to map
            DateTime today = DateTime.Now;
            TimeSpan urgent = deadline - today;
            if (urgent.Days <= 3){
                if(isImportant){
                    Quarters["IU"].AddItem(title, deadline);
                }
                else{
                    Quarters["NU"].AddItem(title, deadline);
                }
            }
            else{
                if(isImportant){
                    Quarters["IN"].AddItem(title, deadline);
                }
                else{
                    Quarters["NN"].AddItem(title, deadline);
                }
            }
        }

        public void ArchiveItems()
        {
            //Removes all TodoItem object with parametr isDone from list todoItems
            foreach (TodoQuarter quarter in Quarters.Values){
                quarter.ArchiveItems();
            }
        }

        public String toString()
        {
            //Return a todoQuarters list formatted to string
            String outputString = "";
            String quarterAsString = "";
            foreach (TodoQuarter quarter in Quarters.Values)
            {
                quarterAsString += quarter.ToString();
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

        public void AddItemsFromFile(String filename){

        }

        public void SaveItemsToFile(String filename){
            
        }
        

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