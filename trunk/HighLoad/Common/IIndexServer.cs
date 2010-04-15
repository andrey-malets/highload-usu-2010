using System.Collections.Generic;
using Common.DataContracts;

namespace DataContract
{
	public interface IIndexServer
	{
		IEnumerable<DataRow> Search();
		void IndexUpdate();
	}
}