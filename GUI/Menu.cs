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
        public Menu()
        {
            InitializeComponent();
            loadTableTheLoai();
            loadTableSach();
            loadTableDocGia();
            loadTableMuonSach();
            loadTableTraSach();
            launchLoaiSachOnSachTable();
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
            if (selectedTheLoai >= 0)
            {
                theLoaiBus.delete(selectedTheLoai);
                loadTableTheLoai();
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

        private void clearTheLoai_Click(object sender, EventArgs e)
        {
            TenTheLoaiTb.Text = "";
            MaTheLoaiTb.Text = "";
            TimTheLoaiTb.Text = "";
            loadTableTheLoai();
            TimTheLoaiTb.Enabled = true;


        }

        private void TimTLBtn_Click(object sender, EventArgs e)
        {
            var ma = long.Parse(TimTheLoaiTb.Text);
            var list = theLoaiBus.findListByMaTheLoai(ma);
            var source = new BindingSource(list, null);
            TableTheLoai.DataSource = source;
            TimTheLoaiTb.Enabled = false;
        }

        private void TimTheLoaiTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back)
                e.SuppressKeyPress = !int.TryParse(Convert.ToString((char)e.KeyData), out int _);
        }


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
            maDocGiaTbMS.Text = "";
            ngayMuonTbMS.Text = "";
            ngayHenTraTbMS.Text = "";
            soLuongMuonTbMS.Text = "";
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
           /*     var errors = sachsBus.edit(long.Parse(TenSachTb.Text), (TenTacGiaTb.Text), (NhaXuatBanTb.Text), (NamXuatBanTb.Text), (SoLuongTb.Text));
                if (errors.count > 0) 
                {
                    handleShowErrors.errors;
                    MessageBox.Show("Sửa thành công");
                } */
                    loadTableSach();
                 } 
        }

        private void XoaBtn_Click(object sender, EventArgs e)
        {
            if (selectedSach >= 0)
            {
             //   SachBus.delete();
                loadTableSach();
            }
        }
    }
}
