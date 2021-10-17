using System;
using System.IO;
using BitMiracle.LibTiff.Classic;
using BitMiracle.Tiff2Pdf;

namespace Tiff2PdfLib
{
    public static class Lib
    {
        const string UnnamedFile = "-";

        /// Converts a TIFF stream to a PDF stream.
        public static void ConvertStream(Stream inputStream, Stream outputStream)
        {
            using var input = Tiff.ClientOpen(UnnamedFile, "r", inputStream, new TiffStream());
            if (input == null)
            {
                throw new Exception("Can't open input stream for reading");
            }

            var t2p = new T2P
            {
                m_testFriendly = false,
                m_outputfile = outputStream
            };
            t2p.validate();

            using var output = Tiff.ClientOpen(UnnamedFile, "w", t2p, t2p.m_stream);
            if (output == null)
            {
                throw new Exception("Can't initialize output descriptor");
            }

            t2p.write_pdf(input, output);
            if (t2p.m_error)
            {
                throw new Exception("An error occurred creating output PDF");
            }
        }
    }
}
