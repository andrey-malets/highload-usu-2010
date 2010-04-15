using System;

namespace Common.DataContracts
{
	public interface IStoragable
	{
		Guid Id { get; set; }
		Guid GlobalId { get; set; }
		//DataCreated { get; }
		long Updated { get; }
	}
}