using System;

namespace EisenhowerCore {
public class TodoItem
    {
        private string Title;
        private DateTime Deadline = new DateTime();
        private bool IsDone;

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

        public string ToString()
        {
            string outputString = "";
            int Month = Deadline.Month;
            int Day = Deadline.Day;
            if (IsDone){
                outputString = String.Format("[x] {0}-{1} {2}", Day, Month, Title);
            }
            else{
                outputString = String.Format("[ ] {0}-{1} {2}", Day, Month, Title);
            }
            return outputString;
        }

    }

}