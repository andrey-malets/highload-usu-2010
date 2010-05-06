using System.Collections.Generic;

namespace Common.Clients
{
    public interface IStorageClient
    {
        IEnumerable<T> Update<T>(long revision);
        T Save<T>(T data);
    }
}