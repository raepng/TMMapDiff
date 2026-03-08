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
                if (!block.name.ToLower().Equals("grass") && !(block.name.Contains("FC") && !block.name.Contains("FCB")))
                {
                    oldBlocks.Add(block);
                }
            });

            newMap.BakedBlocks?.ForEach(b =>
            {
                Block block = ToBlock(b);
                if (!block.name.ToLower().Equals("grass") && !(block.name.Contains("FC") && !block.name.Contains("FCB")))
                {
                    newBlocks.Add(block);
                }
            });

            oldMap.AnchoredObjects?.ForEach(b =>
            {
                Block block = ToBlock(b);
                if (!block.name.ToLower().Equals("grass") && !(block.name.Contains("FC") && !block.name.Contains("FCB")))
                {
                    oldBlocks.Add(block);
                }
            });

            newMap.AnchoredObjects?.ForEach(b =>
            {
                Block block = ToBlock(b);
                if (!block.name.ToLower().Equals("grass") && !(block.name.Contains("FC") && !block.name.Contains("FCB")))
                {
                    newBlocks.Add(block);
                }
            });

            CalcDiff();
            PopulateTable();

            progressUpdateTimer.Stop();
        }

        private void PopulateTable()
        {
            BlockControl[,] blockControls = new BlockControl[maxX, maxZ];

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
                progress = (int)((currentBlock / (float)totalBlocks) * 100);
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
                progress = (int)((currentBlock / (float)totalBlocks) * 100);
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
            if(b.AbsolutePositionInMap.HasValue)
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
