using System;
using System.IO;

namespace RemoveWorkspace
{
    internal class Helpers
    {
        private class myFile
        {
            public string filePath;
            public string fileName;
            public string fileNameWithoutExtension;
        }
        internal static string MakeFilenameToSave(string filenameToRead)
        {
            checkFilenameIsExisting(filenameToRead);
            myFile file = ExtractPathAndFile(filenameToRead);
            string newFile = file.filePath + @"\" + file.fileNameWithoutExtension + " redacted.docx"; 
            if (File.Exists(newFile))
            {
                throw new System.IO.FileLoadException("File already exist: " + newFile, newFile);
            }

            return newFile;
        }

        private static myFile ExtractPathAndFile(string filenameToRead)
        {
            int pos = filenameToRead.LastIndexOf(@"\");
            checkFileExtension(filenameToRead);
            myFile file = new myFile();
            if (pos == -1)
            {
                file.filePath = Environment.CurrentDirectory;
                file.fileName = filenameToRead;
                file.fileNameWithoutExtension = FilenameWithoutExtension(file.fileName);
            }
            else
            {
                file.filePath = filenameToRead.Substring(0, pos);
                file.fileName = filenameToRead.Substring(pos+1);
                file.fileNameWithoutExtension = FilenameWithoutExtension(file.fileName);
            }
            return file;
        }

        internal static string CheckFilenamesAndReturnFilenameToSave(string filenameToRead, string filenameToSave)
        {
            checkFilenameIsExisting(filenameToRead);
            myFile fileRead = ExtractPathAndFile(filenameToRead);
            myFile fileSave = ExtractPathAndFile(filenameToSave);
            string newFile = fileSave.filePath + @"\" + fileSave.fileName;
            if (File.Exists(newFile))
            {
                throw new System.IO.FileLoadException("File already exist: " + newFile, newFile);
            }
            return newFile;
        }

        private static string FilenameWithoutExtension(string fileName)
        {
            return fileName.Substring(0, fileName.Length - 5);
        }

        private static void checkFileExtension(string filenameToRead)
        {
            int length = filenameToRead.Length;
            if(length < 6 || !(filenameToRead.Substring(length-5).Equals(".docx"))) {
                throw new System.IO.FileFormatException("File is not a word file with ending .docx" + filenameToRead);
            }
        }

        private static void checkFilenameIsExisting(string filenameToRead)
        {
            if( !File.Exists(filenameToRead))
            {
                // Filename does not exist!
                throw new System.IO.FileNotFoundException("File does not exist: " + filenameToRead, filenameToRead);
            }
        }
    }
}