using System;
using System.Collections.Generic;
using Common.DataContracts;
using Common.Serialization;

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

		public IEnumerable<DataRow> Search()
		{
			throw new NotImplementedException();
		}
	}
}