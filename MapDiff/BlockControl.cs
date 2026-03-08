using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapDiff
{
    public partial class BlockControl : UserControl
    {
        private HashSet<string> untouchedBlocks = new HashSet<string>();
        private List<string> removedBlocks = new List<string>();
        private List<string> addedBlocks = new List<string>();

        private bool addedBlock;
        private bool removedBlock;

        public BlockControl()
        {
            InitializeComponent();
        }

        public void SetUntouched(string name)
        {
            untouchedBlocks.Add(name);
        }

        public void SetRemoved(string name)
        {
            removedBlocks.Add(name);
            removedBlock = true;
            SetAddedAndRemoved(addedBlock, removedBlock);
        }

        public void SetAdded(string name)
        {
            addedBlocks.Add(name);
            addedBlock = true;
            SetAddedAndRemoved(addedBlock, removedBlock);
        }

        public void SetAddedAndRemoved(bool added, bool removed)
        {
            addedBlock = added;
            removedBlock = removed;
            if (addedBlock)
            {
                if (removedBlock)
                {
                    BackColor = Color.Yellow;
                }
                else
                {
                    BackColor = Color.Green;
                }
            }
            else if (removedBlock)
            {
                BackColor = Color.Red;
            }
        }

        private void BlockControl_Click(object sender, EventArgs e)
        {
            BlockDiffView blockDiffView = new BlockDiffView();
            blockDiffView.SetDiffs(untouchedBlocks, addedBlocks, removedBlocks);
            blockDiffView.Show(this);
        }

        private void BlockControl_MouseHover(object sender, EventArgs e)
        {
            hoverToolTip.ShowAlways = true;
            hoverToolTip.Show($"Untouched: {string.Join(",\n ", untouchedBlocks)}\nAdded: {string.Join(",\n ", addedBlocks)}\nRemoved: {string.Join(",\n ", removedBlocks)}", this, 5000);
        }
    }
}
