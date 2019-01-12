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
	public partial class EditaFuncionarioPage : ContentPage
	{
        private Funcionario funciSelecionado;

        public EditaFuncionarioPage (Funcionario _funcionario)
		{
			InitializeComponent ();
            this.funciSelecionado = _funcionario;
            BindingContext = funciSelecionado;
        }

        private void btnOnSalvarClicked(object sender, EventArgs e)
        {
            var RealmDb = Realm.GetInstance();
            using (var trans = RealmDb.BeginWrite())
            {
                funciSelecionado.Nome = txtNome.Text;
                funciSelecionado.Setor = txtSetor.Text;
                funciSelecionado.Cargo = txtCargo.Text;
                funciSelecionado.Qualificacao = txtQualificacao.Text;
                trans.Commit();
            }
            Navigation.PopToRootAsync();
        }
    }
}