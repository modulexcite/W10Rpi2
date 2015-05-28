using System.ComponentModel;
using System.Runtime.CompilerServices;
using FaceApi01.Annotations;

namespace FaceApi01.Model
{
    public class OneDriveImage : INotifyPropertyChanged
    {
        private string _desc;
        private string _oneDriveUrl;

        public string Desc
        {
            get { return _desc; }
            set
            {
                if (value == _desc) return;
                _desc = value;
                OnPropertyChanged();
            }
        }

        public string OneDriveUrl
        {
            get { return _oneDriveUrl; }
            set
            {
                if (value == _oneDriveUrl) return;
                _oneDriveUrl = value;
                OnPropertyChanged();
            }
        }

        public OneDriveImage(string desc, string url)
        {
            _desc = desc;
            _oneDriveUrl = url;
        }

        public override string ToString()
        {
            return Desc;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
