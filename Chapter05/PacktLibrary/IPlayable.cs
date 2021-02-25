using static System.Console;

namespace Packt.Shared
{
    public interface Iplayable
    {
        void Play();

        void Pause();

        void Stop()// default interface implementation;
        {
            WriteLine("Defualt implementation of Stop.");
        }
    }
}