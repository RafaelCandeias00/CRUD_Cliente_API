using CRUD_Cliente.src.models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Cliente.src.dto
{
    /// <summary>
    /// <para>Resumo: Classe responsável para transportar um cliente para registro</para>
    /// <para>Criado por: Rafael Candeias</para>
    /// </summary>
    public class NewClientDTO
    {
        #region Attributes
        [Required, StringLength(30)]
        public string Nome { get; set; }

        [Required, StringLength(11)]
        public string CPF { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataNasciemento { get; set; }

        [Required]
        public Sexo Sexo { get; set; }

        [Required, StringLength(50)]
        public string Estado { get; set; }

        [Required, StringLength(50)]
        public string Cidade { get; set; }
        #endregion

        #region Constructor
        public NewClientDTO(string nome, string cPF, DateTime dataNasciemento, Sexo sexo, string estado, string cidade)
        {
            Nome = nome;
            CPF = cPF;
            DataNasciemento = dataNasciemento;
            Sexo = sexo;
            Estado = estado;
            Cidade = cidade;
        }
        #endregion
    }

    /// <summary>
    /// <para>Resumo: Classe responsável para transportar um cliente para atualizar</para>
    /// <para>Criado por: Rafael Candeias</para>
    /// </summary>
    public class UpdateClientDTO
    {
        #region Attributes
        [Required]
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Nome { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataNasciemento { get; set; }

        [Required]
        public Sexo Sexo { get; set; }

        [Required, StringLength(50)]
        public string Estado { get; set; }

        [Required, StringLength(50)]
        public string Cidade { get; set; }
        #endregion

        #region Constructor
        public UpdateClientDTO(string nome, DateTime dataNasciemento, Sexo sexo, string estado, string cidade)
        {
            Nome = nome;
            DataNasciemento = dataNasciemento;
            Sexo = sexo;
            Estado = estado;
            Cidade = cidade;
        }
        #endregion
    }
}
