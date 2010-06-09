using System.Collections.Generic;
using Common.DataContracts;

namespace Common
{
	public interface IIndexServer
	{
		IEnumerable<DataRow> Search();
		void IndexUpdate();
	}
}