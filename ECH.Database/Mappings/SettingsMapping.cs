using ECH.Database.Entities;
using FluentNHibernate.Mapping;

namespace ECH.Database.Mappings
{
    public class SettingsMapping : ClassMap<Settings>
    {
        public SettingsMapping()
        {
            Id(s => s.Id).Not.Nullable();
            Map(s => s.Speed).Not.Nullable();
            Map(s => s.Active).Not.Nullable();
            Map(s => s.Direction).Not.Nullable();
            Map(s => s.CreateDate).Not.Nullable();
            References(s => s.ChangedBy)
                .Cascade.None();
        }
    }
}