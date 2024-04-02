using System;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class SpeechForm : Form
    {
        public SpeechForm()
        {
            InitializeComponent();
        }

        private SpeechSynthesizer ss;

        private void Form1_Load(object sender, EventArgs e)
        {
            ss = new SpeechSynthesizer();
        }

        //读
        private void btnRead_Click(object sender, EventArgs e)
        {
            ss.Rate = trackBarSpeed.Value;
            // ss.Volume = trbVolumn.Value;
            ss.SpeakAsync(txtMsg.Text);
        }

        //暂停
        private void btnPause_Click(object sender, EventArgs e)
        {
            ss.Pause();
        }

        //继续
        private void txtContinue_Click(object sender, EventArgs e)
        {
            ss.Resume();
        }

        //录音
        private void txtRecord_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer ss = new SpeechSynthesizer();
            ss.Rate = trackBarSpeed.Value;
            //ss.Volume = trbVolumn.Value;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Wave Files|*.wav";
            ss.SetOutputToWaveFile(sfd.FileName);
            ss.Speak(txtMsg.Text);
            ss.SetOutputToDefaultAudioDevice();
            MessageBox.Show("完成录音~~", "提示");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}