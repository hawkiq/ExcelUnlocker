using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.IO.Compression;
using System.Xml.Linq;
using System.Diagnostics;



namespace ExcelDecrypter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filelbl.Text = openFileDialog.FileName;
            }
                
        }

        private void UnlockBtnProcess_Click(object sender, EventArgs e)
        {
            string filePath = openFileDialog.FileName;
            Console.WriteLine("Selected file: " + filePath);
            string extension = Path.GetExtension(filePath);
            if (extension == ".xls" || extension == ".xlsx" || extension == ".xlsm")
            {
                // Create a copy of the original file with a .zip extension in the temporary directory
                string tempZipFile = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(filePath) + ".zip");
                Console.WriteLine("Temporary ZIP file: " + tempZipFile);
                File.Copy(filePath, tempZipFile);

                // Extract the contents of the ZIP file to a temporary directory
                string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                Console.WriteLine("Temporary directory: " + tempDir);
                ZipFile.ExtractToDirectory(tempZipFile, tempDir);

                // Navigate to specific folder inside extracted contents
                string targetDir = Path.Combine(tempDir, "xl", "worksheets");
                string[] files = Directory.GetFiles(targetDir, "sheet*");
                Console.WriteLine("Found {0} files starting with 'sheet':", files.Length);
                // Do processing on files in target folder
                foreach (string file in files)
                {
                    Console.WriteLine("  " + file);

                    XDocument doc = XDocument.Load(file);

                    // Remove any sheetProtection elements from the document
                    // Get all sheetProtection elements
                    XNamespace ns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
                    IEnumerable<XElement> sheetProtections = doc.Descendants(ns+ "sheetProtection");

                    // Print number of sheetProtection elements found
                    Console.WriteLine("Found {0} sheetProtection elements in file {1}", sheetProtections.Count(), file);

                    // Remove all sheetProtection elements
                    sheetProtections.Remove();


                    // Save the modified XDocument object back to the file
                    doc.Save(file);
                }

                // Compress the modified files into a ZIP file
                string zipFileName = Path.Combine(Path.GetTempPath(), "edited_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".zip");
                Console.WriteLine("Compressed ZIP file: " + zipFileName);

                ZipFile.CreateFromDirectory(tempDir, zipFileName, CompressionLevel.Optimal, false);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Macro-Enabled Workbook (*.xlsm)|*.xlsm";
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(filePath) + "_hawkiq_unlocked_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Copy the ZIP file to the selected location with a .xlsm extension
                    string xlsmFileName = Path.ChangeExtension(saveFileDialog.FileName, ".xlsm");
                    Console.WriteLine("Selected XLSM file: " + xlsmFileName);
                    File.Copy(zipFileName, xlsmFileName);

                    // Open the folder where the file was saved 
                    string folderPath = Path.GetDirectoryName(xlsmFileName);
                    Process.Start(folderPath);
                }
                // Clean up temporary files and directories
                File.Delete(tempZipFile);
                File.Delete(zipFileName);
                Directory.Delete(tempDir, true);
                Console.WriteLine("Temporary files and directories deleted.");
            }
            else
            {
                MessageBox.Show("Selected file is not a Excel file.");
            }
        }
    }
}
