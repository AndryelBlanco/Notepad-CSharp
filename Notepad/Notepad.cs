using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Notepad_Neo : Form
    {
        public Notepad_Neo()
        {
            InitializeComponent();
        }

        private void fechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ApplicationMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            string fileName = "";

            saveDialog.Filter = "Rich Text File (*.rtf)|*.rtf|Plain Text File (*.txt)|*.txt";
            saveDialog.DefaultExt = "*.txt";
            saveDialog.FilterIndex = 1;
            saveDialog.Title = "Salvar arquivo";

            DialogResult result = saveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = saveDialog.FileName;
            }
            else
            {
                return;
            }

            RichTextBoxStreamType stream_type;
            if(saveDialog.FilterIndex == 2)
            {
                stream_type = RichTextBoxStreamType.PlainText;
            }
            else
            {
                stream_type = RichTextBoxStreamType.RichText;
            }

            App_TextArea.SaveFile(fileName, stream_type);
            MessageBox.Show("Arquivo salvo com sucesso!");
        }

        private void fonteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontSelector = new FontDialog();

            if(fontSelector.ShowDialog() == DialogResult.OK)
            {
                App_TextArea.Font = fontSelector.Font;
                //App_TextArea.Font.Size = fontSelector.Font.Size;
            }
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Question Question = new Form_Question();

            DialogResult resultQuestion = Question.ShowDialog();
            //DialogResult result = MessageBox.Show("Você realmente quer abrir um novo arquivo ? (Os dados do arquivo atual serão perdido, salve-os primeiro)", "Abir novo arquivo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (resultQuestion == DialogResult.Yes)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                string fileName = "";

                saveDialog.Filter = "Rich Text File (*.rtf)|*.rtf|Plain Text File (*.txt)|*.txt";
                saveDialog.DefaultExt = "*.txt";
                saveDialog.FilterIndex = 1;
                saveDialog.Title = "Salvar arquivo";

                DialogResult result = saveDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    fileName = saveDialog.FileName;
                }
                else
                {
                    return;
                }

                RichTextBoxStreamType stream_type;
                if (saveDialog.FilterIndex == 2)
                {
                    stream_type = RichTextBoxStreamType.PlainText;
                }
                else
                {
                    stream_type = RichTextBoxStreamType.RichText;
                }

                App_TextArea.SaveFile(fileName, stream_type);
                App_TextArea.Text = "";
                MessageBox.Show("Arquivo salvo com sucesso!");
               
            }
            else if(resultQuestion == DialogResult.No)
            {
                App_TextArea.Text = "";

            }
        }
    }
}
