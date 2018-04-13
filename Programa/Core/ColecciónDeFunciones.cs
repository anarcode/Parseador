namespace Programa.Core
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ColecciónDeFunciones // : IEnumerable<Función>
    {
        Dictionary<string, Función> _funciones;

        public Función this[string nombre]
        {
            get
            {
                if (_funciones.ContainsKey(nombre))
                {
                    return _funciones[nombre];
                }
                return null;
            }
        }

        public ColecciónDeFunciones()
        {
            _funciones = new Dictionary<string, Función>();
        }

        //public IEnumerator<Función> GetEnumerator()
        //{
        //    return _funciones.Values.GetEnumerator();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new System.NotImplementedException();
        //}

        public void Añadir(Función función)
        {
            if (!_funciones.ContainsKey(función.Nombre))
            {
                _funciones.Add(función.Nombre, función);
            }
        }

        public IEnumerable<Función> Invertidas()
        {
            return _funciones.Values
                .OrderByDescending(f => f.InicioEnElCódigo)
                .AsEnumerable();
        }
    }
}