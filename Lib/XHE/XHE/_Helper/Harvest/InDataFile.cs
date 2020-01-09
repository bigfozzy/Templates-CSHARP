using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XHE.XHE_Window;
using XHE._Helper.Tools.File;
using XHE._Helper.Tools.Log;

namespace XHE._Helper.Harvest
{
    /// <summary>
    /// файл входных данных (входнйо файл)
    /// </summary>
    public class InDataFile
    {        

        #region переменные

        /// <summary>
        /// путь к файлу с данными
        /// </summary>
        protected string path = null;
        /// <summary>
        /// имя одного элемента файла данных
        /// </summary>
        protected string nameItem = null;
        /// <summary>
        /// пауза после выполнения одного шага
        /// </summary>
        protected long stepPause = 0;

        /// <summary>
        /// текущая позиция в файле данных
        /// </summary>
        private long currentPos =0;        
        /// <summary>
        /// число строк в файле данных
        /// </summary>
        private long totalCount = -1;

        #endregion        

        #region создание

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="path">путь к файлу с данными</param>
        /// <param name="nameItem">имя одного элемента файла с данными</param>
        /// <param name="stepPause">пауза по завершении шага</param>
        public InDataFile(string path, string nameItem, int stepPause=1)
        {
            // задать главные переменные
            this.path = path;
            this.nameItem = nameItem;
            this.stepPause = stepPause;

            // инициаизировать сведения о продолжении
            InitContinueInfo();
        }
        /// <summary>
        /// иницировать сведения о продолжении (вспомогательная)
        /// </summary>
        private void InitContinueInfo()
        {
            // нет информации о продолжении - старт
            currentPos = 0; 
            
            // получить информацию о продолжении из файла продолжения
            if (System.IO.File.Exists(path + ".continue.txt"))
                currentPos = Convert.ToInt32(TextFileTools.GetLine(path + ".continue.txt", 0));

            // лог
            LogTools.LogEvent("Start : begin with "+currentPos.ToString()+" "+nameItem+". Total : "+GetCount().ToString());
        }

        #endregion
        
        #region получить внтреннее состояние

        /// <summary>
        /// получить текущуую позицию в файле данных
        /// </summary>
        /// <returns>текущая позиция в файле данных</returns>
        public long GetCurrentPos()
        {
            return currentPos;
        }
        /// <summary>
        /// получить число строк в файле данных
        /// </summary>
        /// <returns>число строк в файле данных</returns>
        public long GetCount()
        {
            // если еще не получали - вычислим
            if (totalCount == -1)
                totalCount = TextFileTools.GetLinesCount(path);

            // результат
            return totalCount;
        }

        #endregion

        #region работа с файлом данных

        /// <summary>
        /// получить данные для следующего шага
        /// </summary>
        /// <returns>данные для следующего шага</returns>
        public string GetNext()
        {
            return TextFileTools.GetLine(path, currentPos);
        }

        /// <summary>
        /// указать что завершился очереднйо шаг(запись информации о продолжении и вывод прогресса)
        /// </summary>
        /// <param name="app">XHEApplication</param>
        public void FinishStep(XHEApplication app=null)
        {
		    // следующая позиция
		    currentPos++;

            // записать информацию о продолжении
            if (currentPos % 10 == 0 )
                TextFileTools.WriteFile(path+".continue.txt",currentPos.ToString());

            // показать прогресс
            if (app != null)
            {
                app.set_title(currentPos + " / " + totalCount);
                app.set_tray_tooltip(currentPos + " / " + totalCount);
            }
        }

        #endregion        
    }
}
