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

        public void setNumeroActivo(decimal numeroActivo)
        {
            this.numeroActivo = numeroActivo;
        }

        public string getNumeroPantalla()
        {            
            return Convert.ToString(this.numeroActivo);
        }

        public string getLogOperacion()
        {
            return this.log_operacion;
        }

        public void generarLogOperacion(string numeroSecundario)
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

        public void cancelar()
        {
            numeroActivo = 0;
            operacion = "";
            log_operacion = "";
        }

        #region Metodos de Operaciones

        public void calcular(decimal numeroSecundario)
        {
            generarLogOperacion(numeroSecundario.ToString());

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

        public string getPorcentagePorOperacion(string numConvertir)
        {
            string respuesta = "";
            if (numConvertir.Contains("."))
            {
                numConvertir = numConvertir.Remove(numConvertir.IndexOf("."), 1);
            }

            decimal numConvertido = Convert.ToDecimal($"0.{numConvertir}");

            if (operacion == "+" || operacion == "-")
            {
                respuesta = Convert.ToString(numeroActivo * numConvertido); 
            }
            else if (operacion == "*" || operacion == "/")
            {
                respuesta = Convert.ToString(numConvertido);
            }

            return respuesta;
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

        public void sumarMemoria(decimal numero)
        {
            memoria.sumarNumeroGuardado(numero);
        }

        public void restarMemoria(decimal numero)
        {
            memoria.restarNumeroGuardado(numero);
        }

        public void guardaMemoria(decimal numero)
        {
            memoria.guardarMemoria(numero);
        }

        public decimal llamarMemoria()
        {
            return memoria.getNumeroGuardado();
        }

        public void borrarMemoria()
        {
            memoria.borrarMemoria();
        }

        #endregion
    }
}
