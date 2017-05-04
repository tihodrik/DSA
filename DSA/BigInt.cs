using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA
{
    public class BigInt
    {
        public List<int> number { get; set; }
        public int Count
        {
            get
            {
                return number.Count;
            }
        }
        private bool negative;
        private int p;

        public static BigInt zero = new BigInt(0);
        public static BigInt one = new BigInt(1);
        public static BigInt two = new BigInt(2);

        public BigInt()
        {
            number = new List<int>();
            negative = false;
        }
        public BigInt(int num)
        {
            if (num < 0)
            {
                negative = true;
                num *= -1;
            }
            else
            {
                negative = false;
            }
            number = new List<int>();

            string numSTR = num.ToString();
            int count = numSTR.Count();

            for (int i = 0; i < count; i++)
            {
                number.Insert(0,numSTR[i]-'0');
            }
        }
        public BigInt(string num)
        {
            int index = 0;
            while (num[index] < '1' && num[index] > '9')
            {
                index++;
            }
            if (index > 0 && num[index-1] == '-')
            {
                negative = true;
            }
            number = new List<int>();
            int count = num.Count();
            for (int i = index; i < count; i++)
            {
                number.Insert(0, num[i]-'0');
            }
        }
        /// <summary>
        /// Лист сформирован в прямом порядке
        /// </summary>
        /// <param name="num">Ьолтшое целое число</param>
        /// <param name="neg">Знак числа</param>
        public BigInt(List<int> num, bool neg)
        {
            int count = num.Count;
                        
            number = new List<int>();
            for (int i = 0; i < count; i++)
            {
                number.Insert(0, num[count - i - 1]);
            }

            negative = neg;
        }
        public BigInt(BigInt num)
        {
            int count = num.Count;
            
            number = new List<int>();
            for (int i = 0; i < count; i++)
            {
                number.Add(num[i]);
            }

            negative = num.negative;
        }
        public BigInt(uint num)
        {
            negative = false;
            string n = num.ToString();

            number = new List<int>();

            string numSTR = num.ToString();
            int count = numSTR.Count();

            for (int i = 0; i < count; i++)
            {
                number.Insert(0, numSTR[i] - '0');
            }
        }
        
        // Итератор
        public int this[int i]{
            get
            {
                return number[i];
            }
            set
            {
                number[i] = value;
            }

        }
        /// <summary>
        /// Добавление числа на место старшего разряда (т.е. в конец листа)
        /// </summary>
        /// <param name="n">з</param>
        private void AddValue(int n)
        {
            number.Add(n);
        }
        private BigInt GetRange(int begin, int count)
        {
            return new BigInt(number.GetRange(begin, count), false);
        }
        /// <summary>
        /// Вставка цифры в произвольный разряд числа
        /// </summary>
        /// <param name="index">Позиция вставки (0 - младший разряд, count-1 - старший разряд)</param>
        /// <param name="item">Цифра для вставки</param>
        private void Insert(int index, int item)
        {
            number.Insert(index, item);
        }

        // Сумма больших чисел
        public static BigInt operator + (BigInt A, BigInt B)
        {
            // А < B
            if (A.negative && !B.negative)
            {
                BigInt tmpA = new BigInt(A);
                tmpA.negative = false;

                return B - tmpA;
            }
            // B < A
            if (!A.negative && B.negative)
            {
                BigInt tmpB = new BigInt(B);
                tmpB.negative = false;

                return A - tmpB;
            }

            RemoveNulls(A);
            RemoveNulls(B);

            int count = A.Count;
            if (B.Count > count)
            {
                count = B.Count;
                AddNulls(A, count);
            }
            else
            {
                if (B.Count < count)
                {
                    AddNulls(B, count);
                }
            }

            BigInt result = new BigInt();
            if (A.negative && B.negative)
            {
                result.negative = true;
            }

            bool nextBit = false;

            for (int i = 0; i < count; i++)
            {
                if (nextBit)
                {
                    result.AddValue((A[i] + B[i] + 1) % 10);
                    nextBit = false;

                    if ((A[i] + B[i] + 1) / 10 > 0)
                    {
                        nextBit = true;
                    }
                }
                else
                {
                    result.AddValue((A[i] + B[i]) % 10);
                    if ((A[i] + B[i]) / 10 > 0)
                    {
                        nextBit = true;
                    }
                }
            }
            if (nextBit)
            {
                result.AddValue(1);
            }

            return result;
        }
        public static BigInt operator +(BigInt A, int B)
        {
            BigInt tmpB = new BigInt(B);
            return A + B;
        }
        // Разность больших чисел
        public static BigInt operator - (BigInt A, BigInt B)
        {
            BigInt tmpA = new BigInt(A);
            BigInt tmpB = new BigInt(B);

            RemoveNulls(tmpA);
            RemoveNulls(tmpB);

            BigInt result;

        // Условия по знаку

            // (-A) - (-B)
            if (tmpA.negative && tmpB.negative) {
                tmpA.negative = false;
                tmpB.negative = false;

                return tmpB - tmpA;
            }
            // A - (-B)
            if (!tmpA.negative && tmpB.negative) {
                tmpB.negative = false;

                return A + tmpB;
            }
            // (-A) - B
            if (tmpA.negative && !tmpB.negative)
            {               
                tmpA.negative = false;
                tmpB.negative = false;
                
                result = tmpA + tmpB;
                result.negative = true;
                
                return result;
            }

         // Условия по величине
            if (tmpA == tmpB)
            {
                return new BigInt(0);
            }
            if (tmpA < tmpB)
            {
                result = tmpB - tmpA;
                result.negative = true;

                return result;
            }

            // A > B
            int count = tmpA.Count;
            if (tmpB.Count > count)
            {
                count = tmpB.Count;
                AddNulls(tmpA, count);
            }
            else
            {
                if (tmpB.Count < count)
                {
                    AddNulls(tmpB, count);
                }
            }

            result = new BigInt();

            for (int i = 0; i < count; i++)
            {
                if (tmpA[i] < tmpB[i])
                {
                    tmpA[i + 1]--;
                    result.AddValue(tmpA[i] + 10 - tmpB[i]);
                }
                else
                {
                    result.AddValue(tmpA[i] - tmpB[i]);
                }
            }
            return result;
        }
        public static BigInt operator - (BigInt A, int B)
        {
            BigInt tmpB = new BigInt(B);
            return A - tmpB;
        }
        // Умножение методом Карацубы
        public static BigInt operator * (BigInt A, BigInt B)
        {
            BigInt tmpA = new BigInt(A);
            BigInt tmpB = new BigInt(B);
            RemoveNulls(tmpA);
            RemoveNulls(tmpB);

            int max = 9;

            if (tmpA.Count + tmpB.Count < max)
            {
                return naive_mul(tmpA, tmpB);
            }

            int count = tmpA.Count;
            if (tmpB.Count > count)
            {
                count = tmpB.Count;
            }
            if (count % 2 != 0)
            {
                count++;
            }
            AddNulls(tmpA, count);
            AddNulls(tmpB, count);

            BigInt A1 = tmpA.GetRange(0, count / 2);
            BigInt A2 = tmpA.GetRange(count / 2, count / 2);
            BigInt B1 = tmpB.GetRange(0, count / 2);
            BigInt B2 = tmpB.GetRange(count / 2, count / 2);

            BigInt sumA = A1 + A2;
            BigInt sumB = B1 + B2;

            BigInt MUL1 = A1 * B1;
            BigInt MUL2 = A2 * B2;
            BigInt MUL3 = sumA * sumB;

            MUL3 = MUL3 - (MUL1 + MUL2);

            BigInt result = new BigInt();
            result.AddValue(0);
            
            if (MUL2 != 0)
            {
                for (int i = 0; i < count; i++)
                {
                    MUL2.Insert(0, 0);
                }
            }
            if (MUL3 != 0)
            {
                for (int i = 0; i < count / 2; i++)
                {
                    MUL3.Insert(0, 0);
                }
            }

            result = result + MUL2;
            result = result + MUL3;
            result = result + MUL1;

            RemoveNulls(result);

            return result;
        }
        public static BigInt operator *(BigInt A, int B)
        {
            BigInt tmpB = new BigInt(B);
            return A * tmpB;
        }
        // Получение остатка от деления
        public static BigInt operator % (BigInt A, BigInt B)
        {
            if (B <= 0)
            {
                throw new ArgumentOutOfRangeException("B must be positive");
            }

            // Ускорим для определения четности
            BigInt two = new BigInt(2);
            if (B == two)
            {
                if (A[0] % 2 == 0)
                {
                    return new BigInt(0);
                }
                return new BigInt(1);
            }

            BigInt tmpA = new BigInt(A);
            BigInt tmpB = new BigInt(B);

            RemoveNulls(tmpA);
            RemoveNulls(tmpB);

            // Нужно, чтобы правильно провести следующее сравнение
            tmpA.negative = false;

            if (tmpA < tmpB)
            {
                if (A.negative)
                {
                    return tmpB - tmpA;
                }
                else
                {
                    return tmpA;
                }
            }

            int count = tmpB.Count;
            BigInt result;

            result = tmpA.GetRange(tmpA.Count - count, count);

            while (count < tmpA.Count)
            {
                if (result < tmpB)
                {
                    count++;
                    result.Insert(0, tmpA[tmpA.Count - count]);
                }
                while (result >= tmpB)
                {
                    result = result - tmpB;
                }
            }
            while (result >= tmpB)
            {
                result = result - tmpB;
            }
            RemoveNulls(result);

            if (A.negative)
            {
                return tmpB - result;
            }
            return result;
        }
        public static BigInt operator / (BigInt A, BigInt B) {
            BigInt tmpA = new BigInt(A);
            BigInt tmpB = new BigInt(B);

            RemoveNulls(tmpA);
            RemoveNulls(tmpB);

            // Нужно, чтобы правильно провести следующее сравнение
            tmpA.negative = false;

            if (tmpA < tmpB)
            {
                return new BigInt(0);
            }

            int count = tmpB.Count;
            BigInt result = new BigInt();

            BigInt tmp = tmpA.GetRange(tmpA.Count - count, count);

            while (count < tmpA.Count)
            {
                if (tmp < tmpB)
                {
                    count++;
                    tmp.Insert(0, tmpA[tmpA.Count - count]);
                }
                if (tmp >= tmpB)
                {
                    result.Insert(0, 0);
                    while (tmp >= tmpB)
                    {
                        result[0]++;
                        tmp = tmp - tmpB;
                    }
                }
            }
            if (tmp >= tmpB)
            {
                result.Insert(0, 0);
                while (tmp >= tmpB)
                {
                    result[0]++;
                    tmp = tmp - tmpB;
                }
            }

            if (A.negative || B.negative)
            {
                result.negative = true;
            }
            
            return result;
        }

        public static bool operator == (BigInt A, BigInt B) {
            if (A.negative != B.negative)
            {
                return false;
            }
            BigInt tmpA = new BigInt(A);
            BigInt tmpB = new BigInt(B);

            RemoveNulls(tmpA);
            RemoveNulls(tmpB);

            if (tmpA.Count != tmpB.Count)
            {
                return false;
            }

            int count = tmpA.Count;
            for (int i = 0; i < count; i++)
            {
                if (tmpA[i] != tmpB[i])
                {
                    return false;
                }
            }

            return true;
        }
        public static bool operator == (BigInt A, int B)
        {
            BigInt tmpB = new BigInt(B);
            return A == tmpB;
        }
        public static bool operator != (BigInt A, BigInt B)
        {
            if (!(A == B))
            {
                return true;
            }
            return false;
        }
        public static bool operator != (BigInt A, int B)
        {
            BigInt tmpB = new BigInt(B);
            return A != tmpB;
        }
        public static bool operator < (BigInt A, BigInt B) {
            BigInt tmpA = new BigInt(A);
            BigInt tmpB = new BigInt(B);

            RemoveNulls(tmpA);
            RemoveNulls(tmpB);

            if (!A.negative && B.negative) {
                return false;
            }
            if (A.negative && !B.negative) {
                return true;
            }

            if (tmpA.Count > tmpB.Count)
            {
                if (tmpA.negative)
                    return true;
                return false;
            }
            if (tmpA.Count < tmpB.Count)
            {
                if (tmpA.negative)
                {
                    return false;
                }
                return true;
            }

            int count = tmpA.Count;

            for (int i = 0; i < count; i++)
            {
                if (tmpA[count - i - 1] < tmpB[count - i - 1])
                {
                    return true;
                }                
            }

            return false;
        }
        public static bool operator > (BigInt A, BigInt B)
        {
            if (!(A == B) && !(A < B))
            {
                return true;
            }
            return false;
        }
        public static bool operator <= (BigInt A, BigInt B) {
            if (A < B || A == B) {
                return true;
            }
            return false;
        }
        public static bool operator <= (BigInt A, int B) {
            BigInt tmpB = new BigInt(B);
            return A <= tmpB;
        }
        public static bool operator >= (BigInt A, BigInt B)
        {
            if (A > B || A == B)
            {
                return true;
            }
            return false;
        }
        public static bool operator >= (BigInt A, int B)
        {
            BigInt tmpB = new BigInt(B);
            return A >= tmpB;
        }

        public static BigInt Pow(BigInt A, BigInt B, BigInt module)
        {
            BigInt zero = new BigInt(0);
            BigInt one = new BigInt(1);
            BigInt two = new BigInt(2);

            BigInt a = A;
            BigInt b = B;
            BigInt result = one;

            while (b > zero)
            {

                BigInt r = b % two;
                BigInt q = b / two;
                if (r == zero)
                {
                    b = q;
                    a = (a * a) % module;
                }
                else
                {
                    b = b - one;
                    result = (result * a) % module;
                }
            }
            return result;
        }
        
        // Добавление незначащих нулей
        private static void AddNulls(BigInt item, int count)
        {
            // Все листы реверсированы, значит, самый старший разряд
            // имеет самый большой номер в массиве
            int c = item.Count;
            while (c < count)
            {
                item.AddValue(0);
                c++;
            }
        }
        // Удаление незначащих нулей
        private static void RemoveNulls(BigInt item)
        {
            // Все листы реверсированы, значит, самый старший разряд
            // имеет самый большой номер в массиве
            int i = 0;
            int count = item.Count;
            while ((count - i - 1) > 0 && item[count - i - 1] == 0)
            {
                i++;
            }
            item.number.RemoveRange(count - i, i);
        }

        // Обычное умножение (если есть уверенность, что при умножении A и B получится число, влезающее в int)
        private static BigInt naive_mul(BigInt A, BigInt B)
        {
            int A1 = GetNum(A);
            int B1 = GetNum(B);

            return new BigInt(A1 * B1);
        }   
        
        // Перевод вектора в число
        private static int GetNum(BigInt item)
        {
            int result = 0;

            RemoveNulls(item);
                        
            for (int i = 0; i < item.Count; i++)
            {
                result += item[i] * IntPow(10, i);
            }

            if (item.negative)
                return result * (-1);
            return result;
        }

        // Возведение числа p в степень k
        private static int IntPow(int p, int k)
        {
            int result = 1;
            for (int i = 0; i < k; i++)
            {
                result *= p;
            }
            return result;
        }


    }

}
