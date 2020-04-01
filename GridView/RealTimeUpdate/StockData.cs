using System;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.GridView.RealTimeUpdate
{
	public class StockData : INotifyPropertyChanged
	{
		private string name;
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				if (this.name != value)
				{
					this.name = value;
					this.OnPropertyChanged("Name");
				}
			}
		}

		private double change;
		public double Change
		{
			get
			{
				return this.change;
			}
			set
			{
				if (this.change != value)
				{
					this.change = value;
					this.OnPropertyChanged("Change");
				}
			}
		}

		private DateTime lastUpdate;
		public DateTime LastUpdate
		{
			get
			{
				return this.lastUpdate;
			}
			set
			{
				if (this.lastUpdate != value)
				{
					this.lastUpdate = value;
					this.OnPropertyChanged("LastUpdate");
				}
			}
		}

		private void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
