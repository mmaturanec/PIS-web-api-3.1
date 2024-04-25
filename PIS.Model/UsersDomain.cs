using PIS.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIS.Model
{
	public class UsersDomain
	{
        public UsersDomain()
        {
            
        }
        public UsersDomain(PisUsersMmaturanec user)
        {
            UserId = user.UserId;
            UserLoginName = user.UserLoginName;
            UserName = user.UserName;
            UserSurname = user.UserSurname;
            UserEmail = user.UserEmail;
            UserApproved = user.UserApproved;
        }

        public int UserId { get; set; }
        public string UserLoginName { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public int? UserApproved{ get; set; }
    }
}
