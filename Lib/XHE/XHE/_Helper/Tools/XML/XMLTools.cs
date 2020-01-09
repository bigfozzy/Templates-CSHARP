using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using XHE._Helper.Tools.Folder;

namespace XHE._Helper.Tools.XML
{
    public class XMLTools
    {
        #region работа с TreeView
        /// <summary>
        /// загрузить XML в дерево 
        /// </summary>
        /// <param name="sPath">путь</param>
        /// <param name="Tree">контрол</param>
        static public XmlDocument LoadTreeFromXML(string sPath, TreeView Tree)
        {
            // загрузим xml
            XmlDocument dom = new XmlDocument();
            dom.Load(sPath);
            // построить динамичесике элементы XML по 1 уровню
            for (int i = 0; i < dom.DocumentElement.ChildNodes.Count;i++ )
                BuildDynamicXMLElement(dom.DocumentElement.ChildNodes[i], Application.StartupPath+"\\", dom);
            
            // очистим дерево            
            Tree.Nodes.Clear();

            // добавим корневой узел и зададим его свойства
            Tree.Nodes.Add(new TreeNode(""));
            TreeNode tNode = Tree.Nodes[0];
            SetTreeNodeView(dom.DocumentElement, tNode);

            // добавим все остальное дерево
            AddNodeToTree(dom.DocumentElement, tNode, dom);

            // покажем
            Tree.Refresh();
            
            // вернем модель XML
            return dom;
        }
        // добавить узел
        static private void AddNodeToTree(XmlNode inXmlNode, TreeNode inTreeNode, XmlDocument dom)
        {
            // если есть дочерние то идем дальше
            if (inXmlNode.HasChildNodes)
            {
                // пройдем по всем source элементам
                int iNum = 0;
                XmlNodeList nodeList = inXmlNode.ChildNodes;
                for (int i = 0; i <= nodeList.Count - 1; i++)
                {
                    // получим элемент source
                    XmlNode xNode = inXmlNode.ChildNodes[i];
                    if (xNode.Name != "source")
                        continue;

                    // добавим узел с таким именем
                    inTreeNode.Nodes.Add(new TreeNode(""));
                    TreeNode tNode = inTreeNode.Nodes[iNum++];
                    SetTreeNodeView(xNode, tNode);

                    // добавим подузлы 
                    AddNodeToTree(xNode, tNode, dom);
                }
            }
        }
        // проинициализируем элемент дерева по XML элементу source
        static private void SetTreeNodeView(XmlNode inXmlNode, TreeNode tNode)
        {
            // зададим имя
            tNode.Text = GetChildElementValueByName(inXmlNode, "name");
            
            // зададим иконку
            int iIndex=Convert.ToInt16(GetChildElementValueByName(inXmlNode, "icon"));
            tNode.ImageIndex = tNode.SelectedImageIndex = iIndex;
            
            // зададим состояние развернутости
            if (GetChildElementValueByName(inXmlNode, "expand") == "true")
            {
                if (tNode.Parent != null && !tNode.Parent.IsExpanded)
                {
                    tNode.Expand();
                    tNode.Parent.Expand();
                }
            }

            // зададим XML объект ассоциированный с этим узлом
            tNode.Tag = inXmlNode;

        }
        #endregion

        #region работа с XML
        // задаем значение дочернего аттрибута
        static public void SetChildElementValueByName(XmlNode inXmlNode, string sName, string sValue, XmlDocument dom)
        {
            // пройдем по подъэлементам
            XmlNodeList nodeList = inXmlNode.ChildNodes;
            for (int i = 0; i <= nodeList.Count - 1; i++)
            {
                // найдем дочерний элемент с таким именем
                XmlNode xNode = inXmlNode.ChildNodes[i];
                if (xNode.Name != sName)
                    continue;

                // нашли - зададим значение
                xNode.InnerText = sValue;
            }
            
            // если такого нет - надо создать
            XmlElement elementDom = dom.CreateElement(sName);
            elementDom.InnerText = sValue;
            inXmlNode.AppendChild(elementDom);
        }        
        // получим значение дочернего аттрибута
        static public string GetChildElementValueByName(XmlNode inXmlNode, string sName)
        {
            // пройдем по подъэлементам
            XmlNodeList nodeList = inXmlNode.ChildNodes;
            for (int i = 0; i <= nodeList.Count - 1; i++)
            {
                // найдем дочерний элемент с таким именем
                XmlNode xNode = inXmlNode.ChildNodes[i];
                if (xNode.Name != sName)
                    continue;

                // вернем его значение
                return xNode.InnerText;
            }
            
            return null;
        }
        // построить динамические узлы XML
        private static void BuildDynamicXMLElement(XmlNode inXmlNode, string sAddPath, XmlDocument dom)
        {
            // проверим я вляется ли элемент динамическим
            if (GetChildElementValueByName(inXmlNode, "folder") == null)
                return;

            // путь к папке где все лежит
            string sPath = GetChildElementValueByName(inXmlNode, "folder");
            sPath = sAddPath + sPath + "\\";

            // получим все пути файлов
            List<string> aFilesAndFolders = new List<string>();
            FolderTools.GetAllFilesInFolder(sPath, "*.*", false, false, false, aFilesAndFolders);

            // сосздадим эелементы по этой папке
            for (int i = 0; i < aFilesAndFolders.Count; i++)
            {
                string sPathName = aFilesAndFolders[i];
                string sRelPath = sPathName.Substring(sPath.Length);

                // создадим и добавим элемент
                XmlElement elementDom = dom.CreateElement("source");
                inXmlNode.AppendChild(elementDom);

                // зададим его дочерние поля
                SetChildElementValueByName(elementDom, "name", sRelPath, dom);
                SetChildElementValueByName(elementDom, "expand", "false", dom);

                // вычислим путь
                string sPath1 = Application.StartupPath + "\\";
                sPath1 = sPathName.Substring(sPath1.Length);
                int index = sPath1.IndexOf(".");
                if (index == -1)
                    sPath1 = sPath1 + ".php";
                sPath1 = sPath1.ToLower();

                // зададим путь
                SetChildElementValueByName(elementDom, "url", "http://humanemulator.info/file.php/?file=" + sPath1, dom);

                // зададим внешний вид
                if (Directory.Exists(sPathName))
                {
                    // папка с файлами
                    SetChildElementValueByName(elementDom, "icon", "3", dom);
                    SetChildElementValueByName(elementDom, "folder", "", dom);
                }
                else
                {
                    // файл
                    SetChildElementValueByName(elementDom, "icon", "7", dom);
                    SetChildElementValueByName(elementDom, "file", sPathName, dom);

                }
            }

            // пройдемся по пакам в этой папке и сосздадим элементы по ним
            for (int i = 0; i < inXmlNode.ChildNodes.Count; i++)
            {
                XmlNode elementDom = inXmlNode.ChildNodes[i];
                // толкьо для source
                if (elementDom.Name != "source")
                    continue;
                // толкьо для папок
                if (GetChildElementValueByName(elementDom, "folder") == null)
                    continue;
                // построим элементы
                BuildDynamicXMLElement(elementDom, sAddPath + GetChildElementValueByName(inXmlNode, "folder") + "\\" + GetChildElementValueByName(elementDom, "name"), dom);
            }
        }
        #endregion
        
   }
}
