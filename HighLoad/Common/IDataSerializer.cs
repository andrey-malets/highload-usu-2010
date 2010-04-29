namespace Common
{
	public interface IDataSerializer
	{
	    byte[] Serialize(string str);

        string Deserialize(byte[] bytes);
	}
}