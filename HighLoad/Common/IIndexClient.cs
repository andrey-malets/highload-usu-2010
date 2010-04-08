using System.Collections.Generic;

namespace Common
{
	public interface IIndexClient
	{
		IEnumerable<DataContract> Search();
	}



	//toDO kill???
	public interface IIndexServer
	{
		IEnumerable<DataContract> Search();		
	}
}