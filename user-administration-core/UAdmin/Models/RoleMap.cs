namespace UAdmin.Models
{
    /// <summary>
    /// Класс маппинга роли
    /// </summary>
    public class RoleMap : EntityMap<Role>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public RoleMap()
        {
            Map(m => m.Name);
            HasManyToMany<User>(user => user.Users)
                .Table("User_Role")
                .ParentKeyColumn("roleId")
                .ChildKeyColumn("userId")
                .Cascade.SaveUpdate();
        }
    }
}
