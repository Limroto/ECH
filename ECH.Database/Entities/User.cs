using System;
using System.Collections.Generic;

namespace ECH.Database.Entities
{
    public class User
    {
        public virtual int Id { get; protected set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime ChangeDate { get; protected set; }
        public virtual IList<Settings> Settings { get; set; }

        public User()
        {
            Settings = new List<Settings>();
            ChangeDate = DateTime.Now;
        }

        public virtual void AddSetting(Settings setting)
        {
            setting.ChangedBy = this;
            Settings.Add(setting);
        }
    }
}