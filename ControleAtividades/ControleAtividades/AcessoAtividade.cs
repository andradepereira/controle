using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ControleAtividades
{
    class AcessoAtividade
    {

        int id_ativ, id_func, desc_ativ;
        DateTime data_ativ;

        #region var
        public DateTime Data_ativ
        {
            get
            {
                return data_ativ;
            }

            set
            {
                data_ativ = value;
            }
        }

        public int Id_ativ
        {
            get
            {
                return Id_ativ1;
            }

            set
            {
                Id_ativ1 = value;
            }
        }

        public int Id_ativ1
        {
            get
            {
                return Id_ativ2;
            }

            set
            {
                Id_ativ2 = value;
            }
        }

        public int Id_ativ2
        {
            get
            {
                return id_ativ;
            }

            set
            {
                id_ativ = value;
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
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        private String converterData(String data)
        {
            DateTime dt = Convert.ToDateTime(data);

            return dt.ToString("yyyy/MM/dd");
        }

        public string buscarid(string nome)
        {
            carregar_tabela("select id_func from func where nome_func='" + nome + "'");
            return tabela_memoria.Rows[0]["id_func"].ToString();
        }

        public void inserirativ(string idfunc, string desc, string data, string hora)
        {
            string dt = converterData(data);
            carregar_tabela("insert into atividade values(0,"+idfunc+",'"+desc+"','"+dt+"', '"+hora+"')");
        }

        public DataTable listartudo()
        {
            carregar_tabela("select a.id_ativ, f.nome_func,a.desc_ativ, a.data_ativ, a.hora_ativ from atividade a, func f where f.id_func = a.id_func");
            return tabela_memoria;
        }


    }
}
