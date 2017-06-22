using System;

namespace RedNoble.Inspection.Integration
{
    public abstract class BaseDto<T>
    {
        protected BaseDto()
        {
            CreationTime = DateTime.Now;
        }


        public virtual T Id { get; set; }

        public bool IsDeleted { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public DateTime? CreationTime { get; set; }

        public long CreatorUserId { get; set; }
    }
}