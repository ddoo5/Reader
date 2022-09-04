namespace Reader
{
    public class UI
    {
        public static void SetConsoleSettings()
        {
            Console.SetWindowSize(125, 32);
            Console.CursorVisible = false;
            Console.Title = "Reader";
        }

        public static void WriteGreetingText()
        {
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
            if (time.Hour >= 22 && time.Hour < 5)
            {
                day = "Доброй ночи";
            }

            string a = $"{day}! Я Умка. Ваш голосовой чтец. Я поддерживаю чтение файлов из word и pdf документов. Умею читать на русском and on english, но уровень моего english is very bad and better to use russian. Мы с вами встретимся позже, а пока ознакомьтесь с предложенным меню";

            Thread.Sleep(420);

            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]);
                Thread.Sleep(48);
            }

            Thread.Sleep(300);
            Console.Clear();
        }


        public static void WriteInstructions()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Сейчас я опишу краткую инструкцию, ее лучше придерживаться(т.к. релиза без интерфейса не будет)\n" +
                "Если у вас звук до сих пор не включен, сделайте это, Умка вам будет подсказывать, но по тексу можно будет понять смысл \n" +
                "Из ошибок и логики работы я постарался учесть большинство, но если вы найдете, то буду признателен(если ошибка красного цвета и умка до этого говорила - значит она уже найдена)\n" +
                "Теперь перейдем к инструкции:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1) Лучше не совершать ошибок т.к. прийдется заново запускать программу");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2) Придерживаться первого пункта");
            Console.WriteLine("3) Придерживаться инструкций, которые будут выводится");
            Console.WriteLine("4) Правильный путь к файлу вы можете найти через проводник и совершить ctr+c ctr+v");
            Console.ResetColor();

            Console.WriteLine("Exit: Press any key");

            Console.ReadKey();

            Console.Clear();
        }


        public static void WriteChooseFile()
        {
            Console.WriteLine("Какой тип файла вы желаете выбрать?");
            Console.WriteLine("1) Word документ");
            Console.WriteLine("2) PDF документ");
        }


        public static void WriteReadingFormat()
        {
            Console.WriteLine("Вам прочитать сейчас или вы послушаете позже?");
            Console.WriteLine("1) Сейчас");
            Console.WriteLine("2) Позже");
        }
    }
}
