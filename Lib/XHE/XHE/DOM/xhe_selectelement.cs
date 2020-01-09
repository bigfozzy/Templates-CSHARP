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
    ////////////////////////////////////////////////// Lisatbox /////////////////////////////////////////////////
    public class XHESelectElement : XHEBaseDOMVisual
    {
        //////////////////////////////////// SERVICVE FUNCTIONS /////////////////////////////////////////////
        // server initialization
        public XHESelectElement(string server, string password, XHEScriptBase script)
            : base(server, password)
        {
            Script = script;
            m_Prefix = "SelectElement";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // выбрать опцию по ее индексу в листбоксе с заданным номером
        public bool select_index_by_number(int number, int index, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "index", index.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выбрать опцию по ее индексу в листбоксе с заданным именем
        public bool select_index_by_name(string name, int index, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "index", index.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выбрать опцию по ее индексу в листбоксе с заданным значением аттрибута
        public bool select_index_by_attribute(string attr_name, string attr_value, int exactly_attr, int index, string frame = "-1")
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly_attr, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly_attr", exactly_attr.ToString() }, { "index", index.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // выбрать опцию по ее тексту в листбоксе с заданным номером
        public bool select_text_by_number(int number, string text, int exactly = 1, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "text", text }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выбрать опцию по ее тексту в листбоксе с заданным именем
        public bool select_text_by_name(string name, string text, int exactly = 1, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "text", text }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выбрать опцию по ее тексту в листбоксе с заданным значением аттрибута
        public bool select_text_by_attribute(string attr_name, string attr_value, int exactly_attr, string text, bool exactly = true, string frame = "-1")
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly_attr, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly_attr", exactly_attr.ToString() }, { "text", text }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // выбрать опцию по ее значению в листбоксе с заданным номером
        public bool select_value_by_number(int number, string value, int exactly = 1, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "value", value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выбрать опцию по ее значению в листбоксе с заданным именем
        public bool select_value_by_name(string name, string value, int exactly = 1, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "value", value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выбрать опцию по ее значению в листбоксе с заданным значением аттрибута
        public bool select_value_by_attribute(string attr_name, string attr_value, int exactly_attr, string value, bool exactly = true, string frame = "-1")
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly_attr, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly_attr", exactly_attr.ToString() }, { "value", value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // выбрать опцию по ее индексу в листбоксе с заданным значением аттрибута и в форме с заданным номером (no wait exist mode)
        public bool select_index_by_attribute_by_form_number(string attr_name, string attr_value, int exactly_attr, int index, int form_number, string frame = "-1")
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly_attr", exactly_attr.ToString() }, { "index", index.ToString() }, { "form_number", form_number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выбрать опцию по ее индексу в листбоксе с заданным значением аттрибута и в форме с заданным именем (no wait exist mode)
        public bool select_index_by_attribute_by_form_name(string attr_name, string attr_value, int exactly_attr, int index, string form_name, string frame = "-1")
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly_attr", exactly_attr.ToString() }, { "index", index.ToString() }, { "form_name", form_name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // выбрать опцию по ее тексту в листбоксе с заданным значением аттрибута и в форме с заданным номером (no wait exist mode)
        public bool select_text_by_attribute_by_form_number(string attr_name, string attr_value, int exactly_attr, string text, bool exactly, int form_number, string frame = "-1")
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly_attr", exactly_attr.ToString() }, { "text", text }, { "exactly", exactly.ToString() }, { "form_number", form_number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выбрать опцию по ее тексту в листбоксе с заданным значением аттрибута и в форме с заданным именем (no wait exist mode)
        public bool select_text_by_attribute_by_form_name(string attr_name, string attr_value, int exactly_attr, string text, bool exactly, string form_name, string frame = "-1")
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly_attr", exactly_attr.ToString() }, { "text", text }, { "exactly", exactly.ToString() }, { "form_name", form_name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // выбрать опцию по ее значению в листбоксе с заданным значением аттрибута и в форме с заданным номером (no wait exist mode)
        public bool select_value_by_attribute_by_form_number(string attr_name, string attr_value, int exactly_attr, string value, bool exactly, int form_number, string frame = "-1")
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly_attr", exactly_attr.ToString() }, { "value", value }, { "exactly", exactly.ToString() }, { "form_number", form_number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выбрать опцию по ее значению в листбоксе с заданным значением аттрибута и в форме с заданным именем (no wait exist mode)
        public bool select_value_by_attribute_by_form_name(string attr_name, string attr_value, int exactly_attr, string value, bool exactly, string form_name, string frame = "-1")
        {
            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly_attr", exactly_attr.ToString() }, { "value", value }, { "exactly", exactly.ToString() }, { "form_name", form_name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // выбрать случайную опцию в листбоксе с заданным номером
        public bool select_random_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выбрать случайную опцию в листбоксе с заданным именем
        public bool select_random_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выбрать случайную опцию в листбоксе с заданным именем
        public bool select_random_by_attribute(string attr_name, string attr_value, int exactly_attr, string frame = "-1")
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly_attr, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly_attr", exactly_attr.ToString() } , { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // выбрать опции по их индексам в листбоксе с заданным номером
        public bool multi_select_indexes_by_number(int number, string indexes, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "indexes", indexes }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выбрать опции по их индексам в листбоксе с заданным именем
        public bool multi_select_indexes_by_name(string name, string indexes, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "indexes", indexes }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // выбрать опции их текстам в листбоксе с заданным номером
        public bool multi_select_values_by_number(int number, string values, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "values", values }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выбрать опции по их текстам в листбоксе с заданным именем
        public bool multi_select_values_by_name(string name, string values, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "values", values }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // выбрать опции их значениям в листбоксе с заданным номером
        public bool multi_select_texts_by_number(int number, string texts, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "texts", texts }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // выбрать опции по их значениям в листбоксе с заданным именем
        public bool multi_select_texts_by_name(string name, string texts, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "texts", texts }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить индекс выбранной опции в листбоксе с заданным номером
        public int get_selected_index_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить индекс выбранной опции в листбоксе с заданным именем
        public int get_selected_index_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить индекс выбранной опции в листбоксе с заданным значением аттрибута
        public int get_selected_index_by_attribute(string attr_name, string attr_value, int exactly, string frame = "-1")
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить текст выбранной опции в листбоксе с заданным номером
        public string get_selected_text_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить текст выбранной опции в листбоксе с заданным именем
        public string get_selected_text_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить текст выбранной опции в листбоксе с заданным значением аттрибута
        public string get_selected_text_by_attribute(string attr_name, string attr_value, int exactly, string frame = "-1")
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        // получить размер листбокса (количества рядов) с заданным номером
        public int get_size_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить размер листбокса (количества рядов) с заданным именем
        public int get_size_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить размер листбокса с заданным значением аттрибута
        public int get_size_by_attribute(string attr_name, string attr_value, int exactly, string frame = "-1")
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить длину листбокса с заданным номером
        public int get_length_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить длину листбокса с заданным именем
        public int get_length_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить длинну листбокса с заданным значением аттрибута
        public int get_length_by_attribute(string attr_name, string attr_value, int exactly, string frame = "-1")
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_int(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить тип листбокса с заданным номером
        public string get_type_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить тип листбокса с заданным именем
        public string get_type_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить тип листбокса с заданным значением аттрибута
        public string get_type_by_attribute(string attr_name, string attr_value, int exactly, string frame = "-1")
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить текст всех опций листбокса с заданным номером
        public string get_all_texts_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить текст всех опций листбокса с заданным именем
        public string get_all_texts_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить текст всех опций листбокса с заданным значением аттрибута
        public string get_all_texts_by_attribute(string attr_name, string attr_value, int exactly, string frame = "-1")
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        // получить значения всех опций листбокса с заданным номером
        public string get_all_values_by_number(int number, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить значения всех опций листбокса с заданным именем
        public string get_all_values_by_name(string name, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // получить значения всех опций листбокса с заданным значением аттрибута
        public string get_all_values_by_attribute(string attr_name, string attr_value, int exactly, string frame = "-1")
        {
            wait_element_exist_by_attribute(attr_name, attr_value, exactly, frame);

            string[,] aParams = new string[,] { { "attr_name", attr_name }, { "attr_value", attr_value }, { "exactly", exactly.ToString() }, { "frame", frame } };
            return call_get(MethodBase.GetCurrentMethod().Name, aParams);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // добавить опцию к листбоксу с заданным номером
        public bool add_option_by_number(int number, string text, string value, string frame = "-1")
        {
            wait_element_exist_by_number(number, frame);

            string[,] aParams = new string[,] { { "number", number.ToString() }, { "text", text }, { "value", value }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }
        // добавить опцию к листбоксу с заданным именем
        public bool add_option_by_name(string name, string text, string value, string frame = "-1")
        {
            wait_element_exist_by_name(name, frame);

            string[,] aParams = new string[,] { { "name", name }, { "text", text }, { "value", value }, { "frame", frame } };
            return call_boolean(MethodBase.GetCurrentMethod().Name, aParams);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    };
}