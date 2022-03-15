using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hadOOP
{
    class GameTimer
    {
        public DateTime Update { get; set; }
        public DateTime NextUpdate { get; set; }

        public GameTimer()
        {
            Update = DateTime.Now;
            NextUpdate = DateTime.Now.AddMilliseconds(500);
        }

        public bool IsUpdating()
        {
            if(Update < NextUpdate)
            {
                Update = DateTime.Now;
                return true;
            }
            else
            {
                NextUpdate = DateTime.Now.AddMilliseconds(500);
                return false;
            }
        }
    }
}
