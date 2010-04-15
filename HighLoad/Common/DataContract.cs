using System;

namespace Common
{
    // что-то примерное, для теста HighLoadWeb
    public class DataContract
    {

        public Guid Id{ get; private set;}


        public string Name{ get; set;}


        public int Number { get; set; }


        public DateTime RevisionTime{ get; private set;}

        public DataContract()
        {
            this.Id = System.Guid.NewGuid();
            this.RevisionTime = DateTime.Now;
        }

        public DataContract(int number, string name)
            : this()
        {
            Name = name;
            Number = number;
        }
    }
}
