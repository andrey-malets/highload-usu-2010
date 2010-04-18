using System;
using System.Runtime.Serialization;

namespace USU.HighLoad.Storage.StorageDataContract
{
    [DataContract]
    public class DataRecord
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid GlobalId { get; set; }

        [DataMember]
        public DateTime RevisionDate { get; set; }

        [DataMember]
        public int Number { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public long Updated { get; set; }

    }
}