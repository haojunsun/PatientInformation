using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInformation.Infrastructure.Authentication
{
    public class AuthenticationSection : ConfigurationSection
    {
        [ConfigurationProperty("users")]
        [ConfigurationCollection(typeof(UserCollection))]
        public UserCollection Users
        {
            get
            {
                return (UserCollection)base["users"];
            }
        }
    }
}
