﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TemplateSevenSource3Dominio
{
    public class Funcionario
    {
        public int Id { get; set; }
        [RegularExpression(@"[a-zA-Z0-9]{3,15}", ErrorMessage = "Apenas letras e números mínimo 3 caracteres")]
        [DisplayName("Login")]
        public string Login { get; set; }
        [RegularExpression(@"[a-z A-Z]{3,50}", ErrorMessage = "Apenas letras para nomes,mínimo 3 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("Senha")]
        [Required(ErrorMessage = "A Senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Compare("Senha", ErrorMessage = "As senhas são diferentes")]
        [DataType(DataType.Password)]
        [DisplayName("Confirmar senha")]
        public string ConfirmarSenha { get; set; }
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        [DisplayName("ID Cargo")]
        public int IdCargo { get; set; }
        public string NomeCargo { get; set; }
    }
}