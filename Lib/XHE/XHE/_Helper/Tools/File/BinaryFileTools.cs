using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XHE._Helper.Tools.File
{
    /// <summary>
    /// работа с бинарными файлами
    /// </summary>
    public class BinaryFileTools
    {
        #region работа с сортированым файлом

        /// <summary>
        /// проверить есть ли такое число в отсортировоанном по Int32 файле
        /// </summary>
        /// <param name="iValue">число</param>
        /// <param name="FS">файловый поток</param>
        /// <param name="BR">бинарный читатель</param>
        /// <returns>true - есть</returns>
        static public bool IsExistInt32InSortedFile(int iValue,FileStream FS,BinaryReader BR,long iSize)
        {
            long lMinPos = 0;
            long lMaxPos = iSize - 1;
            long lPos = iSize / 2;
            Int32 iCurValue = -1;
            while (true)
            {
                lPos = (lMaxPos + lMinPos) / 2;
                FS.Seek(lPos * 4, SeekOrigin.Begin);
                iCurValue = BR.ReadInt32();
                if (iCurValue == iValue)
                    return true;
                if (iCurValue > iValue)
                    lMaxPos = lPos;
                if (iCurValue < iValue)
                    lMinPos = lPos;

                // последний чек
                if (lMaxPos - lMinPos < 2)
                {
                    FS.Seek(lMaxPos * 4, SeekOrigin.Begin);
                    iCurValue = BR.ReadInt32();
                    if (iCurValue == iValue)
                        return true;

                    if (lMaxPos != lMinPos)
                    {
                        FS.Seek(lMinPos * 4, SeekOrigin.Begin);
                        iCurValue = BR.ReadInt32();
                        if (iCurValue == iValue)
                            return true;
                    }

                    return false;
                }
            }
        }

        #endregion
    }
}
