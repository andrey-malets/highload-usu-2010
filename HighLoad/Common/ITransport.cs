using System.Collections.Specialized;

namespace Common
{
	public interface ITransport
	{
		NameValueCollection Interact(IServerEndpoint serverEndpoint, NameValueCollection message);
	}
}