namespace Common
{
	//toDO ����� �������� ��������� ���� �� �����
	public interface IServerEndpoint
	{
        string ServerInfo { get; set; }
        string Url { get; set; }
        string Port { get; set; }
	}
}