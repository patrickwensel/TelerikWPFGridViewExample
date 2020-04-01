using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Telerik.Windows.Examples
{
    /// <summary>
    /// A football club.
    /// </summary>
    public class Club : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        private DateTime established;
        private int stadiumCapacity;

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

        public DateTime Established
        {
            get { return this.established; }
            set
            {
                if (value != this.established)
                {
                    this.established = value;
                    this.OnPropertyChanged("Established");
                }
            }
        }

        public int StadiumCapacity
        {
            get { return this.stadiumCapacity; }
            set
            {
                if (value != this.stadiumCapacity)
                {
                    this.stadiumCapacity = value;
                    this.OnPropertyChanged("StadiumCapacity");
                }
            }
        }

        public Club(string name, DateTime established, int stadiumCapacity)
        {
            this.name = name;
            this.established = established;
            this.stadiumCapacity = stadiumCapacity;
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

        public static IEnumerable<Club> GetClubs()
        {
            ObservableCollection<Club> clubs = new ObservableCollection<Club>();

            clubs.Add(new Club("Arsenal", new DateTime(1886, 1, 1), 60432));
            clubs.Add(new Club("Aston Villa", new DateTime(1874, 1, 1), 39339));
            clubs.Add(new Club("Birmingham City", new DateTime(1875, 1, 1), 30016));
            clubs.Add(new Club("Blackburn Rovers", new DateTime(1875, 1, 1), 31367));
            clubs.Add(new Club("Bolton Wanderers", new DateTime(1874, 1, 1), 27879));
            clubs.Add(new Club("Burnley", new DateTime(1882, 1, 1), 22546));
            clubs.Add(new Club("Chelsea", new DateTime(1905, 1, 1), 42449));
            clubs.Add(new Club("Everton", new DateTime(1878, 1, 1), 40900));
            clubs.Add(new Club("Fulham", new DateTime(1879, 1, 1), 19250));
            clubs.Add(new Club("Hull City", new DateTime(1904, 1, 1), 25404));
            clubs.Add(new Club("Liverpool", new DateTime(1892, 1, 1), 45362));
            clubs.Add(new Club("Manchester City", new DateTime(1887, 1, 1), 48000));
            clubs.Add(new Club("Manchester United", new DateTime(1878, 1, 1), 76212));
            clubs.Add(new Club("Portsmouth", new DateTime(1898, 1, 1), 19179));
            clubs.Add(new Club("Stoke City", new DateTime(1863, 1, 1), 28218));
            clubs.Add(new Club("Sunderland", new DateTime(1879, 1, 1), 49000));
            clubs.Add(new Club("Tottenham Hotspur", new DateTime(1882, 1, 1), 36236));
            clubs.Add(new Club("West Ham United", new DateTime(1895, 1, 1), 35595));
            clubs.Add(new Club("Wigan Athletic", new DateTime(1932, 1, 1), 25138));
            clubs.Add(new Club("Wolverhampton Wanderers", new DateTime(1877, 1, 1), 28525));

            return clubs;
        }
    }
}
