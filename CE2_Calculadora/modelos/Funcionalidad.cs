using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE2_Calculadora.modelos
{
    internal class Funcionalidad
    {

        private string log_operacion;
        
        private decimal numeroActivo;

        private string operacion;

        private Memoria memoria;

        public Funcionalidad(decimal numeroActivo)
        {
            this.numeroActivo = numeroActivo;
            this.log_operacion = "";
            this.operacion = "";
            this.memoria = new Memoria(0);
        }

        public string getNumeroPantalla()
        {            
            return Convert.ToString(this.numeroActivo);
        }

        public string getLogOperacion()
        {
            return this.log_operacion;
        }

        public void generarLogOperacion(decimal numeroSecundario)
        {
            this.log_operacion = $"{this.numeroActivo} {this.operacion} {numeroSecundario}"; 
        }

        public void setOperacion(string operacion)
        {
            this.operacion = operacion;            
        }

        public string getOperacion()
        {
            return operacion;
        }

        #region Metodos de Operaciones

        public void calcular(decimal numeroSecundario)
        {
            generarLogOperacion(numeroSecundario);

            switch(this.operacion)
            {
                case "+":
                    sumar(numeroSecundario);
                    break;
                case "-":
                    restar(numeroSecundario);
                    break;
                case "/":
                    dividir(numeroSecundario);
                    break;
                case "*":
                    multiplicar(numeroSecundario);
                    break;
                case "mod":
                    modulo(numeroSecundario);
                    break;                
            }
        }

        public void sumar(decimal numeroSecundario)
        {
            numeroActivo = numeroActivo + numeroSecundario;
        }

        public void restar(decimal numeroSecundario)
        {
            numeroActivo = numeroActivo - numeroSecundario;
        }

        public void dividir(decimal numeroSecundario)
        {
            numeroActivo = numeroActivo / numeroSecundario;
        }

        public void multiplicar(decimal numeroSecundario)
        {
            numeroActivo = numeroActivo * numeroSecundario;
        }

        public void modulo(decimal numeroSecundario)
        {
            numeroActivo = numeroActivo % numeroSecundario;
        }

        public void porcentaje()
        {
            
        }

        public void sumarMemoria()
        {
            memoria.sumarNumeroGuardado(numeroActivo);
        }

        public void restarMemoria()
        {
            memoria.restarNumeroGuardado(numeroActivo);
        }

        public void guardaMemoria()
        {
            memoria.guardarMemoria(numeroActivo);
        }

        public void llamarMemoria()
        {
            numeroActivo = memoria.getNumeroGuardado();
        }

        public void borrarMemoria()
        {
            memoria.borrarMemoria();
        }

        #endregion
    }
}
