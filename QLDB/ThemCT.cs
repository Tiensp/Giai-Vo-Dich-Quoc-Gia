using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBDDTO;
using QLBDBUS;



namespace QLBDUI.GiaiDauFD.QLDB

{

    public partial class ThemCT : Form

    {
        private LoaiCauThuBUS lctBus = new LoaiCauThuBUS();
        private List<LoaiCauThuDTO> listLCT = new List<LoaiCauThuDTO>();
        private CauThuBUS ctBUS = new CauThuBUS();
        private List<CauThuDTO> listCT = new List<CauThuDTO>();
        private bool butt9wasClicked = false;
        public ThemCT()

        {

            InitializeComponent();

        }



        private void ThemCT_Load(object sender, EventArgs e)//Load loại cầu thủ vào combobox

        {
            listLCT = lctBus.loadLoaiCT();
            foreach  (LoaiCauThuDTO lct in listLCT)
            {
                this.cbxPlayerType.Items.Add(lct.LoaiCauThu);
            }


        }



        private void button9_Click(object sender, EventArgs e)

        {
            bool check = false;//Biến kiểm tra thông tin nhập đã đầy đủ hay chưa.
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                check = true;
                MessageBox.Show("Bạn chưa nhập mã cầu thủ!", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }                
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                check = true;
                MessageBox.Show("Bạn chưa nhập tên cầu thủ!", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(cbxPlayerType.Text))
            {
                check = true;
                MessageBox.Show("Bạn chưa chọn loại cầu thủ!", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if(!check)//biến check kiểm tra mã cầu thủ đã tồn tại hay chưa
            {
                listCT = ctBUS.loadcauthu();

                foreach (CauThuDTO ct in listCT)
                {
                    if (ct.MaCauThu == int.Parse(textBox1.Text))
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                    MessageBox.Show("Mã cầu thủ đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    butt9wasClicked = true;
                    this.Close();
                }
            }           
        }

        public CauThuDTO send_data()//Gửi data cầu thủ mới vào danh sách cầu thủ form thêm đội bóng.
        {
            if(butt9wasClicked)//nếu không chọn lưu cầu thủ vưa nhập sẽ truyền về null
            {
                int loaict = 0;
                foreach (LoaiCauThuDTO lct in listLCT)//load mã loại cầu thủ đã được chọn
                {
                    if (lct.LoaiCauThu == cbxPlayerType.Text) loaict = lct.MaLoaiCT;
                }



                CauThuDTO ct = new CauThuDTO()
                {
                    MaCauThu = int.Parse(textBox1.Text),

                    TenCauThu = textBox2.Text,

                    NgaySinh = dateTimePicker1.Value,

                    TuoiCauThu = DateTime.Now.Year - dateTimePicker1.Value.Year,

                    MaLoaiCT = loaict,

                    GhiChu = textBox3.Text

                };


                return ct;
            }

            return null;
        }

        private void BackButt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)//Giới hạn chỉ nhập số cho mã cầu thủ
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }

}