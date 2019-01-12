using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsandoRealm.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsandoRealm.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExibeFuncionarioPage : ContentPage
	{
        Funcionario funciSelecionado;

        public ExibeFuncionarioPage (Funcionario _funcionario)
		{
			InitializeComponent ();
            funciSelecionado = _funcionario;
            BindingContext = funciSelecionado;
        }

        private void OnEditaClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditaFuncionarioPage(funciSelecionado));
        }
        private async void OnDeletaClicked(object sender, EventArgs e)
        {
            bool resposta = await DisplayAlert("Confirma", "Tem Certeza ?", "Sim", "Não");

            if (resposta)
            {
                var RealmDb = Realm.GetInstance();
                var funci = RealmDb.All<Funcionario>().First(f => f.Id == funciSelecionado.Id);
                // Deleta um objeto com uma transação
                using (var trans = RealmDb.BeginWrite())
                {
                    RealmDb.Remove(funci);
                    trans.Commit();
                }
            }
            await Navigation.PopToRootAsync();
        }
    }
}