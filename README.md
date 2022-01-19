# RemoveWorkspace
Basic cmd tool for removing workspace


This is the command line tool (created 2017 as presented in CTFG) for redacting the assessment reports.

Basics:

Program is written in C# and updated (19 Jan 2021) to .NET framework 4.8 (sorry, not transferred to .NET core...)
You can easily compile via Microsoft Visual Studio Code
How to:

Clone or download the repository
Compile
How to use:

You have to start the command line tool "RemoveWorkspace.exe" with parameters:
e.g. you have an assessment report template in the same folder as the .exe file, call (Windows Terminal with PowerShell) .\RemoveWorkspace.exe .\Clinical_Assessment_report_part_I.docx You will get the redacted version named "Clinical_Assessment_report_part_I redacted.docx"
If you would like to name also the destination file, do the call with two parameters, the source file and the destination file. (Please make sure that the destination file does not exist.)

Have fun!
