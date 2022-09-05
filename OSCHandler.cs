﻿using OscCore;
using System.Text.RegularExpressions;
using VRCSTT.Config;

namespace VRCSTT
{
    internal static class OSCHandler 
    { 
        internal static void SendOverOSC(string text)
        {
            Regex.Replace(text, "[@\\\"'\\\\]", string.Empty);
            var client = new OscClient(STTConfig.Address, STTConfig.Port);
            var message = new OscMessage("/chatbox/input", text.Replace("\\", ""), true);
            client.SendAsync(message);
            client.Dispose();

            IsTyping(false);
        }

        internal static void IsTyping(bool b)
        {
            var client = new OscClient(STTConfig.Address, STTConfig.Port);
            var message = new OscMessage("/chatbox/typing", b); 
            client.SendAsync(message);
            client.Dispose();
        }
    }
}
