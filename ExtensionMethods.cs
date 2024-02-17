// adapted from https://ourcodeworld.com/articles/read/1094/how-to-implement-a-copy-cut-and-paste-context-menu-over-a-rich-text-box-in-winforms-c-sharp

namespace scratchpad;

using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;

public static class RichTextBoxExtensions
{
    public static void EnableContextMenu(this RichTextBox rtb)
    {

        if (rtb.ContextMenuStrip == null)
        {
            // Create a ContextMenuStrip without icons
            ContextMenuStrip cms = new();
            cms.ShowImageMargin = false;

            var undo = AddNewMenuItem(cms, "Undo", (sender, e) => rtb.Undo());
            var redo = AddNewMenuItem(cms, "Redo", (sender, e) => rtb.Redo());
            cms.Items.Add(new ToolStripSeparator());
            var cut =  AddNewMenuItem(cms, "Cut", (sender, e) => rtb.Cut());
            var copy = AddNewMenuItem(cms, "Copy", (sender, e) => rtb.Copy());
            var copyBase64 = AddNewMenuItem(cms, "Copy Base64", (sender, e) => Clipboard.SetText(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(rtb.SelectedText))));
            var paste = AddNewMenuItem(cms, "Paste", (sender, e) => rtb.Paste());
            var delete = AddNewMenuItem(cms, "Delete", (sender, e) =>  rtb.SelectedText = "");
            cms.Items.Add(new ToolStripSeparator());
            var selectAll = AddNewMenuItem(cms, "Select All", (sender, e) =>  rtb.SelectAll());

            cms.Opening += (sender, e) =>
            {
                undo.Enabled = !rtb.ReadOnly && rtb.CanUndo;
                redo.Enabled = !rtb.ReadOnly && rtb.CanRedo;
                cut.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
                copy.Enabled = rtb.SelectionLength > 0;
                paste.Enabled = !rtb.ReadOnly && Clipboard.ContainsText();
                delete.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
                selectAll.Enabled = rtb.TextLength > 0 && rtb.SelectionLength < rtb.TextLength;
                copyBase64.Enabled = copy.Enabled;
            };

            // var CopySecureString = new ToolStripMenuItem("Copy PS Secure String");
            // CopySecureString.Click += (sender, e) =>  {



            //     // s
            //     // byte[] data = new byte[s.Length * 2];

            //     // if (s.Length > 0)
            //     // {
            //     //     IntPtr ptr = Marshal.SecureStringToCoTaskMemUnicode(s);

            //     //     try
            //     //     {
            //     //         Marshal.Copy(ptr, data, 0, data.Length);
            //     //     }
            //     //     finally
            //     //     {
            //     //         Marshal.ZeroFreeCoTaskMemUnicode(ptr);
            //     //     }
            //     // }
            //     var bytes = System.Text.Encoding.UTF8.GetBytes(rtb.SelectedText);

            //     var protectedBytes = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);                

            //     Clipboard.SetText(System.Text.Encoding.UTF8.GetString( protectedBytes));
            // };

            // cms.Items.Add(CopySecureString);



   



            rtb.ContextMenuStrip = cms;
        }
    }

    private static ToolStripMenuItem AddNewMenuItem(ContextMenuStrip contextMenuStrip, string Text, System.EventHandler handler)
    {
        var menuItem = new ToolStripMenuItem(Text);
        menuItem.Click += handler;
        contextMenuStrip.Items.Add(menuItem);

        return menuItem;
    }
}