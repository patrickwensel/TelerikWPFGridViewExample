using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using System.Collections;

namespace Telerik.Windows.Examples.GridView.EnumDataSource
{
    public class MyDataContext : ViewModelBase
    {
        public MyDataContext()
        {
            Data = AllPlayers;
            SelectedItem = Countries.FirstOrDefault();
        }

        IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> _countries;
        public IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> Countries
        {
            get
            {
                if (_countries == null)
                {
                        // Calling this static factory method will return an IEnumerable
			            // full of view models. The Value property of each view model is
			            // the actual enum value, so you would typically set 
			            // RadComboBox.SelectedValueMemberPath to be equal to "Value". 
			            // The DisplayName property of each view model returns the first 
			            // of the following properties that is not null:
			            // - DisplayShortName (Silverlight only)
			            // - Description
			            // - Name
			            // So you would typically set the DisplayMemberPath of the combo to
			            // be equal to "DisplayName". But you can use any of the other
			            // properties of the view model if you want.

                    _countries = Telerik.Windows.Data.EnumDataSource.FromType<Country>();
                }

                return _countries;
            }
        }

        IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> _positions;
        public IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> Positions
        {
            get
            {
                if (_positions == null)
                {
                    _positions = Telerik.Windows.Data.EnumDataSource.FromType<Position>();
                }

                return _positions;
            }
        }

        private IList<Player> _allPlayers;
        public IEnumerable<Player> AllPlayers
		{
			get
			{
				if (this._allPlayers == null)
				{
					this._allPlayers = new List<Player>();

					this._allPlayers.Add(new Player("Pepe Reina", Position.GK, Country.ESP));
					this._allPlayers.Add(new Player("Jamie Carragher", Position.DF, Country.GBR));
					this._allPlayers.Add(new Player("Steven Gerrard", Position.MF, Country.GBR));
					this._allPlayers.Add(new Player("Fernando Torres", Position.FW, Country.ESP));

					this._allPlayers.Add(new Player("Edwin van der Sar", Position.GK, Country.NLD));
					this._allPlayers.Add(new Player("Rio Ferdinand",Position.DF, Country.GBR));
					this._allPlayers.Add(new Player("Ryan Giggs", Position.MF, Country.GBR));
					this._allPlayers.Add(new Player("Wayne Rooney", Position.FW, Country.GBR));

					this._allPlayers.Add(new Player("Petr Čech", Position.GK, Country.CZE));
					this._allPlayers.Add(new Player("John Terry", Position.DF, Country.GBR));
					this._allPlayers.Add(new Player("Frank Lampard", Position.MF, Country.GBR));
					this._allPlayers.Add(new Player("Nicolas Anelka", Position.FW, Country.FRA));

					this._allPlayers.Add(new Player("Manuel Almunia", Position.GK, Country.ESP));
					this._allPlayers.Add(new Player("Gaël Clichy", Position.DF, Country.FRA));
					this._allPlayers.Add(new Player("Cesc Fàbregas", Position.MF, Country.ESP));
					this._allPlayers.Add(new Player("Robin van Persie", Position.FW, Country.NLD));
				}

				return this._allPlayers;
			}
		}

        IEnumerable _data;
        public IEnumerable Data
        {
            get
            {
                return _data;
            }
            set
            {
                if (_data != value)
                {
                    _data = value;

                    OnPropertyChanged("Data");
                }
            }
        }

        EnumMemberViewModel _selectedItem;
        public EnumMemberViewModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set 
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;

                    OnPropertyChanged("SelectedItem");

                    if (_selectedItem != null)
			        {
				        Country selectedCountry = (Country)_selectedItem.Value;
				
				        List<Player> players = new List<Player>();
				        foreach (Player p in this.AllPlayers)
				        {
					        if (p.Country == selectedCountry)
					        {
						        players.Add(p);
					        }
				        }

				        Data = players;
			        }
			        else
			        {
				        Data = null;
			        }
                }
            }
        }
    }
}
