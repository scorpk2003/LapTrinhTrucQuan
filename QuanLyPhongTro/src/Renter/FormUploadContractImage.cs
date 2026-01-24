using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormUploadContractImage : Form
    {
        private readonly Contract _contract;
        private readonly ContractService _contractService;
        private string _selectedImagePath;

        public bool ImageUploaded { get; private set; }

        public FormUploadContractImage(Contract contract)
        {
            InitializeComponent();
            _contract = contract;
            _contractService = new ContractService();
            ImageUploaded = false;

            this.Load += FormUploadContractImage_Load;
            this.btnChooseImage.Click += BtnChooseImage_Click;
            this.btnUpload.Click += BtnUpload_Click;
            this.btnCancel.Click += (s, e) => this.Close();
        }

        private void FormUploadContractImage_Load(object sender, EventArgs e)
        {
            lblContractInfo.Text = $"Hợp đồng: Phòng {_contract.IdRoomNavigation?.Name ?? "N/A"}\n" +
                                  $"Từ {_contract.StartDate:dd/MM/yyyy} đến {_contract.EndDate:dd/MM/yyyy}\n" +
                                  $"Trạng thái: {_contract.Status}";

            if (_contract.Status != "Tạm thời")
            {
                MessageBox.Show("Hợp đồng này không cần upload ảnh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            btnUpload.Enabled = false;
        }

        private void BtnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Chọn ảnh hợp đồng";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = openFileDialog.FileName;

                    try
                    {
                        if (picPreview.Image != null)
                            picPreview.Image.Dispose();

                        picPreview.Image = Image.FromFile(_selectedImagePath);
                        lblFileName.Text = Path.GetFileName(_selectedImagePath);
                        btnUpload.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi tải ảnh: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedImagePath))
            {
                MessageBox.Show("Vui lòng chọn ảnh trước!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string contractFolder = Path.Combine(Application.StartupPath, "Contracts");
                if (!Directory.Exists(contractFolder))
                    Directory.CreateDirectory(contractFolder);

                string fileName = $"{_contract.Id}_{DateTime.Now:yyyyMMddHHmmss}{Path.GetExtension(_selectedImagePath)}";
                string destinationPath = Path.Combine(contractFolder, fileName);

                File.Copy(_selectedImagePath, destinationPath, true);

                string relativePath = Path.Combine("Contracts", fileName);
                bool success = _contractService.UploadContractImage(_contract.Id, relativePath);

                if (success)
                {
                    ImageUploaded = true;
                    MessageBox.Show("Upload ảnh hợp đồng thành công!\nHợp đồng đã được kích hoạt.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Upload ảnh thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (File.Exists(destinationPath))
                        File.Delete(destinationPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi upload: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (picPreview.Image != null)
            {
                picPreview.Image.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}
