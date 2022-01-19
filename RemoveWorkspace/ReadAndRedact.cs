using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace RemoveWorkspace
{
    internal class ReadAndRedact
    {
        internal static void Start(string filenameToRead, string filenameToSave)
        {
            // Copy old file to new file such that the original file is not changed
            File.Copy(filenameToRead, filenameToSave);
            // see https://docs.microsoft.com/en-us/office/open-xml/how-to-remove-a-document-part-from-a-package
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filenameToSave, true))
            {
                // Main Document Part
                MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                // All Tables
                List<Table> tables = mainPart.Document.Descendants<Table>().ToList();
                // properties of all tables
                IEnumerable<TableProperties> tableProps = mainPart.Document.Descendants<TableProperties>().Where(
                    tp => tp.TableCaption != null);
                // Go to each property value
                foreach (TableProperties tProp in tableProps)
                {
                    // Check for "Workspace" as the name
                    if (tProp.TableCaption.Val.ToString().Equals("Workspace")) 
                    {
                        Table table = (Table)tProp.Parent;
                        IEnumerable<TableRow> rows = table.Elements<TableRow>();
                        TableRow firstRow = rows.FirstOrDefault();
                        // Remove caption text "Workspace" and replace it with "Redacted" thus we know that this
                        // table has been 'redacted'
                        tProp.TableCaption.Val = "Redacted";
                        // table.
                        // Delete the first row
                        firstRow.Remove();
                    }
                }
            }
        }
    }
}