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
    public partial class FrmAddUrl : Form
    {
        public string ConnectionString { get; private set; }
        public int TrackId { get; private set; }
        private readonly FrmMain FrmMain;
        public FrmAddUrl(string connectionString, int trackId, FrmMain frmMain)
        {
            ConnectionString = connectionString;
            TrackId = trackId;
            FrmMain = frmMain;
            InitializeComponent();
        }

        private void BtnAddUrl_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string url = tbUrl.Text;
                try
                {
                    string errorMsg = "";
                    if (string.IsNullOrWhiteSpace(url))
                        errorMsg += "A link nem lehet üres!\n";
                    if (!string.IsNullOrEmpty(errorMsg))
                        throw new Exception(errorMsg);
                    if (url.Contains("https://youtu.be/"))
                    {
                        new SqlCommand(
                            "UPDATE tracks " +
                           $"SET url = '{url.Substring(url.LastIndexOf('/') + 1)}' " +
                           $"WHERE id = {TrackId};", conn)
                            .ExecuteNonQuery();
                    }
                    else
                    {
                        new SqlCommand(
                            "UPDATE tracks " +
                           $"SET url = '{url}' " +
                           $"WHERE id = {TrackId};", conn)
                            .ExecuteNonQuery();
                    }
                    
                    MessageBox.Show("Az url link hozzáadása sikerült!");
                    Close();
                    
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            FrmMain.FillDGV();
        }
    }
}
