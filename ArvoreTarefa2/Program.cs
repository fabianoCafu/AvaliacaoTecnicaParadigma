namespace ArvoreTarefa2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nCenário 1°");
            
            int[] arrayCenario1 = { 3, 2, 1, 6, 0, 5 };
            Processamento.ProcessarCenario(arrayCenario1);

            Console.WriteLine("\nCenário 2° ");
           
            int[] arrayCenario2 = { 7, 5, 13, 9, 1, 6, 4 };
            Processamento.ProcessarCenario(arrayCenario2);
        }
    }
}
