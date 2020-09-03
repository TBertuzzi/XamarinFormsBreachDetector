using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.BreachDetector;

namespace XamarinFormsBreachDetector
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            VerificarBrechasSeguranca();
        }

        private void VerificarBrechasSeguranca()
        {
            var isRootOrJailbreak = CrossBreachDetector.Current.IsRooted();
            var isVirtualDevice = CrossBreachDetector.Current.IsRunningOnVirtualDevice();
            var inDebug = CrossBreachDetector.Current.InDebugMode();
            var fromStore = CrossBreachDetector.Current.InstalledFromStore();
            var localAuthentication = CrossBreachDetector.Current.GetDeviceLocalSecurityType();

            var rootOrJailbreak = (Device.RuntimePlatform == Device.Android ? "Root" : "Jaibreak");
            if (isRootOrJailbreak.HasValue
                && isRootOrJailbreak.Value)
                lblRoot.Text = $"Este APP possui : {rootOrJailbreak}  ";
            else
                lblRoot.Text = $"Este APP  Não possui : {rootOrJailbreak} ";

            var virtualDevice = (Device.RuntimePlatform == Device.Android ? "Emulador" : "Simulador");
            if (isVirtualDevice.HasValue
                && isVirtualDevice.Value)
                lblVirtual.Text = $"Este APP Esta Rodando no  : {virtualDevice}  ";
            else
                lblVirtual.Text = $"Este APP esta rodando em um celular ";

            if (inDebug.HasValue
               && inDebug.Value)
                lblDebug.Text = $"Este APP Esta Rodando em Debug  ";
            else
                lblDebug.Text = $"Este APP esta rodando em Release ";

            if (fromStore.HasValue
              && fromStore.Value)
                lblStore.Text = $"Este APP foi instalado da loja  ";
            else
                lblStore.Text = $"Este APP foi instalado de outra fonte ";

            switch(localAuthentication)
            {
                case DeviceSecurityLockScreenType.Biometric:
                    lblAutenticacao.Text = "Este Dispositivo possui Autenticação por : Biometria";
                    break;
                case DeviceSecurityLockScreenType.Pass:
                    lblAutenticacao.Text = "Este Dispositivo possui Autenticação por : Senha";
                    break;
                case DeviceSecurityLockScreenType.None:
                    lblAutenticacao.Text = "Este Dispositivo não possui Autenticação";
                    break;
                case DeviceSecurityLockScreenType.Unknown:
                    lblAutenticacao.Text = "Este Dispositivo possui Autenticação desconhecida";
                    break;

            }


        }
    }
}
