namespace UAdmin.Models
{
    /// <summary>
    /// Класс маппинга пользователя
    /// </summary>
    public class UserMap : EntityMap<User>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public UserMap()
        {
            Map(user => user.Login).Index("IX_User_Login");
            Map(user => user.Name);
            Map(user => user.Email);
            Map(user => user.Password);
            HasManyToMany<Role>(user => user.Roles)
                .Table("User_Role")
                .ChildKeyColumn("roleId")
                .ParentKeyColumn("userId")
                .Cascade.SaveUpdate();
        }
    }
}   
