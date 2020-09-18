using System;
using System.Drawing;
using System.Windows.Forms;

namespace calculatorFormPrj
{
    public partial class formMain : Form
    {
        struct ButtonStruct
        {
            public char Content;
            public bool IsBold;

            public ButtonStruct(char content, bool isBold)
            {
                this.Content = content;
                this.IsBold = isBold;
            }
            //per noi oggetto .tostring fa gia rappresentazione stringa del content
            public override string ToString()
            {
                return Content.ToString();
            }

        }
        private ButtonStruct[,] buttons =
        {
            {new ButtonStruct(' ',false),new ButtonStruct(' ',false),new ButtonStruct(' ',false),new ButtonStruct(' ',false)},
            {new ButtonStruct(' ',false),new ButtonStruct(' ',false),new ButtonStruct(' ',false),new ButtonStruct('/',false)},
            {new ButtonStruct('7',true),new ButtonStruct('8',true),new ButtonStruct('9',true),new ButtonStruct('x',false)},
            {new ButtonStruct('4',true),new ButtonStruct('5',true),new ButtonStruct('6',true),new ButtonStruct('-',false)},
            {new ButtonStruct('1',true),new ButtonStruct('2',true),new ButtonStruct('3',true),new ButtonStruct('+',false)},
            {new ButtonStruct('±',false),new ButtonStruct('0',true),new ButtonStruct(',',false),new ButtonStruct('=',false)}
        };

        private RichTextBox resultBox;

        public formMain()
        {
            InitializeComponent();

        }

        private void formMain_Load(object sender, EventArgs e)
        {
            MakeResultBox(resultBox);
            MakeButtons(buttons);
        }

        private void MakeResultBox(RichTextBox resultBox)
        {
            resultBox = new RichTextBox();
            resultBox.Font = new Font("Segoe UI", 22);
            resultBox.SelectionAlignment = HorizontalAlignment.Right;
            resultBox.Width = this.Width - 16;
            resultBox.Height = 50;
            resultBox.Top = 40;
            resultBox.ReadOnly = true;
            this.Controls.Add(resultBox);

        }

        private void MakeButtons(ButtonStruct[,] buttons)
        {
            int buttonWidth = 82, buttonHeight = 60;
            int posX = 0, posY = 101;
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    Button newButton = new Button();
                    newButton.Font = new Font("Segoe UI", 16);
                    //override: newButton.Text = buttons[i,j].ToString();
                    ButtonStruct bs = buttons[i, j];
                    newButton.Text = bs.Content.ToString();
                    if (bs.IsBold)
                    {
                        newButton.Font = new Font(newButton.Font, FontStyle.Bold);
                    }
                    newButton.Width = buttonWidth;
                    newButton.Height = buttonHeight;
                    newButton.Left = posX;
                    newButton.Top = posY;
                    this.Controls.Add(newButton);
                    posX += buttonWidth;
                }
                posX = 0;
                posY += buttonHeight;
            }

        }
    }
}
