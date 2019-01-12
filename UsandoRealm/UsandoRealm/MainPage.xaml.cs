using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsandoRealm.Model;
using UsandoRealm.Views;
using Xamarin.Forms;

namespace UsandoRealm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var RealmDb = Realm.GetInstance();
            var listaFuncionarios = RealmDb.All<Funcionario>();
            lvFuncionarios.ItemsSource = listaFuncionarios;
        }

        private void lvFuncionarios_OnSelecao(object sender, SelectedItemChangedEventArgs e)
        {
            //O ItemSelected é chamado quando um item é deselecionado
            //e isso torna o SelectedItem null  
            if (e.SelectedItem == null)
                return;
            
            var funciSelecionado = (Funcionario)e.SelectedItem;

            Navigation.PushAsync(new ExibeFuncionarioPage(funciSelecionado));
        }

        private async void btnIncluir_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NovoFuncionarioPage());
        }
    }
}
