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

namespace Pendulum
{
    public partial class FrmEdit : Form
    {
        public string ConnectionString { get; private set; }
        public int TrackId { get; private set; }
        public string SelTitle { get; private set; }
        public string SelLength { get; private set; }
        public string SelUrl { get; private set; }
        public string SelAlbum { get; private set; }
        private readonly FrmMain FrmMain;
        public FrmEdit(string conncectionString, int trackId, string title, string length, string url, string album, FrmMain frmMain)
        {
            ConnectionString = conncectionString;
            TrackId = trackId;
            SelTitle = title;
            SelLength = length;
            SelUrl = url;
            SelAlbum = album;
            FrmMain = frmMain;
            InitializeComponent();
        }
        private void FrmEdit_Load(object sender, EventArgs e)
        {
            tbTitle.Text = SelTitle;
            tbLength.Text = SelLength;
            tbAlbum.Text = SelAlbum;
            tbUrl.Text = SelUrl;
            
        }

        private void FrmEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                string msg = "Szeretné szerkeszteni az adatokat?";
                var res = MessageBox.Show(msg, "Igen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    conn.Open();

                    string title = tbTitle.Text;
                    string length = tbLength.Text;
                    string album = tbAlbum.Text;
                    string url = tbUrl.Text;
                    try
                    {
                        string errorMsg = "";
                        if (string.IsNullOrWhiteSpace(title))
                            errorMsg += "A szám címe nem maradhat üresen!\n";
                        if (title.Length >= 255)
                            errorMsg += "A szám címe nem lehet 255 karakternél hosszabb!\n";
                        if (string.IsNullOrWhiteSpace(album))
                            errorMsg += "Az album neve nem maradhat üresen!\n";
                        if (album.Length != 4)
                            errorMsg += "Az albumnak 4 karakternek kell lennie!\n";
                        if (url.Length >= 30)
                            errorMsg += "A link nem lehet 30 karakternél hosszabb!\n";
                        if (url.Length == 0)
                            tbUrl.Text = "null";
                        if (!string.IsNullOrEmpty(errorMsg))
                            throw new Exception(errorMsg);

                        if (url.Contains("https://youtu.be/"))
                        {
                            new SqlCommand(
                            "UPDATE tracks " +
                           $"SET title = '{tbTitle.Text}', " +
                           $"length = '00:{tbLength.Text}', " +
                           $"album = '{tbAlbum.Text}', " +
                           $"url = '{url.Substring(url.LastIndexOf('/') + 1)}' " +
                           $"WHERE id = {TrackId};", conn)
                            .ExecuteNonQuery();
                        }
                        else
                        {
                            new SqlCommand(
                            "UPDATE tracks " +
                           $"SET title = '{tbTitle.Text}', " +
                           $"length = '00:{tbLength.Text}', " +
                           $"album = '{tbAlbum.Text}', " +
                           $"url = '{tbUrl.Text}' " +
                           $"WHERE id = {TrackId};", conn)
                            .ExecuteNonQuery();
                        }
                        
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                    
                }
                conn.Close();

            }
            FrmMain.FillDGV();
        }

    }
}
