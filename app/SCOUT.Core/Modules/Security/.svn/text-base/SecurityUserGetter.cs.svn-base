namespace SCOUT.Core.Data
{
    public class SecurityUserGetter : IUserInfoGetter
    {
        public string UserLoginName
        {
            get
            {
                if(Security.UserSecurity.CurrentUser != null)                    
                    return Security.UserSecurity.CurrentUser.Login;               
                
                return "";                
            }
        }
    }
}