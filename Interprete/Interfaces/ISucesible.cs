namespace Interprete.Interfaces
{
    public interface ISucesible<in T>
    {
        void EstablecerSucesor(T sucesor);
    }
}