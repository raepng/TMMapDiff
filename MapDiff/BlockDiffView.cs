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
    public partial class BlockDiffView : Form
    {
        public BlockDiffView()
        {
            InitializeComponent();
        }

        public void SetDiffs(HashSet<string> untouchedBlocks, List<string> addedBlocks, List<string> removedBlocks)
        {
            foreach (string block in untouchedBlocks)
            {
                diffListBox.Items.Add("Untouched: " + block);
            }

            foreach (string block in addedBlocks)
            {
                diffListBox.Items.Add("Added: " + block);
            }

            foreach (string block in removedBlocks)
            {
                diffListBox.Items.Add("Removed: " + block);
            }
        }
    }
}
