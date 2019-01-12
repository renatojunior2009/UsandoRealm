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
	public partial class NovoFuncionarioPage : ContentPage
	{
		public NovoFuncionarioPage ()
		{
			InitializeComponent ();
		}

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            var RealmDb = Realm.GetInstance();
            var FunciId = RealmDb.All<Funcionario>().Count() + 1;
            var funcionario = new Funcionario()
            {
                Id = FunciId,
                Nome = txtNome.Text,
                Setor = txtSetor.Text,
                Cargo = txtCargo.Text,
                Qualificacao = txtQualificacao.Text
            };
            RealmDb.Write(() => {
                funcionario = RealmDb.Add(funcionario);
            });
            await Navigation.PopAsync();
        }
    }
}