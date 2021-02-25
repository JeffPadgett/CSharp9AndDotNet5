using System;

namespace Packt.Shared
{
    public class Thing
    {
        //sets object to whatever defult value it should be, if it is a stirng, it will be "", if it is an int it will be 0 etc;
        public object Data = default(object);

        public String Process(object input)
        {
            if (Data == input)
            {
                return "Data and input are the same";
            }
            else
            {
                return "Data and input are NOT the same";
            }
        }
    }
}