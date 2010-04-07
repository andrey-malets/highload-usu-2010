using System;

namespace Common
{
    // что-то примерное, для теста HighLoadWeb
    public class HighLoadDataString
    {
        private Guid id;

        public Guid Id
        {
            get { return id; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        private DateTime revisionTime;

        public DateTime RevisionTime
        {
            get { return revisionTime; }
        }

        public HighLoadDataString(int number, string name)
        {
            this.id = System.Guid.NewGuid();
            this.number = number;
            this.name = name;
            this.revisionTime = DateTime.Now;
        }
    }
}
