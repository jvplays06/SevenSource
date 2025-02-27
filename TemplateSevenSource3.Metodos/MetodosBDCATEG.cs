﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateSevenSource3.Dominio;
using TemplateSevenSource3AcessoDados;
using TemplateSevenSource3Dominio;

namespace TemplateSevenSource3.Metodos
{
    public class MetodosBDCATEG
    {
        Banco banco = new Banco();
        public void CadastrarCategoria(Categoria categoria)
        {
            var strQuery = "";
            strQuery = string.Format("INSERT INTO CATEGORIA(TIPOCATEGORIA,VALOR_P_DIA,DSCATEGORIA)VALUES(UPPER('{0}'),{1},UPPER('{2}'))", categoria.Tipo, categoria.Valor_p_dia,categoria.Descricao) ;
            banco.ExecutarComando(strQuery);
        }
        public void DeletarCategoria(int id)
        {
            var strQuery = "";
            strQuery += string.Format("DELETE FROM CATEGORIA WHERE IDCATEGORIA={0}", id);
            banco.ExecutarComando(strQuery);
        }
        public void AtualizarCategoria(Categoria categoria)
        {
            var strQuery = "";
            strQuery += string.Format("UPDATE CATEGORIA SET ");
            strQuery += string.Format("TIPOCATEGORIA=UPPER('{0}'),", categoria.Tipo);
            strQuery += string.Format("VALOR_P_DIA={0},", categoria.Valor_p_dia);
            strQuery += string.Format("DSCATEGORIA=UPPER('{0}') ", categoria.Descricao);
            strQuery += string.Format("WHERE IDCATEGORIA={0}", categoria.Id);
            banco.ExecutarComando(strQuery);
        }
        public List<Categoria> ListarCategoria()
        {
            using (banco = new Banco())
            {
                var strQuery = "SELECT * FROM CATEGORIA;";
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeCategoria(retorno);
            };
        }
        public List<Categoria> ListaDeCategoria(SqlDataReader retorno)
        {
            var categoria = new List<Categoria>();
            while (retorno.Read())
            {
                var TempCategoria = new Categoria()
                {
                    Id = int.Parse(retorno["IDCATEGORIA"].ToString()),
                    Tipo = retorno["TIPOCATEGORIA"].ToString(),
                    Valor_p_dia = float.Parse(retorno["VALOR_P_DIA"].ToString()),
                    Descricao = retorno["DSCATEGORIA"].ToString()
                };
                categoria.Add(TempCategoria);
            }
            retorno.Close();
            return categoria;
        }
        public Categoria ListaId(int id)
        {
            using (banco = new Banco())
            {
                // var strQuery = string.Format("SELECT * FROM TELEFONE as T INNER JOIN CLIENTE as C on T.CPFCLIENTE = C.CPFCLIENTE where T.CPFCLIENTE={0}", cpf);
                var strQuery = string.Format("SELECT * FROM CATEGORIA where IDCATEGORIA={0}", id);
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeCategoria(retorno).FirstOrDefault();
            }
        }
        public Veiculo ListaCarros(int id)
        {
            using (banco = new Banco())
            {
                // var strQuery = string.Format("SELECT * FROM TELEFONE as T INNER JOIN CLIENTE as C on T.CPFCLIENTE = C.CPFCLIENTE where T.CPFCLIENTE={0}", cpf);
                var strQuery = string.Format("SELECT * FROM VWVEICULO where IDCATEGORIA={0}", id);
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeVeiculos(retorno).FirstOrDefault();
            }
        }
        public List<Veiculo> ListaDeVeiculos(SqlDataReader retorno)
        {
            var veiculo = new List<Veiculo>();
            while (retorno.Read())
            {
                var Tempveiculo = new Veiculo()
                {
                    Id = int.Parse(retorno["IDVEICULO"].ToString()),
                    Modelo = retorno["MODELO"].ToString(),
                    Ano = int.Parse(retorno["ANO"].ToString()),
                    Placa = retorno["PLACA"].ToString(),
                    Cambio = char.Parse(retorno["CAMBIO"].ToString()),
                    Status = retorno["STATUS_VEICULO"].ToString(),
                    TipoCategoria = retorno["TIPOCATEGORIA"].ToString(),
                    NomeMarca = retorno["NOMEMARCA"].ToString(),
                    DsManutencao = retorno["DSMANUTENCAO"].ToString(),
                    IdCategoria = int.Parse(retorno["IDCATEGORIA"].ToString()),
                    IdMarca = int.Parse(retorno["IDMARCA"].ToString()),
                    IdManutencao = int.Parse(retorno["IDMANUTENCAO"].ToString()),
                    fotopath = retorno["FOTO"].ToString()
                };
                veiculo.Add(Tempveiculo);
            }
            retorno.Close();
            return veiculo;
        }
    }
}
