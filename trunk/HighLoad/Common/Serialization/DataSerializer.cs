using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common.Serialization
{
    public class DataSerializer : IDataSerializer
    {
        private readonly BinaryFormatter _binaryFormatter;

        public DataSerializer()
        {
            _binaryFormatter = new BinaryFormatter();
        }

        public byte[] Serialize<T>(T param)
        {
            var mem = new MemoryStream();
            _binaryFormatter.Serialize(mem, param);
            return mem.ToArray();
        }

        public T Deserialize<T>(byte[] bytes)
        {
            return (T)_binaryFormatter.Deserialize(new MemoryStream(bytes));
        }
    }
}