using Dapper;
using RegistroClientes.Factorie;
using RegistroClientes.Interface;
using RegistroClientes.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroClientes.MSSQL
{
    public class MSSQLCadastro : ICadastroDb
    {
        private readonly string _conexao;

        public MSSQLCadastro(ConfiguracaoCadastro configuracao)
        {
            _conexao = configuracao.ConexaoComBanco;
        }

        public List<Cliente> Cadastros()
        {
            using (var conexao = new SqlConnection(_conexao))
            {
                var query = @"SELECT Id
                                    ,NomeCliente
                                    ,CPF
                                FROM Clientes";
                return conexao.Query<Cliente>(query).ToList();
            }
        }

        public bool Excluir(int id)
        {
            using (var conexao = new SqlConnection(_conexao))
            {
                var query = @"DELETE FROM Clientes WHERE Id = @Id";

                conexao.Execute(query, new { id });
                return true;
            }
        }

        public bool Insert(Cliente cadastro)
        {
            using (var conexao = new SqlConnection(_conexao))
            {
                var sql = @"INSERT INTO Clientes
                             (NomeCliente
                             ,CPF)
                      VALUES
                             (@NomeCliente
                             ,@CPF)";

                conexao.Execute(sql, new
                {
                    NomeCliente = cadastro.NomeCliente,
                    CPF = cadastro.CPF,                 
                });
                return true;
            }
        }

        public bool Update(Cliente cadastro)
        {
            using (var conexao = new SqlConnection(_conexao))
            {
                var sql = @"UPDATE Clientes
                            SET NomeCliente = @NomeCliente
                               ,CPF = @CPF
                            WHERE Id = @Id ";

                conexao.Execute(sql, new
                {
                    Id = cadastro.Id,
                    NomeCliente = cadastro.NomeCliente,
                    CPF = cadastro.CPF,
                });
                return true;
            }
        }
    }
}
