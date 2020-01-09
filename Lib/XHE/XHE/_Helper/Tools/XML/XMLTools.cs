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
        #region ������ � TreeView
        /// <summary>
        /// ��������� XML � ������ 
        /// </summary>
        /// <param name="sPath">����</param>
        /// <param name="Tree">�������</param>
        static public XmlDocument LoadTreeFromXML(string sPath, TreeView Tree)
        {
            // �������� xml
            XmlDocument dom = new XmlDocument();
            dom.Load(sPath);
            // ��������� ������������ �������� XML �� 1 ������
            for (int i = 0; i < dom.DocumentElement.ChildNodes.Count;i++ )
                BuildDynamicXMLElement(dom.DocumentElement.ChildNodes[i], Application.StartupPath+"\\", dom);
            
            // ������� ������            
            Tree.Nodes.Clear();

            // ������� �������� ���� � ������� ��� ��������
            Tree.Nodes.Add(new TreeNode(""));
            TreeNode tNode = Tree.Nodes[0];
            SetTreeNodeView(dom.DocumentElement, tNode);

            // ������� ��� ��������� ������
            AddNodeToTree(dom.DocumentElement, tNode, dom);

            // �������
            Tree.Refresh();
            
            // ������ ������ XML
            return dom;
        }
        // �������� ����
        static private void AddNodeToTree(XmlNode inXmlNode, TreeNode inTreeNode, XmlDocument dom)
        {
            // ���� ���� �������� �� ���� ������
            if (inXmlNode.HasChildNodes)
            {
                // ������� �� ���� source ���������
                int iNum = 0;
                XmlNodeList nodeList = inXmlNode.ChildNodes;
                for (int i = 0; i <= nodeList.Count - 1; i++)
                {
                    // ������� ������� source
                    XmlNode xNode = inXmlNode.ChildNodes[i];
                    if (xNode.Name != "source")
                        continue;

                    // ������� ���� � ����� ������
                    inTreeNode.Nodes.Add(new TreeNode(""));
                    TreeNode tNode = inTreeNode.Nodes[iNum++];
                    SetTreeNodeView(xNode, tNode);

                    // ������� ������� 
                    AddNodeToTree(xNode, tNode, dom);
                }
            }
        }
        // ����������������� ������� ������ �� XML �������� source
        static private void SetTreeNodeView(XmlNode inXmlNode, TreeNode tNode)
        {
            // ������� ���
            tNode.Text = GetChildElementValueByName(inXmlNode, "name");
            
            // ������� ������
            int iIndex=Convert.ToInt16(GetChildElementValueByName(inXmlNode, "icon"));
            tNode.ImageIndex = tNode.SelectedImageIndex = iIndex;
            
            // ������� ��������� �������������
            if (GetChildElementValueByName(inXmlNode, "expand") == "true")
            {
                if (tNode.Parent != null && !tNode.Parent.IsExpanded)
                {
                    tNode.Expand();
                    tNode.Parent.Expand();
                }
            }

            // ������� XML ������ ��������������� � ���� �����
            tNode.Tag = inXmlNode;

        }
        #endregion

        #region ������ � XML
        // ������ �������� ��������� ���������
        static public void SetChildElementValueByName(XmlNode inXmlNode, string sName, string sValue, XmlDocument dom)
        {
            // ������� �� �������������
            XmlNodeList nodeList = inXmlNode.ChildNodes;
            for (int i = 0; i <= nodeList.Count - 1; i++)
            {
                // ������ �������� ������� � ����� ������
                XmlNode xNode = inXmlNode.ChildNodes[i];
                if (xNode.Name != sName)
                    continue;

                // ����� - ������� ��������
                xNode.InnerText = sValue;
            }
            
            // ���� ������ ��� - ���� �������
            XmlElement elementDom = dom.CreateElement(sName);
            elementDom.InnerText = sValue;
            inXmlNode.AppendChild(elementDom);
        }        
        // ������� �������� ��������� ���������
        static public string GetChildElementValueByName(XmlNode inXmlNode, string sName)
        {
            // ������� �� �������������
            XmlNodeList nodeList = inXmlNode.ChildNodes;
            for (int i = 0; i <= nodeList.Count - 1; i++)
            {
                // ������ �������� ������� � ����� ������
                XmlNode xNode = inXmlNode.ChildNodes[i];
                if (xNode.Name != sName)
                    continue;

                // ������ ��� ��������
                return xNode.InnerText;
            }
            
            return null;
        }
        // ��������� ������������ ���� XML
        private static void BuildDynamicXMLElement(XmlNode inXmlNode, string sAddPath, XmlDocument dom)
        {
            // �������� � ������� �� ������� ������������
            if (GetChildElementValueByName(inXmlNode, "folder") == null)
                return;

            // ���� � ����� ��� ��� �����
            string sPath = GetChildElementValueByName(inXmlNode, "folder");
            sPath = sAddPath + sPath + "\\";

            // ������� ��� ���� ������
            List<string> aFilesAndFolders = new List<string>();
            FolderTools.GetAllFilesInFolder(sPath, "*.*", false, false, false, aFilesAndFolders);

            // ��������� ��������� �� ���� �����
            for (int i = 0; i < aFilesAndFolders.Count; i++)
            {
                string sPathName = aFilesAndFolders[i];
                string sRelPath = sPathName.Substring(sPath.Length);

                // �������� � ������� �������
                XmlElement elementDom = dom.CreateElement("source");
                inXmlNode.AppendChild(elementDom);

                // ������� ��� �������� ����
                SetChildElementValueByName(elementDom, "name", sRelPath, dom);
                SetChildElementValueByName(elementDom, "expand", "false", dom);

                // �������� ����
                string sPath1 = Application.StartupPath + "\\";
                sPath1 = sPathName.Substring(sPath1.Length);
                int index = sPath1.IndexOf(".");
                if (index == -1)
                    sPath1 = sPath1 + ".php";
                sPath1 = sPath1.ToLower();

                // ������� ����
                SetChildElementValueByName(elementDom, "url", "http://humanemulator.info/file.php/?file=" + sPath1, dom);

                // ������� ������� ���
                if (Directory.Exists(sPathName))
                {
                    // ����� � �������
                    SetChildElementValueByName(elementDom, "icon", "3", dom);
                    SetChildElementValueByName(elementDom, "folder", "", dom);
                }
                else
                {
                    // ����
                    SetChildElementValueByName(elementDom, "icon", "7", dom);
                    SetChildElementValueByName(elementDom, "file", sPathName, dom);

                }
            }

            // ��������� �� ����� � ���� ����� � ��������� �������� �� ���
            for (int i = 0; i < inXmlNode.ChildNodes.Count; i++)
            {
                XmlNode elementDom = inXmlNode.ChildNodes[i];
                // ������ ��� source
                if (elementDom.Name != "source")
                    continue;
                // ������ ��� �����
                if (GetChildElementValueByName(elementDom, "folder") == null)
                    continue;
                // �������� ��������
                BuildDynamicXMLElement(elementDom, sAddPath + GetChildElementValueByName(inXmlNode, "folder") + "\\" + GetChildElementValueByName(elementDom, "name"), dom);
            }
        }
        #endregion
        
   }
}
