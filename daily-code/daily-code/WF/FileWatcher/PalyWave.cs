using System.Collections.Generic;
using System.Media;

namespace FileWatcher
{
    internal class PalyWave
    {
        private PalyWave()
        {
        }

        private static PalyWave instance;

        public static PalyWave Instance
        {
            get { return instance ?? (instance = new PalyWave()); }
        }

        public List<PalyWave> list = new List<PalyWave>();

        public void Add()
        {
            list.Add(this);
        }

        public void Remove()
        {
            list.Remove(this);
        }

        private SoundPlayer player = new SoundPlayer();//C#播放类

        //-------------------------------------------------------------------
        /// <summary>
        /// 播放声音
        /// </summary>
        /// <param name="wfname">声音文件</param>
        public void Play(string wfname)//只播放一次
        {
            player.SoundLocation = wfname;//指向声音文件
            player.Load();//同步
            player.Play();
            player.LoadCompleted += player_LoadCompleted;
        }

        private void player_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("Test");
        }

        /// <summary>
        /// 循环播放声音
        /// </summary>
        /// <param name="wfname">声音文件</param>
        public void RedoPlay(string wfname)//循环播放
        {
            player.SoundLocation = wfname;//指向声音文件

            player.Load();//同步
            player.PlayLooping();//开始播放
        }

        //--------------------------------------------------------------------
        /// <summary>
        /// 停止播放
        /// </summary>
        public void StopPlay()
        {
            player.Stop();
        }
    }
}