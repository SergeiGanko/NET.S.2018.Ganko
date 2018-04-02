using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Streams
{
    using System.CodeDom;
    using System.Linq;

    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    /// <summary>
    /// StreamsExtension class
    /// </summary>
    public static class StreamsExtension
    {

        #region Public members

        #region Implementation by byte copy logic using class FileStream as a backing store stream .

        /// <summary>
        /// Copies the content of file to another file
        /// </summary>
        /// <param name="sourcePath">The source file path.</param>
        /// <param name="destinationPath">The destination file path.</param>
        /// <returns>Returns copied bytes quantity</returns>
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int writtenBytes = 0;

            using (FileStream readStream = File.OpenRead(sourcePath))
            {
                using (FileStream writeStream = File.Create(destinationPath))
                {
                    readStream.CopyTo(writeStream);

                    writtenBytes = (int)writeStream.Length;
                }
            }

            return writtenBytes;
        }

        #endregion

        #region Implementation by byte copy logic using class MemoryStream as a backing store stream.

        /// <summary>
        /// Copies the content of file to another file.
        /// </summary>
        /// <param name="sourcePath">The source file path.</param>
        /// <param name="destinationPath">The destination file path.</param>
        /// <returns>Returns copied bytes quantity</returns>
        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            byte[] buffer = null;
            int writtenBytes = 0;
            using (StreamReader reader = File.OpenText(sourcePath))
            {
                buffer = Encoding.UTF8.GetBytes(reader.ReadToEnd());
            }

            using (var memoryStream = new MemoryStream(buffer, 0, buffer.Length))
            {
                memoryStream.Write(buffer, 0, buffer.Length);
                buffer = memoryStream.ToArray();
            }

            char[] array = Encoding.UTF8.GetChars(buffer);

            using (StreamWriter writer = new StreamWriter(destinationPath))
            {
                writer.Write(array);
                writtenBytes = writer.Encoding.GetByteCount(array);
            }

            return writtenBytes;
        }

        #endregion

        #region Implementation by block copy logic using FileStream buffer.

        /// <summary>
        /// Copies the content of file to another file.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>Returns copied bytes quantity</returns>
        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int writtenBytes = 0;

            using (FileStream readStream = File.OpenRead(sourcePath))
            {
                using (FileStream writeStream = File.OpenWrite(destinationPath))
                {
                    int length = (int)readStream.Length;
                    byte[] buffer = new byte[length];

                    int bytesRead = 0;
                    int offset = 0;

                    while ((bytesRead = readStream.Read(buffer, offset, length - offset)) > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                        offset += bytesRead;
                    }

                    writtenBytes = (int)writeStream.Length;
                }
            }

            return writtenBytes;
        }

        #endregion

        #region Implementation by block copy logic using MemoryStream.

        /// <summary>
        /// Copies the content of file to another file.
        /// </summary>
        /// <param name="sourcePath">The source file path.</param>
        /// <param name="destinationPath">The destination file path.</param>
        /// <returns>Returns copied bytes quantity</returns>
        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int writtenBytes = 0;

            using (StreamReader reader = File.OpenText(sourcePath))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (StreamWriter writer = new StreamWriter(destinationPath))
                    {
                        byte[] buffer = null;
                        char[] array = new char[100];
                        byte[] resultArray = null;
                        int bytesRead;
                        int offset = 0;
                        while ((bytesRead = reader.Read(array, offset, array.Length - offset)) > 0)
                        {
                            offset += bytesRead;
                            buffer = Encoding.UTF8.GetBytes()
                            memoryStream.Write(buffer, 0, buffer.Length);
                            resultArray = memoryStream.ToArray();

                            writer.Write();
                        }

                        writtenBytes = writer.Encoding.GetByteCount(array);
                    }
                }
            }

            return writtenBytes;
        }

        #endregion

        #region Implementation by block copy logic using class-decorator BufferedStream.

        /// <summary>
        /// Copies the content of file to another file.
        /// </summary>
        /// <param name="sourcePath">The source file path.</param>
        /// <param name="destinationPath">The destination file path.</param>
        /// <returns>Returns copied bytes quantity</returns>
        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int writtenBytes = 0;

            using (FileStream readStream = File.OpenRead(sourcePath))
            {
                int length = (int)readStream.Length;
                byte[] buffer = new byte[length];

                using (BufferedStream bufferedStream = new BufferedStream(readStream, length))
                {
                    using (FileStream writeStream = File.OpenWrite(destinationPath))
                    {
                        int bytesRead = 0;
                        int offset = 0;

                        while ((bytesRead = bufferedStream.Read(buffer, offset, length - offset)) > 0)
                        {
                            writeStream.Write(buffer, 0, bytesRead);
                            offset += bytesRead;
                        }

                        writtenBytes = (int)writeStream.Length;
                    }
                }
            }

            return writtenBytes;
        }

        #endregion

        #region Implementation by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        /// <summary>
        /// Copies the content of file to another file.
        /// </summary>
        /// <param name="sourcePath">The source file path.</param>
        /// <param name="destinationPath">The destination file path.</param>
        /// <returns>Returns copied string lines quantity</returns>
        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int writtenSrtings = 0;

            using (FileStream fileStream = File.OpenRead(sourcePath))
            {
                using (TextReader reader = new StreamReader(fileStream))
                {
                    using (TextWriter writer = new StreamWriter(destinationPath))
                    {
                        while (reader.Peek() > -1)
                        {
                            writer.WriteLine(reader.ReadLine());

                            writtenSrtings++;
                        }
                    }
                }
            }

            return writtenSrtings;
        }

        #endregion

        #region Implementation content comparison logic of two files 

        /// <summary>
        /// Determines whether comparison of two files.
        /// </summary>
        /// <param name="sourcePath">The source file path.</param>
        /// <param name="destinationPath">The destination file path.</param>
        /// <returns>
        ///   <c>true</c> if the source file equals the destination file; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            if (sourcePath == destinationPath)
            {
                return true;
            }

            FileStream sourceFile = File.Open(sourcePath, FileMode.Open);
            FileStream destinationFile = File.Open(destinationPath, FileMode.Open);

            if (sourceFile.Length != destinationFile.Length)
            {
                sourceFile.Close();
                destinationFile.Close();

                return false;
            }

            int sourceFileByte;
            int destinationFileByte;

            do
            {
                sourceFileByte = sourceFile.ReadByte();
                destinationFileByte = destinationFile.ReadByte();
            }
            while ((sourceFileByte == destinationFileByte) && (sourceFileByte != -1));

            sourceFile.Close();
            destinationFile.Close();

            return (sourceFileByte - destinationFileByte) == 0;
        }

        #endregion

        #endregion

        #region Private members

        #region Implementation of the validation logic

        /// <summary>
        /// The input validation method.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <exception cref="ArgumentException">Throws when sourcePath or destinationPath is invalid</exception>
        /// <exception cref="FileNotFoundException">Throws when file is not found</exception>
        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (!IsValidFileName(sourcePath))
            {
                throw new ArgumentException($"String path ({nameof(sourcePath)}) is empty, null or whitespace.");
            }

            if (!IsValidFileName(destinationPath))
            {
                throw new ArgumentException($"String path ({nameof(destinationPath)}) is empty, null or whitespace.");
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"File {nameof(sourcePath)} not found");
            }
        }

        /// <summary>
        /// Defines the correctness of the incoming file path
        /// </summary>
        /// <param name="name">The string name.</param>
        /// <returns>
        ///   <c>true</c> if file path is correct string; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsValidFileName(string name)
        {
            return 
                !string.IsNullOrWhiteSpace(name) &&
                name.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 &&
                !Path.GetFullPath(name).StartsWith(@"\\.\");
        }

        #endregion

        #endregion

    }
}
