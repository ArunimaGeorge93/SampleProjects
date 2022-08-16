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
    public partial class FileReaderEx : System.Web.UI.Page
    {
        string excelPath = @"C:\Users\C5093300\source\repos\ExamplesUsage\ExamplesUsage\Uploads\";
        string currFilePath = string.Empty; //File Full Path  
        string currFileExtension = string.Empty; //File Extension 
        string connString = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUploader_Click(object sender, EventArgs e)
        {
            String savePath = @"C:\Users\C5093300\source\repos\ExamplesUsage\ExamplesUsage\Uploads\";
            //String excelPath = @"C:\Users\C5093300\source\repos\ExamplesUsage\ExamplesUsage\Uploads\DEMO LOAD TEMPLETE FOR SPLIT.xlsx";
            if (FileUploader.HasFile)
            {
                try
                {
                    //excel read

                   
                   // string con ="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelPath + ";Extended Properties=Excel 12.0;";
                    

                    //eccel read end
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
                        switch (s.Substring(0,1))
                        {
                            case "1":
                                string[] strlst1 = { "2:9", "10:17", "18:25", "26:429" };
                                foreach (var a in strlst1)
                                {
                                    string[] tests = a.Split(':');
                                    string final = SubstringByIndexes(s, Convert.ToInt32(tests[0]), Convert.ToInt32(tests[1]));
                                    finalline = string.Concat((string.IsNullOrEmpty(finalline) ? (finalline) : (finalline + " ")) + final);
                                }
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
                    // To iterate over it.
                    //foreach (List<string> subList in myList)
                    //{
                    //    foreach (string item in subList)
                    //    {
                    //        Console.WriteLine(item);
                    //    }
                    //}

                    //txtReader.Text = myList;
                }
                catch(Exception ce)
                {
                    UploadStatusLabel.Text = ce.Message;
                }
            }
            else
            {
                // Notify the user that a file was not uploaded.
                UploadStatusLabel.Text = "You did not specify a file to upload.";
            }
        }
        //public string StringSplitter(string line,int type)
        //{
        //    string final1 = string.Empty;
        //    if (type==1)
        //    {
        //        string[] arry = {"2:9","10:17","18:25","26:429"};
        //        foreach(var a in arry)
        //        {
        //            string[] tests = a.Split(':');
        //           string final=SubstringByIndexes(line,Convert.ToInt32(tests[0]),Convert.ToInt32(tests[1]));
        //            final1= string.Concat((string.IsNullOrEmpty(final1)?(final1):(final1+" "))+final);
        //        }
                
                
        //       // string final = string.Join(" ", test, test1, test2, test3);
        //        return final1;
        //    }

        //    return line;
        //}
        public string SubstringByIndexes(string value, int startIndex, int endIndex)
        {
            if (startIndex > value.Length|| endIndex > value.Length)
                return string.Empty;
            return value.Substring((startIndex-1), (endIndex - startIndex + 1));
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = this.fileSelect.PostedFile;
            string fileName = file.FileName;
           // string tempPath = System.IO.Path.GetTempPath(); //Get Temporary File Path  
           // fileName = System.IO.Path.GetFileName(fileName); //Get File Name (not including path)  
            this.currFileExtension = System.IO.Path.GetExtension(fileName); //Get File Extension  
            this.currFilePath = excelPath + fileName; //Get File Path after Uploading and Record to Former Declared Global Variable  
            file.SaveAs(this.currFilePath); //Upload  
            InitializeOledbConnection(currFilePath, currFileExtension);
            if (this.currFileExtension == ".xlsx" || this.currFileExtension == ".xls")
            {
                DataTable dt = ReadExcelToTable(currFilePath); //Read Excel File (.XLS and .XLSX Format)  
            }
            else if (this.currFileExtension == ".csv")
            {
               // DataTable dt = ReadExcelWidthStream(currFilePath); //Read .CSV File  
            }
        }
        ///<summary>  
        ///Method to Read XLS/XLSX File  
        ///</summary>  
        ///<param name="path">Excel File Full Path</param>  
        ///<returns></returns>  
        private DataTable ReadExcelToTable(string path)
        {
            //Connection String  
            
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" }); //Get All Sheets Name  
                string firstSheetName = sheetsName.Rows[0][2].ToString(); //Get the First Sheet Name  
                string sql = string.Format("SELECT * FROM [{0}],firstSheetName"); //Query String  
                OleDbDataAdapter ada = new OleDbDataAdapter(sql, connString);
                DataSet set = new DataSet();
                ada.Fill(set);
                return set.Tables[0];
            }
        }
        void InitializeOledbConnection(string filename, string extrn)
        {
            

            if (extrn == ".xls")
            {
                //Connectionstring for excel v8.0    

                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Extended Properties=Excel 8.0;HDR=NO;IMEX=1';";
            }                
            else
            {
                //Connectionstring fo excel v12.0    
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties=Excel 12.0;";
                
                //OledbConn = new OleDbConnection(connString);
            }
                
        }
        
    }
}