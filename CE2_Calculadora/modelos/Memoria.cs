using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE2_Calculadora.modelos
{
    internal class Memoria
    {
        private decimal numeroGuardado;

        public Memoria(decimal numeroGuardado)
        {
            this.numeroGuardado = numeroGuardado;
        }

        public void guardarMemoria(decimal numero)
        {
            this.numeroGuardado = numero;
        }

        public void sumarNumeroGuardado(decimal numero)
        {
            this.numeroGuardado += numero;
        }

        public void restarNumeroGuardado(decimal numero)
        {
            this.numeroGuardado -= numero;
        }        

        public decimal getNumeroGuardado()
        {
            return this.numeroGuardado;
        }

        public void borrarMemoria()
        {
            numeroGuardado = 0;
        }
    }
}
