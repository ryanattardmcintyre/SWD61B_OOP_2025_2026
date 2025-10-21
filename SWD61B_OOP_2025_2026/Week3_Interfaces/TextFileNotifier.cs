using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week3_Interfaces
{
    public class TextFileNotifier : INotifier
    {
        private string _path;
        public TextFileNotifier(string path)
        {
            notifications = new List<string>();
            _path = path;
        }

        private List<string> notifications;
        public List<string> Notifications
        {
            get { return notifications; }
        }
        public void Notify(string message)
        {
            notifications.Add(message);
            File.AppendAllText(_path, message);
        }

        public void Notify(string message, string recipient)
        {
            string notification = $"{message} to {recipient}";
            notifications.Add(notification);

            File.AppendAllText(_path, notification);
        }

        public void Notify(string message, string recipient, string from)
        {
            string notification = $"{from}: {message} to {recipient}";
            notifications.Add(notification);

            File.AppendAllText(_path, notification);
        }
    }
}
