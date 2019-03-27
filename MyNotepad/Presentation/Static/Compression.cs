using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;
using System.Text;

namespace MyNotepad.Logic
{
    static public class Compression
    {
        private const int LEVEL_OF_COMPRESSION = 9;

        static public byte[] CompressToByteArray(string data, string zipEntryName)
        {
            MemoryStream dataToStream = new MemoryStream(Encoding.UTF8.GetBytes(data));

            MemoryStream outputMemStream = new MemoryStream();
            ZipOutputStream zipStream = new ZipOutputStream(outputMemStream);

            zipStream.SetLevel(LEVEL_OF_COMPRESSION);

            ZipEntry newEntry = new ZipEntry(zipEntryName);
            newEntry.DateTime = DateTime.Now;

            zipStream.PutNextEntry(newEntry);

            StreamUtils.Copy(dataToStream, zipStream, new byte[4096]);
            zipStream.CloseEntry();

            zipStream.IsStreamOwner = false;
            zipStream.Close();

            outputMemStream.Position = 0;

            return outputMemStream.ToArray();
        }

        static public string ExtractToString(byte[] archiveFilenameIn)
        {
            ZipFile zf = null;
            string result = null;
            try
            {
                var fs = new MemoryStream(archiveFilenameIn);
                zf = new ZipFile(fs);

                foreach (ZipEntry zipEntry in zf)
                {
                    string entryFileName = zipEntry.Name;

                    byte[] buffer = new byte[4096];
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    using (MemoryStream stream = new MemoryStream())
                    {
                        StreamUtils.Copy(zipStream, stream, buffer);
                        stream.Position = 0;
                        result = Encoding.UTF8.GetString(stream.ToArray());
                    }
                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true;
                    zf.Close();
                }
            }

            return result;
        }
    }
}