﻿namespace Re_TTSCat.Data
{
    public partial class Conf
    {
        public Conf()
        {
            AutoUpdate = false;
            BlackList = "";
            WhiteList = "";
            BlockMode = 0;
            GiftBlockMode = 0;
            KeywordBlockMode = 0;
            BlockUID = true;
            DebugMode = false;
            DownloadFailRetryCount = 5;
            DoNotKeepCache = false;
            Engine = 0;
            GiftBlackList = "";
            GiftWhiteList = "";
            KeywordBlackList = "";
            KeywordWhiteList = "";
            MinimumDanmakuLength = 3;
            MaximumDanmakuLength = 50;
            ReadInQueue = true;
            ReadPossibility = 100;
            TTSVolume = 100;
            ReadSpeed = 0;
            UseGoogleGlobal = false;

            CustomEngineURL = "https://tts.example.com/?text=$TTSTEXT";
            OnConnected = "已成功连接至房间: $ROOM";
            OnDisconnected = "已断开连接: $ERROR";
            OnDanmaku = "$USER 说: $DM";
            OnGift = "收到来自 $USER 的 $COUNT 个 $GIFT";
            OnGuardBuy = "$USER 上船了 $COUNT 月";
            OnLiveStart = "直播已开始";
            OnLiveEnd = "直播已结束";
            OnWelcome = "欢迎老爷: $USER";
            OnWelcomeGuard = "欢迎船员: $USER";
        }
    }
}
