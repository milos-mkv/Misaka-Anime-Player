using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MisakaAnimePlayer.models;
using Newtonsoft.Json;
using System.IO;
using MetroFramework.Controls;

namespace MisakaAnimePlayer
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public List<Episode> episodes = new List<Episode>();
        public Episode currentEpisode;
        public MainForm()
        {
            InitializeComponent();

            using (StreamReader reader = new StreamReader("data\\Episodes.json"))
            {
                string json = reader.ReadToEnd();
                episodes = JsonConvert.DeserializeObject<List<Episode>>(json);
            }
            this.MaximizeBox = false;
            metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            pictureBox1.Image = Image.FromFile("data/logo.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            currentEpisode = this.episodes[0];
            metroLabel2.Text = currentEpisode.Title;
            metroLabel3.Text = currentEpisode.Description;

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 26; i++)
            {
                MetroButton button = new MetroButton();
                button.Width = 30;
                button.StyleManager = metroStyleManager1;

                button.Text = i.ToString();
                button.Click += new System.EventHandler(this.EpisodeButtonClick);

                flowLayoutPanel1.Controls.Add(button);
            }
        }

        public void EpisodeButtonClick(object sender, EventArgs e)
        {
            MetroButton button = (MetroButton)sender;
            int number = Convert.ToInt32(button.Text) - 1;
            currentEpisode = this.episodes[number];
            metroLabel2.Text = currentEpisode.Title;
            metroLabel3.Text = currentEpisode.Description;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            VideoForm vf = new VideoForm();
            vf.Text = currentEpisode.Title;
            vf.axWindowsMediaPlayer1.URL = currentEpisode.Link;
            vf.Show();
        }
    }
}
