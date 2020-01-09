using System.Diagnostics;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System;
using XHE;
using System.Reflection;

namespace XHE.XHE_DOM
{
////////////////////////////////////////////////// Table ////////////////////////////////////////////////////
    public class XHETable : XHEBaseDOMVisual
    {
	    /////////////////////////////////// SERVICVE FUNCTIONS //////////////////////////////////////////////
	    // server initialization
        public XHETable(string server, string password, XHEScriptBase script)
            : base(server, password)
	    {
            Script = script;
            m_Prefix = "Table";
	    }
	    /////////////////////////////////////////////////////////////////////////////////////////////////////

	    /////////////////////////////////////////////////////////////////////////////////////////////////////

        // экспорт всей таблицы или ее части в csv формат
        public bool export_to_csv(string file_path, int number, string rows = "", string cols = "", bool as_html = true, string separator = ";", string frame = "-1")
	    {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] {  { "file_path", file_path},  { "number", number.ToString() }, { "rows", rows }, { "cols", cols }, { "as_html", as_html.ToString() }, { "separator", separator }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	    }
        // экспорт всей таблицы или ее части в xml формат
        public bool export_to_xml(string file_path, int number, string rows = "", string cols = "", bool as_html = true, string frame = "-1")
	    {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] {  { "file_path", file_path},  { "number", number.ToString() }, { "rows", rows }, { "cols", cols }, { "as_html", as_html.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
	    }

	    /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // получить количество €чеек таблицы по ее номеру
        public int get_cells_by_number(int number, string frame = "-1")
	    {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
	    }
	    // получить число строк таблицы по ее номеру
        public int get_rows_by_number(int number, string frame = "-1")
	    {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
	    }
	    // получить число столбцов таблицы по ее номеру
        public int get_cols_by_number(int number, string frame = "-1",int row=0)
	    {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } , { "row", row.ToString() }};
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
	    }

        // получить текст заданной €чейки (по столбцу и строке) в таблице с заданным номеру
        public string get_cell_by_number(int number, int row, int col, bool as_html = false, string frame = "-1")
	    {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] {  { "number", number.ToString() }, { "row", row.ToString() }, { "col", col.ToString() }, { "as_html", as_html.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
	    }
	    // получить текст заданной €чейки (по позиции) в таблице с заданным номером
        public string get_cell_by_pos_by_number(int number, int pos, bool as_html = false, string frame = "-1")
	    {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] {  { "number", number.ToString() }, { "pos", pos.ToString() }, { "as_html", as_html.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
	    }

	    // получить текст заданной строки в таблице с заданным номеру
        public string get_row_by_number(int number, int row, bool as_html = false, string frame = "-1")
	    {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] {  { "number", number.ToString() }, { "row", row.ToString() }, { "as_html", as_html.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
	    }
	    // получить текст заданного столбца в таблице с заданным номеру
        public string get_col_by_number(int number, int col, bool as_html = false, string frame = "-1")
	    {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] {  { "number", number.ToString() }, { "col", col.ToString() }, { "as_html", as_html.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
	    }
        //  получить текст заданной части таблицы с заданным номеру
        public string get_rows_cols_by_number(int number, string rows, string cols, bool as_html = false, string separator = "<br>", string frame = "-1")
	    {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] {  { "number", number.ToString() },  { "rows", rows }, { "cols", cols }, { "as_html", as_html.ToString() },  { "separator", separator}, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
	    }

	    /////////////////////////////////////////////////////////////////////////////////////////////////////

	    // получить x координату €чейки (по строке и столбцу) у таблицы с заданным номером
        public int get_cell_x_by_number(int number, int row, int col, string frame = "-1")
	    {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] {  { "number", number.ToString() }, { "row", row.ToString() }, { "col", col.ToString() },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
	    }
	    // получить x координату €чейки (по строке и столбцу) у таблицы с заданным внутренним текстом
        public int get_cell_x_by_inner_text(string inner_text, int exactly, int row, int col, string frame = "-1")
	    {
		    wait_element_exist_by_inner_text(inner_text,exactly,frame);		

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "row", row.ToString() }, { "col", col.ToString() },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
	    }
	    // получить x координату €чейки (по строке и столбцу) у таблицы с заданным значением аттрибута
        public int get_cell_x_by_attribute(string attr_name, string attr_value, int exactly, int row, int col, string frame = "-1")
	    {
		    wait_element_exist_by_attribute(attr_name,attr_value,exactly,frame);		

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "row", row.ToString() }, { "col", col.ToString() },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
	    }

        // получить y координату €чейки (по строке и столбцу) у таблицы с заданным номером
        public int get_cell_y_by_number(int number, int row, int col, string frame = "-1")
	    {
		    wait_element_exist_by_number(number,frame);		

            string[,] aParams = new string[,] {  { "number", number.ToString() }, { "row", row.ToString() }, { "col", col.ToString() },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
	    }
	    // получить y координату €чейки (по строке и столбцу) у таблицы с заданным внутренним текстом
        public int get_cell_y_by_inner_text(string inner_text, int exactly, int row, int col, string frame = "-1")
	    {
		    wait_element_exist_by_inner_text(inner_text,exactly,frame);		

            string[,] aParams = new string[,] { { "inner_text", inner_text }, { "exactly", exactly.ToString() }, { "row", row.ToString() }, { "col", col.ToString() },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
	    }
	    // получить y координату €чейки (по строке и столбцу) у таблицы с заданным значением аттрибута
        public int get_cell_y_by_attribute(string attr_name, string attr_value, int exactly, int row, int col, string frame = "-1")
	    {
		    wait_element_exist_by_attribute(attr_name,attr_value,exactly,frame);		

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "row", row.ToString() }, { "col", col.ToString() },  { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
	    }
	    /////////////////////////////////////////////////////////////////////////////////////////////////////
    };	
}