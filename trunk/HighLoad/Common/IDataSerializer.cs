namespace Common
{
	public interface IDataSerializer
	{
	    byte[] Serialize<T>(T param);

        T Deserialize<T>(byte[] bytes);
	}
}