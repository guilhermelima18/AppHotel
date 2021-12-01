using System;
using System.Collections.Generic;
using System.Text;

namespace AppHotel.Model
{
    public class Hospedagem
    {
        public Suite QuartoEscolhido { get; set; }
        public int QtdeAdultos { get; set; }
        public int QtdeCriancas { get; set; }
        public DateTime DataCheckIn
        {
            get; set;
        }
        public DateTime DataCheckOut
        {
            get; set;
        }
        public int Estadia
        {
            get => DataCheckOut.Subtract(DataCheckIn).Days;
        }
        public double ValorTotal
        {
            get => ((QtdeAdultos * QuartoEscolhido.DiariaAdulto) + (QtdeCriancas * QuartoEscolhido.DiariaCrianca)) * Estadia;
        }
    }
}
