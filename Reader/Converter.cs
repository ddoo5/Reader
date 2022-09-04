using NAudio.Lame;
using NAudio.MediaFoundation;
using NAudio.Wave;
using System.Net;

namespace Reader
{
    public class Converter
    {
        public static void Convert(string url)
        {
            string input = url;
            string output = input.Substring(0, input.Length - 3) + "mp3";
            MediaType mediaType = MediaFoundationEncoder.SelectMediaType(AudioSubtypes.MFAudioFormat_MP3, new WaveFormat(44100, 1), 0);

            using (MediaFoundationReader reader = new MediaFoundationReader(input))
            {
                using (var encoder = new MediaFoundationEncoder(mediaType))
                {
                    encoder.Encode(output, reader);
                }
            }
        }


        public static string Search(string fileName)
        {
            DirectoryInfo directory = new(Directory.GetCurrentDirectory());
            FileInfo[] file = directory.GetFiles(fileName, SearchOption.AllDirectories);
            return @$"{ file[0].Directory}";
        }
    }
}
