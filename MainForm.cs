namespace scratchpad;


public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void richTextBox_KeyUp(object sender, KeyEventArgs e)
    {
        this.timer.Stop();
        this.timer.Start();
    }

    private void MainForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            this.richTextBox.Visible = true;
            this.richTextBox.Enabled = true;
            this.richTextBox.Focus();
            this.timer.Stop();
            this.timer.Start();
            e.Handled = true;
        }
        if (e.KeyCode == Keys.F2)
        {
            this.richTextBox.Visible = false;
            this.richTextBox.Enabled = false;
            this.richTextBox.Focus();
            this.timer.Stop();
            this.timer.Start();
            e.Handled = true;
        }


    }

    private void timer_Tick(object sender, EventArgs e)
    {
        this.richTextBox.Visible = false;
        this.richTextBox.Enabled = false;
    }

}
