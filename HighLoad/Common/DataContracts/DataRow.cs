using System;

namespace Common.DataContracts
{
	public class DataRow : IStoragable
	{
		public Guid Id{ get; set; }
		public Guid GlobalId { get; set; }
		public long Updated { get; set; }

		public string Name{ get; set;}


		public int Number { get; set; }


		public DateTime RevisionTime{ get; private set;}

		public DataRow()
		{
			// TODO: to be deleted
			this.Id = System.Guid.NewGuid();
			this.RevisionTime = DateTime.Now;
		}

		public DataRow(int number, string name)
			: this()
		{
			Name = name;
			Number = number;
		}
	}
}