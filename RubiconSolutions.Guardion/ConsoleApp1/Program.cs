using RubiconSolutions.Guardion.Core.Attributes.Marker;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class User
    {
        [Guardion]
        public string? Name { get; set; }
    }
}
