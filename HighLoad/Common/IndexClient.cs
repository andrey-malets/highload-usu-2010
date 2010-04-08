using System;
using System.Collections.Generic;

namespace Common
{
	public class IndexClient : IIndexClient
	{
		private IDataSerializer dataSerializer;
		private ITransport transport;

		public IndexClient(IDataSerializer dataSerializer, ITransport transport)
		{
			this.dataSerializer = dataSerializer;
			this.transport = transport;
		}

		public IEnumerable<DataContract> Search()
		{
			throw new NotImplementedException();
		}
	}
}