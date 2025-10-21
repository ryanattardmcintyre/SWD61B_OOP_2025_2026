using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_Interfaces
{
    public class ConsoleNotifier : INotifier, INotificationStylist
    {
        public ConsoleNotifier() {
            notifications = new List<string>();
        }

        private List<string> notifications;
        public List<string> Notifications
        {
            get { return notifications; }
        }

        public void Notify(string message)
        {
            notifications.Add(message);
            Console.WriteLine(message);
        }

        public void Notify(string message, string recipient)
        {
            Style("Green");
            string notification = $"{message} to {recipient}";
            notifications.Add(notification);
            Console.WriteLine(notification);
        }

        public void Notify(string message, string recipient, string from)
        {
            Style("Green");
            string notification = $"{from} : {message} to {recipient}";
            notifications.Add(notification);
            Console.WriteLine(notification);
        }

        public string Style(string color)
        {
            try
            {
                Enum.TryParse<ConsoleColor>(color, ignoreCase: true, out var colorToInput);
                Console.ForegroundColor = colorToInput;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            return color;
        }

        public string Style(bool bold, bool italic, bool underline)
        {
            return "";
        }

       
    }
}
