using NAudio.Lame;
using NAudio.Wave;
using System.Net;

namespace Reader
{
    public class Converter
    {
        public static void Convert(string url)
        {
            
            using (var client = new WebClient())
            {
                var file = client.DownloadData(url);
                var target = new WaveFormat(16000, 32, 2);
                using (var outPutStream = new MemoryStream())
                using (var waveStream = new WaveFileReader(new MemoryStream(file)))
                using (var conversionStream = new WaveFormatConversionStream(target, waveStream))
                using (var writer = new LameMP3FileWriter(outPutStream, conversionStream.WaveFormat, 32, null))
                {
                    conversionStream.CopyTo(writer);
                }
            }
        }
    }
}
