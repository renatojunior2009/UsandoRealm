using Realms;

namespace UsandoRealm.Model
{
    public class Funcionario : RealmObject
    {
        [PrimaryKey]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Setor { get; set; }
        public string Qualificacao { get; set; }
    }
}
