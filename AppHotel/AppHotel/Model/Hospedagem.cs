using System;
using System.Collections.Generic;
using System.Text;

namespace AppHotel.Model
{
    public class Hospedagem
    {
        int qtdeAdultos;
        Suite quartoEscolhido;

        public Suite QuartoEscolhido 
        {
            get => quartoEscolhido;
            set
            {
                quartoEscolhido = value ?? throw new Exception("Por favor, selecione um quarto para continuar.");
            }
        }

        public int QtdeAdultos
        {
            get => qtdeAdultos;
            set
            {
                if (value == 0)
                {
                    throw new Exception("Por favor, selecione a quantidade de adultos.");
                }

                qtdeAdultos = value;
            } 
        }

        public int QtdeCriancas { get; set; }

        public DateTime DataCheckIn { get; set; }

        public DateTime DataCheckOut { get; set; }

        public int Estadia => DataCheckOut.Subtract(DataCheckIn).Days;
        
        public double ValorTotal => ((QtdeAdultos * QuartoEscolhido.DiariaAdulto) + (QtdeCriancas * QuartoEscolhido.DiariaCrianca)) * Estadia;
    }
}
