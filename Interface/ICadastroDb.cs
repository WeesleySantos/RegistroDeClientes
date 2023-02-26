
using RegistroClientes.Model;
using System.Collections.Generic;

namespace RegistroClientes.Interface
{
    public interface ICadastroDb
    {
        bool Insert(Cliente cadastro);
        bool Update(Cliente cadastro);
        bool Excluir(int id);
        List<Cliente> Cadastros();
    }
}
