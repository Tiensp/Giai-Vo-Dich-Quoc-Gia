using QLBDBUS;
using QLBDDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBDUI.GiaiDauFD.QuiDinh
{
    public partial class ThemLoaiBT : Form
    {
        private bool addStatus;
        public ThemLoaiBT()
        {
            InitializeComponent();
        }

        public bool AddStatus { get => addStatus; set => addStatus = value; }
        #region Methods
        public string send_data()
        {
            string data = textBox1.Text;
            return data;
        }
        #endregion
        private void AddButt_Click(object sender, EventArgs e)
        {
            AddStatus = true;
            this.Close();
        }

        #region Events
        #endregion

        private void CancelButt_Click(object sender, EventArgs e)
        {
            AddStatus = false;
            this.Close();
        }

        private void ThemLoaiBT_Load(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }
    }
}
