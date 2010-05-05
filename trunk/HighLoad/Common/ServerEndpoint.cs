namespace Common
{
	public class ServerEndpoint : IServerEndpoint
	{
		public string ServerInfo
		{
			get; set;
		}
        public string Url
        {
            get; set;
        }
        public string Port
        {
            get; set;
        }
    }
}