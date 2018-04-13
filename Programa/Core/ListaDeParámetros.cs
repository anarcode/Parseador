namespace Programa.Core
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class ListaDeParámetros : IEnumerable<Parámetro>
    {
        List<Parámetro> _parámetros;
        ReadOnlyCollection<Parámetro> _listaDelectura;

        public Parámetro this[int índice]
        {
            get
            {
                if(índice < _parámetros.Count)
                {
                    return _parámetros[índice];
                }
                return null;
            }
        }

        public int Total => _parámetros.Count;

        public ListaDeParámetros()
        {
            _parámetros = new List<Parámetro>();
            _listaDelectura = new ReadOnlyCollection<Parámetro>(_parámetros);
        }

        public void Añadir(Parámetro parámetro)
        {
            _parámetros.Add(parámetro);
        }

        public IEnumerator<Parámetro> GetEnumerator()
        {
            return _listaDelectura.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}