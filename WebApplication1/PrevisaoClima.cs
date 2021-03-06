//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    public partial class PrevisaoClima
    {
        public int Id { get; set; }
        public int CidadeId { get; set; }
        public System.DateTime DataPrevisao { get; set; }
        public string Clima { get; set; }

        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public Nullable<decimal> temperaturaMinima { get; set; }

        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public Nullable<decimal> temperaturaMaxima { get; set; }

        public virtual Cidade Cidade { get; set; }

        public string DiaSemana 
        {
            get
            { 
                return new Funcoes().RetornaDiaSemana(DataPrevisao);
            } 
        }
    }

    public class Funcoes
    {
        public string RetornaDiaSemana(DateTime _data)
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            return culture.TextInfo.ToTitleCase(dtfi.GetDayName(_data.DayOfWeek));
        }
    }

}
