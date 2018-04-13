namespace Interprete.Core
{
    using Interprete.Interfaces;
    using Interprete.Procesadores;
    using Programa.Interfaces;
    using System;
    using System.Collections.Generic;

    public class RepositorioDeProcesadores : IRepositorioDeProcesadores
    {
        ILenguaje _lenguaje;
        readonly Dictionary<string, IProcesadorSucesible> _procesadoresDeVariablesTipados;

        public RepositorioDeProcesadores(ILenguaje lenguaje)
        {
            _lenguaje = lenguaje;
            _procesadoresDeVariablesTipados = new Dictionary<string, IProcesadorSucesible>
            {
                { "string", new ProcesadorDeDeclaraciónDeString(_lenguaje, this) },
                { _lenguaje.NombreTipoEntero , new ProcesadorDeDeclaraciónDeInt(_lenguaje, this) }
            };
        }

        public IProcesador ObtenerProcesadorDeCuerpoDeExpresiones()
        {
            return new ProcesadorDeCuerpoDeExpresiones(new ManejadorDeProcesadores(this, null));
        }

        public IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeVariable()
        {
            return new ProcesadorDeDeclaraciónDeVariable(_lenguaje, this);
        }

        public IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeFunción()
        {
            return new ProcesadorDeDeclaraciónDeFunción(this, _lenguaje);
        }

        public IProcesador ObtenerProcesadorDeDeclaraciónDeParámetros()
        {
            return new ProcesadorDeDeclaraciónDeParámetros(_lenguaje, this);
        }

        public IProcesadorSucesible ObtenerProcesadorDeAsignación()
        {
            return new ProcesadorDeAsignación(this);
        }

        public IEvaluador ObtenerProcesadorDeEvaluación()
        {
            return new ProcesadorDeEvaluación(this);
        }

        public IProcesadorSucesible ObtenerProcesadorDeLiteralInt(IEvaluador evaluador)
        {
            return new ProcesadorDeLiteralInt(_lenguaje, this, evaluador);
        }

        public IProcesadorSucesible ObtenerProcesadorDeLiteralString(IEvaluador evaluador)
        {
            return new ProcesadorDeLiteralString(_lenguaje, this, evaluador);
        }

        public IProcesadorSucesible ObtenerProcesadorDeLiteralBool(IEvaluador evaluador)
        {
            return new ProcesadorDeLiteralBool(_lenguaje, this, evaluador);
        }

        public IProcesadorSucesible ObtenerProcesadorDeApilaciónDeVariable(IEvaluador evaluador)
        {
            return new ProcesadorDeApilaciónDeVariable(this, evaluador);
        }

        public IProcesadorSucesible ObtenerProcesadorDeBucleFor()
        {
            return new ProcesadorDeBucleFor(new ManejadorDeDeclaradorDeVariables(this));
        }

        public IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeVariableTipada(string tipo)
        {
            if (_procesadoresDeVariablesTipados.ContainsKey(tipo))
            {
                return _procesadoresDeVariablesTipados[tipo];
            }

            throw new InvalidOperationException("Declaración de variable un poco mierder.");
        }

        public IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeString()
        {
            return new ProcesadorDeDeclaraciónDeString(_lenguaje, this);
        }

        public IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeParámetroString()
        {
            return new ProcesadorDeDeclaraciónDeParámetroString(_lenguaje, this);
        }

        public IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeInt()
        {
            return new ProcesadorDeDeclaraciónDeInt(_lenguaje, this);
        }

        public IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeParámetroInt()
        {
            return new ProcesadorDeDeclaraciónDeParámetroInt(_lenguaje, this);
        }

        public IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeBool()
        {
            return new ProcesadorDeDeclaraciónDeBool(_lenguaje, this);
        }

        public IProcesadorSucesible ObtenerProcesadorDeDeclaraciónDeParámetroBool()
        {
            return new ProcesadorDeDeclaraciónDeParámetroBool(_lenguaje, this);
        }

        public IProcesadorSucesible ObtenerProcesadorDeLlamadaFunción(IEvaluador evaluador)
        {
            return new ProcesadorDeLlamadaFunción(this, evaluador);
        }

        public IProcesadorSucesible ObtenerProcesadorDeRetornoDeValor()
        {
            return new ProcesadorDeRetornoDeValor(this);
        }

        public IProcesadorSucesible ObtenerProcesadorDeTipoDeRetornoInt(IEvaluador evaluador)
        {
            return new ProcesadorDeTipoDeRetornoInt(_lenguaje, this, evaluador);
        }

        public IProcesadorSucesible ObtenerProcesadorDeTipoDeRetornoString(IEvaluador evaluador)
        {
            return new ProcesadorDeTipoDeRetornoString(_lenguaje, this, evaluador);
        }

        public IProcesadorSucesible ObtenerProcesadorDeTipoDeRetornoBool(IEvaluador evaluador)
        {
            return new ProcesadorDeTipoDeRetornoBool(_lenguaje, this, evaluador);
        }
    }
}