using System;

namespace DataMatrixGS1CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int width = 0;
                int hight = 0;
                string dmContent = "";
                string fileName = "";
                if (args == null)
                    Console.WriteLine("DataMatrix(int width, int hight, string dmContent, string fileName)");
                else if (args.Length != 4)
                {
                    Console.WriteLine("4 parameters expected");
                    Console.WriteLine("DataMatrix(int width, int hight, string dmContent, string fileName)");
                }
                else
                {
                    width = int.Parse(args[0]);
                    hight = int.Parse(args[1]);
                    dmContent = args[2];
                    fileName = args[3];
                }

                DataMatrixGS1.DataMatrixGS1.generateDataMatrix(dmContent, width, hight, fileName);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
}
    }
}
