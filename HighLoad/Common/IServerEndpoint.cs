namespace Common
{
	//toDO нужно отличать ендпойнты друг от друга
	public interface IServerEndpoint
	{
        string ServerInfo { get; set; }
        string Url { get; set; }
        string Port { get; set; }
	}


    public interface IServerEndpointFactory
    {
        IServerEndpoint GetStorageServerEndpoint();
        IServerEndpoint GetIndexServerEndpoint();
    }

    public class ServerEndpointFactory
    {
        public IServerEndpoint GetStorageServerEndpoint()
        {
            return new ServerEndpoint();
        }

        public IServerEndpoint GetIndexServerEndpoint()
        {
            return new ServerEndpoint();
        }
    }
}