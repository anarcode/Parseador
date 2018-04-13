namespace Programa.Instrucciones
{
    using Programa.Core;
    using System.Collections.Generic;

    public class LlamadaAFunciónNativa : Instrucción
    {
        string _nombre;

        //public Queue<string> Parámetros { get; set; }

        public LlamadaAFunciónNativa(string nombreDeFunción, string valor) : base(valor)
        {
            _nombre = nombreDeFunción;
            //Parámetros = parámetros;
        }

        public override void Ejecutar(ContextoDePrograma contexto)
        {
            var función = contexto.Declaración.FuncionesNativas[_nombre];
            var contextoDeFunción = new ContextoDePrograma(función.Clonar());
            if (función != null)
            {
                //Queue<string> cola = new Queue<string>(Parámetros);
                foreach (var parámetro in función.Parámetros)
                {
                    contextoDeFunción.Variables.Add(new Variable
                    {
                        Tipo = parámetro.Tipo,
                        Nombre = parámetro.Nombre,
                        Valor = contexto.DesapilarDato() //cola.Dequeue()
                    });
                }
            }

            while (contextoDeFunción.Declaración.Instrucciones.Count > 0)
            {
                var instrucción = contextoDeFunción.Declaración.Instrucciones.Dequeue();
                instrucción.Ejecutar(contextoDeFunción);
            }

            contexto.ValorDeRetorno = contextoDeFunción.ValorDeRetorno;
        }

        protected override Instrucción Clonar(string valor)
        {
            return new LlamadaAFunciónNativa(_nombre, valor)
            {
                Inicio = Inicio
            };
        }
    }
}