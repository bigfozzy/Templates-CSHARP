using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace XHE._Helper.Tools.GUI
{
    public class MenuItemTools
    {
        // чекнуть меню как радиокнопку
        static public void CheckRadioItem(ToolStripMenuItem miItem,bool bCheck)
        {
            // зазадим чекнутость
            miItem.Checked = bCheck;
            // зададим состояние
            if (miItem.Checked)
                miItem.CheckState = CheckState.Indeterminate;
            else
                miItem.CheckState = CheckState.Unchecked;            
        }

        // клонировань меню
        public static ToolStripMenuItem Clone(ToolStripMenuItem aMenuItem)
        {
            ToolStripMenuItem aClone= new ToolStripMenuItem(aMenuItem.Text,aMenuItem.Image,null,aMenuItem.ShortcutKeys);
            aClone.Visible = true;
            aClone.Enabled = aMenuItem.Enabled;
            aClone.Size = aMenuItem.Size;
            aClone.TextAlign = aMenuItem.TextAlign;
            aClone.ImageTransparentColor = aMenuItem.ImageTransparentColor;
            return aClone;
        }
        
        // склонировать элементы меню в другое меню или кнопку
        public static void CloneDropDownMenuFromChildMenuItems(ToolStripDropDownItem tbMenu, ToolStripMenuItem aParentMenuItem)
        {
            for (int i = 0; i < aParentMenuItem.DropDownItems.Count; i++)
            {
                ToolStripMenuItem menuItem = aParentMenuItem.DropDownItems[i] as ToolStripMenuItem;
                if (menuItem != null)
                {                    
                    ToolStripMenuItem aClone = Clone(menuItem);
                    tbMenu.DropDownItems.Add(aClone);

                    // подменю
                    if (menuItem.DropDownItems.Count != 0)
                        CloneDropDownMenuFromChildMenuItems(aClone, menuItem);
                }
                else
                    tbMenu.DropDownItems.Add(new ToolStripSeparator());                
            }
        }
        
        // склонировать элементы меню в другое меню или кнопку
        public static void CloneContextFromChildMenuItems(ContextMenuStrip tbMenu, ToolStripMenuItem aParentMenuItem)
        {
            for (int i = 0; i < aParentMenuItem.DropDownItems.Count; i++)
            {
                ToolStripMenuItem menuItem = aParentMenuItem.DropDownItems[i] as ToolStripMenuItem;
                if (menuItem != null)
                {                    
                    ToolStripMenuItem aClone = Clone(menuItem);
                    tbMenu.Items.Add(aClone);
    
                    // подменю
                    if (menuItem.DropDownItems.Count!=0)
                        CloneDropDownMenuFromChildMenuItems(aClone, menuItem);
                }
                else
                    tbMenu.Items.Add(new ToolStripSeparator());                
                
            }
        }
        

    }
}
