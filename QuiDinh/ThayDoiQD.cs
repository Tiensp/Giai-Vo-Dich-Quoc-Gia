using QLBDBUS;

using QLBDDTO;

using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Data.SqlClient;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Windows.Forms;



namespace QLBDUI.GiaiDauFD.QuiDinh

{

    public partial class ThayDoiQD : Form

    {

        private ThamSoBUS tsBUS;

        private LoaiCauThuBUS lctBUS;

        private LoaiBanThangBUS lbtBUS;

        private List<ThamSoDTO> ListThamSoSTO = new List<ThamSoDTO>();

        private List<LoaiBanThangDTO> ListLoaiBanThangSTO = new List<LoaiBanThangDTO>();

        private int UpdateButt_Clicked = 0;

        List<string> TTXHlist = new List<string>();

        ThemLoaiBT formThemLBT = new ThemLoaiBT();



        public ThayDoiQD()

        {

            InitializeComponent();

        }



        #region Methods

        private void loadForm() //load dữ liệu lên form

        {



        }

        #endregion



        private void dataGridViewLBT_load()

        {

            int i = ListLoaiBanThangSTO.Count;

            //hiển thị lên dgvLBT

            BindingSource bsLBT = new BindingSource();

            bsLBT.DataSource = ListLoaiBanThangSTO;

            dataGridViewLBT.Columns.Clear();

            dataGridViewLBT.DataSource = null;

            dataGridViewLBT.ColumnHeadersVisible = false;



            dataGridViewLBT.AutoGenerateColumns = false;

            dataGridViewLBT.AllowUserToAddRows = false;

            dataGridViewLBT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridViewLBT.DataSource = bsLBT;



            DataGridViewTextBoxColumn clMLBT = new DataGridViewTextBoxColumn();

            clMLBT.Name = "MaLoaiCT";

            clMLBT.HeaderText = "Mã Loại BT";

            clMLBT.DataPropertyName = "MaLoaiBT";

            dataGridViewLBT.Columns.Add(clMLBT);

            clMLBT.Visible = false;



            DataGridViewTextBoxColumn clLBT = new DataGridViewTextBoxColumn();

            clLBT.Name = "LoaiCT";

            clLBT.HeaderText = "Loại BT";

            clLBT.DataPropertyName = "TenLoaiBT";

            dataGridViewLBT.Columns.Add(clLBT);



            dataGridViewLBT.CurrentCell = dataGridViewLBT.Rows[0].Cells[1]; //thiết lập lại currentCell

        }

        private void dataGridViewTTXH_default_load() //load dataGridView TTXH mặc định

        {

            while (dataGridViewTTXH.ColumnCount > 0) //xóa columntable về rỗng

            {

                dataGridViewTTXH.Columns.RemoveAt(0);

            }

            dataGridViewTTXH.AutoGenerateColumns = false;

            dataGridViewTTXH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridViewTTXH.AllowUserToAddRows = false;

            dataGridViewTTXH.ReadOnly = true;



            DataGridViewTextBoxColumn clID = new DataGridViewTextBoxColumn(); //add column

            clID.Name = "ID";

            clID.HeaderText = "ID";

            clID.DataPropertyName = "ID";

            dataGridViewTTXH.Columns.Add(clID);

            clID.Visible = false;

            DataGridViewTextBoxColumn clTTXH = new DataGridViewTextBoxColumn(); //add column

            clTTXH.Name = "TTXH";

            clTTXH.HeaderText = "TTXH";

            clTTXH.DataPropertyName = "TTXH";

            dataGridViewTTXH.Columns.Add(clTTXH);



            DataTable dtTTXH = new DataTable();



            DataColumn dcID = new DataColumn("ID", typeof(string)); //add column

            dtTTXH.Columns.Add(dcID);

            DataColumn dcTTXH = new DataColumn("TTXH", typeof(string)); //add column

            dtTTXH.Columns.Add(dcTTXH);



            DataRow row = dtTTXH.NewRow();

            row["TTXH"] = "Điểm";

            row["ID"] = "0";

            int diemPosition = 0;

            dtTTXH.Rows.InsertAt(row, diemPosition);



            DataRow row1 = dtTTXH.NewRow();

            row1["TTXH"] = "Hiệu số";

            row1["ID"] = "1";

            int hieusoPosition = 1;

            dtTTXH.Rows.InsertAt(row1, hieusoPosition);



            DataRow row2 = dtTTXH.NewRow();

            row2["TTXH"] = "Bàn thắng sân khách";

            row2["ID"] = "2";

            int btskPosition = 2;

            dtTTXH.Rows.InsertAt(row2, btskPosition);



            DataRow row3 = dtTTXH.NewRow();

            row3["TTXH"] = "Kết quả đối kháng";

            row3["ID"] = "3";

            int kqdkPosition = 3;

            dtTTXH.Rows.InsertAt(row3, kqdkPosition);



            dataGridViewTTXH.DataSource = dtTTXH;

            dataGridViewTTXH.ColumnHeadersVisible = false;

        }

        private void dataGridViewTTXH_load(List<string> list) //load dataGridView TTXH

        {

            while (dataGridViewTTXH.ColumnCount > 0) //xóa columntable về rỗng

            {

                dataGridViewTTXH.Columns.RemoveAt(0);

            }



            DataTable dtTTXH = new DataTable();



            DataColumn dcID = new DataColumn("ID", typeof(string)); //add column

            dtTTXH.Columns.Add(dcID);

            DataColumn dcTTXH = new DataColumn("TTXH", typeof(string)); //add column

            dtTTXH.Columns.Add(dcTTXH);



            for (int i = 0; i < list.Count; i++)

            {

                switch (list[i])

                {

                    case "Điểm":

                        {

                            DataRow row = dtTTXH.NewRow();

                            row["TTXH"] = "Điểm";

                            row["ID"] = "0";

                            int diemPosition = i;

                            dtTTXH.Rows.InsertAt(row, diemPosition);

                            break;

                        }

                    case "Hiệu số":

                        {

                            DataRow row1 = dtTTXH.NewRow();

                            row1["TTXH"] = "Hiệu số";

                            row1["ID"] = "1";

                            int hieusoPosition = i;

                            dtTTXH.Rows.InsertAt(row1, hieusoPosition);

                            break;

                        }

                    case "Bàn thắng sân khách":

                        {

                            DataRow row2 = dtTTXH.NewRow();

                            row2["TTXH"] = "Bàn thắng sân khách";

                            row2["ID"] = "2";

                            int btskPosition = i;

                            dtTTXH.Rows.InsertAt(row2, btskPosition);

                            break;

                        }

                    case "Kết quả đối kháng":

                        {

                            DataRow row3 = dtTTXH.NewRow();

                            row3["TTXH"] = "Kết quả đối kháng";

                            row3["ID"] = "3";

                            int kqdkPosition = i;

                            dtTTXH.Rows.InsertAt(row3, kqdkPosition);

                            break;

                        }

                }



            }

            dataGridViewTTXH.AutoGenerateColumns = false;

            dataGridViewTTXH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridViewTTXH.AllowUserToAddRows = false;

            dataGridViewTTXH.ReadOnly = true;



            DataGridViewTextBoxColumn clID = new DataGridViewTextBoxColumn(); //add column

            clID.Name = "ID";

            clID.HeaderText = "ID";

            clID.DataPropertyName = "ID";

            dataGridViewTTXH.Columns.Add(clID);

            clID.Visible = false;

            DataGridViewTextBoxColumn clTTXH = new DataGridViewTextBoxColumn(); //add column

            clTTXH.Name = "TTXH";

            clTTXH.HeaderText = "TTXH";

            clTTXH.DataPropertyName = "TTXH";

            dataGridViewTTXH.Columns.Add(clTTXH);



            dataGridViewTTXH.DataSource = dtTTXH;

            dataGridViewTTXH.ColumnHeadersVisible = false;



            dataGridViewTTXH.ReadOnly = true;

            //xóa data list (cho lần cập nhật sau)

            list.Clear();

        }

        private void loadData() //load data lên form

        {

            ListThamSoSTO.Clear();

            ListThamSoSTO.Add(tsBUS.getData("1"));

            if (ListThamSoSTO[0] != null)

                UpdateButt_Clicked = 1;

            else

            {

                UpdateButt_Clicked = 0;

                ListThamSoSTO.Clear();

                ListThamSoSTO.Add(tsBUS.getData("0"));

            }

            BindingSource bsLCT = new BindingSource();

            BindingSource bsLBT = new BindingSource();



            TuoiCTMinNumericUD.Value = ListThamSoSTO[0].TuoiCTMin;

            TuoiCTMaxNumericUD.Value = ListThamSoSTO[0].TuoiCTMax;

            SoLuongCTMinNumericUD.Value = ListThamSoSTO[0].SoLuongCTMin;

            SoLuongCTMaxNumericUD.Value = ListThamSoSTO[0].SoLuongCTMax;

            SoCTNgoaiMaxNumericUD.Value = ListThamSoSTO[0].SoCTNgoaiMax;

            TGGhiBanMaxNumericUD.Value = ListThamSoSTO[0].TGGhiBanMax / 60;

            WinNumericUD.Value = ListThamSoSTO[0].DiemThang;

            DrawNumericUD.Value = ListThamSoSTO[0].DiemHoa;

            LostNumericUD.Value = ListThamSoSTO[0].DiemThua;

            //truyền data vào DataTable

            DataSet dsLCT = lctBUS.getData();

            DataSet dsLBT = lbtBUS.getData();

            //truyền data LBT vào List

            ListLoaiBanThangSTO = dsLBT.Tables[0].AsEnumerable().Select(DataRow => new LoaiBanThangDTO

            {

                MaLoaiBT = DataRow.Field<string>("MaLoaiBT"),

                TenLoaiBT = DataRow.Field<string>("TenLoaiBT")

            }).ToList();





            //hiển thị lên dgvLCT

            bsLCT.DataSource = dsLCT;

            dataGridViewLCT.Columns.Clear();

            dataGridViewLCT.ColumnHeadersVisible = false;

            dataGridViewLCT.DataSource = null;



            dataGridViewLCT.AutoGenerateColumns = false;

            dataGridViewLCT.AllowUserToAddRows = false;

            dataGridViewLCT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridViewLCT.DataSource = bsLCT;

            dataGridViewLCT.DataMember = "LCT";



            DataGridViewTextBoxColumn clLCT = new DataGridViewTextBoxColumn();

            clLCT.Name = "LoaiCT";

            clLCT.HeaderText = "Loại cầu thủ";

            clLCT.DataPropertyName = "LoaiCauThu";

            dataGridViewLCT.Columns.Add(clLCT);

            dataGridViewLCT.ReadOnly = true;



            //hiển thị lên dgvLBT

            dataGridViewLBT_load();



            //load dataGridVIewTTXH

            if (UpdateButt_Clicked == 0)

                dataGridViewTTXH_default_load();

            else

            {

                TTXHlist = tsBUS.getTTXH(UpdateButt_Clicked.ToString());

                dataGridViewTTXH_load(TTXHlist);

            }



        }





        #region Events



        #endregion



        private void ThayDoiQD_Load(object sender, EventArgs e)

        {

            tsBUS = new ThamSoBUS();

            lctBUS = new LoaiCauThuBUS();

            lbtBUS = new LoaiBanThangBUS();

            loadData();

        }



        private void LBTAddButt_Click(object sender, EventArgs e)

        {

            formThemLBT.FormClosed += new FormClosedEventHandler(formThemLBT_FormClosed);

            formThemLBT.ShowDialog();

        }

        private void LBTRemoveButt_Click(object sender, EventArgs e)

        {

            string dataID = dataGridViewLBT.CurrentRow.Cells[0].Value.ToString();

            string data = dataGridViewLBT.CurrentRow.Cells[1].Value.ToString();

            LoaiBanThangDTO itemtoRemove = ListLoaiBanThangSTO.SingleOrDefault(item => item.MaLoaiBT == dataID);

            ListLoaiBanThangSTO.Remove(itemtoRemove);



            for (int i = 0; i < ListLoaiBanThangSTO.Count; i++) //set lại ID LBT cho List

            {

                ListLoaiBanThangSTO[i].MaLoaiBT = i.ToString();

            }

            dataGridViewLBT_load();

        }

        private void TTXH_UpButt_Click(object sender, EventArgs e)

        {

            int PrevRowIndex = dataGridViewTTXH.CurrentCell.RowIndex - 1;

            if (PrevRowIndex >= 0)

            {

                var tempData1 = dataGridViewTTXH.CurrentRow.Cells[0].Value; //khởi tạo biến temp lưu giữ giá trị

                var tempData = dataGridViewTTXH.CurrentRow.Cells[1].Value;



                dataGridViewTTXH.CurrentRow.Cells[0].Value = dataGridViewTTXH.Rows[PrevRowIndex].Cells[0].Value; //chuyển đổi giá trị giữa 2 dòng

                dataGridViewTTXH.Rows[PrevRowIndex].Cells[0].Value = tempData1;



                dataGridViewTTXH.CurrentRow.Cells[1].Value = dataGridViewTTXH.Rows[PrevRowIndex].Cells[1].Value;//chuyển đổi giá trị giữ 2 dòng

                dataGridViewTTXH.Rows[PrevRowIndex].Cells[1].Value = tempData;



                dataGridViewTTXH.CurrentCell = dataGridViewTTXH.Rows[PrevRowIndex].Cells[1]; //thiết lập lại Current



            }

        }

        private void TTXH_DownButt_Click(object sender, EventArgs e)

        {

            int NextRowIndex = dataGridViewTTXH.CurrentCell.RowIndex + 1;

            if (NextRowIndex < dataGridViewTTXH.RowCount)

            {

                var tempData1 = dataGridViewTTXH.CurrentRow.Cells[0].Value; //khởi tạo biến temp lưu giữ giá trị

                var tempData = dataGridViewTTXH.CurrentRow.Cells[1].Value;



                dataGridViewTTXH.CurrentRow.Cells[0].Value = dataGridViewTTXH.Rows[NextRowIndex].Cells[0].Value; //chuyển đổi giá trị giữa 2 dòng

                dataGridViewTTXH.Rows[NextRowIndex].Cells[0].Value = tempData1;



                dataGridViewTTXH.CurrentRow.Cells[1].Value = dataGridViewTTXH.Rows[NextRowIndex].Cells[1].Value;//chuyển đổi giá trị giữ 2 dòng

                dataGridViewTTXH.Rows[NextRowIndex].Cells[1].Value = tempData;



                dataGridViewTTXH.CurrentCell = dataGridViewTTXH.Rows[NextRowIndex].Cells[1]; //thiết lập lại Current



            }

        }



        private void formThemLBT_FormClosed(object sender, FormClosedEventArgs e)

        {

            if (formThemLBT.AddStatus == true)

            {

                LoaiBanThangDTO lbt_DTO = new LoaiBanThangDTO();

                lbt_DTO.MaLoaiBT = ListLoaiBanThangSTO.Count().ToString();

                lbt_DTO.TenLoaiBT = formThemLBT.send_data();

                ListLoaiBanThangSTO.Add(lbt_DTO);



                BindingSource bsLBT = new BindingSource();

                bsLBT.DataSource = ListLoaiBanThangSTO;

                dataGridViewLBT.Columns.Clear();

                dataGridViewLBT.DataSource = null;

                dataGridViewLBT.ColumnHeadersVisible = false;



                dataGridViewLBT.AutoGenerateColumns = false;

                dataGridViewLBT.AllowUserToAddRows = false;

                dataGridViewLBT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dataGridViewLBT.DataSource = bsLBT;



                DataGridViewTextBoxColumn clMLBT = new DataGridViewTextBoxColumn();

                clMLBT.Name = "MaLoaiCT";

                clMLBT.HeaderText = "Mã Loại BT";

                clMLBT.DataPropertyName = "MaLoaiBT";

                dataGridViewLBT.Columns.Add(clMLBT);

                clMLBT.Visible = false;



                DataGridViewTextBoxColumn clLBT = new DataGridViewTextBoxColumn();

                clLBT.Name = "LoaiBT";

                clLBT.HeaderText = "Loại BT";

                clLBT.DataPropertyName = "TenLoaiBT";

                dataGridViewLBT.Columns.Add(clLBT);



                dataGridViewLBT.CurrentCell = dataGridViewLBT.Rows[0].Cells[1]; //thiết lập lại currentCell

            }



            formThemLBT = new ThemLoaiBT();

        }



        private void UpdateButt_Click(object sender, EventArgs e)

        {

            ThamSoDTO ts = new ThamSoDTO();

            //check Tuổi CT 

            if (TuoiCTMinNumericUD.Value <= TuoiCTMaxNumericUD.Value)

            {

                ts.TuoiCTMin = (int)TuoiCTMinNumericUD.Value;

                ts.TuoiCTMax = (int)TuoiCTMaxNumericUD.Value;

            }

            else

            {

                MessageBox.Show("Qui định tuổi cầu thủ không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                TuoiCTMinNumericUD.Select();

                return;

            }

            //check Số lượng CT

            if (SoLuongCTMinNumericUD.Value <= SoLuongCTMaxNumericUD.Value)

            {

                ts.SoLuongCTMin = (int)SoLuongCTMinNumericUD.Value;

                ts.SoLuongCTMax = (int)SoLuongCTMaxNumericUD.Value;

            }

            else

            {

                MessageBox.Show("Qui định số lượng cầu thủ không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                SoLuongCTMinNumericUD.Select();

                return;

            }

            //check Số lượng cầu thủ ngoại tối đa

            if (SoCTNgoaiMaxNumericUD.Value <= SoLuongCTMaxNumericUD.Value)

            {

                ts.SoCTNgoaiMax = (int)SoCTNgoaiMaxNumericUD.Value;

            }

            else

            {

                MessageBox.Show("Số cầu thủ ngoại phải nhỏ hơn số cầu thủ tối đa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                SoCTNgoaiMaxNumericUD.Select();

                return;

            }

            //check thời gian ghi bàn tối đa

            ts.TGGhiBanMax = (int)TGGhiBanMaxNumericUD.Value * 60; //covert phút sang giây

            //check điểm thắng - hòa - thua

            if (LostNumericUD.Value < DrawNumericUD.Value && DrawNumericUD.Value < WinNumericUD.Value)

            {

                ts.DiemThang = (int)WinNumericUD.Value;

                ts.DiemHoa = (int)DrawNumericUD.Value;

                ts.DiemThua = (int)LostNumericUD.Value;

            }

            else

            {

                MessageBox.Show("Qui định điểm không hợp lệ: Điểm Thua<Điểm Hòa<Điểm thắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                WinNumericUD.Select();

                return;

            }

            //check Loại bàn thắng

            int iStop = ListLoaiBanThangSTO.Count;

            lbtBUS.deleteData();

            for (int i = 0; i < iStop; i++)

            {

                lbtBUS.them(ListLoaiBanThangSTO[i]);

            }



            //cập nhật TTXH

            for (int i = 0; i < dataGridViewTTXH.RowCount; i++)

            {

                int a = Int32.Parse(dataGridViewTTXH.Rows[i].Cells[0].Value.ToString());

                switch (a)

                {

                    case 0:

                        {

                            ts.Diem = i;

                            break;

                        }

                    case 1:

                        {

                            ts.HieuSo = i;

                            break;

                        }

                    case 2:

                        {

                            ts.BTSK = i;

                            break;

                        }

                    case 3:

                        {

                            ts.KQDK = i;

                            break;

                        }

                }



            }

            //thêm Mã Tham Số 

            ts.MaThamSo = "1";



            //thêm vào database

            tsBUS.addData(ts);

            //load lại dữ liệu lên form

            UpdateButt_Clicked = 1;

            loadData();

        }



        private void DefaultButt_Click(object sender, EventArgs e)

        {

            tsBUS.deleteData();

            lbtBUS.deleteData();

            LoaiBanThangDTO lbt = new LoaiBanThangDTO();

            lbt.MaLoaiBT = "0";

            lbt.TenLoaiBT = "A";

            lbtBUS.them(lbt);

            LoaiBanThangDTO lbt1 = new LoaiBanThangDTO();

            lbt1.MaLoaiBT = "1";

            lbt1.TenLoaiBT = "B";

            lbtBUS.them(lbt1);

            LoaiBanThangDTO lbt2 = new LoaiBanThangDTO();

            lbt2.MaLoaiBT = "2";

            lbt2.TenLoaiBT = "C";

            lbtBUS.them(lbt2);

            UpdateButt_Clicked = 0;

            loadData();



        }

    }

}