using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ControleAtividades
{
    class AcessoFuncionario
    {
        string nome, login, senha;
        #region variaveis encapsuladas

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
            }
        }
        #endregion

        // criar as variáveis para acessar o MYSQL
        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        // método de acesso ao BD
        private void carregar_tabela(String comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, TI.Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        public Boolean buscarfunc(string login, string senha)
        {
            carregar_tabela("select * from func where login_func = '" + login + "' and senha_func = '" + senha + "'");
            if (tabela_memoria.Rows.Count > 0)
            {
                Nome = tabela_memoria.Rows[0]["nome_func"].ToString();
                return true;
            }
            else { return false; }
        }
    }
}
