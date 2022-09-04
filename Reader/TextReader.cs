using System.Speech.Synthesis;

namespace Reader
{
    public class TextVoiceReader
    {
        public static void Greeting()
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            string day = "";
            var time = DateTime.Now;

            if (time.Hour >= 5 && time.Hour < 12)
            {
                day = "Good morning";
            }
            if (time.Hour >= 12 && time.Hour < 18)
            {
                day = "Добрый день";
            }
            if (time.Hour >= 18 && time.Hour < 22)
            {
                day = "Good evening";
            }
            if (time.Hour >= 22 || time.Hour < 5)
            {
                day = "Доброй ночи";
            }

            synthesizer.SelectVoice("Umka");
            synthesizer.Volume = 80;
            synthesizer.Rate = 1;
            synthesizer.SetOutputToDefaultAudioDevice();

            synthesizer.Speak($"{day}! Я Умка. Ваш голосовой чтец. Я поддерживаю чтение файлов из word и pdf документов. Умею читать на русском and on english, но уровень моего english is very bad and better to use russian.");
            Thread.Sleep(120);
            synthesizer.Speak("Мы с вами встретимся позже, а пока ознакомьтесь с предложенным меню");
        }



        public static void Save(string text)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();

            synthesizer.SelectVoice("Umka");
            synthesizer.Rate = 2;    //add speed settings   -4-i drunk today        1-normal speed   5-fast   7-too fast   10-what???
            synthesizer.Volume = 80;    //add volume settings
            //synthesizer.AddLexicon();

            synthesizer.SetOutputToWaveFile("ReaderFile.wav");

            synthesizer.Speak(text);
        }


        public static void Speak(string text)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();

            synthesizer.SelectVoice("Umka");
            synthesizer.Volume = 100;
            synthesizer.Rate = 2;
            synthesizer.SetOutputToDefaultAudioDevice();

            synthesizer.Speak(text);
        }
    }
}
