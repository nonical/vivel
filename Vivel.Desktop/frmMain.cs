using System;
using System.Windows.Forms;
using Vivel.Desktop.Hospital;
using Vivel.Desktop.Resources.Drive;
using Vivel.Desktop.Resources.FAQ;
using Vivel.Desktop.Resources.PresetBadge;
using Vivel.Desktop.Resources.Report;
using Vivel.Desktop.Resources.User;

namespace Vivel.Desktop
{
    public partial class frmMain : Form
    {
        private int childFormNumber = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void hospitalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleanMdiParent();

            var form = new frmHospital
            {
                MdiParent = this,
                Dock = DockStyle.Fill
            };

            form.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleanMdiParent();

            var form = new frmUser
            {
                MdiParent = this,
                Dock = DockStyle.Fill
            };

            form.Show();
        }

        private void drivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleanMdiParent();

            var form = new frmDrive
            {
                MdiParent = this,
                Dock = DockStyle.Fill
            };

            form.Show();
        }

        private void fAQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleanMdiParent();

            var form = new frmFAQ()
            {
                MdiParent = this,
                Dock = DockStyle.Fill
            };

            form.Show();
        }

        private void cleanMdiParent()
        {
            if (Application.OpenForms.Count > 1)
                Application.OpenForms[1]?.Close();
        }

        private void presetBadgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleanMdiParent();

            var form = new frmPresetBadge()
            {
                MdiParent = this,
                Dock = DockStyle.Fill
            };

            form.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleanMdiParent();

            var form = new frmReport()
            {
                MdiParent = this,
                Dock = DockStyle.Fill
            };

            form.Show();
        }
    }
}
