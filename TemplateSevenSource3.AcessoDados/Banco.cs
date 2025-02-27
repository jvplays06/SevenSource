﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using TemplateSevenSource3Dominio;
using System.Web.Routing;

namespace TemplateSevenSource3AcessoDados
{
    public class Banco : IDisposable
    {
        private SqlConnection conexao;

        public Banco()
        {
            conexao = new SqlConnection(@"Data Source=SOUSA-PC;Initial Catalog=LOCADORASEVENCAR;User ID=sa;Password=joaovictor");
            conexao.Open();
        }
        public void ExecutarComando(string strQuery)
        {           
                SqlCommand cmd = new SqlCommand(strQuery, conexao);
                cmd.ExecuteNonQuery();          
        }
        public SqlDataReader ExecultarConsulta(string strQuery)
        {
            
                SqlCommand cmd = new SqlCommand(strQuery, conexao);
                return cmd.ExecuteReader();            
       }
        public int RetornaIdEnd(Cliente cliente)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string str = string.Format("Select IDENDERECO from ENDERECO where RUA='{0}' and NUMERO='{1}' and BAIRRO='{2}' and ESTADO='{3}' and CIDADE='{4}'and CEP='{5}';", cliente.Rua, cliente.Numero, cliente.Bairro, cliente.Estado, cliente.Cidade, cliente.Cep);
            da = new SqlDataAdapter(str, conexao);
            da.Fill(dt);
            cliente.idend = (int)dt.Rows[0]["IDENDERECO"];
            return cliente.idend;
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }
    }
}
