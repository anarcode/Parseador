namespace Interprete.Procesadores
{
    using Interprete.Core;
    using Interprete.Interfaces;
    using Programa.Core;
    using Programa.Interfaces;
    using System.Text.RegularExpressions;
    using System.Linq;
    using Programa.Instrucciones;

    public abstract class ProcesadorDeDeclaración : ProcesadorSucesible
    {
        const string
            ERROR_VARIABLE_EXISTENTE = "Ya existe una variable con ese nombre",
            ERROR_DECLARACION_SIN_VALOR = "Que se te olvida poner un valor, tontopollas!!",
            ERROR_TIPO_INVALIDO = "El valor no es válido para un {0}!!";

        protected const string
            NOMBRE_GRUPO_NOMBRE_DE_VARIABLE = "nombreDeVariable",
            NOMBRE_GRUPO_VALOR_DE_VARIABLE = "valorDeVariable";

        Match _coincidencia;
        IEvaluador _evaluador;

        protected ILenguaje Lenguaje { get; private set; }

        protected ITipo TipoDeVariable { get; private set; }

        protected string NombreDeVariable => _coincidencia.Groups[NOMBRE_GRUPO_NOMBRE_DE_VARIABLE].Value;

        protected string ValorDeVariable { get; private set; }

        protected ProcesadorDeDeclaración(ILenguaje lenguaje, IRepositorioDeProcesadores repositorio)
            : base(repositorio)
        {
            Lenguaje = lenguaje;
            _evaluador = new ProcesadorDeEvaluación(Repositorio);
        }

        protected abstract ITipo CrearTipo();

        protected abstract void CrearComportamiento(string cadena, DeclaraciónDeContexto contexto, int desplazamiento);

        protected override bool ComprobaciónAdicional(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            return coincidencias[0].Index == 0; //No está al principio, asi que pasa algo raro
        }

        protected sealed override void ProcesarCadena(string cadena, MatchCollection coincidencias, DeclaraciónDeContexto declaración, int desplazamiento)
        {
            _coincidencia = coincidencias[0];
            TipoDeVariable = CrearTipo();

            if (cadena.Length != _coincidencia.Value.Length)
            {
                throw new ErrorDeCompilación(
                    new ErrorDeDeclaración(
                        cadena,
                        string.Format(ERROR_TIPO_INVALIDO, TipoDeVariable.Nombre),
                        coincidencias[0].Index + desplazamiento,
                        cadena.Length));
            }

            if (declaración.VariablesDeclaradas.Where(v => v.Nombre == NombreDeVariable).Count() > 0)
            {
                throw new ErrorDeCompilación(
                    new ErrorDeDeclaración(
                        cadena,
                        ERROR_VARIABLE_EXISTENTE,
                        coincidencias[0].Index + desplazamiento,
                        cadena.Length));
            }

            var valorDeVariable = _coincidencia.Groups[NOMBRE_GRUPO_VALOR_DE_VARIABLE];
            if (string.IsNullOrEmpty(valorDeVariable.Value))
            {
                if (cadena.Contains(Lenguaje.OperadorDeAsignación))
                {
                    throw new ErrorDeCompilación(
                        new ErrorDeDeclaración(
                            cadena,
                            ERROR_DECLARACION_SIN_VALOR,
                            coincidencias[0].Index + desplazamiento,
                            cadena.Length));
                }
                //else
                //{
                //    var instrucción = new ApilarDato(TipoDeVariable.ValorPorDefecto, cadena)
                //    {
                //        Inicio = desplazamiento
                //    };
                //    declaración.Instrucciones.Enqueue(instrucción);
                //}
            }
            else
            {
                _evaluador.Procesar(valorDeVariable.Value, declaración, desplazamiento + valorDeVariable.Index);
                if (TipoDeVariable.Nombre != _evaluador.TipoDeSalida.Nombre)
                {
                    string mensaje = string.Format(ERROR_TIPO_INVALIDO, TipoDeVariable.Nombre);
                    throw new ErrorDeCompilación(
                        new ErrorDeDeclaración(
                            cadena,
                            mensaje,
                            coincidencias[0].Index + desplazamiento,
                            cadena.Length));
                }
            }

            CrearComportamiento(coincidencias[0].Value, declaración, desplazamiento);

            if (!string.IsNullOrEmpty(valorDeVariable.Value))
            {
                var cargarValorEnVariable = new CargarDatoEnVariable(NombreDeVariable, cadena)
                {
                    Inicio = desplazamiento
                };
                declaración.Instrucciones.Enqueue(cargarValorEnVariable);
            }
        }
    }
}