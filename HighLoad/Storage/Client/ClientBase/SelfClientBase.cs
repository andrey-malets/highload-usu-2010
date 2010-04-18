using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ClientBase
{
    public class SelfClientBase<TChannel> : ClientBase<TChannel>, IDisposable where TChannel : class 
    {
        public SelfClientBase()
        {}

        public SelfClientBase( Binding binding, EndpointAddress endpointAddress ) : base( binding, endpointAddress )
        {}

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            try
            {
                Close();
            }
            catch (Exception)
            {
                Abort();
            }
        }

        #endregion

    }
}