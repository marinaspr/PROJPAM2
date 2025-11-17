using AppRpgEtec.Models;
using AppRpgEtec.Services.Usuarios;
using AppRpgEtec.Views.Disputas;
using System.Windows.Input;

namespace AppRpgEtec.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService _uService;
        public ICommand AutenticarCommand { get; set; }
        public ICommand RegistrarCommand { get; set; }
        public ICommand DirecionarCadastroCommand { get; set; }
        public UsuarioViewModel()
        {
            _uService = new UsuarioService();
            InicializarCommands();
        }

        public void InicializarCommands()
        {
            AutenticarCommand = new Command(async () => await AutenticarUsuario());
            RegistrarCommand = new Command(async () => await RegistrarUsuario());
            DirecionarCadastroCommand = new Command(async () => await DirecionarParaCadastro());
        }

        #region AtributosPropriedades
        private string login = string.Empty;
        private string senha = string.Empty;
        //CTRL R + E -> Cria propriedade do atributo

        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }
        public string Senha
        {
            get => senha;
            set
            {
                senha = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Metodos

        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;

        public async Task AutenticarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Username = Login;
                u.PasswordString = Senha;
                Usuario uAutenticado = await _uService.PostAutenticarUsuarioAsync(u);

                //if (!string.IsNullOrEmpty(uAutenticado.Token))
                if (uAutenticado.Id != 0)
                {
                    string mensagem = $"Bem vindo {u.Username}";
                    Preferences.Set("UsuarioToken", uAutenticado.Token);
                    Preferences.Set("UsuarioId", uAutenticado.Id);
                    Preferences.Set("UsuarioUsername", uAutenticado.Username);
                    Preferences.Set("UsuarioPerfil", uAutenticado.Perfil);

                    //Início da coleta de Geolocalização atual para Atualização na API
                    _isCheckingLocation = true;
                    _cancelTokenSource = new CancellationTokenSource();
                    GeolocationRequest request =
                        new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                    Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                    Usuario uloc = new Usuario();
                    uloc.Id = uAutenticado.Id;
                    uloc.Latitude = location.Latitude;
                    uloc.Longitude = location.Longitude;

                    UsuarioService uServiceLoc = new UsuarioService(uAutenticado.Token);
                    await uServiceLoc.PutAtualizarLocalizacaoAsync(uloc);
                    //Fim da coleta de Geolocalização atual para Atualização na API

                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    Application.Current.MainPage = new ListagemView();
                }
                else
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", "Dados incorretos :(", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informação",
                        ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task RegistrarUsuario()//Método para registrar um usuário     
        {
            try
            {
                Usuario u = new Usuario();
                u.Username = Login;
                u.PasswordString = Senha;

                Usuario uRegistrado = await _uService.PostRegistrarUsuarioAsync(u);

                if (uRegistrado.Id != 0)
                {
                    string mensagem = $"Usuário Id {uRegistrado.Id} registrado com sucesso.";
                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    await Application.Current.MainPage
                        .Navigation.PopAsync();//Remove a página da pilha de visualização
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaCadastro()//Método para exibição da view de Cadastro      
        {
            try
            {
                await Application.Current.MainPage.
                    Navigation.PushAsync(new Views.Usuarios.CadastroView());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        //android:icon="@mipmap/appicon" android:roundIcon="@mipmap/appicon_round"



        #endregion

    }
}
