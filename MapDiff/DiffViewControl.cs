using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapDiff
{
    public partial class DiffViewControl : UserControl
    {
        public DiffViewControl()
        {
            InitializeComponent();
        }

        public void SetBlocks(BlockControl[,] blockControls, int blockControlSize)
        {
            this.Size = new Size(blockControls.GetLength(0) * blockControlSize, blockControls.GetLength(1) * blockControlSize);

            for (int x = 0; x < blockControls.GetLength(0); x++)
            {
                for (int z = 0; z < blockControls.GetLength(1); z++)
                {
                    BlockControl blockControl = blockControls[x, z];
                    if(blockControl != null)
                    {
                        blockControl.Location = new Point(x * blockControl.Width, z * blockControl.Height);
                        this.Controls.Add(blockControl);
                    }
                }
            }
        }
    }
}
