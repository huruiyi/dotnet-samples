using System;
using System.Drawing;
using System.Windows.Forms;
using WfApp.Infrastructure;

namespace WfApp
{
    public partial class ExplorerSample : Form
    {
        private DirectoryView _dir;

        public ExplorerSample()
        {
            InitializeComponent();
        }

        private void SetTitle(FileView fv)
        {
            this.Text = fv.Name;
            this.Icon = fv.Icon;
        }

        private void ExplorerSample_Load(object sender, EventArgs e)
        {
            thumbnailsMenuItem.CheckOnClick = true;
            tilesMenuItem.CheckOnClick = true;
            iconsMenuItem.CheckOnClick = true;
            listMenuItem.CheckOnClick = true;
            detailsMenuItem.CheckOnClick = true;

            DataGridViewImageColumn dataGridViewIcon = new DataGridViewImageColumn
            {
                Name = "Icon",
                DataPropertyName = "Icon",
                HeaderText = "",
                Width = 20
            };

            DataGridViewTextBoxColumn dataGridViewName = new DataGridViewTextBoxColumn
            {
                Name = "Name",
                DataPropertyName = "Name",
                HeaderText = "名称",
                Width = 400
            };

            DataGridViewTextBoxColumn dataGridViewSize = new DataGridViewTextBoxColumn
            {
                Name = "SizeCol",
                DataPropertyName = "Size",
                HeaderText = "大小"
            };

            DataGridViewTextBoxColumn dataGridViewType = new DataGridViewTextBoxColumn
            {
                Name = "Type",
                DataPropertyName = "Type",
                HeaderText = "类型"
            };
            DataGridViewTextBoxColumn dataGridViewDateModified = new DataGridViewTextBoxColumn
            {
                Name = "DateModified",
                DataPropertyName = "DateModified",
                HeaderText = "修改日期"
            };

            dataGridView1.Columns.Add(dataGridViewIcon);
            dataGridView1.Columns.Add(dataGridViewName);
            dataGridView1.Columns.Add(dataGridViewSize);
            dataGridView1.Columns.Add(dataGridViewType);
            dataGridView1.Columns.Add(dataGridViewDateModified);

            _dir = new DirectoryView();
            this.FileViewBindingSource.DataSource = _dir;

            SetTitle(_dir.FileView);

            DataGridViewColumn col = this.dataGridView1.Columns["Size"];

            if (null != col)
            {
                DataGridViewCellStyle style = col.HeaderCell.Style;

                style.Padding = new Padding(style.Padding.Left, style.Padding.Top, 6, style.Padding.Bottom);
                style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            col = this.dataGridView1.Columns["Name"];

            if (null != col)
            {
                this.dataGridView1.Rows[0].Cells[col.Index].Selected = true;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "SizeCol")
            {
                long size = (long)e.Value;

                if (size < 0)
                {
                    e.Value = "";
                }
                else
                {
                    size = ((size + 999) / 1000);
                    e.Value = size.ToString() + " " + "KB";
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Icon icon = (e.Value as Icon);

            if (null != icon)
            {
                using (SolidBrush b = new SolidBrush(e.CellStyle.BackColor))
                {
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }

                e.Graphics.DrawIcon(icon, e.CellBounds.Width - icon.Width - 1, e.CellBounds.Y + 1);
                e.Handled = true;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    _dir.Activate(this.FileViewBindingSource[e.RowIndex] as FileView);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                _dir.Activate(this.FileViewBindingSource[e.RowIndex] as FileView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region 工具栏

        private void backSplitButton_Click(object sender, EventArgs e)
        {
            _dir.Up();
        }

        private void forwardSplitButton_Click(object sender, EventArgs e)
        {
        }

        private void upSplitButton_ButtonClick(object sender, EventArgs e)
        {
            _dir.Up();
        }

        private void ClearItems(ToolStripMenuItem selected)
        {
            // Clear items
            foreach (ToolStripMenuItem child in viewSplitButton.DropDownItems)
            {
                if (child != selected)
                {
                    child.Checked = false;
                }
            }
        }

        private bool DoActionRequired(object sender)
        {
            ToolStripMenuItem item = (sender as ToolStripMenuItem);
            bool doAction;

            ClearItems(item);

            if (!item.Checked)
            {
                item.Checked = true;
                doAction = false;
            }
            else
            {
                doAction = true;
            }

            return doAction;
        }

        private void thumbnailsMenuItem_Click(object sender, EventArgs e)
        {
            if (DoActionRequired(sender))
            {
                MessageBox.Show("Thumbnails View");
            }
        }

        private void tilesMenuItem_Click(object sender, EventArgs e)
        {
            if (DoActionRequired(sender))
            {
                MessageBox.Show("Tiles View");
            }
        }

        private void iconsMenuItem_Click(object sender, EventArgs e)
        {
            if (DoActionRequired(sender))
            {
                MessageBox.Show("Icons View");
            }
        }

        private void listMenuItem_Click(object sender, EventArgs e)
        {
            if (DoActionRequired(sender))
            {
                MessageBox.Show("List View");
            }
        }

        private void detailsMenuItem_Click(object sender, EventArgs e)
        {
            if (DoActionRequired(sender))
            {
                MessageBox.Show("Details View");
            }
        }

        #endregion 工具栏

        #region Other

        private void toolStripMenuItem4_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (sender as ToolStripMenuItem);

            foreach (ToolStripMenuItem child in viewSplitButton.DropDownItems)
            {
                if (child != item)
                {
                    child.Checked = false;
                }
                else
                {
                    item.Checked = true;
                }
            }
        }

        private void Renderer_RenderToolStripBorder(object sender, ToolStripRenderEventArgs e)
        {
            e.Graphics.DrawLine(SystemPens.ButtonShadow, 0, 1, toolBar.Width, 1);
            e.Graphics.DrawLine(SystemPens.ButtonHighlight, 0, 2, toolBar.Width, 2);
        }

        #endregion Other
    }
}