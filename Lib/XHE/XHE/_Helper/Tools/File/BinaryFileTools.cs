using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XHE._Helper.Tools.File
{
    /// <summary>
    /// ������ � ��������� �������
    /// </summary>
    public class BinaryFileTools
    {
        #region ������ � ������������ ������

        /// <summary>
        /// ��������� ���� �� ����� ����� � ���������������� �� Int32 �����
        /// </summary>
        /// <param name="iValue">�����</param>
        /// <param name="FS">�������� �����</param>
        /// <param name="BR">�������� ��������</param>
        /// <returns>true - ����</returns>
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

                // ��������� ���
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
