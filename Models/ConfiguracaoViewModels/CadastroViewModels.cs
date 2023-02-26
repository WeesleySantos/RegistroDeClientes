using RegistroClientes.Factorie;
using RegistroClientes.Interface;
using RegistroClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroClientes.Models
{
    public class CadastroViewModels
    {
        public CadastroViewModels()
        {

        }

        private readonly ICadastroDb _cadastroDb;

        public CadastroViewModels(ConfiguracaoCadastro configuracao)
        {
            _cadastroDb = CadastroFactoyDb.GetCadastroDb(configuracao);
        }

        public Cliente Cadastro { get; set; }  

        public List<Cliente> Cadastros { get; set; }

        public bool InserirCadastro(Cliente cadastro)
        {
            return _cadastroDb.Insert(cadastro);
        }

        public bool AtualizarCadastro(Cliente cadastro)
        {
            return _cadastroDb.Update(cadastro);
        }
        public bool EcluirCadastro(int id)
        {
            return _cadastroDb.Excluir(id);
        }
        public List<Cliente> ListaDeCadastro()
        {
            return _cadastroDb.Cadastros();
        }
    }
}
