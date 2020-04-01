using System;
using System.Linq;
using System.ComponentModel;

namespace Telerik.Windows.Examples.GridView.EnumDataSource
{
    /// <summary>
    /// A football player.
    /// </summary>
    public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        private Position position;
        private Country country;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value != this.name)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        public Position Position
        {
            get { return this.position; }
            set
            {
                if (value != this.position)
                {
                    this.position = value;
                    this.OnPropertyChanged("Position");
                }
            }
        }

        public Country Country
        {
            get { return this.country; }
            set
            {
                if (value != this.country)
                {
                    this.country = value;
                    this.OnPropertyChanged("Country");
                }
            }
        }

        public Player(string name, Position position, Country country)
        {
            this.name = name;
            this.position = position;
            this.country = country;
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (null != this.PropertyChanged)
            {
                this.PropertyChanged(this, args);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}
