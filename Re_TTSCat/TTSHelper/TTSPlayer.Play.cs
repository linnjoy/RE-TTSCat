﻿using System;
using System.IO;
using System.Threading;
using System.Windows.Threading;
using NAudio.Wave;
using Re_TTSCat.Data;

namespace Re_TTSCat
{
    public static partial class TTSPlayer
    {
        public static void Play(string filename, bool wait = true, bool forceKeepCache = false)
        {
            var frame = new DispatcherFrame();
            var thread = new Thread(() =>
            {
                try
                {
                    using (var reader = new AudioFileReader(filename))
                    {
                        using (var waveOut = new WaveOutEvent())
                        {
                            waveOut.Init(reader);
                            reader.Volume = Volume;
                            Bridge.ALog($"音量设置为: {Volume}");
                            waveOut.Play();
                            Vars.TotalPlayed++;
                            if (!wait)
                                frame.Continue = false;
                            while (waveOut.PlaybackState != PlaybackState.Stopped)
                            {
                                if (Vars.CallPlayerStop)
                                    waveOut.Stop();
                                if (!reader.Volume.IsNearEnough(Volume, 0.02f))
                                {
                                    Bridge.ALog($"同步音量: {Volume}");
                                    reader.Volume = Volume;
                                }
                                Thread.Sleep(50);
                            }
                        }
                    }
                    if (Vars.CurrentConf.DoNotKeepCache && !forceKeepCache)
                    {
                        Bridge.ALog($"正在删除缓存文件: {filename}");
                        File.Delete(filename);
                    }
                }
                catch (Exception ex)
                {
                    Bridge.ALog($"播放过程中发生错误: {Path.GetFileName(filename)}: {ex.Message}");
                }
                frame.Continue = false;
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            Dispatcher.PushFrame(frame);
        }
    }
}
