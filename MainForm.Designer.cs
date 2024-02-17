using System.Drawing.Drawing2D;
using System.Reflection;
using System.Resources;

namespace scratchpad;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Timer timer = null;
    private RichTextBox richTextBox = new RichTextBox();
    private Label label = new Label();
    private ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {

        ResourceManager rm = new ResourceManager( "scratchpad.Resources", Assembly.GetExecutingAssembly());

        this.Icon =  (Icon)rm.GetObject("padlock");

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1024, 512);
        this.BackColor = Color.LightSlateGray;
        this.Text = "Scratchpad";
        this.KeyPreview = true;
        this.KeyDown += new KeyEventHandler(this.MainForm_KeyDown);

        // RichTextBox
        this.richTextBox.BackColor = System.Drawing.Color.FromArgb(0x1f, 0x1f, 0x1f);
        this.richTextBox.ForeColor = System.Drawing.Color.Aqua;
        this.richTextBox.Font = new Font("Consolas", 12);
        this.richTextBox.Location = new Point(0, 0);
        this.richTextBox.Dock = DockStyle.Fill;
        this.richTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox_KeyUp);
        this.richTextBox.EnableContextMenu();
        this.Controls.Add(richTextBox); //here add it to the current form instance
        
        // this.label.AutoSize = true;
        this.label.Width = 600;
        this.label.Height = 150;
        this.label.TextAlign = ContentAlignment.MiddleCenter;
        this.label.Text = "Press F1 to continue";
        this.label.Font = new Font(this.Font.FontFamily, 20);
        this.label.ForeColor = Color.BlueViolet;
        this.label.Top = (this.ClientSize.Height - this.label.Height) / 2;
        this.label.Left = (this.ClientSize.Width - this.label.Width) / 2;
        this.label.Anchor = AnchorStyles.None;
        this.Controls.Add(label);

        // timer
        this.timer = new System.Windows.Forms.Timer(this.components);
        this.timer.Interval = 10000;
        this.timer.Tick += new System.EventHandler(this.timer_Tick);
    }

    #endregion
}
