using System.Collections.Generic;
using Common.DataContracts;

namespace Common
{
	public interface IIndexClient
	{
		IEnumerable<DataRow> Search();
	}
}