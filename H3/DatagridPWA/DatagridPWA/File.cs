using System.Collections.ObjectModel;
using System.ComponentModel;
using Blazored.LocalStorage;

namespace DatagridPWA
{
    public class File : INotifyPropertyChanged
    {
        // Constructor for file object
        public File(Guid id, string name, string type, long size, byte[] data, DateTime lastModified, bool isEditActivated)
        {
            _id = id;
            _name = name;
            _type = type;
            _size = size;
            _data = data;
            _lastModified = lastModified;
            _isEditActivated = isEditActivated;
        }

        // Object fields

        private Guid _id;
        private string _name;
        private string _type;
        private long _size;
        private byte[] _data;
        private DateTime _lastModified;
        private bool _isEditActivated;

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }
        public string Name
        {

            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                NotifyPropertyChanged("Type");
            }
        }
        public long Size
        {
            get { return _size; }
            set
            {
                _size = value;
                NotifyPropertyChanged("Size");
            }
        }
        public byte[] Data
        {
            get { return _data; }
            set
            {
                _data = value;
                NotifyPropertyChanged("Data");
            }
        }
        public DateTime LastModified
        {
            get { return _lastModified; }
            set
            {
                _lastModified = value;
                NotifyPropertyChanged("LastModified");
            }
        }
        public bool IsEditActivated
        {
            get { return _isEditActivated; }
            set
            {
                _isEditActivated = value;
                NotifyPropertyChanged("IsEditActivated");
            }
        }

        // EventHandler for property
        public event PropertyChangedEventHandler? PropertyChanged;
        
        // Notify's property eventhandler when property has changed
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
