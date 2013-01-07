using ECH.Database.Entities;
using FluentNHibernate.Mapping;

namespace ECH.Database.Mappings
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Id(u => u.Id)
                .Not.Nullable();
            Map(u => u.FirstName).Not.Nullable();
            Map(u => u.LastName).Not.Nullable();
            Map(u => u.ChangeDate).Not.Nullable();
            HasMany(u => u.Settings)
                .KeyColumn("ChangedBy")
                .Inverse()
                .Cascade.All();
        }
    }
}