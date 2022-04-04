using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hadOOP
{
    public interface IUser
    {
        public string UserName { get; set; }

        public string PwdHash { get; set; }

        public int HighScore { get; set; }

        string returnUserName();
    }
}
