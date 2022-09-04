using Reader;

namespace Reader
{
    public class Launcher_with_Logics
    {
        public static void Launch()
        {
            try
            {
                UI.SetConsoleSettings();

                Thread thread2 = new Thread(new ThreadStart(TextVoiceReader.Greeting));
                Thread thread1 = new Thread(new ThreadStart(UI.WriteGreetingText));

                thread1.Start();
                thread2.Start();
                Thread.Sleep(19306);

                UI.WriteInstructions();

                UI.WriteChooseFile();

                Console.CursorVisible = true;

                while (true)
                {
                    LogicsForFisrtsChoose();

                    Thread.Sleep(1000);
                }
            }
            catch(Exception a)
            {
                TextVoiceReader.Speak("Вы доигрались и у вас теперь возникла ошибка, но так как я плохо говорю по английски, читайте сами, либо обратитесь к разработчику. Вот ссылка на него");
                Console.WriteLine("Link: https://github.com/ddoo5/Reader\n\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(a.Message);
                Console.WriteLine(a.HelpLink);
                Console.ResetColor();
            }
        }

        public static void LogicsForFisrtsChoose()
        {
            int chooseFile = Convert.ToInt32(Console.ReadLine());

            switch (chooseFile)
            {
                case -3:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("!!?\n");
                    TextVoiceReader.Speak("Все, уже точно несмешно. Я кончаю");

                    throw new Exception("YOU HAVE JUST TWO VARIANTS!!! 1 OR 2");
                    Console.ResetColor();
                    break;
                case -2:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("!!!");
                    TextVoiceReader.Speak("Какие -2, вы точно ошибаетесь?");
                    Console.ResetColor();
                    break;
                case -1:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("!!");
                    TextVoiceReader.Speak("Как может быть -1, вы ошиблись");
                    Console.ResetColor();
                    break;
                case 0:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("!");
                    TextVoiceReader.Speak("Разве я 0 предлагала?");
                    Console.ResetColor();
                    break;
                case 1:   //word case
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t+\n");
                    TextVoiceReader.Speak("Отлично, теперь ознакомьтесь с примером ввода файла, будьте внимательны!");
                    Console.ResetColor();

                    Console.WriteLine(@"C:\Users\Developer\Documents\WordBook.docx" + "\n");
                    TextVoiceReader.Speak("точка docx обязательно писать так как это формат файла");

                    WordEnterLogic();
                    break;
                case 2:     //pdf case
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" \t+\n");
                    TextVoiceReader.Speak("Замечательно, теперь ознакомьтесь с примером ввода файла, будьте внимательны!");
                    Console.ResetColor();

                    Console.WriteLine(@"C:\Users\Developer\Documents\PDFBook.pdf" + "\n");
                    TextVoiceReader.Speak("точка pdf обязательно писать так как это формат файла");

                    PDFEnterLogic();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("!");
                    TextVoiceReader.Speak("Я не просила вас складывать 2 с 1");
                    Console.ResetColor();
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("!!");
                    TextVoiceReader.Speak("Вы издиваетесь надо мной?");
                    Console.ResetColor();
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("!!!");
                    TextVoiceReader.Speak("Зачем вы ввели 5?");
                    Console.ResetColor();
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("!!!?");
                    TextVoiceReader.Speak("Разве я 6 предлагала?");
                    Console.ResetColor();
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("??????????");
                    TextVoiceReader.Speak("Досвидания");

                    throw new Exception("YOU HAVE JUST TWO VARIANTS!!! 1 OR 2");
                    Console.ResetColor();
                    break;
                default:
                    TextVoiceReader.Speak("Выберите нужный формат");
                    break;
            }
        }



        public static void WordEnterLogic()
        {
            while (true)
            {
                string link = Console.ReadLine();

                if (File.Exists(link) == true)
                {
                    TextVoiceReader.Speak("Я нашла этот файл. Укажите страницы");

                    UI.WritePageCoutFrom();
                    int pagefrom = Convert.ToInt32(Console.ReadLine());

                    UI.WritePageCoutFrom();
                    int pageto = Convert.ToInt32(Console.ReadLine());

                    TextVoiceReader.Speak("Отлично: теперь выберите формат");

                    UI.WriteReadingFormat();

                    int choose = Convert.ToInt32(Console.ReadLine());

                    string textFromFile = FilesReader.WordRead(link, pagefrom, pageto);

                    switch (choose)
                    {
                        case 1:
                            TextVoiceReader.Speak(textFromFile);
                            break;
                        case 2:
                            TextVoiceReader.Speak("Сохранение займет некоторое время");

                            //TextVoiceReader.Save(textFromFile);

                            Converter.Convert(@"..\HERE.wav");

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Файл сохранен");
                            Console.ResetColor();
                            break;
                        default:
                            TextVoiceReader.Speak("Выберите из предложенных вариантов");
                            break;
                    }
                }
            }
        }


        public static void WordPageLogic()
        {

        }


        public static void PDFEnterLogic()
        {
            while (true)
            {
                string link = Console.ReadLine();

                if (File.Exists(link) == true)
                {
                    TextVoiceReader.Speak("Я нашла этот файл. Укажите страницы");

                    UI.WritePageCoutFrom();
                    int pagefrom = Convert.ToInt32(Console.ReadLine());

                    UI.WritePageCoutFrom();
                    int pageto = Convert.ToInt32(Console.ReadLine());

                    TextVoiceReader.Speak("Отлично: теперь выберите формат");

                    UI.WriteReadingFormat();

                    int choose = Convert.ToInt32(Console.ReadLine());

                    string textFromFile = FilesReader.PdfRead(link, pagefrom, pageto);

                    switch (choose)
                    {
                        case 1:
                            TextVoiceReader.Speak(textFromFile);
                            break;
                        case 2:
                            TextVoiceReader.Speak("Сохранение займет некоторое время");

                            TextVoiceReader.Save(textFromFile);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Файл сохранен");
                            Console.ResetColor();
                            break;
                        default:
                            TextVoiceReader.Speak("Выберите из предложенных вариантов");
                            break;
                    }
                }
                else
                {
                    TextVoiceReader.Speak("Я не нашла этот файл. Попробуйте еще раз и перепровверьте свой ввод");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(link);
                    Console.ResetColor();
                }
            }
        }


        public static void PDFPageLogic()
        {

        }
    }
}
