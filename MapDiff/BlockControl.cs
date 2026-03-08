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

        private bool onlyGrass = false;
        private bool showGrass = false;

        private Action<MouseEventArgs>? mouseMoveCallback;

        public BlockControl()
        {
            InitializeComponent();
        }

        public void SetShowGrass(bool show)
        {
            showGrass = show;
            UpdateColors(addedBlock, removedBlock);
        }

        public void SetUntouched(string name)
        {
            untouchedBlocks.Add(name);
            if(!name.ToLower().Equals("grass"))
            {
                onlyGrass = false;
            }
            UpdateColors(addedBlock, removedBlock);
        }

        public void SetRemoved(string name)
        {
            removedBlocks.Add(name);
            onlyGrass = false;
            removedBlock = true;
            UpdateColors(addedBlock, removedBlock);
        }

        public void SetAdded(string name)
        {
            addedBlocks.Add(name);
            onlyGrass = false;
            addedBlock = true;
            UpdateColors(addedBlock, removedBlock);
        }

        private void UpdateColors(bool added, bool removed)
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
            else if (untouchedBlocks.All(b => b.ToLower().Equals("grass")))
            {
                onlyGrass = true;
                if (showGrass)
                {
                    BackColor = Color.Beige;
                }
                else
                {
                    BackColor = Color.Black;
                }
            }
            else
            {
                BackColor = Color.LightBlue;
            }
        }

        private void BlockControl_MouseHover(object sender, EventArgs e)
        {
            if(!onlyGrass || showGrass)
            {
                hoverToolTip.ShowAlways = true;
                hoverToolTip.Show($"Untouched: {string.Join(",\n ", untouchedBlocks)}\nAdded: {string.Join(",\n ", addedBlocks)}\nRemoved: {string.Join(",\n ", removedBlocks)}", this, 5000);
            }
            else
            {
                hoverToolTip.ShowAlways = false;
            }
        }

        private void BlockControl_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMoveCallback?.Invoke(e);
        }

        internal void SetMoveCallback(Action<MouseEventArgs> onMouseMove)
        {
            this.mouseMoveCallback = onMouseMove;
        }

        private void BlockControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (!onlyGrass || showGrass))
            {
                BlockDiffView blockDiffView = new BlockDiffView();
                blockDiffView.SetDiffs(untouchedBlocks, addedBlocks, removedBlocks);
                blockDiffView.Show(this);
            }
        }
    }
}
