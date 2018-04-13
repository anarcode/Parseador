namespace Interprete.Procesadores
{
    using Core;
    using Interfaces;
    using Programa.Core;
    using Programa.Instrucciones;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class ProcesadorDeApilaciónDeVariable : ProcesadorSucesible
    {
        IEvaluador _evaluador;

        readonly string EXPRESION = $@"{FORMATO_VALIDO_NOMBRE_DE_VARIABLE}";

        protected override string Expresión => EXPRESION;

        public ProcesadorDeApilaciónDeVariable(IRepositorioDeProcesadores repositorio, IEvaluador evaluador)
            : base(repositorio)
        {
            _evaluador = evaluador;
        }

        protected override bool ComprobaciónAdicional(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            return coincidencias[0].Index == 0 && cadena.Length == coincidencias[0].Length;
        }

        protected override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            string nombreDeVariable = coincidencias[0].Value;
            var variable = declaración.VariablesDeclaradas.Where(v => v.Nombre == nombreDeVariable).First();
            if(variable != null)
            {
                var instrucción = new ApilarDatoDesdeVariable(coincidencias[0].Value, cadena)
                {
                    Inicio = desplazamiento
                };

                _evaluador.TipoDeSalida = variable.Tipo;
                declaración.Instrucciones.Enqueue(instrucción);
            }
            else
            {
                //EXCEPCION: Variable no existe
            }
        }
    }
}