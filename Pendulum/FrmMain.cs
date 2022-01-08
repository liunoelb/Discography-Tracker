using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Pendulum
{
    public partial class FrmMain : Form
    {
        public string ConnectionString { get; private set; }
        static readonly List<Album> Albums = new List<Album>();
        static readonly List<Track> Tracks = new List<Track>();
        public FrmMain()
        {
            ConnectionString = 
               @"Server=(localdb)\MSSQLLocalDB;" +
                "Database=music";
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FillCB();

        }

        public void FillDGV()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                dgv.Rows.Clear();
                var r = new SqlCommand(
                    "SELECT tracks.title, tracks.length, tracks.url, tracks.id, tracks.album " +
                    "FROM tracks, albums " +
                    "WHERE tracks.album = albums.id " +
                   $"AND albums.title LIKE '{cbAlbum.GetItemText(cbAlbum.SelectedItem)}' " +
                   $"AND tracks.title LIKE '%{tbSearch.Text}%';", conn)
                    .ExecuteReader();
                while (r.Read())
                {
                    dgv.Rows.Add(
                        r[0], r.GetTimeSpan(1).ToString("m':'ss"), r[2], r[3], r[4]);
                }
                if (dgv.RowCount > 0) tbSearch.Enabled = true;
                
                conn.Close();
            }
        }

        private void FillCB()
        {
            cbArtist.Items.Clear();
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var r = new SqlCommand(
                    "SELECT artist FROM albums GROUP BY artist;", conn)
                    .ExecuteReader();
                while (r.Read())
                {
                    cbArtist.Items.Add(r[0]);
                }
               
                conn.Close();
            }
        }

        private void CbArtist_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbAlbum.Items.Clear();
            cbAlbum.Text = "";
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var r = new SqlCommand(
                    $"SELECT title FROM albums WHERE artist LIKE '{cbArtist.SelectedItem}';", conn)
                    .ExecuteReader();
                while (r.Read())
                {
                    if (cbArtist.SelectedItem != null)
                    {
                        cbAlbum.Enabled = true;
                        cbAlbum.Items.Add(r[0]);
                    }
                }
                conn.Close();
            }
        }

        private void CbAlbum_SelectedValueChanged(object sender, EventArgs e)
        {
            FillDGV();
            switch (cbAlbum.GetItemText(cbAlbum.SelectedItem))
            {
                case "Hold Your Colour":
                    pbAlbumcover.Image = Image.FromFile(@"..\..\Resources\pendulum_covers\hold_your_colour.jpg");
                    break;
                case "In Silico":
                    pbAlbumcover.Image = Image.FromFile(@"..\..\Resources\pendulum_covers\in_silico.jpg");
                    break;
                case "Immersion":
                    pbAlbumcover.Image = Image.FromFile(@"..\..\Resources\pendulum_covers\immersion.jpg");
                    break;
                case "rituals":
                    pbAlbumcover.Image = Image.FromFile(@"..\..\Resources\goreshit_covers\rituals.jpg");
                    break;
                case "mlsfaw":
                    pbAlbumcover.Image = Image.FromFile(@"..\..\Resources\goreshit_covers\mlsfaw.jpg");
                    break;
                case "semantics":
                    pbAlbumcover.Image = Image.FromFile(@"..\..\Resources\goreshit_covers\semantics.jpg");
                    break;
                case "my love feels all wrong":
                    pbAlbumcover.Image = Image.FromFile(@"..\..\Resources\goreshit_covers\my_love_feels_all_wrong.jpg");
                    break;
                case "gnb":
                    pbAlbumcover.Image = Image.FromFile(@"..\..\Resources\goreshit_covers\gnb.jpg");
                    break;
                default:
                    break;
            }

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var r = new SqlCommand(
                    "SELECT release " +
                    "FROM albums " +
                   $"WHERE title LIKE '{cbAlbum.GetItemText(cbAlbum.SelectedItem)}';", conn)
                    .ExecuteReader();
                while (r.Read())
                {
                    rtb.Text = $"Release: {DateTime.Parse(r[0] + "").ToString("yyyy. MMMM. dd.")}";
                }
                
                r.Close();
                r = new SqlCommand(
                    "SELECT SUM(DATEDIFF(S, '0:00:00', tracks.length)) as time " +
                    "FROM tracks, albums " +
                    "WHERE tracks.album = albums.id " +
                   $"AND albums.title LIKE '{cbAlbum.GetItemText(cbAlbum.SelectedItem)}' " +
                    "GROUP BY albums.id;", conn)
                    .ExecuteReader();
                while (r.Read())
                {
                    double totalLength = Convert.ToDouble(r[0]) / 60;
                    rtb.Text += $"\n\nTotal length of album: {Math.Round(totalLength, 2)} minutes";
                }
                
                
                conn.Close();
            }

            dgv.Rows[0].Selected = true;
            if (dgv.Rows[0].Cells["ColumnUrl"].Value.ToString() == "null")
            {
                linklbUrl.Text = "NOPE";
                btnUrl.Enabled = true;
            }
            else
            {
                linklbUrl.Text = "https://youtu.be/" + dgv.Rows[0].Cells["ColumnUrl"].Value.ToString();
                btnUrl.Enabled = false;
            }

        }

        private void TbSearch_TextChanged(object sender, EventArgs e) => FillDGV();

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows[e.RowIndex].Cells["ColumnUrl"].Value.ToString() == "null")
            {
                linklbUrl.Text = "NOPE";
                btnUrl.Enabled = true;
            }
            else
            {
                linklbUrl.Text = "https://youtu.be/" + dgv.Rows[e.RowIndex].Cells["ColumnUrl"].Value.ToString();
                btnUrl.Enabled = false;
            }
            

        }

        private void LinklbUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => System.Diagnostics.Process.Start(linklbUrl.Text);
        private void BtnUrl_Click(object sender, EventArgs e)
            => new FrmAddUrl(ConnectionString, Convert.ToInt32(dgv.CurrentRow.Cells[3].Value), this).ShowDialog();

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string title = dgv.CurrentRow.Cells["ColumnTitle"].Value.ToString();
                string length = dgv.CurrentRow.Cells["ColumnLength"].Value.ToString();
                string url = dgv.CurrentRow.Cells["ColumnUrl"].Value.ToString();
                string album = dgv.CurrentRow.Cells["ColumnAlbum"].Value.ToString();

                new FrmEdit(ConnectionString, Convert.ToInt32(dgv.CurrentRow.Cells[3].Value), title, length, url, album, this)
                    .ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void BtnDiscography_Click(object sender, EventArgs e)
        {
            List<string> files = new List<string>();
            string fileName = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "";
            ofd.Filter = "Text Files|*.txt";
            ofd.InitialDirectory = @"C:\";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;
                files.Add(fileName);
            }
            if (File.Exists(fileName))
            {
                using (var sr = new StreamReader(fileName))
                {
                    string header = "";
                    header = sr.ReadLine();
                    if (header.Contains("[albums]"))
                    {
                        string sor = "";
                        while (!sor.Contains("[tracks]"))
                        {
                            sor = sr.ReadLine();
                            if (!sor.Contains("[tracks]"))
                            {
                                Albums.Add(new Album(sor));
                            }
                        }
                        while (!sr.EndOfStream)
                        {
                            Tracks.Add(new Track(sr.ReadLine()));
                        }
                    }
                    using (var conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        try
                        {
                            string albumQuery =
                            "INSERT INTO albums (id, artist, title, release) VALUES " +
                            "(@id, @artist, @title, @release);";
                            using (var cmd = new SqlCommand(albumQuery, conn))
                            {
                                cmd.Parameters.Add("@id", SqlDbType.VarChar);
                                cmd.Parameters.Add("@artist", SqlDbType.VarChar);
                                cmd.Parameters.Add("@title", SqlDbType.VarChar);
                                cmd.Parameters.Add("@release", SqlDbType.Date);
                                for (int i = 0; i < Albums.Count; i++)
                                {
                                    cmd.Parameters["@id"].Value = Albums[i].AlbumId;
                                    cmd.Parameters["@artist"].Value = Albums[i].AlbumArtist;
                                    cmd.Parameters["@title"].Value = Albums[i].AlbumTitle;
                                    cmd.Parameters["@release"].Value = Albums[i].AlbumRelease;
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            string trackQuery =
                                   "INSERT INTO tracks (title, length, album, url) VALUES " +
                                   "(@title, @length, @albumfk, @url);";
                            using (var cmd = new SqlCommand(trackQuery, conn))
                            {
                                cmd.Parameters.Add("@title", SqlDbType.VarChar);
                                cmd.Parameters.Add("@length", SqlDbType.Time);
                                cmd.Parameters.Add("@albumfk", SqlDbType.VarChar);
                                cmd.Parameters.Add("@url", SqlDbType.VarChar);
                                for (int i = 0; i < Tracks.Count; i++)
                                {
                                    cmd.Parameters["@title"].Value = Tracks[i].TrackTitle;
                                    cmd.Parameters["@length"].Value = Tracks[i].TrackLength;
                                    cmd.Parameters["@albumfk"].Value = Tracks[i].AlbumFk;
                                    cmd.Parameters["@url"].Value = Tracks[i].TrackUrl;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            MessageBox.Show("Az fájl beolvasása sikerült!");

                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("Hiba történt a fájl beolvasásakor!" + exc.Message);
                        }
                        conn.Close();
                    }
                }
            }
            FillCB();
            
            
        }

    }
}
