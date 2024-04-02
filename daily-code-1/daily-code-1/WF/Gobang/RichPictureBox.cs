using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gobang
{
    class RichPictureBox : PictureBox
    {
        public RichPictureBox()
        {
            this.BackColor = Color.Transparent;
        }
        public void Insert(string pictureName, Image picture, int point_X, int point_Y)
        {
            PictureBox pb = new PictureBox();
            pb.Location = new Point(point_X, point_Y);
            pb.Name = pictureName;
            pb.Size = new Size(picture.Width, picture.Height);
            pb.BackColor = Color.Transparent;
            pb.Image = picture;
            this.Controls.Add(pb);
        }
        public void Remove(string pictureName)
        {
            Control[] controls = this.Controls.Find(pictureName, true);
            if (controls.Length == 0)
                return;
            this.Controls.Remove(controls[0]);
        }
        public void Clear()
        {
            this.Controls.Clear();
        }
    }
}
