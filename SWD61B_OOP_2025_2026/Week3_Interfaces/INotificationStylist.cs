using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_Interfaces
{
    public interface INotificationStylist
    {
        string Style(string color);
        string Style(bool bold, bool italic, bool underline);


    }
}
