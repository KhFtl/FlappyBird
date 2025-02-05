using FlappyBird.Services;
using FlappyBird.Services.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class RecordsForm : Form
    {
        IRecordToFile _recordToFile = Settings.GetCurrentServiceRecord();
        public RecordsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FillTable()
        {
            label1.Text = $"Current Service: {_recordToFile.GetType().Name}";

            List<UserInfo> userInfos = _recordToFile.ReadRecord(Settings.fileName);
            userInfos = userInfos.OrderByDescending(x => x.Score).ToList();
            if (userInfos.Count > 0)
            {
                dataGridView1.Rows.Clear();
                int i = 0;
                foreach (var useInfo in userInfos)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["Name"].Value = useInfo.Name;
                    dataGridView1.Rows[i].Cells["Score"].Value = useInfo.Score;
                    dataGridView1.Rows[i].Cells["StartGame"].Value = useInfo.StartGame.ToLongDateString() + useInfo.StartGame.ToLongTimeString();
                    dataGridView1.Rows[i].Cells["EndGame"].Value = useInfo.EndGame.ToLongDateString() + useInfo.EndGame.ToLongTimeString();
                    i++;
                }
            }
        }

        private void RecordsForm_Shown(object sender, EventArgs e)
        {
            FillTable();
        }

        private void RecordsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
