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

namespace QLBDUI.GiaiDauFD.QLDB
{
    public partial class themMoiDB : Form
    {
        private DoiBongBUS dbBUS;
        private CauThuBUS ctBUS = new CauThuBUS();
        private List<CauThuDTO> ListCauThuSTO = new List<CauThuDTO>();
        private ThemCT formthemCT = new ThemCT();
        private capNhatCT formcapnhat;
        private int socauthungoai = 0;
        public themMoiDB()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void load_data_ct()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = ListCauThuSTO;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "Ma";
            clMa.HeaderText = "Mã Cầu Thủ";
            clMa.DataPropertyName = "MaCauThu";
            dataGridView1.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "Ten";
            clTen.HeaderText = "Tên Câu Thủ";
            clTen.DataPropertyName = "TenCauThu";
            dataGridView1.Columns.Add(clTen);

            DataGridViewTextBoxColumn clNgaySinh = new DataGridViewTextBoxColumn();
            clNgaySinh.Name = "NgaySinh";
            clNgaySinh.HeaderText = "Ngày sinh";
            clNgaySinh.DataPropertyName = "NgaySinh";
            dataGridView1.Columns.Add(clNgaySinh);

            DataGridViewTextBoxColumn clLoaiCauThu = new DataGridViewTextBoxColumn();
            clLoaiCauThu.Name = "LoaiCauThu";
            clLoaiCauThu.HeaderText = "Loại Câu Thủ";
            clLoaiCauThu.DataPropertyName = "MaLoaiCT";
            dataGridView1.Columns.Add(clLoaiCauThu);

            DataGridViewTextBoxColumn clGhiChu = new DataGridViewTextBoxColumn();
            clGhiChu.Name = "GhiChu";
            clGhiChu.HeaderText = "Ghi chú";
            clGhiChu.DataPropertyName = "GhiChu";
            dataGridView1.Columns.Add(clGhiChu);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource];
            myCurrencyManager.Refresh();
        }//Load danh sách cầu thủ vào datagridview

        private void button9_Click(object sender, EventArgs e)
        {
            ///
            bool check = false;//Biến kiểm tra đội bóng đã tồn tại hay chưa.

            List<DoiBongDTO> listdb = dbBUS.load();//Load danh sách các đội bóng đã có trong database.


            if (!string.IsNullOrEmpty(textBox3.Text))
                foreach (DoiBongDTO db in listdb)//Kiểm tra xem đã tồn tại mã đội bóng đã tồn tại trong database.
                {
                
                    if (db.MaDoiBong.ToString() == textBox3.Text)
                    {
                        socauthungoai = db.SoCauThuNgoai;
                        check = true;
                        break;
                    }                  
                }
            if(check)
            {
                DialogResult result = MessageBox.Show("Mã đội bóng đã tồn tại, Bạn có muốn thay đổi thông tin đội bóng này!", "Cần xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)//Nếu đội bóng đã tồn tại và muốn thay đổi thông tin đội bóng đó.
                {

                    List<CauThuDTO> listct = ctBUS.loadcauthu();//Load lại danh sách cầu thủ tất cả cầu thủ.
                    foreach (CauThuDTO ct in listct)
                    {
                        bool ktdata = false;//Biến kiểm tra cầu thủ đã xuất hiện trong datagridview chưa.
                        foreach (CauThuDTO ctdata in ListCauThuSTO)
                        {
                            if(ctdata.MaCauThu == ct.MaCauThu)
                            {
                                ktdata = true;
                                break;
                            }
                        }
                        if(!ktdata)
                            if (ct.MaDoiBong == int.Parse(textBox3.Text))//xét cầu thủ thuộc đội bóng này.
                            {
                                ListCauThuSTO.Add(ct);
                                textBox4.Text = (int.Parse(textBox4.Text) + 1).ToString();                                        
                            }

                    }
                    load_data_ct();
                    DialogResult result2 = MessageBox.Show("Bạn có muốn cập nhật lại danh sách cầu thủ của đội bóng!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result2 == DialogResult.Yes)
                    {
                        socauthungoai = 0;
                        foreach (CauThuDTO ct in ListCauThuSTO)
                        {
                            if (ct.MaLoaiCT == 2) socauthungoai++;
                        }
                    }

                    DoiBongDTO dbDTO = new DoiBongDTO();



                    check = true;//Biến kiểm tra bạn đã nhập đày đủ thông tin đội bóng hay chưa.
                    if (String.IsNullOrEmpty(textBox1.Text))
                    {
                        MessageBox.Show("Bạn chưa nhập tên đội bóng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        check = false;
                    }
                    else if (String.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Bạn chưa nhập tên sân nhà đội bóng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        check = false;
                    }

                    if (check)
                    {
                        dbDTO.MaDoiBong = int.Parse(textBox3.Text);

                        dbDTO.TenDoiBong = textBox1.Text;

                        dbDTO.SoLuongCauThu = int.Parse(textBox4.Text);

                        dbDTO.TenSanNha = textBox2.Text;

                        dbDTO.SoCauThuNgoai = socauthungoai;

                        //update đội bóng

                        bool kt = dbBUS.capnhat(dbDTO);

                        if (kt == false)
                            {
                                    MessageBox.Show("Lưu Đội bóng Lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        else
                            {
                                MessageBox.Show("Lưu Đội bóng Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                            }

                        //add cầu thủ
                        if (kt)
                        {                           
                            if(result2 == DialogResult.Yes)
                            {
                                for (int i = 0; i < ListCauThuSTO.Count; i++)
                                {
                                    CauThuDTO ctDTO = ListCauThuSTO[i];

                                    ctDTO.MaDoiBong = int.Parse(textBox3.Text);

                                    bool kt1 = ctBUS.them(ctDTO);                                   
                                }
                                MessageBox.Show("Lưu Danh Sách cầu thủ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                                
                        }

                    }

                }

            }
            else
            {
                DoiBongDTO dbDTO = new DoiBongDTO();

                check = true;

                if (String.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Bạn chưa nhập mã đội bóng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    check = false;
                }
                else if (String.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Bạn chưa nhập tên đội bóng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    check = false;
                }
                else if (String.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Bạn chưa nhập tên sân nhà đội bóng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    check = false;
                }

                if (check)
                {
                    foreach (CauThuDTO ct in ListCauThuSTO)
                    {
                        if (ct.MaLoaiCT == 2) socauthungoai++;
                    }

                    dbDTO.MaDoiBong = int.Parse(textBox3.Text);

                    dbDTO.TenDoiBong = textBox1.Text;

                    dbDTO.SoLuongCauThu = int.Parse(textBox4.Text);

                    dbDTO.SoCauThuNgoai = socauthungoai;

                    dbDTO.TenSanNha = textBox2.Text;

                    //add đội bóng 

                    bool kt = dbBUS.them(dbDTO);

                    if (kt == false)
                    {
                        
                            MessageBox.Show("Lưu Đội Bóng Lỗi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        MessageBox.Show("Lưu Đội bóng Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }



                    //add cầu thủ
                    if (kt)
                    {
                        for (int i = 0; i < ListCauThuSTO.Count; i++)
                        {
                            CauThuDTO ctDTO = ListCauThuSTO[i];

                            ctDTO.MaDoiBong = int.Parse(textBox3.Text);

                            bool kt1 = ctBUS.them(ctDTO);
                            
                        }
                        MessageBox.Show("Lưu Danh Sách cầu thủ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
        }   //button Lưu đội bóng
        
        private void themMoiDB_Load(object sender, EventArgs e)
        {
            dbBUS = new DoiBongBUS();
            load_data_ct();
        }

        public void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            formthemCT.FormClosed += new FormClosedEventHandler(formthemCT_FormClosed);
            formthemCT.Show();
        }

        private void formthemCT_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(formthemCT.send_data() != null)
            {
            ListCauThuSTO.Add(formthemCT.send_data());
            this.textBox4.Text = (Convert.ToInt32(textBox4.Text)+1).ToString();
            }
                
            formthemCT = new ThemCT();
            this.Show();
            load_data_ct();
        }

        private void UpdateCTButt_Click(object sender, EventArgs e)
        {
            bool canupdate = false;//Biến kiểm tra bạn đã chọn cầu thủ muốn update hay chưa.
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                canupdate = true;
                this.Hide();
                    int Mact = int.Parse(item.Cells["Ma"].Value.ToString());
                    string tencauthu = item.Cells["Ten"].Value.ToString();
                    string ngaysinh = item.Cells["NgaySinh"].Value.ToString();
                    int loaict = int.Parse(item.Cells["LoaiCauThu"].Value.ToString());
                    string ghichu = item.Cells["GhiChu"].Value.ToString();


                formcapnhat = new capNhatCT(Mact, tencauthu, ngaysinh, loaict, ghichu);//Truyền thông tin cầu thủ muốn cập nhật vào form capnhatct
                formcapnhat.FormClosed += new FormClosedEventHandler(formcapnhat_FormClosed);
                formcapnhat.Show();
            }

            if (!canupdate) MessageBox.Show("Bạn chưa chọn cầu thủ để cập nhật thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void formcapnhat_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (formcapnhat.send_data() != null)
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    for (int i = 0; i < ListCauThuSTO.Count; i++)
                    {
                        if (ListCauThuSTO[i].MaCauThu == int.Parse(item.Cells["Ma"].Value.ToString()))
                        {
                            ListCauThuSTO.RemoveAt(i);
                            break;
                        }
                    }
                }
                ListCauThuSTO.Add(formcapnhat.send_data());
            }

            formthemCT = new ThemCT();
            this.Show();
            load_data_ct();
        }

        private void PlayerDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                for (int i = 0; i < ListCauThuSTO.Count; i++)
                {
                    if (ListCauThuSTO[i].MaCauThu == int.Parse(item.Cells["Ma"].Value.ToString()))
                    {
                        if (textBox4.Text != null)
                        {
                            List<CauThuDTO> listct = ctBUS.loadcauthu();
                            foreach (CauThuDTO ct in listct)
                            {
                                if (ct.MaCauThu == int.Parse(item.Cells["Ma"].Value.ToString()))
                                {
                                    DialogResult result = MessageBox.Show("Cầu thủ này đã được lưu vào database, Bạn có muốn xóa!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if(result == DialogResult.Yes)
                                        ctBUS.xoa(ct);
                                }                                    
                            }
                        }
                            
                        ListCauThuSTO.RemoveAt(i);
                        break;
                    }                                  
                }
            }
            load_data_ct();


            this.textBox4.Text = (Convert.ToInt32(textBox4.Text) - 1).ToString();
            
                
        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
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
