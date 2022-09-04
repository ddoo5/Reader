using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class TextVoiceReader
    {
        public static void Read()
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.SelectVoice("Umka");
            synthesizer.Speak("Привет это тест, а это тест запятой. Тест точки");
        }
    }
}
