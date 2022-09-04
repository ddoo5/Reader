using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;
using DocumentFormat.OpenXml.Packaging;


public class FilesReader
{
	public static string WordRead(string pathWord)     //add select pages
    {
		string text = "";

		using (WordprocessingDocument document = WordprocessingDocument.Open(pathWord, true))
		{
			text = document.MainDocumentPart.Document.Body.InnerText;
		}

		return text;
	}


	public static string PdfRead(string pathPDF)   //add select pages
	{
		using (PdfReader reader = new PdfReader(pathPDF))
		{
			StringBuilder text = new StringBuilder();	

			for (int i = 1; i <= reader.NumberOfPages; i++)
			{
				text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
			}

			return text.ToString();
		}
	}
}
