﻿using BilibiliDM_PluginFramework;
using System.Text.RegularExpressions;
using System;

namespace Re_TTSCat.Data
{
    public partial class Conf
    {
        public static bool CheckKeywordEligibility(string content)
        {
            switch (Vars.CurrentConf.KeywordBlockMode)
            {
                default:
                    return true;
                case 1:
                    var list1 = Vars.CurrentConf.KeywordBlackList.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string keyword in list1)
                    {
                        if (content.Contains(keyword)) return false;
                        Regex r = new Regex(keyword);
                        Match m = r.Match(content);
                        if (m.Success) return false;
                        if (content.Contains(keyword)) return false;
                    }
                    return true;
                case 2:
                    var list2 = Vars.CurrentConf.KeywordWhiteList.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string keyword in list2)
                    {
                        if (content.Contains(keyword)) return true;
                        Regex r = new Regex(keyword);
                        Match m = r.Match(content);
                        if (m.Success) return true;
                        if (content.Contains(keyword)) return true;
                    }
                    return false;
            }
        }

        public static bool CheckKeywordEligibility(ReceivedDanmakuArgs e)
        {
            if (!CheckKeywordEligibility(e.Danmaku.CommentText))
            {
                Bridge.ALog("忽略：弹幕已命中屏蔽规则");
                return false;
            }
            return true;
        }
    }
}
