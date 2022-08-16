using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamplesUsage
{
    public partial class ExcelReader : System.Web.UI.Page
    {
        DataTable dtsheet = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
       

        protected void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                HttpPostedFile Inputfile = this.fileSelect.PostedFile;
                DataSet dsexcelRecords = new DataSet();
                IExcelDataReader reader = null;
                Stream FileStream = null;
                string message = string.Empty;
                if (Inputfile.ContentLength>0)
                    {
                        FileStream = Inputfile.InputStream;

                        if (Inputfile != null && FileStream != null)
                        {
                            if (Inputfile.FileName.EndsWith(".xls"))
                                reader = ExcelReaderFactory.CreateBinaryReader(FileStream);
                            else if (Inputfile.FileName.EndsWith(".xlsx"))
                                reader = ExcelReaderFactory.CreateOpenXmlReader(FileStream);
                            else
                                message = "The file format is not supported.";

                            dsexcelRecords = reader.AsDataSet();
                            reader.Close();

                            if (dsexcelRecords != null && dsexcelRecords.Tables.Count > 0)
                            {
                                dtsheet = dsexcelRecords.Tables[0];
                            
                            foreach (DataColumn column in dtsheet.Columns)
                            {
                                string cName = dtsheet.Rows[0][column.ColumnName].ToString();
                                if (!dtsheet.Columns.Contains(cName) && cName != "")
                                {
                                    column.ColumnName = cName;
                                }
                            }
                            // dtsheet.Rows[0].Delete();
                            dtsheet.Rows.RemoveAt(0);
                            if (FileUploader.HasFile)
                                {
                                batfilereader();
                                }
                                else
                                message = "Please select a bat file";
                            }
                            else
                                message = "Selected file is empty.";
                        }
                        else
                            message = "Invalid File.";
                    }
                else
                    message = "Please select a excel file";


            }
            catch (Exception)
            {
                throw;
            }

        }
        public void batfilereader()
        {
            String savePath = @"C:\Users\C5093300\source\repos\ExamplesUsage\ExamplesUsage\Uploads\";
            
                try
                {
                
                string findcol2 = "RecordType = 2";
                DataRow[] foundRows2 = dtsheet.Select(findcol2);
                string findcol3 = "RecordType = 3";
                DataRow[] foundRows3 = dtsheet.Select(findcol3);
                String fileName = FileUploader.FileName;
                    savePath += fileName;
                    FileUploader.SaveAs(savePath);

                    var ls = new List<string>();
                    List<string> myList = new List<string>();
                    var reader = new StreamReader(savePath);
                    while (!reader.EndOfStream)
                    {
                        var s = reader.ReadLine().Trim();
                        string finalline = string.Empty;
                        s = string.Join("", s.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                        // List<string> ab = s.Split(new[] { "  " }, StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToList();
                        //start switch case
                        //string caseSwitch = s.ToString();
                        switch (s.Substring(0, 1))
                        {
                            case "1":
                                string findcol1 = "RecordType = 1";
                                DataRow[] foundRows1 = dtsheet.Select(findcol1);
                           // DataTable test1 = dtsheet.Select(findcol1);
                            DataTable dtRollover = new DataTable();
                            DataRow dtrow = null;
                            int index = 0;
                            dtrow = dtRollover.NewRow();
                            dtRollover.Rows.Add(dtrow);
                            foreach (DataRow dataRow in foundRows1)
                            {
                                dtRollover.Columns.Add(dataRow.ItemArray[0].ToString());
                                string extractindex = string.Empty;
                                if (dataRow.ItemArray[1] !=null && dataRow.ItemArray[2]!=null)
                                extractindex = SubstringByIndexes(s, Convert.ToInt32(dataRow.ItemArray[1]), Convert.ToInt32(dataRow.ItemArray[2]));
                                dtRollover.Rows[0][index] = extractindex;
                                index++;
                            }
                            Gvsplit.DataSource = dtRollover;
                            Gvsplit.DataBind();
                            break;
                            case "2":
                                string[] strlst2 = { "2:9", "10:17", "18:25", "26:429" };
                                foreach (var a in strlst2)
                                {
                                    string[] tests = a.Split(':');
                                    string final = SubstringByIndexes(s, Convert.ToInt32(tests[0]), Convert.ToInt32(tests[1]));
                                    finalline = string.Concat((string.IsNullOrEmpty(finalline) ? (finalline) : (finalline + " ")) + final);
                                }
                                break;
                            case "3":
                                Console.WriteLine("Case 3");
                                break;
                            default:
                                Console.WriteLine("Value didn’t match earlier.");
                                break;
                        }
                        //end switch case

                        myList.Add(finalline);
                    }
                    reader.Close();
                    
                }
                catch (Exception ce)
                {
                   // UploadStatusLabel.Text = ce.Message;
                }
        }

        public string SubstringByIndexes(string value, int startIndex, int endIndex)
        {
            if (startIndex > value.Length || endIndex > value.Length)
                return string.Empty;
            return value.Substring((startIndex - 1), (endIndex - startIndex + 1));
        }
    }
}