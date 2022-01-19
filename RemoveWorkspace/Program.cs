using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveWorkspace
{
    class Program
    {
        static void Main(string[] args)
        {
            // args contains the path and filename of the word file that we would like to redact
            string filenameToRead;
            string filenameToSave;
            switch (args.Length)
            {
                case 0:
                    Console.WriteLine("Please add filepath and filename that should be redacted and/or the destination");
                    return;
                case 1:
                    filenameToRead = args[0];
                    filenameToSave = Helpers.MakeFilenameToSave(filenameToRead);
                    Console.WriteLine("File will be saved with 'redacted' appended to the file name");
                    Console.WriteLine(filenameToSave);
                    break;
                case 2:
                    filenameToRead = args[0];
                    filenameToSave = args[1];
                    filenameToSave = Helpers.CheckFilenamesAndReturnFilenameToSave(filenameToRead, filenameToSave);
                    Console.WriteLine("File will be saved with 'redacted' appended to the file name");
                    Console.WriteLine(filenameToSave);
                    break;
                default:
                    Console.WriteLine(@"Number of arguments is not matching. Please enter filepath\filename and/or in addition the destination");
                    return;
            }

            ReadAndRedact.Start(filenameToRead, filenameToSave);
            Console.WriteLine("Fin.");

        }
    }
}
