using Reader;

TextVoiceReader.Read();

string a = Console.ReadLine();
string resulta = FilesReader.PdfRead(a);
Console.WriteLine(resulta);


string b = Console.ReadLine();
string resultb = FilesReader.WordRead(b);
Console.WriteLine(resultb);

