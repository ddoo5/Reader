using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;
using Reader;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;

public class FilesReader
{
    public static string WordRead(string pathWord, int frompage, int topage)
    {
        StringBuilder text = new StringBuilder();

        Application word = new Application();
        object miss = System.Reflection.Missing.Value;
        object readOnly = true;
        Document docs = word.Documents.Open(pathWord, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);


        if (frompage > 0 && frompage <= docs.Paragraphs.Count - 1)
        {
            if (topage > frompage && topage <= docs.Paragraphs.Count)
            {
                for (int i = frompage; i < topage; i++)
                {
                    text.Append(docs.Paragraphs[i].Range.Text.ToString());
                }

                docs.Close();
                word.Quit();
            }
            else
            {
                TextVoiceReader.Speak("Вы ошиблись. Страница, до которой нужно прочитать, не может быть меньше ноля или больше обшего количества страниц в документе. Попробуйте снова");

                throw new Exception("Page error");
            }

        }
        else
        {
            TextVoiceReader.Speak("Вы ошиблись. Страница, с которой нужно начать чтение, не может быть меньше ноля или больше обшего количества страниц в документе. Попробуйте снова");

            throw new Exception("Page error");
        }

        return text.ToString();
	}


	public static string PdfRead(string pathPDF, int frompage, int topage)
	{
		using (PdfReader reader = new PdfReader(pathPDF))
		{
			StringBuilder text = new StringBuilder();	

			if(frompage > 0 && frompage <= reader.NumberOfPages - 1)
			{
				if(topage > frompage && topage <= reader.NumberOfPages)
				{
                    for (int i = frompage; i <= topage; i++)
                    {
                        text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                }
				else
				{
                    TextVoiceReader.Speak("Вы ошиблись. Страница, до которой нужно прочитать, не может быть меньше ноля или больше обшего количества страниц в документе. Попробуйте снова");

                    throw new Exception("Page error");
                }
			}
			else
			{
                TextVoiceReader.Speak("Вы ошиблись. Страница, с которой нужно начать чтение, не может быть меньше ноля или больше обшего количества страниц в документе. Попробуйте снова");

				throw new Exception("Page error");
            }
			

			return text.ToString();
		}
	}
}
