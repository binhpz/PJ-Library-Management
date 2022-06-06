using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Menu : Form
    {
        private TheLoaiBus theLoaiBus = new TheLoaiBus { };
        private SachBus sachsBus = new SachBus { };
        private DocGiaBus docGiaBus = new DocGiaBus { };
        private MuonSachBus muonSachBus = new MuonSachBus { };
        private TraSachBus traSachBus = new TraSachBus { };

        private long selectedTheLoai = -1;
        private long selectedSach = -1;
        private int selectedItemLoaiSachh = -1;
        private int selectedItemDocGia = -1;
        private long selectedDocGia = -1;
        public Menu()
        {
            InitializeComponent();
            loadTableTheLoai();
            loadTableSach();
            loadTableDocGia();
            loadTableMuonSach();
            loadTableTraSach();
            launchLoaiSachOnSachTable();
            launchDocGiaOnMuonSachTable();
            launchSachOnMuonSachTable();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void TabQuanLySach_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void siticoneDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TableDocGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TableTheLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ThemTLBtn_Click(object sender, EventArgs e)
        {
            var tenTheLoai = this.TenTheLoaiTb.Text;
            if (tenTheLoai == "")
            {
                MessageBox.Show("Nhập tên thể loại");
            } else if (!theLoaiBus.add(tenTheLoai))
            {
                MessageBox.Show("Thể loại đã tồn tại");
            } else
            {
                MessageBox.Show("Thêm thành công");
                loadTableTheLoai();
            }

        }

        private void TenTheLoaiTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void TableTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            /*
            DataGridViewRow row = TableTheLoai.Rows[e.RowIndex];
            var data1 = row.Cells[0].Value.ToString();
            var data2 = row.Cells[1].Value.ToString();
            Console.WriteLine("-----------------> ", data1);
            Console.WriteLine("-----------------> ", data2);
            */

            var dvg = sender as DataGridView;
            //Get the current row's data, if any
            var row = dvg.Rows[e.RowIndex];
            //This works if you data bound the DGV as normal
            var loaisach = row.DataBoundItem as LoaiSach;  //Or DataRow if you're using a Dataset
            if (loaisach != null)
            {
                selectedTheLoai = loaisach.MaLoaiSach;
                MaTheLoaiTb.Text = loaisach.MaLoaiSach.ToString();
                TenTheLoaiTb.Text = loaisach.TenLoaiSach;
            }
        }

        private void XoaTLBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa ??",
                                    " Xác nhận xóa !!",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (selectedTheLoai >= 0)
                {
                    theLoaiBus.delete(selectedTheLoai);
                    loadTableTheLoai();
                }
            }
        }

        private void gundfhugkdui_Click(object sender, EventArgs e)
        {
                   }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            {
                      }
        }

        private void MaTheLoaiTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void TimTheLoaiTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel15_Click(object sender, EventArgs e)
        {

        }

        private void SuaTLBtn_Click(object sender, EventArgs e)
        {
            if (TenTheLoaiTb.Text == "")
            {
                MessageBox.Show("yêu cầu nhập tên thể loại!");
            } else
            {
                var errors = theLoaiBus.edit(long.Parse(MaTheLoaiTb.Text), TenTheLoaiTb.Text);
                if (errors.Count > 0)
                {
                    handleShowErrors(errors);
                } else
                {
                    MessageBox.Show("Sửa thành công");
                    loadTableTheLoai();
                }

            }
        }

      
        private void TimTLBtn_Click(object sender, EventArgs e)
        {
            var list = theLoaiBus.findListByTenTheLoai(TenTheLoaiTb.Text);
            var source = new BindingSource(list, null);
            TableTheLoai.DataSource = source;
            //TimTheLoaiTb.Enabled = false;
        }

        /*
        private void TimTheLoaiTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back)
                e.SuppressKeyPress = !int.TryParse(Convert.ToString((char)e.KeyData), out int _);
        }
        */


        private void loadTableTheLoai()
        {
            TableTheLoai.DataSource = null;
            var bindingList = theLoaiBus.getList();
            var source = new BindingSource(bindingList, null);
            TableTheLoai.DataSource = source;
        }

        private void loadTableSach()
        {
            tableSach.DataSource = null;
            var bindingList = sachsBus.getList();
            var source = new BindingSource(bindingList, null);
            tableSach.DataSource = source;
        }

        private void loadTableDocGia()
        {
            TableDocGia.DataSource = null;
            var bindingList = docGiaBus.getList();
            var source = new BindingSource(bindingList, null);
            TableDocGia.DataSource = source;
        }

        private void loadTableMuonSach()
        {
            muonSachTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            muonSachTable.DataSource = null;
            var bindingList = muonSachBus.getList();
            var source = new BindingSource(bindingList, null);
            muonSachTable.DataSource = source;
        }

        private void loadTableTraSach()
        {
            traSachTable.DataSource = null;
            var bindingList = traSachBus.getList();
            var source = new BindingSource(bindingList, null);
            traSachTable.DataSource = source;
        }

        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ThemBtn_Click(object sender, EventArgs e)
        {
            var tenSach = TenSachTb.Text;
            var tenTacGia = TenTacGiaTb.Text;
            var nhaXuatBan = NhaXuatBanTb.Text;
            var namXuatBan = int.Parse(NamXuatBanTb.Text);
            var soLuong = int.Parse(SoLuongTb.Text);

            if (tenSach == "" || tenTacGia == "" || nhaXuatBan == "" || NamXuatBanTb.Text == "" || SoLuongTb.Text == "")
            {
                MessageBox.Show("Yêu cầu nhập đủ tất cả thông tin!");
            }
            
            if(namXuatBan > DateTime.Now.Year)
            {
                MessageBox.Show("Năm xuất bản không hợp lệ!");
            }

            if (soLuong < 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!");
            }

            List<string> errors = new List<string>();

            LoaiSach ls = (LoaiSach)LoaiSachCb.Items[selectedItemLoaiSachh];

            if (selectedItemLoaiSachh >= 0)
            {
                errors = sachsBus.Create(tenSach, tenTacGia, nhaXuatBan, namXuatBan, soLuong, ls.MaLoaiSach);
            }else
            {
                MessageBox.Show("Yêu cầu chọn thể loại!");
            }

            if (errors.Count > 0)
            {
                handleShowErrors(errors);
            }
            else
            {
                MessageBox.Show("Thêm thành công");
                loadTableSach();
            }

        }

        private void launchLoaiSachOnSachTable()
        {
            var loaiSach = theLoaiBus.getAll();
            LoaiSachCb.DataSource = loaiSach;
            LoaiSachCb.DisplayMember = "TenLoaiSach";
        }

        private void launchDocGiaOnMuonSachTable()
        {
            var docgia = docGiaBus.getList();
            docgiaCBOnMuonSach.DataSource = docgia;
            docgiaCBOnMuonSach.DisplayMember = "TenDG";
        }

        private void launchSachOnMuonSachTable()
        {
            var sach = sachsBus.getList();
            sachLBMuonSach.DataSource = sach;
            sachLBMuonSach.DisplayMember = "TenSach";
        }

        private void LoaiSachCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItemLoaiSachh = LoaiSachCb.SelectedIndex;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NamXuatBanTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back)
                e.SuppressKeyPress = !int.TryParse(Convert.ToString((char)e.KeyData), out int _);
        }

        private void SoLuongTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back)
                e.SuppressKeyPress = !int.TryParse(Convert.ToString((char)e.KeyData), out int _);
        }

        private void handleShowErrors(List<string> errors)
        {
            var errText = string.Join("\n", errors);
            MessageBox.Show(errText);
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            TenSachTb.Text = "";
            TenTacGiaTb.Text = "";
            NhaXuatBanTb.Text = "";
            NamXuatBanTb.Text = "";
            SoLuongTb.Text = "";
            loadTableSach();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel24_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel22_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
          
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            maDocGiaTbTS.Text = "";
            soLuongMuonTbTS.Text = "";
            ngayTraTbTS.Text = "";
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            maDocGiaQLDG.Text = "";
            tenDocGiaQLDG.Text = "";
            NgaySinhDp.Value = DateTime.Now;
            NgayHhtDp.Value = DateTime.Now;
            DiaChiTb.Text = "";
            SoCmndTb.Text = "";
            SdtTb.Text = "";
            loadTableDocGia();
        }

        private void muonSachTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var cell = 3;
            if (e.ColumnIndex == cell && e.RowIndex >= 0)
            {
                var sach = (HashSet<Sach>)muonSachTable.Rows[e.RowIndex].Cells[cell].Value;
                if (sach != null)
                {
                    e.Value = string.Join(", \n", sach.Select(x => x.MaSach + ": " + x.TenSach));
                }
               
            }
        }

        private void muonSachTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    
        private void SuaBtn_Click(object sender, EventArgs e)
        {
            if (TenSachTb.Text == "")
            {
                MessageBox.Show("yêu cầu nhập tên sách!");
            }
            else if (TenTacGiaTb.Text == "")
            {
                MessageBox.Show("yêu cầu nhập tên tác giả!");
            }
            else if (NhaXuatBanTb.Text == "")
            {
                MessageBox.Show("yêu cầu nhập nhà xuất bản!");
            } else if (NamXuatBanTb.Text == "")
            {
                MessageBox.Show("yêu cầu nhập năm xuất bản!");
            } else if (SoLuongTb.Text == "")
            {
                MessageBox.Show("yêu cầu nhập số lượng!");
            }
            else
            {
                LoaiSach ls = (LoaiSach)LoaiSachCb.Items[selectedItemLoaiSachh];
                var errors = sachsBus.edit(long.Parse(MaSachTb.Text), TenSachTb.Text, TenTacGiaTb.Text, 
                    ls.MaLoaiSach, NhaXuatBanTb.Text, int.Parse(NamXuatBanTb.Text), int.Parse(SoLuongTb.Text));
                if (errors.Count > 0)
                {
                    handleShowErrors(errors);
                }
                else
                {
                    MessageBox.Show("Sửa thành công");
                    loadTableTheLoai();
                }
                loadTableSach();
            } 
        }

        private void XoaBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa ??",
                                      " Xác nhận xóa !!",
                                      MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (selectedSach >= 0)
                {
                    sachsBus.delete(selectedSach);
                    loadTableSach();
                }
            }
            else
            {
            }

        }

        private void tableSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dvg = sender as DataGridView;
            //Get the current row's data, if any
            var row = dvg.Rows[e.RowIndex];
            //This works if you data bound the DGV as normal
            var sach = row.DataBoundItem as Sach;  //Or DataRow if you're using a Dataset
            if (sach != null)
            {
                selectedSach = sach.MaSach;
                MaSachTb.Text = sach.MaSach.ToString();
                TenSachTb.Text = sach.TenSach;
                TenTacGiaTb.Text = sach.TenTacGia;
                NhaXuatBanTb.Text = sach.NhaXuatBan;
                NamXuatBanTb.Text = sach.NamXuatBan.ToString();
                SoLuongTb.Text = sach.SoLuong.ToString();
                var tenLoaiSach = sach.LoaiSach.TenLoaiSach;
                LoaiSachCb.SelectedIndex = LoaiSachCb.FindStringExact(tenLoaiSach);
            }
        }

        private void XoaDocGiaBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa ??",
                                    " Xác nhận xóa !!",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (selectedDocGia >= 0)
                {
                    docGiaBus.delete(selectedDocGia);
                    loadTableDocGia();
                }
            }
            else
            {
            }
        }

        private void TimKiemBtn_Click(object sender, EventArgs e)
        {
            if (TenSachTb.Text == "")
            {
                MessageBox.Show("Yêu cầu nhập tên sách!");
            } else
            {
                var list = sachsBus.findListByTenSach(TenSachTb.Text);
                tableSach.DataSource = null;
                var bindingList = list;
                var source = new BindingSource(bindingList, null);
                tableSach.DataSource = source;
            }
        }

        private void clearTheLoai_Click(object sender, EventArgs e)
        {
            TenTheLoaiTb.Text = "";
            MaTheLoaiTb.Text = "";
            loadTableTheLoai();
        }

        private void ThemDocGiaBtn_Click(object sender, EventArgs e)
        {
            // check field emppty;
            // 
            var errors = docGiaBus.add(tenDocGiaQLDG.Text, NgaySinhDp.Value, DiaChiTb.Text, SoCmndTb.Text, SdtTb.Text, NgayHhtDp.Value);

            if (errors.Count > 0)
            {
                handleShowErrors(errors);
            }
            else
            {
                MessageBox.Show("Thêm thành công");
                loadTableDocGia();
            }
        }

        private void TableDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dvg = sender as DataGridView;
            //Get the current row's data, if any
            var row = dvg.Rows[e.RowIndex];
            //This works if you data bound the DGV as normal
            var docgia = row.DataBoundItem as DocGia;  //Or DataRow if you're using a Dataset
            if (docgia != null)
            {
                selectedDocGia = docgia.MaDG;
                tenDocGiaQLDG.Text = docgia.TenDG;
                maDocGiaQLDG.Text = docgia.MaDG.ToString();
                NgayHhtDp.Value = (DateTime)docgia.NgayHetHanThe;
                NgaySinhDp.Value = (DateTime)docgia.NgaySinh;
                DiaChiTb.Text = docgia.DiaChi;
                SoCmndTb.Text = docgia.SoCMT;
                SdtTb.Text = docgia.SDT;

            }
        }

        private void SuaDocGiaBtn_Click(object sender, EventArgs e)
        {
            var errors = docGiaBus.edit(selectedDocGia, tenDocGiaQLDG.Text, NgaySinhDp.Value, DiaChiTb.Text, SoCmndTb.Text, SdtTb.Text, NgayHhtDp.Value);

            if (errors.Count > 0)
            {
                handleShowErrors(errors);
            }
            else
            {
                MessageBox.Show("Sửa thành công");
                loadTableDocGia();
            }
        }

        private void TimDocGiaBtn_Click(object sender, EventArgs e)
        {
            var list = docGiaBus.search(tenDocGiaQLDG.Text, SdtTb.Text, SoCmndTb.Text);
            TableDocGia.DataSource = null;
            var bindingList = list;
            var source = new BindingSource(bindingList, null);
            TableDocGia.DataSource = source;
        }

        private void tableLayoutPanel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void docgiaCBOnMuonSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItemDocGia = docgiaCBOnMuonSach.SelectedIndex;
        }

        private void loaiSachBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
