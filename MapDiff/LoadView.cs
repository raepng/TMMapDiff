using GBX.NET;
using GBX.NET.Engines.Game;
using GBX.NET.Extensions;
using GBX.NET.LZO;

namespace MapDiff
{
    public partial class LoadView : Form
    {
        public LoadView()
        {
            InitializeComponent();

            Gbx.LZO = new Lzo();
        }

        private void selectOldBtn_Click(object sender, EventArgs e)
        {
            var res = openMapDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                mapOldTxt.Text = openMapDialog.FileName;
            }
        }

        private void selectNewBtn_Click(object sender, EventArgs e)
        {
            var res = openMapDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                mapNewTxt.Text = openMapDialog.FileName;
            }
        }

        private void showDiffBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CGameCtnChallenge oldMap = Gbx.ParseNode<CGameCtnChallenge>(mapOldTxt.Text);
                CGameCtnChallenge newMap = Gbx.ParseNode<CGameCtnChallenge>(mapNewTxt.Text);
                DiffView diffView = new DiffView();
                diffView.Show();
                diffView.LoadDiff(oldMap, newMap);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading maps: " + ex.Message);
            }
        }
    }
}
