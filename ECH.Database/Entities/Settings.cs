using System;

namespace ECH.Database.Entities
{
    public class Settings
    {
        public virtual int Id { get; protected set; }
        public virtual string Direction { get; set; }
        public virtual int Speed { get; set; }
        public virtual bool Active { get; set; }
        public virtual User ChangedBy { get; set; }
        public virtual DateTime CreateDate { get; protected set; }

        public Settings()
        {
            CreateDate = DateTime.Now;
        }
    }
}