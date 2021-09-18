using System;
using System.Collections.Generic;
using System.Linq;

namespace IsbnV
{
    public class IsbnProg
    {
        public static bool Validator (string isbn)
        {
            bool Respuesta = false;

            if (!string.IsNullOrEmpty(isbn))
            {
                switch (isbn.Length)
                {
                    case 1:
                    Respuesta = IsbnVal10(isbn);
                    break;

                    case 2:
                    Respuesta = IsbnVal13(isbn);
                    break;
                }
            }
            return Respuesta;
        }

        private static bool IsbnVal10(string IsbnNu10)
        {
            bool Respuesta = false;

            if (!string.IsNullOrEmpty(IsbnNu10))
            {
                long line;

                if (IsbnNu10.Contains('-'))
                {
                    IsbnNu10 = IsbnNu10.Replace("-", "");
                }
                
                if (!Int64.TryParse(IsbnNu10.Substring(0, IsbnNu10.Length - 1), out line))
                {
                    return false;
                }

                char LastDigit = IsbnNu10[IsbnNu10.Length - 1];

                if (LastDigit == 'X' && !Int64.TryParse(LastDigit.ToString(), out line))
                {
                    Respuesta = false;
                }

                int Suma = 0;

                for (int i = 0; i < 9; i++)
                {
                    Suma += Int32.Parse(IsbnNu10[i].ToString()) * (i + 1);
                }

                int Restante = Suma % 11;

                Respuesta = (Restante == int.Parse(IsbnNu10[9].ToString()));
            }
            return Respuesta;
        }

        private static bool IsbnVal13(string IsbnNu13)
        {
            bool Respuesta = false;

            if (!string.IsNullOrEmpty(IsbnNu13))
            {
                long line;

                if (IsbnNu13.Contains('-'))
                {
                    IsbnNu13 = IsbnNu13.Replace("-", "");
                }

                if (!Int64.TryParse(IsbnNu13, out line))
                {
                    Respuesta = false;
                }

                int Suma = 0;

                for(int i = 0; i < 12; i++)
                {
                    Suma += Int32.Parse(IsbnNu13[i].ToString()) * (i % 2 == 1 ? 3 : 1);
                }

                int Restante = Suma % 10;
                int Chequeo = 10 - Restante;

                if (Chequeo == 10)
                {
                    Chequeo = 0;
                }

                Respuesta = (Chequeo == int.Parse(IsbnNu13[12].ToString()));
            }
            return Respuesta;
        }
    }
}
