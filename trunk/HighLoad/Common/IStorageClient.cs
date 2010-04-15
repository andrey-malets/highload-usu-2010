using System.Collections.Generic;
using Common.DataContracts;

namespace Common
{
	public interface IStorageClient
	{
		IEnumerable<IStoragable> Update(long revision);
	}
}