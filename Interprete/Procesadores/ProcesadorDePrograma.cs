namespace Interprete.Procesadores
{
    using Core;
    using Interfaces;
    using Programa.Core;
    using System.Text.RegularExpressions;

    public class ProcesadorDePrograma : Procesador
    {
        const string
            NOMBRE_GRUPO_NOMBRE_DE_PROGRAMA = "nombreDePrograma",
            NOMBRE_GRUPO_CUERPO = "cuerpo",
            MENSAJE_ERROR = "Estructura de programa mal formada";

        readonly string
            EXPRESION = $"program{SEPARADORES}(?<{NOMBRE_GRUPO_NOMBRE_DE_PROGRAMA}>[{CARACTERES_NOMBRE_DE_PROGRAMA}]+){SEPARADORES}{{{SEPARADORES}(?<{NOMBRE_GRUPO_CUERPO}>[{CARACTERES_CUERPO_DE_PROGRAMA}]*){SEPARADORES}}}";

        protected override string Expresión => EXPRESION;

        IProcesador _procesadorDeCuerpoDeExpresiones;

        public ProcesadorDePrograma(IRepositorioDeProcesadores repositorio)
            : base(repositorio)
        {
            _procesadorDeCuerpoDeExpresiones = repositorio.ObtenerProcesadorDeCuerpoDeExpresiones();
        }

        protected override (bool, string) ComprobaciónAntesDeDelegar()
        {
            return (false, MENSAJE_ERROR);
        }

        protected override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            declaración.Nombre = coincidencias[0].Groups[NOMBRE_GRUPO_NOMBRE_DE_PROGRAMA].Value;
            string cuerpo = coincidencias[0].Groups[NOMBRE_GRUPO_CUERPO].Value;

            var procesadorDeFunciones = Repositorio.ObtenerProcesadorDeDeclaraciónDeFunción();

            try
            {
                procesadorDeFunciones.Procesar(cuerpo, declaración, coincidencias[0].Groups[NOMBRE_GRUPO_CUERPO].Index);

                foreach (var función in declaración.Funciones.Invertidas())
                {
                    desplazamiento += función.LongitudDeDeclaración;
                    cuerpo = cuerpo.Remove(función.InicioEnElCódigo, función.LongitudDeDeclaración);
                }

                //Si cuerpo no termina con ; sé que está mal
                if (!string.IsNullOrEmpty(cuerpo))
                {
                    _procesadorDeCuerpoDeExpresiones.Procesar(cuerpo, declaración, coincidencias[0].Groups[NOMBRE_GRUPO_CUERPO].Index + desplazamiento);

                    if (declaración.Instrucciones.Count == 0)
                    {
                        declaración.Correcto = false;

                        if (declaración.Error == null)
                        {
                            declaración.Error = new ErrorDeDeclaración(cuerpo, "Igual te falta un punto y coma...", coincidencias[0].Groups[NOMBRE_GRUPO_CUERPO].Index, coincidencias[0].Groups[NOMBRE_GRUPO_CUERPO].Length);
                        }
                    }
                }
                //Tengo que meterle una instrucción al útlimo } para la depuración (y a cada función lo mismo???)
            }
            catch (ErrorDeCompilación error)
            {
                declaración.Correcto = false;
                declaración.Error = error.ErrorDeDeclaración;
            }
        }
    }
}