using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace TI
{
    class acessoFesta
    {
        
        double preco_festa;
        int cod_festa, qtdcrianca_festa, qtdadulto_festa;
        DataTable listaFesta;

        public DataTable ListaFesta
        {
            get { return listaFesta; }
            set { listaFesta = value; }
        }

        public int Cod_festa
        {
            get { return cod_festa; }
            set { cod_festa = value; }
        }
        string nome_festa, palhaco_festa, pipoqueiroalgodao_festa, fotografo_festa, horaadd_festa, horainicio_festa;
        DateTime data_festa;

        public DateTime Data_festa
        {
            get { return data_festa; }
            set { data_festa = value; }
        }

        public string Horainicio_festa
        {
            get { return horainicio_festa; }
            set { horainicio_festa = value; }
        }

        public string Horaadd_festa
        {
            get { return horaadd_festa; }
            set { horaadd_festa = value; }
        }

        public string Fotografo_festa
        {
            get { return fotografo_festa; }
            set { fotografo_festa = value; }
        }

        public string Pipoqueiroalgodao_festa
        {
            get { return pipoqueiroalgodao_festa; }
            set { pipoqueiroalgodao_festa = value; }
        }

        public string Palhaco_festa
        {
            get { return palhaco_festa; }
            set { palhaco_festa = value; }
        }

        public string Nome_festa
        {
            get { return nome_festa; }
            set { nome_festa = value; }
        }

        public double Preco_festa
        {
            get { return preco_festa; }
            set { preco_festa = value; }
        }        

        public int Qtdcrianca_festa
        {
            get { return qtdcrianca_festa; }
            set { qtdcrianca_festa = value; }
        }

        public int Qtdadulto_festa
        {
            get { return qtdadulto_festa; }
            set { qtdadulto_festa = value; }
        }

        // criar as variáveis para acessar o MYSQL
        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;


        // método de acesso ao BD
        private void carregar_tabela(String comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        private String converterData(String data)
        {
            DateTime dt = Convert.ToDateTime(data);

            return dt.ToString("yyyy/MM/dd");
        }

        public void inserir(string nome, string palhaco, string pipoqalgod, string fotografo, string horaadd, string qtdcri, string qtdadult, string precotot, string data, string horainicio)
        {
            string datacorreta = converterData(data);
            carregar_tabela("insert into festa values(0, '"+nome+"', '"+palhaco+"', '"+pipoqalgod+"', '"+fotografo+"', '"+horaadd+"', "+qtdcri+", "+qtdadult+", "+precotot+", '"+datacorreta+"', '"+horainicio+"' )");
        }

        public DataTable listartudo()
        {
            carregar_tabela("select * from festa");
                return tabela_memoria;
        }

        public Boolean pesquisarNome (string nome)
        {

            carregar_tabela( "select * from festa where nome_festa ='" +nome + "'");
            if (tabela_memoria.Rows.Count != 0)
            {
                cod_festa = Convert.ToInt32( tabela_memoria.Rows[0]["cod_festa"].ToString());
                nome_festa = tabela_memoria.Rows[0]["nome_festa"].ToString();
                palhaco_festa = tabela_memoria.Rows[0]["palhaco_festa"].ToString();
                pipoqueiroalgodao_festa = tabela_memoria.Rows[0]["pipoqueiroalgodao_festa"].ToString();
                fotografo_festa = tabela_memoria.Rows[0]["fotografo_festa"].ToString();
                horaadd_festa = tabela_memoria.Rows[0]["horaadd_festa"].ToString();
                qtdcrianca_festa = Convert.ToInt32( tabela_memoria.Rows[0]["qtdcrianca_festa"].ToString());
                qtdadulto_festa = Convert.ToInt32( tabela_memoria.Rows[0]["qtdadulto_festa"].ToString());
                preco_festa = Convert.ToDouble(tabela_memoria.Rows[0]["preco_festa"].ToString());
                horainicio_festa = tabela_memoria.Rows[0]["horainicio_festa"].ToString();
                data_festa = Convert.ToDateTime( tabela_memoria.Rows[0]["data_festa"].ToString());

                if (tabela_memoria.Rows.Count > 1)
                {
                    listaFesta = tabela_memoria;
                }
                else
                {
                    listaFesta = null;

                }


                return true;


            }

            else
            {
                return false;
            }
        }

        public Boolean pesquisarData (string data)
        {

            carregar_tabela( "select * from festa where data_festa ='" +data + "'");
            if (tabela_memoria.Rows.Count != 0)
            {
                cod_festa = Convert.ToInt32(tabela_memoria.Rows[0]["cod_festa"].ToString());
                nome_festa = tabela_memoria.Rows[0]["nome_festa"].ToString();
                palhaco_festa = tabela_memoria.Rows[0]["palhaco_festa"].ToString();
                pipoqueiroalgodao_festa = tabela_memoria.Rows[0]["pipoqueiroalgodao_festa"].ToString();
                fotografo_festa = tabela_memoria.Rows[0]["fotografo_festa"].ToString();
                horaadd_festa = tabela_memoria.Rows[0]["horaadd_festa"].ToString();
                qtdcrianca_festa = Convert.ToInt32( tabela_memoria.Rows[0]["qtdcrianca_festa"].ToString());
                qtdadulto_festa = Convert.ToInt32( tabela_memoria.Rows[0]["qtdadulto_festa"].ToString());
                preco_festa = Convert.ToDouble(tabela_memoria.Rows[0]["preco_festa"].ToString());
                horainicio_festa = tabela_memoria.Rows[0]["horainicio_festa"].ToString();
                data_festa = Convert.ToDateTime(tabela_memoria.Rows[0]["data_festa"].ToString());               



                return true;


            }

            else
            {
                return false;
            }
        }


        public void excluir(string cod)
        {
            carregar_tabela("delete from festa where cod_festa="+cod+"");
        }

        public void alterar(string novoNome, string novoPalhaco, string NovoPipoqalgod, string novoFotografo, string novaHoraadd, string novaQtdcri, string novaQtdadult, string novaData, string NovaHorainicio)
        {
            string datacorreta = converterData(novaData);
            carregar_tabela("update festa set nome_festa = '"+novoNome+"', palhaco_festa = '"+novoPalhaco+"', pipoqueiroalgodao_festa='"+NovoPipoqalgod+"', fotografo_festa='"+novoFotografo+"', horaadd_festa= '"+novaHoraadd+"',qtdcrianca_festa= "+novaQtdcri+", qtdadulto_festa="+novaQtdadult+", data_festa='"+datacorreta+"', horainicio_festa='"+NovaHorainicio+"'");
        }

         
        

    }
}
