using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GridView.MergedColumnHeaders
{
	public class Vehicle : ViewModelBase
	{
		public Vehicle(string make, string model, string variant, string power, string fuel, string usd, string category)
		{
			this.Make = make;
			this.Model = model;
			this.Variant = variant;
			this.Power = power;
			this.Fuel = fuel;
			this.USD = usd;
			this.Category = category;
		}

		public Vehicle() { }

		public string Make { get; set; }
		public string Model { get; set; }
		public string Variant { get; set; }
		public string Power { get; set; }
		public string Fuel { get; set; }
		public string USD { get; set; }
		public string Category { get; set; }


		public static List<Vehicle> GetSampleListOfVehicles()
		{
			List<Vehicle> vehicles = new List<Vehicle>
			              	{
								new Vehicle("Alfa Romeo","159","Sportwagon","88 kW (120 PS)","Diesel","18000","Estate Cars"),
								new Vehicle("Audi","A4 ","Avant","88 kW (120 PS)","Petrol","26649","Estate Cars"),
								new Vehicle("BMW","318i","Touring","105 kW (143 PS)","Petrol","26890","Estate Cars"),
								new Vehicle("Lancia","MUSA","Gold","70 kW (95 PS)","Petrol","18990","Estate Cars"),
								new Vehicle("Ford","Focus","CV 115","85 kW (116 PS)","Diesel","9900","Estate Cars"),
								new Vehicle("Mercedes-Benz","C200","CDI","100 kW (136 PS)","Diesel","28645","Estate Cars"),
								new Vehicle("Bugatti","Veyron","","736 kW (1001 PS)","Petrol","1290000","Limousine"),
								new Vehicle("Citroën","C6","HDi 240","177 kW (241 PS)","Petrol","47990","Limousine"),
								new Vehicle("Ferrari","F430","SCUDERIA","375 kW (510 PS)","Petrol","215000","Limousine"),
								new Vehicle("Volvo","S80","D5","158 kW (215 PS)","Diesel","53715","Limousine"),
								new Vehicle("Lamborghini","Gallardo","LP550-2","405 kW (551 PS)","Petrol","166450","Sport Cars"),
								new Vehicle("Honda","Acura","MDX","94 kW (128 PS)","Petrol","31800","Sport Cars"),
								new Vehicle("Peugeot","RCZ","HDi FAP 165","120 kW (163 PS)","Diesel","33990","Sport Cars"),
								new Vehicle("Mitsubishi","Lancer","Evolution","217 kW(295 PS)","Petrol","35839","Sport Cars"),
								new Vehicle("Aston Martin","V8","Vantage","313 kW (426 PS)","Petrol","99900","Sport Cars"),
								new Vehicle("McLaren","MP4-12C","","441 kW (600 PS)","Petrol","259900","Sport Cars"),
			              	};

			return vehicles;
		}

		private List<Vehicle> _sampleList;

		public List<Vehicle> SampleList
		{
			get
			{
				if (this._sampleList == null)
				{
					this._sampleList = GetSampleListOfVehicles();
				}

				return this._sampleList;
			}
		}
	}
}
