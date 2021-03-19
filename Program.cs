using System;
using System.Globalization;

namespace Neural
{
    class Program
    {
        static void Main(string[] args)
        {     
            
            int[,] matriz = new int[8, 4];
            var linhas = 8;
            double w1 = 1;
            double w2 = -1;
            double w3 = -1;
            double n = 0.2;
            double y = 0;

            int epoca = 1;
            double calculo;
            int contapesoalterado = 0;
            bool naoaprendeu = true;
            int i;


            /* 8 linhas , 4 colunas
             *  ------------------------
             *      | x1 | x2 | x3 | d |
             *      --------------------
             *  e1  |  0 |  0 |  0 | 0 |
             *  e2  |  0 |  0 |  1 | 0 |
             *  e3  |  0 |  1 |  0 | 0 |
             *  e4  |  0 |  1 |  1 | 1 |
             *  e5  |  1 |  0 |  0 | 1 |
             *  e6  |  1 |  0 |  1 | 1 |    
             *  e7  |  1 |  1 |  0 | 1 |
             *  e8  |  1 |  1 |  1 | 1 |
             *    -------------------- 
             * 
             */

            // linha 1 - e1
            matriz[0,0] = 0;  // x1
            matriz[0,1] = 0;  // x2
            matriz[0,2] = 0;  // x3
            matriz[0,3] = 0;  // d


            // linha 2
            matriz[1, 0] = 0;  // x1
            matriz[1, 1] = 0;  // x2
            matriz[1, 2] = 1;  // x3
            matriz[1, 3] = 0;  // d

            // linha 3
            matriz[2, 0] = 0;  // x1
            matriz[2, 1] = 1;  // x2
            matriz[2, 2] = 0;  // x3
            matriz[2, 3] = 0;  // d

            // linha 4 
            matriz[3, 0] = 0;  // x1
            matriz[3, 1] = 1;  // x2
            matriz[3, 2] = 1;  // x3
            matriz[3, 3] = 1;  // d

            // linha 5 
            matriz[4, 0] = 1;  // x1
            matriz[4, 1] = 0;  // x2
            matriz[4, 2] = 0;  // x3
            matriz[4, 3] = 1;  // d

            // linha 6 
            matriz[5, 0] = 1;  // x1
            matriz[5, 1] = 0;  // x2
            matriz[5, 2] = 1;  // x3
            matriz[5, 3] = 1;  // d

            // linha 7
            matriz[6, 0] = 1;  // x1
            matriz[6, 1] = 1;  // x2
            matriz[6, 2] = 0;  // x3
            matriz[6, 3] = 1;  // d

            // linha 8 
            matriz[7, 0] = 1;  // x1
            matriz[7, 1] = 1;  // x2
            matriz[7, 2] = 1;  // x3
            matriz[7, 3] = 1;  // d
                      
                  
            while (naoaprendeu)
            {
                System.Console.WriteLine("Epoca : " + epoca);
                for (i = 0; i < linhas; i++)
                {
                   if (i == 5)
                    {
                        naoaprendeu = true;
                        break;

                    }
                    var x1 = matriz[i, 0];
                    var x2 = matriz[i, 1];
                    var x3 = matriz[i, 2];
                    var d = matriz[i, 3];

                    calculo = ((x1 * w1) + (x2 * w2) + (x3 * w3));
                  
                    System.Console.WriteLine(" X1(" + matriz[i, 0] + ")" + " x W1(" + w1.ToString("f2") + ")" + " + " + "X2(" + matriz[i, 1] + ")" + " x W2(" + w2.ToString("f2") + ") + "+"X3(" + matriz[i, 2] + ")" + " x W3(" + w3.ToString("f2") + ") = " +calculo.ToString("N2"));

                    if (calculo <= 1)
                        y = 0;
                        else
                        y = 1;

                        if (y != d)  // se y diferente de d atualiza peso
                        {                      

                        w1 = (float)((w1) + n * (d - y) * x1);
                        w2 = (float)((w2) + n * (d - y) * x2);
                        w3 = (float)((w3) + n * (d - y) * x3);

                        contapesoalterado++;
                        System.Console.WriteLine("Altera peso : y = "+y+ " d="+d); 
                        }                    
                }
                if (contapesoalterado > 0)
                {
                    naoaprendeu = true;
                    epoca++;
                }
                else
                {
                    naoaprendeu = false;
                }
                contapesoalterado = 0; 
                
                i = 0;               
                
            }


            System.Console.WriteLine("Total Epocas : " + epoca);
            System.Console.WriteLine("Total alteracao de peso : " + contapesoalterado);
            System.Console.WriteLine("Valor de W1 : " + w1.ToString("f2"));
            System.Console.WriteLine("Valor de W2 : " + w2.ToString("f2"));
            System.Console.WriteLine("Valor de W3 : " + w3.ToString("f2"));
            System.Console.WriteLine("Valor de n : " + n.ToString("f2"));

        }
    }
}
