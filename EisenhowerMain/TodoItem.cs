using System;

namespace EisenhowerCore {
public class TodoItem
    {
        public string Title;
        public DateTime Deadline = new DateTime();
        public bool IsDone;

        public TodoItem(string title, DateTime deadline)
        {
            this.Title = title;
            this.Deadline = deadline;
        }

        public string GetTitle()
        {
            return Title;
        }

        public DateTime GetDeadline()
        {
            return Deadline;
        }

        public void publicvoidMark()
        {
            IsDone = true;
        }

        public void Mark()
        {
            IsDone = true;
        }

        public void UnMark()
        {
            IsDone = false;
        }

        public bool getIsDone(){
            return IsDone;
        }

        public string ToString()
        {
            string outputString = "";
            int Month = Deadline.Month;
            int Day = Deadline.Day;
            if (IsDone){
                outputString = String.Format("[x] {1}-{0} {2}", Day, Month, Title);
            }
            else{
                outputString = String.Format("[ ] {1}-{0} {2}", Day, Month, Title);
            }
            return outputString;
        }

    }

}