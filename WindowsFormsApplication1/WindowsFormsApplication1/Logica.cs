using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Logica
    {
        public static string[] normalizeString(string ele1, string ele2)
        {
            int num1 = ele1.Length;
            int num2 = ele2.Length;

            if (ele1.Length > ele2.Length)
            {
                for (int i = 0; i < (num1 - num2); i++)
                {
                    ele2 = "0" + ele2;
                }
            }
            else if (ele1.Length < ele2.Length)
            {
                for (int i = 0; i < (num2 - num1); i++)
                {
                    ele1 = "0" + ele1;
                }
            }

            string[] r = new string[] { ele1, ele2 };
            return r;
        }
        public static string binaryMenos(string ele1, string ele2)
        {
            //1- Normaliza
            string loan = "";
            string soma = "1";
            int somaCount = soma.Length;

            string troca0_b = (normalizeString(ele1, ele2))[1].Replace('0', 'b');
            string troca1_c = troca0_b.Replace('1', 'c');
            string trocab_1 = troca1_c.Replace('b', '1');
            string trocafinal = trocab_1.Replace('c', '0');
            int norma = trocafinal.Length;

            string result = "";

            if (trocafinal.Length > soma.Length)
            {
                for (int i = 0; i < (norma - somaCount); i++)
                {
                    soma = "0" + soma;
                }
            }
            for (int i = trocafinal.Length - 1; i >= 0; i--)
            {
                if (i == trocafinal.Length - 1)
                {
                    if (trocafinal[i].Equals('0') && soma[i].Equals('1')) result = '1' + result;
                    if (trocafinal[i].Equals('1') && soma[i].Equals('1'))
                    {
                        loan = "1";
                        result = "0" + result;
                    }
                }

                if (string.IsNullOrWhiteSpace(loan))
                {
                    if (trocafinal[i].Equals('0') && soma[i].Equals('0')) result = '0' + result;
                    if (trocafinal[i].Equals('1') && soma[i].Equals('0')) result = '1' + result;
                }

                else if (trocafinal[i].Equals('1') && soma[i].Equals('0'))
                {
                    loan = "1";
                    result = "0" + result;
                }

                else if (trocafinal[i].Equals('0') && soma[i].Equals('0'))
                {
                    loan = "";
                    result = "1" + result;
                }
            }

            string num3 = loan + result;
            soma1("11110", num3);
            return loan + result;
        }

        public static string soma1(string ele1, string ele2)
        {
            char[] h = (normalizeString(ele1, ele2))[0].ToCharArray();
            char[] s = (normalizeString(ele1, ele2))[1].ToCharArray();

            string overflow = "";
            string resultado = "";

            for (int i = h.Length - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(overflow))
                {
                    if (h[i].Equals('0') && s[i].Equals('0')) resultado = '0' + resultado;
                    if (h[i].Equals('0') && s[i].Equals('1')) resultado = '1' + resultado;
                    if (h[i].Equals('1') && s[i].Equals('0')) resultado = '1' + resultado;
                    if (h[i].Equals('1') && s[i].Equals('1'))
                    {
                        overflow = "1";
                        resultado = "0" + resultado;
                    }
                }
                else if ((h[i].Equals('1') && s[i].Equals('0')) || h[i].Equals('0') && s[i].Equals('1'))
                {
                    overflow = "1";
                    resultado = "0" + resultado;
                }
                else if ((h[i].Equals('0') && s[i].Equals('0')))
                {
                    overflow = "";
                    resultado = "1" + resultado;
                }
                else if (h[i].Equals('1') && s[i].Equals('1'))
                {
                    overflow = "1";
                    resultado = "1" + resultado;
                }
            }
            string num4 = overflow + resultado;
            string numfinal = num4.Substring(1, num4.Length - 1);

            Console.WriteLine(numfinal);
            return overflow + resultado;

        }

        public static string InverterString(string s){

            int tamanho = s.Length;

            char[] caract = new char[tamanho];

            for (int i = 0; i < tamanho; i++)
            {
                caract[i] = s[tamanho - 1 - i];
            }
            return new string(caract);
        }

        public static void BinDec(string bin)
        {
            int expoente = 0;
            int num;
            int soma = 0;
            string invertnumero = InverterString(bin);

            for (int i = 0; i < bin.Length; i++)
            {
                num = Convert.ToInt32(invertnumero.Substring(i, 1));
                soma += num * (int)(Math.Pow(2, expoente));
                expoente++;
            }
        }
        /*public static string DecHexa(int b)
        {
            string num = "";
            int dividendo = Convert.ToInt32(b);
            int q;
            string bin = "";
            int r;

            if (b == 0)
            {
                return "";
            }
            while (dividendo >= 1)
            {
                q = dividendo / 16;
                r = dividendo % 16;
                num += (dividendo % 16).ToString();
                dividendo = q;
            }
            for (int i = num.Length - 1; i >= 0; i--)
            {
                bin = bin + num[i];
            }
            return InverterString(bin);
        }*/
       public static string DecBin(int n)
        {
            string num = "";
            int dividendo = Convert.ToInt32(n);
            int q;

            if (n == 0)
            {
                return "";
            }
            while(dividendo >= 1)
            {
                    q = dividendo / 2;
                    num += (dividendo % 2).ToString();
                    dividendo = q;
            }   
                Console.WriteLine(InverterString(num));
                return InverterString(num);
                
       }
    }
}
