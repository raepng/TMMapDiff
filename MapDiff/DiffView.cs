using GBX.NET.Engines.Game;
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
    public partial class DiffView : Form
    {
        private List<Block> oldBlocks = new List<Block>();
        private List<Block> newBlocks = new List<Block>();

        private int maxX;
        private int maxZ;

        private int progress;

        public DiffView()
        {
            InitializeComponent();
        }

        public void LoadDiff(CGameCtnChallenge oldMap, CGameCtnChallenge newMap)
        {
            progressUpdateTimer.Start();

            maxX = Math.Max(oldMap.Size.X, newMap.Size.X);
            maxZ = Math.Max(oldMap.Size.Z, newMap.Size.Z);

            oldMap.BakedBlocks?.ForEach(b =>
            {
                Block block = ToBlock(b);
                if (!(block.name.Contains("FC") && !block.name.Contains("FCB")))
                {
                    oldBlocks.Add(block);
                }
            });

            newMap.BakedBlocks?.ForEach(b =>
            {
                Block block = ToBlock(b);
                if (!(block.name.Contains("FC") && !block.name.Contains("FCB")))
                {
                    newBlocks.Add(block);
                }
            });

            oldMap.AnchoredObjects?.ForEach(b =>
            {
                Block block = ToBlock(b);
                if (!(block.name.Contains("FC") && !block.name.Contains("FCB")))
                {
                    oldBlocks.Add(block);
                }
            });

            newMap.AnchoredObjects?.ForEach(b =>
            {
                Block block = ToBlock(b);
                if (!(block.name.Contains("FC") && !block.name.Contains("FCB")))
                {
                    newBlocks.Add(block);
                }
            });

            CalcDiff();
            PopulateTable();

            progressUpdateTimer.Stop();
            diffCalcProgress.Value = 100;
            diffCalcProgress.Update();
        }

        private void PopulateTable()
        {
            BlockControl[,] blockControls = new BlockControl[maxX, maxZ];

            int totalBlocks = oldBlocks.Count + newBlocks.Count;
            int currentBlock = 0;

            foreach (var block in oldBlocks)
            {
                if (blockControls[(int)block.x, (int)block.z] == null)
                {
                    blockControls[(int)block.x, (int)block.z] = new BlockControl();
                }
                if (block.removedBlock)
                {
                    blockControls[(int)block.x, (int)block.z].SetRemoved(block.name);

                    addedRemovedListBox.Items.Add($"Removed: {block.name} at ({block.x}, {block.y}, {block.z})");
                }
                else
                {
                    blockControls[(int)block.x, (int)block.z].SetUntouched(block.name);
                }
                currentBlock++;
                progress = (int)((currentBlock / (float)totalBlocks) * 50 + 50);
            }
            foreach (var block in newBlocks)
            {
                if (blockControls[(int)block.x, (int)block.z] == null)
                {
                    blockControls[(int)block.x, (int)block.z] = new BlockControl();
                }
                if (block.addedBlock)
                {
                    blockControls[(int)block.x, (int)block.z].SetAdded(block.name);

                    addedRemovedListBox.Items.Add($"Added: {block.name} at ({block.x}, {block.y}, {block.z})");
                }
                else
                {
                    blockControls[(int)block.x, (int)block.z].SetUntouched(block.name);
                }
                currentBlock++;
                progress = (int)((currentBlock / (float)totalBlocks) * 50 + 50);
            }

            this.diffViewControl.SetBlocks(blockControls, new BlockControl().Size.Width);
            this.addedRemovedListBox.Update();
        }

        private void CalcDiff()
        {
            int totalBlocks = oldBlocks.Count + newBlocks.Count;
            int currentBlock = 0;
            List<Block> processedBlocks = new List<Block>();

            foreach (var block in oldBlocks)
            {
                currentBlock++;
                progress = (int)((currentBlock / (float)totalBlocks) * 50);
                if (!newBlocks.Any(newBlock => newBlock.x == block.x && newBlock.y == block.y && newBlock.z == block.z))
                {
                    block.SetRemoved();
                }
                processedBlocks.Add(block);
            }

            oldBlocks.Clear();
            oldBlocks.AddRange(processedBlocks);
            processedBlocks.Clear();

            foreach (var block in newBlocks)
            {
                currentBlock++;
                progress = (int)((currentBlock / (float)totalBlocks) * 50);
                if (!oldBlocks.Any(b => b.x == block.x && b.y == block.y && b.z == block.z))
                {
                    block.SetAdded();
                }
                processedBlocks.Add(block);
            }

            newBlocks.Clear();
            newBlocks.AddRange(processedBlocks);
        }

        private Block ToBlock(CGameCtnAnchoredObject b)
        {
            Block block;
            block = new Block
            {
                x = (int)(b.AbsolutePositionInMap.X / 32),
                y = (int)(b.AbsolutePositionInMap.Y),
                z = (int)(b.AbsolutePositionInMap.Z / 32),
                name = b.ItemModel.Id
            };

            return block;
        }

        private Block ToBlock(CGameCtnBlock b)
        {
            Block block;
            if (b.AbsolutePositionInMap.HasValue)
            {
                block = new Block
                {
                    x = (int)(b.AbsolutePositionInMap.Value.X / 32),
                    y = (int)(b.AbsolutePositionInMap.Value.Y),
                    z = (int)(b.AbsolutePositionInMap.Value.Z / 32),
                    name = b.BlockModel.Id
                };
            }
            else
            {
                block = new Block
                {
                    x = b.Coord.X,
                    y = b.Coord.Y,
                    z = b.Coord.Z,
                    name = b.BlockModel.Id
                };
            }

            return block;
        }

        private void progressUpdateTimer_Tick(object sender, EventArgs e)
        {
            diffCalcProgress.Value = progress;
            diffCalcProgress.Update();
        }

        private bool mouseMiddle = false;
        private int prevMouseX = 0;
        private int prevMouseY = 0;

        private void diffViewControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (!mouseMiddle)
                {
                    prevMouseX = e.X;
                    prevMouseY = e.Y;
                    mouseMiddle = true;
                }
                else
                {
                    diffViewControl.Location = new Point(diffViewControl.Location.X + (e.X - prevMouseX), diffViewControl.Location.Y + (e.Y - prevMouseY));
                }
            }
            else
            {
                mouseMiddle = false;
            }
        }

        private void diffViewControl_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue < e.NewValue)
            {
                ppbUpDown.Value = Math.Min(ppbUpDown.Maximum, ppbUpDown.Value + 1);
            }
            else if (e.OldValue > e.NewValue)
            {
                ppbUpDown.Value = Math.Max(ppbUpDown.Minimum, ppbUpDown.Value - 1);
            }
        }

        private int ppbUpDownOldValue = 15;

        private void ppbUpDown_ValueChanged(object sender, EventArgs e)
        {
            diffViewControl.Size = new Size((int)ppbUpDown.Value * maxX, (int)ppbUpDown.Value * maxZ);
            foreach (var item in diffViewControl.Controls)
            {
                var bc = (BlockControl)item;
                bc.Size = new Size((int)ppbUpDown.Value, (int)ppbUpDown.Value);
                bc.Location = new Point((int)(bc.Left * (ppbUpDown.Value / ppbUpDownOldValue)), (int)(bc.Top * (ppbUpDown.Value / ppbUpDownOldValue)));
            }
            ppbUpDownOldValue = (int)ppbUpDown.Value;
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Controls:\nUse the number selector to scale the map.\nUse the middle mouse button to move the map around.\nClick on a tile to get details about what was added and removed there.\n\nTile Colors:\nBlue = Untouched\nRed = Removed\nGreen = Added\n Yellow = Added and Removed\nBeige = Untouched Grass");
        }

        private void showGrassCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in diffViewControl.Controls)
            {
                var blockControl = (BlockControl)item;
                blockControl.SetShowGrass(showGrassCheckBox.Checked);
            }
        }

        public struct Block
        {
            public int x;
            public int y;
            public int z;
            public string name;
            public bool addedBlock;
            public bool removedBlock;

            public void SetAdded()
            {
                addedBlock = true;
                removedBlock = false;
            }

            public void SetRemoved()
            {
                addedBlock = false;
                removedBlock = true;
            }
        }
    }
}
