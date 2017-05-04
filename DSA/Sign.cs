using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Numerics;
using System.Windows.Forms;

namespace DSA
{
    public class Sign
    {
        public BigInteger paramQ { get; set; }
        public BigInteger paramP { get; set; }
        /// <summary>
        /// Результат частного (p-1)/q
        /// </summary>
        public BigInteger paramT { get; set; }

        public BigInteger paramG { get; set; }

        /// <summary>
        /// Закрытый ключ
        /// </summary>
        private BigInteger paramX { get; set; }
        private BigInteger paramY { get; set; }

        public Sign(BigInteger q, BigInteger p)
        {
            paramQ = q;
            paramP = p;
            paramT = (p - BigInteger.One) / q;
            SetParamG();
            paramX = GetRandom(paramQ);
            paramY = BigInteger.ModPow(paramG, paramX, paramP);
        }

        /// <summary>
        /// Устанавливает рандомное значение заданного параметра, которое больше 0 и не превышает maxValue
        /// </summary>
        /// <param name="maxValue">Верхняя граница параметра</param>
        private BigInteger GetRandom(BigInteger maxValue)
        {
            Random rand = new Random();
            double tmp1 = rand.NextDouble();
            double tmp2 = rand.NextDouble();
            int tmp3 = rand.Next();

            BigInteger b1 = new BigInteger(UInt64.MaxValue * tmp1);
            BigInteger b2 = new BigInteger(UInt64.MaxValue * tmp2);
            BigInteger b3 = BigInteger.ModPow(10, tmp3, paramQ);
            BigInteger result = (b1 * b3 + b2) % (paramQ - 1);
            if (result == BigInteger.Zero) {
                return BigInteger.One;
            }
            return result;
        }
        private void SetParamG()
        {
            BigInteger h = BigInteger.One;
            do
            {
                h += BigInteger.One;
                paramG = BigInteger.ModPow(h, paramT, paramP);
            }
            while (paramG < 2);
        }

        public StringBuilder GenerateSign(string text)
        {

            BigInteger H = GetHashCode(text);
            BigInteger k;
            BigInteger r;
            BigInteger s;
            do
            {
                do
                {
                    k = GetRandom(paramQ);
                    r = BigInteger.ModPow(paramG, k, paramP) % paramQ;
                }
                while (r == BigInteger.Zero);

                s = (BigInteger.ModPow(k, paramQ - 2, paramQ) * ((H + paramX * r) % paramQ)) % paramQ;
            }
            while (s == BigInteger.Zero);

            StringBuilder SB = new StringBuilder();
            SB.AppendLine("r = " + r.ToString());
            SB.AppendLine("s = " + s.ToString());

            return SB;
        }
        public StringBuilder CheckSign(string text, string[] sign, ref Label message)
        {
            BigInteger r = BigInteger.Parse(sign[0].Substring(4));
            BigInteger s = BigInteger.Parse(sign[1].Substring(4));
            BigInteger H = GetHashCode(text);
           
            BigInteger w = BigInteger.ModPow(s, paramQ - 2, paramQ);
            BigInteger u1 = (H * w) % paramQ;
            BigInteger u2 = (r * w) % paramQ;

            BigInteger v1 = BigInteger.ModPow(paramG, u1, paramP);
            BigInteger v2 = BigInteger.ModPow(paramY, u2, paramP);
            BigInteger v3 = (v1*v2) % paramP;

            BigInteger v = v3 % paramQ;

            if (v == r)
            {
                message.Text = "Текст корректен";
                message.ForeColor = System.Drawing.Color.Blue;
                message.Visible = true;
            }
            else
            {
                message.Text = "Текст был изменен или неверно заданы параметры";
                message.ForeColor = System.Drawing.Color.Red;
                message.Visible = true;
            }
            return new StringBuilder("v = " + v.ToString());
        }
        
        private BigInteger GetHashCode(string text)
        {
            SHA256 hash = new SHA256Managed();
            byte[] hashBYTE = hash.ComputeHash(Encoding.Default.GetBytes(text));
            BigInteger hashINT = new BigInteger(hashBYTE);

            BigInteger result = hashINT & paramQ;
            return result;
        }
    }
}
 