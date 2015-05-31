using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Logica
    {
        public static string[] normalizeString(string s1, string s2)
        {
            int num1 = s1.Length;
            int num2 = s2.Length;

            if (s1.Length > s2.Length)
            {
                for (int i = 0; i < (num1 - num2); i++)
                {
                    s2 = "0" + s2;
                }
            }
            else if (s1.Length < s2.Length)
            {
                for (int i = 0; i < (num2 - num1); i++)
                {
                    s1 = "0" + s1;
                }
            }
            string[] r = new string[] { s1, s2 };
            return r;
        }
        public static string Subtracao(string b1, string b2)
        {
            string s1 = (normalizeString(b1, b2))[0];
            string s2 = (normalizeString(b1, b2))[1];
            string result = "";

            s2 = s2.Replace('1', 'a');
            s2 = s2.Replace('0', '1');
            s2 = s2.Replace('a', '0');

            s2 = Soma(s2, "1");

            result = Soma(s1, s2);
            result = result.Remove(0, 1);
            return result;
        }   
        public static string Soma(string ele1, string ele2)
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
            return overflow + resultado;
        }
        public static string Multiplicacao(string s1, string s2)
        {
			string resultado = "0";
            string n = BinDec(s2);
            for (int i = 0; i < int.Parse(n); i++)
			{
				resultado = Soma(resultado,s1);
			}
			return resultado;
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

        public static string BinDec(string bin)
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
            return soma+"";
        }
        public static string letrasHexa(int d){

            switch (d)
            {
                case 10:
                    return "A";
                    break;
                case 11:
                    return "B";
                    break;
                case 12:
                    return "C";
                    break;
                case 13:
                    return "D";
                    break;
                case 14:
                    return "E";
                    break;
                case 15:
                    return "F";
                    break;
                default:
                    return d+"";
                    break;
            }
        }

        public static string BinHexa(string b) 
        {
            string d = BinDec(b);
            return DecHexa(int.Parse(d));
        }
        public static string DecHexa(int d)
        {
            int resto = d % 16;
            int result = (d - resto) / 16;

            if (d == 0)
            {
                return "";
            }
            else
            {
                return DecHexa(result) + letrasHexa(resto);
            }
            
        }
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
                return InverterString(num);
                
       }
            public static string Divisao(string s1, string s2)
            {
                string resultado = "0";

                if (int.Parse(s1) >= int.Parse(s2))
                {
                    for (int i = 1; i < int.MaxValue; i++)
                    {
                        string d = Multiplicacao(DecBin(i), s2.ToString());

                        if (int.Parse(d) > int.Parse(s1))
                        {
                            resultado = DecBin(i - 1);
                            return resultado;
                        }

                        if (int.Parse(d) == int.Parse(s1))
                        {
                            resultado = DecBin(i);
                            return resultado;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não é possível realizar essa conta pois o segundo número é maior que o primeiro");
                    return "";
                }
                return resultado;
            }
    }
}
