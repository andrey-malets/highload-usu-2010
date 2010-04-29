namespace Common
{
	//toDO нужно отличать ендпойнты друг от друга
	public interface IServerEndpoint
	{
        string ServerInfo { get; set; }
        string Url { get; set; }
        string Port { get; set; }
	}
}