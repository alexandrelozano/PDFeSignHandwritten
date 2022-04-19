using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommandLine;

namespace PDFeSignHandwritten
{
    static class Program
    {
        public class Options
        {
            [Option('p', "pdf", Required = false, HelpText = "Set PDF file path to open.")]
            public string PDFPath { get; set; }

            [Option('n', "name", Required = false, HelpText = "Sign name info.")]
            public string Name { get; set; }

            [Option('c', "contactinfo", Required = false, HelpText = "Sign contact info.")]
            public string ContactInfo { get; set; }

            [Option('l', "location", Required = false, HelpText = "Sign Location info.")]
            public string Location { get; set; }

            [Option('r', "reason", Required = false, HelpText = "Sign reason info.")]
            public string Reason { get; set; }

            [Option('f', "certificate", Required = false, HelpText = "Certificate file path.")]
            public string Certificate { get; set; }

            [Option('p', "certificatepassword", Required = false, HelpText = "Certificate password.")]
            public string CertificatePassword { get; set; }

            [Option('t', "timestampserver", Required = false, HelpText = "Timestamp server URL.")]
            public string TimestampServer { get; set; }

            [Option('o', "pdfoutput", Required = false, HelpText = "Signed PDF output path.")]
            public string PDFOutput { get; set; }

            [Option('a', "openpdfaftersign", Required = false, HelpText = "Open PDF after sign.")]
            public string OpenPDFAfterSign { get; set; }

            [Option('i', "image", Required = false, HelpText = "Image to use for sign.")]
            public string image { get; set; }

            [Option('h', "help", Required = false, HelpText = "Show command line parameters.")]
            public bool help { get; set; }
        }

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            fMain frmMain;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmMain = new fMain();
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(o => {
                if (!string.IsNullOrEmpty(o.PDFPath))
                {
                    if (System.IO.File.Exists(o.PDFPath))
                    {
                        frmMain.PDFPathToOpenAtStart = o.PDFPath;
                    }
                    else
                    {
                        Console.WriteLine("PDF file not found at " + o.PDFPath);
                        System.Environment.Exit(-1);
                    }
                }

                if (!string.IsNullOrEmpty(o.Name)) ConfigurationManager.AppSettings["Name"] = o.Name;
                if (!string.IsNullOrEmpty(o.ContactInfo)) ConfigurationManager.AppSettings["ContactInfo"] = o.ContactInfo;
                if (!string.IsNullOrEmpty(o.Location)) ConfigurationManager.AppSettings["Location"] = o.Location;
                if (!string.IsNullOrEmpty(o.Reason)) ConfigurationManager.AppSettings["Reason"] = o.Reason;
                if (!string.IsNullOrEmpty(o.Certificate)) ConfigurationManager.AppSettings["Certificate"] = o.Certificate;
                if (!string.IsNullOrEmpty(o.CertificatePassword)) ConfigurationManager.AppSettings["CertificatePassword"] = o.CertificatePassword;
                if (!string.IsNullOrEmpty(o.TimestampServer)) ConfigurationManager.AppSettings["TimestampServer"] = o.TimestampServer;
                if (!string.IsNullOrEmpty(o.PDFOutput)) ConfigurationManager.AppSettings["PDFOutput"] = o.PDFOutput;
                if (!string.IsNullOrEmpty(o.OpenPDFAfterSign)) ConfigurationManager.AppSettings["OpenPDFAfterSign"] = o.OpenPDFAfterSign;
                if (!string.IsNullOrEmpty(o.image)) frmMain.ImageToOpen = o.image;

                if (o.help)
                {
                    string helpMessage = "Command line parameters:\n\n";
                    helpMessage += "-p \t\t\t[path]\t\t PDF file to open\n";
                    helpMessage += "-n \t\t\t[name]\t\t Sign name info\n";
                    helpMessage += "-c \t\t[contactinfo]\t Sign contact info\n";
                    helpMessage += "-l \t\t[location]\t Sign location info\n";
                    helpMessage += "-r \t\t\t[reason]\t\t Sign reason info\n";
                    helpMessage += "-f \t\t[certificate]\t Certificate path\n";
                    helpMessage += "-p \t[password]\t Certificate password\n";
                    helpMessage += "-t \t\t[URL]\t\t Timestamp server URL\n";
                    helpMessage += "-o \t\t[path]\t\t Signed PDF output path\n";
                    helpMessage += "-a \t\t\t\t Open PDF after sign\n";
                    helpMessage += "-i \t\t[path]\t\t Image to use for sign\n";
                    helpMessage += "-help \t\t\t\t\t show this help\n";

                    MessageBox.Show(helpMessage,"PDFeSignHandwritten");
                }
            });

            Application.Run(frmMain);
        }
    }
}
