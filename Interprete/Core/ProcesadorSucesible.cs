namespace Interprete.Core
{
    using Interprete.Interfaces;
    using Programa.Core;
    using System;

    public abstract class ProcesadorSucesible : Procesador, IProcesadorSucesible
    {
        protected IProcesadorSucesible Sucesor { get; private set; }

        //protected override string Expresión => throw new System.NotImplementedException();

        protected ProcesadorSucesible(IRepositorioDeProcesadores repositorio) : base(repositorio)
        {
        }

        public void EstablecerSucesor(IProcesadorSucesible sucesor)
        {
            Sucesor = sucesor;
        }

        public override bool Procesar(string cadena, DeclaraciónDeContexto contexto, int desplazamiento)
        {
            if(base.Procesar(cadena, contexto, desplazamiento))
            {
                return true;
            }
            else
            {
                if (Sucesor != null)
                {
                    (bool ContinuarEjecución, string MensajeDeError) comprobación = ComprobaciónAntesDeDelegar();
                    if (comprobación.ContinuarEjecución)
                    {
                        return Sucesor.Procesar(cadena, contexto, desplazamiento);
                    }
                    else
                    {
                        throw new InvalidOperationException(comprobación.MensajeDeError);
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}