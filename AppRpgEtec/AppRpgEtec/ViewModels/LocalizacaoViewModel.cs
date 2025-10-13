using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRpgEtec.Models;
using AppRpgEtec.Services.Usuarios;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace AppRpgEtec.ViewModels
{
    class LocalizacaoViewModel : BaseViewModel
    {
        private UsuarioService uService;
        private LocalizacaoViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            uService = new UsuarioService(token);
        }
        private Map meuMapa;
        public Map MeuMapa
        {
            get => meuMapa;
            set {
                if (value != null)
                {
                    meuMapa = value;
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

                meuMapa = map;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("ERRO", ex.Message, "ok");
            }
        }

        public async void ExibirUsuariosNoMapa()
        {
            try
            {
                ObservableCollection<Usuario> ocUsuarios await uService.GetUsuariosAsync();
                List<Usuario> listaUsuarios = new List<Usuario>(ocUsuarios);
                Map map = new Map();

                foreach (Usuario u in listaUsuarios)
                {
                    if (u.Latitude != null && u.Longitude != null)
                    {
                        double latitude = (double)u.Latitude;
                        double logitude = (double)u.Longitude;
                        Location location = new Location(latitude, logitude);

                        Pin pinAtual = new Pin()
                        {
                            Type = PinType.Place,
                            Label = u.Username,
                            Address = $"E-mail: {u.Email}",
                            Location = location
                        };
                        map.Pins.Add(pinAtual);
                    }
                }
                MeuMapa = map;
            }

            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
    }
}
        
