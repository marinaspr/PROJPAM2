using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace AppRpgEtec.ViewModels
{
    class LocalizacaoViewModel : BaseViewModel
    {
        private Map meuMapa;
        public Map MeuMapa
        {
            get => meuMapa;
            set {
                if (value != null)
                {
                    meuMapa= value;
                    OnPropertyChanged();
                }
                }
        }
        public async void InicializarMapa()
        {
            try
            {
                Location location = new Location(-234.5200241d, -46.596498d);
                Pin pinEtec = new Pin()
                {
                    Type = PinType.Place,
                    Label = "ETEC Horacio",
                    Address = "Rua Alcantara, 113, Vila Guilherme",
                    Location = location
                };
                Map map = new Map();
                MapSpan mapSpan = MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(5));
                map.Pins.Add(pinEtec);
                map.MoveToRegion(mapSpan);

                meuMapa= map;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("ERRO", ex.Message, "ok");
            }
        }
    }

}
