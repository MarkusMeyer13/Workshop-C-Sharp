namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Button button = new Button();
            button.Location = new Point(192, 186);
            button.Name = "button1";
            button.Size = new Size(112, 34);
            button.TabIndex = 1;
            this.Controls.Add(button);
        }
    }
}