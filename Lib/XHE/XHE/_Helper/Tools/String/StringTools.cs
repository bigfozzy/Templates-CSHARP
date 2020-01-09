using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;


namespace XHE._Helper.Tools.String
{
    public class StringTools
    {
        /// <summary>
        /// сравнить строки на полное и частичное совпадение
        /// </summary>
        /// <param name="sStringIn"></param>
        /// <param name="stringNeeded"></param>
        /// <param name="bExactly"></param>
        /// <returns></returns>
        public static bool CompareString(string sStringIn, string stringNeeded, bool bExactly)
        {
            // если это тот что надо - кликнем на нем
            if (bExactly)
            {
                if (sStringIn == stringNeeded)
                    return true;
            }
            else
            {
                if (sStringIn.IndexOf(stringNeeded) != -1)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// получить номер как строку
        /// </summary>
        /// <param name="iCharCount">число символов</param>
        /// <returns></returns>
        public static string GetNumberAsString(int iNumber, int iCharCount)
        {
            string sNumber = Convert.ToString(iNumber);
            while (sNumber.Length < iCharCount)
                sNumber = "0" + sNumber;
            return sNumber;
        }

        /// <summary>
        /// получить хост по урлу
        /// </summary>
        /// <param name="sUrl"></param>
        /// <returns></returns>
        public static string GetHostFromUrl(string sUrl)
        {
            // попробуем преобразовать в URI
            Uri uri = null;
            try
            {
                uri = new Uri(sUrl);
            }
            catch (Exception)
            {
                return null;
            }
            // если получилось
            if (uri == null)
                return null;

            // хост от ури
            return uri.Host;
        }

        /// <summary>
        /// Разобрать строку 
        /// </summary>
        /// <param name="sData">строка для разбора</param>
        /// <param name="sPref1">префикс поиска начала строки</param>
        /// <param name="sPref2">префикс поиска конец строки</param>
        /// <param name="index">старовый индекс</param>
        /// <param name="bDelPref">учитывать ли длину префикса начала строки</param>
        /// <returns></returns>
        public static string ParseString(string sData, string sPref1, string sPref2, ref int index, bool bDelPref)
        {
            // получаем индекс начала строки
            int index1 = sData.IndexOf(sPref1, index);
            if (index1 == -1)
            {
                index = -1;
                return "";
            }
            // получаем индекс конца строки
            int index2 = sData.IndexOf(sPref2, index1);
            if (index2 == -1)
            {
                index = -1;
                return "";
            }
            // учитываем ди лину префекса
            int delLen = 0;
            if (bDelPref)
                delLen = sPref1.Length;
            // получаем строку
            string sRes = sData.Substring(index1 + delLen, index2 - index1 - delLen);
            // меняем стартовый индекс
            index = index2;
            // возвращаем результат 
            return sRes;
        }

        /// <summary>
        /// получить число слов в слове
        /// </summary>
        /// <param name="sKeyword">слово или фраза</param>
        /// <returns>число слов</returns>
        public static int GetKeywordCount(string sKeyword)
        {
            int iCount = 1;

            int iIndex = -1;
            while (true)
            {
                iIndex = sKeyword.IndexOf(' ', iIndex + 1);
                if (iIndex == -1)
                    break;
                iCount++;
            }
            return iCount;
        }

        /// <summary>
        /// преобразовать целое в строку с запятыми
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        public static string ToStringWithCommas(int iNumber)
        {
            string s = iNumber.ToString();
            string str = s, str1 = "";
            bool beProceed = false;
            while (str.Length > 3)
            {
                str1 = "," + str.Substring(str.Length - 3) + str1;
                str = str.Substring(0, str.Length - 3);
                beProceed = true;
            }
            if (beProceed)
                s = str + str1;
            return s;

        }

        /// <summary>
        /// преобразовать целое в строку с запятыми
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        public static string ToStringWithCommas(ulong iNumber)
        {
            string s = iNumber.ToString();
            string str = s, str1 = "";
            bool beProceed = false;
            while (str.Length > 3)
            {
                str1 = "," + str.Substring(str.Length - 3) + str1;
                str = str.Substring(0, str.Length - 3);
                beProceed = true;
            }
            if (beProceed)
                s = str + str1;
            return s;
        }

        /// <summary>
        /// преобразовать целое в строку с запятыми
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        public static string ToStringWithCommas(double iNumber)
        {
            string s = iNumber.ToString();
            int iIndex = s.IndexOf(',');
            string sAdd = s.Substring(iIndex + 1);
            if (sAdd.Length == 1)
                sAdd += "0";
            if (iIndex != -1)
                s = s.Substring(0, iIndex);
            string str = s, str1 = "";
            bool beProceed = false;
            while (str.Length > 3)
            {
                str1 = "," + str.Substring(str.Length - 3) + str1;
                str = str.Substring(0, str.Length - 3);
                beProceed = true;
            }
            if (beProceed)
                s = str + str1 + "." + sAdd;
            else
                s = str + "." + sAdd;
            return s;
        }
            
        /// <summary>
        /// вернуть подсктроку внутри префикусов
        /// </summary>
        /// <param name="sStr"></param>
        /// <param name="sPrefix1"></param>
        /// <param name="sPrefix2"></param>
        /// <returns></returns>
        public static string GetSubstringByPrefix(string sStr, string sPrefix1, string sPrefix2,ref int index)
        {
            // получим начало и конец
            int iIndex1 = sStr.IndexOf(sPrefix1, index);
            if (iIndex1 == -1)
                return null;
            int iIndex2 = sStr.IndexOf(sPrefix2, iIndex1 + sPrefix1.Length);
            if (iIndex2 == -1)
                return null;

            // вернем строку
            index = iIndex2;
            return sStr.Substring(iIndex1 + sPrefix1.Length, iIndex2 - sPrefix1.Length - iIndex1);
        }
        /// <summary>
        /// показать в панели отладки коллекцию ключей и занчений
        /// </summary>
        /// <param name="myCol">коллекция со значениями</param>
        public static void PrintKeysAndValues(NameValueCollection myCol)
        {
            Console.WriteLine("   KEY        VALUE");
            foreach (string s in myCol.AllKeys)
                Console.WriteLine("   {0,-10} {1}", s, myCol[s]);
            Console.WriteLine();
        }
        /// <summary>
        /// показать в панели отладки коллекцию индексов, ключей и занчений
        /// </summary>
        /// <param name="myCol">коллекция со значениями</param>
        public static void PrintKeysAndValues2(NameValueCollection myCol)
        {
            Console.WriteLine("   [INDEX] KEY        VALUE");
            for (int i = 0; i < myCol.Count; i++)
                Console.WriteLine("   [{0}]     {1,-10} {2}", i, myCol.GetKey(i), myCol.Get(i));
            Console.WriteLine();
        }
    }
}
