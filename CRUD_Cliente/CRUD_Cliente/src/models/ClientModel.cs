﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Cliente.src.models
{
    /// <summary>
    /// <para>Resumo: Classe responsável por representar tb_clients no banco</para>
    /// </summary>
    [Table("tb_clients")]
    public class ClientModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
    }
}