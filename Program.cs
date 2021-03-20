using System;
using System.Globalization;

namespace Neural
{
    class Program
    {
        static void Main(string[] args)
        {     
            
             /* Exemplo de Matriz
             * 
             * 8 linhas , 4 colunas
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


          

            int epoca = 1;
            int i;
            int y; 
            int contapesoalterado = 0;
            double calculo = 0;       
            bool naoaprendeu = true;
            bool informapeso = true;
            
            Console.Write("Informe a quantidades de elementos  : ");
            int elementos = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Informe a quantidades de conjuntos do elementos  : ");
            int conjuntoselementos = Convert.ToInt16(Console.ReadLine());
            double[] matrizpeso = new double[conjuntoselementos-1];  // 3 - 1 = 2   0  1 
            int[,] matriz = new int[elementos, conjuntoselementos] ;
            int[] matrizdesejada = new int[elementos];


            Console.WriteLine();

            Console.Write("Informe a nível de aprendizagem (n) : ");
            double n = Convert.ToDouble(Console.ReadLine());

            for (int e=0; e<elementos; e++)
            {
                for (int ce = 0; ce < conjuntoselementos; ce++)
                {
                    if (informapeso)
                    {
                        for (int ip=0; ip < conjuntoselementos-1; ip++)
                        {
                            Console.WriteLine("Informe o valor de peso W [{0}]  = ", ip + 1);
                            matrizpeso[ip] = Convert.ToDouble(Console.ReadLine());

                        }
                        informapeso = false;
                    }

                    if ((ce + 1) == conjuntoselementos)
                    {
                        Console.WriteLine("Informe o valor do desejado do elemento [{0}]  = ", e + 1);
                        matriz[e, ce] = Convert.ToInt16(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("Informe o valor do elemento [{0}] x{1} = ", e + 1, ce + 1);
                        matriz[e, ce] = Convert.ToInt16(Console.ReadLine());
                    }
                }               
            }

            // Listar Matrizes

            for (int m = 0; m < elementos; m++)
            {
                Console.WriteLine(" Elemento [{0}] :", m + 1);
                for (int cm = 0; cm < conjuntoselementos; cm++)
                {
                    if ((cm + 1) == conjuntoselementos)
                    {
                        Console.Write(" d{0} [ {1} ]", cm + 1, matriz[m, cm]);
                    }
                    else
                    {
                        Console.Write(" x{0} [ {1} ]", cm + 1 , matriz[m,cm]);  
                    }                                    
                }
               
            }

            // Matriz Desejada de X (elementos)

            for (int de=0; de < elementos; de++)
            {               
                matrizdesejada[de] = matriz[de, conjuntoselementos - 1];  // 0 2  {  0 , 0 , [0] }              
            }

            // Listar Matriz Desejada

            Console.WriteLine("Listagem de Matrizes Desejadas");

            for (int lmd=0; lmd < elementos; lmd++)
            {
                Console.WriteLine("Matriz Desejada do elemento X{0} é {1} ",lmd+1,matrizdesejada[lmd]);
            }


            while (naoaprendeu) 
            {               
              
                Console.WriteLine();
                System.Console.WriteLine("Epoca : " + epoca);
                for (i = 0; i < elementos; i++)
                {
                   

                    int[] matrizcalculo = new int[conjuntoselementos-1];  // 3 -1 = 2 ->  x 1 e x 2 

                    for (int c=0; c < matrizcalculo.Length-1; c++)  //  2 - 1  = 1 ->  0..1  2 sai do loop
                    {                                              
                        matrizcalculo[c] = matriz[i, c];
                    }


                    Console.WriteLine("-------------------------------------------");

                    calculo = 0; 
                    for (int ci=0; ci < conjuntoselementos-1; ci++ )
                    {
                        calculo += ((matriz[i, ci] * matrizpeso[ci]));
                        Console.WriteLine(" X"+(i+1)+"("+matriz[i,ci]+")  x W"+(ci+1)+"("+ matrizpeso[ci].ToString("f2")+")");  //+ " x W{1}(" + matrizpeso[1].ToString("f2") + ")", i + 1, 1);

                        //    Console.WriteLine(" X{0}(" + matriz[i, ci] + ")" + " x W{1}(" + matrizpeso[ci].ToString("f2") + ")",ci+1,ci+1);
                    }


                    if (calculo <= 1)
                        y = 0;
                        else
                        y = 1;

                        if (y != matrizdesejada[i]) // Altera peso 
                        {
                           Console.WriteLine("Alterou peso : y = {0}  d={1} ", y, matrizdesejada[i]);

                     
                            for (int mp = 0; mp < matrizpeso.Length; mp++)  // 0 1 2 
                                {
                                    var w = Convert.ToDouble(matrizpeso[mp]);
                                    var dx = matrizdesejada[i]; 
                                    var ex = matriz[i, mp];
                                    matrizpeso[mp] = w + n * (dx - y) * ex;
                                }

                                for (int nc=0; nc < matrizpeso.Length; nc++)
                                {
                                   Console.WriteLine(" Peso W{0} = {1}", (nc + 1), matrizpeso[nc].ToString("f2"));
                                }
                                Console.WriteLine();
                        
                                contapesoalterado++;                           
                            }

                    Console.WriteLine(" Total Soma Elementos X{0} = {1}", i + 1, calculo.ToString("f2"));


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

            Console.WriteLine("Total Epocas : " + epoca);
            for (int nc = 0; nc < matrizpeso.Length; nc++)
            {
                Console.WriteLine(" Peso W{0} atualizado = {1}", (nc + 1), matrizpeso[nc].ToString("f2"));
            }
            Console.WriteLine("Valor de n : " + n.ToString("f2"));

            Console.ReadKey();
        }
    }
}
