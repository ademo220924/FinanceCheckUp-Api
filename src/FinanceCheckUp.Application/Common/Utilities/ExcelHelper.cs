using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using FinanceCheckUp.Application.Models.Common;
using System.Data;

namespace fincheckup.Helper
{
    public static class ExcelHelper
    {
        public static DataTable ExcelToDataTable(string filePath)
        {
            var book = new Workbook();
            book.LoadDocument(filePath);


            for (int i = book.Worksheets.Count - 1; i >= 0; i--)
            {
                if (book.Worksheets[i].Visible == false)
                {
                    book.Worksheets.RemoveAt(i);
                }
            }
            Worksheet sheet1 = book.Worksheets[0];

            var range1 = sheet1.GetUsedRange();
            //    var table1 = sheet1.CreateDataTable(range1, false);
            //int counter = table1.Columns.Count;
            //Worksheet sheet1z = book.Worksheets[0];
            //sheet1z.ClearContents(range1);
            //sheet1z.CopyFrom(sheet);
            Worksheet sheet = book.Worksheets[0];
            List<int> nlist = new List<int>();
            for (int i = range1.CurrentRegion.ColumnCount; i >= 0; i--)
            {
                if (sheet.Columns[i].Visible == false)
                {
                    nlist.Add(i);
                }
            }


            var range = sheet.GetUsedRange();

            //for (int i = range.CurrentRegion.ColumnCount-1; i >=0 ; i--)
            //{
            //    if (range.CurrentRegion[i].ColumnWidth == 0)
            //    {
            //        range.CurrentRegion[i].Delete();
            //    }
            //}

            var table = sheet.CreateDataTable(range, false);
            //DataTable dataTable = sheet.CreateDataTable(range, true);
            //dataTable.Columns[0].DataType = System.Type.GetType("System.String");
            //DataTableExporter exporter = sheet.CreateDataTableExporter(range, dataTable, true);

            for (int i = 0; i < table.Columns.Count - 1; i++)
            {
                table.Columns[i].DataType = typeof(string);
            }
            //for (int i = range1.CurrentRegion.ColumnCount - 1; i >= 0; i--)
            //{
            //    table.Columns[i].DataType = typeof(string);

            //}
            var exporter = sheet.CreateDataTableExporter(range, table, false);

            exporter.Options.SkipEmptyRows = true;
            exporter.CellValueConversionError += Exporter_CellValueConversionError;
            exporter.Export();

            for (int i = range1.CurrentRegion.ColumnCount - 1; i >= 0; i--)
            {

                if (nlist.Contains(i))
                {

                    table.Columns.Remove(table.Columns[i]);
                }
            }
            return table;




        }

        private static void Exporter_CellValueConversionError(object sender, CellValueConversionErrorEventArgs e)
        {
            e.Action = DataTableExporterAction.Continue;
            e.DataTableValue = null;
        }
        public static IEnumerable<XmlExcel> CheckColumnPdfExcel(DataTable e)
        {
            int counter = 0;

            List<string> nlist = new List<string>();
            List<List<string>> nlista = new List<List<string>>();
            int chkzone = 0;

            foreach (DataColumn column in e.Columns)
            {
                nlist = new List<string>();
                foreach (DataRow row in e.Rows)
                {
                    counter++;
                    if (row[column] != null)
                    {
                        string value = row[column].ToString();
                        if (!String.IsNullOrEmpty(value))
                        {
                            if (!nlist.Contains(value))
                            {
                                nlist.Add(value);
                            }
                        }
                    }


                }
                nlista.Add(nlist);


            }
            List<int> ntechg = new List<int>();
            chkzone = nlista.Max(x => x.Count) / 10;
            for (int i = nlista.Count - 1; i >= 0; i--)
            {
                if (nlista[i].Count < 5)
                {

                    if (nlista[i].Count == 0)
                    {
                        nlista.RemoveAt(i);
                        ntechg.Add(i);
                    }
                    if (nlista[i].Count > 0 && (!nlista[i][0].ToLower().Contains("alacak") && !nlista[i][0].ToLower().Contains("borç") && !nlista[i][0].ToLower().Contains("borc")))
                    {
                        nlista.RemoveAt(i);
                        ntechg.Add(i);
                    }

                }
            }
            ntechg.Sort();


            for (int i = ntechg.Count - 1; i >= 0; i--)
            {

                //ntechg.Add(i);
                e.Columns.RemoveAt(ntechg[i]);
            }
            // t.Columns.RemoveAt(columnIndex);
            //for (int i = 0; i < 10; i++)
            //{

            //    for (int z = 0; z < e.Columns.Count; z++)
            //    {
            //        if (!nlist.Contains(e.Rows[i][z]))
            //        {
            //            nlist.Add(e.Rows[i][z]);
            //        }
            //        nlista.Add(nlist);
            //    }

            //}

            while (e.Columns.Count < 5)
            {
                e.Columns.Add(new DataColumn());
            }

            if (e.Columns.Count > 5)
            {
                for (int i = e.Columns.Count - 1; i >= 5; i--)
                {
                    e.Columns.RemoveAt(i);
                }
            }


            var chk = nlista;

            e.Columns[0].ColumnName = "AccountMainID";
            e.Columns[1].ColumnName = "AccountMainDescription";
            e.Columns[2].ColumnName = "DebitAmount";
            e.Columns[3].ColumnName = "CreditAmount";
            e.Columns[4].ColumnName = "AmountBakiye";
            e.AcceptChanges();


            //var json = JsonConvert.SerializeObject(e);
            //var YourConvertedDataType = JsonConvert.DeserializeObject<XmlExcel>(json);

            //DataTable dtCloned = e.Clone();




            //foreach (DataRow row in e.Rows)
            //{
            //    dtCloned.ImportRow(row);
            //}


            try
            {
                //List<XmlExcelCheck> nlistExceln = new List<XmlExcelCheck>();
                //XmlExcelCheck nexceln = new XmlExcelCheck();
                //foreach (var item in e.AsEnumerable())
                //{
                //    try
                //    {
                //        nexceln = new XmlExcelCheck();
                //        nexceln.AccountMainID = checkValz(item.Field<String>("AccountMainID")).ToString();
                //        nexceln.AccountMainDescription = checkValz(item.Field<String>("AccountMainDescription")).ToString();
                //        nexceln.DebitAmount = checkValz(item.Field<String>("DebitAmount")).ToString();
                //        nexceln.CreditAmount = checkValz(item.Field<String>("CreditAmount")).ToString();
                //        nexceln.AmountBakiye = checkValz(item.Field<String>("AmountBakiye")).ToString();
                //        nlistExceln.Add(nexceln);
                //    }
                //    catch (Exception ex)
                //    {
                //        var chkxx = ex;
                //        throw;
                //    }

                //}

                IEnumerable<XmlExcel> lstCustomer = e.AsEnumerable().Select(x => new XmlExcel()
                {
                    AccountMainID = checkValz(x.Field<String>("AccountMainID")).ReplaceLineEndings()
  .Split(Environment.NewLine, StringSplitOptions.None)[0],
                    AccountMainDescription = checkValz(x.Field<String>("AccountMainDescription")).ReplaceLineEndings()
  .Split(Environment.NewLine, StringSplitOptions.None)[0],
                    DebitAmount = checkValz(x.Field<String>("DebitAmount")).ReplaceLineEndings()
  .Split(Environment.NewLine, StringSplitOptions.None)[0],
                    CreditAmount = checkValz(x.Field<String>("CreditAmount")).ReplaceLineEndings()
  .Split(Environment.NewLine, StringSplitOptions.None)[0],
                    AmountBakiye = checkValz(x.Field<String>("AmountBakiye")).ReplaceLineEndings()
  .Split(Environment.NewLine, StringSplitOptions.None)[0]
                }).ToList();
                int conuter = lstCustomer.Count();
                int conuterz = lstCustomer.Where(x => x.AccountMainID.Length < 3).Count();
                if (conuterz > conuter / 2)
                {
                    e.Columns.RemoveAt(0);
                    return CheckColumnRev(e);
                }
                else
                {
                    return lstCustomer;
                }

            }
            catch
            {

                IEnumerable<XmlExcel> lstCustomer = e.AsEnumerable().Select(x => new XmlExcel()
                {
                    AccountMainID = checkValz(x.Field<String>("AccountMainID")),
                    AccountMainDescription = checkValz(x.Field<String>("AccountMainDescription")),
                    DebitAmount = checkValz(x.Field<double?>("DebitAmount")),
                    CreditAmount = checkValz(x.Field<double?>("CreditAmount")),
                    AmountBakiye = checkValz(x.Field<double?>("AmountBakiye"))
                }).ToList();
                int conuter = lstCustomer.Count();
                int conuterz = lstCustomer.Where(x => x.AccountMainID.Length < 3).Count();
                if (conuterz > conuter / 2)
                {
                    e.Columns.RemoveAt(0);
                    return CheckColumnRev(e);
                }
                else
                {
                    return lstCustomer;
                }

            }



        }
        public static IEnumerable<XmlExcel> CheckColumn(DataTable e)
        {
            int counter = 0;

            List<string> nlist = new List<string>();
            List<List<string>> nlista = new List<List<string>>();
            int chkzone = 0;

            foreach (DataColumn column in e.Columns)
            {
                nlist = new List<string>();
                foreach (DataRow row in e.Rows)
                {
                    counter++;
                    if (row[column] != null)
                    {
                        string value = row[column].ToString();
                        if (!String.IsNullOrEmpty(value))
                        {
                            if (!nlist.Contains(value))
                            {
                                nlist.Add(value);
                            }
                        }
                    }


                }
                nlista.Add(nlist);


            }
            List<int> ntechg = new List<int>();
            chkzone = nlista.Max(x => x.Count) / 10;
            for (int i = nlista.Count - 1; i >= 0; i--)
            {
                if (nlista[i].Count < 5)
                {
                    nlista.RemoveAt(i);
                    ntechg.Add(i);
                }
            }
            ntechg.Sort();


            for (int i = ntechg.Count - 1; i >= 0; i--)
            {

                //ntechg.Add(i);
                e.Columns.RemoveAt(ntechg[i]);
            }
            // t.Columns.RemoveAt(columnIndex);
            //for (int i = 0; i < 10; i++)
            //{

            //    for (int z = 0; z < e.Columns.Count; z++)
            //    {
            //        if (!nlist.Contains(e.Rows[i][z]))
            //        {
            //            nlist.Add(e.Rows[i][z]);
            //        }
            //        nlista.Add(nlist);
            //    }

            //}

            while (e.Columns.Count < 5)
            {
                e.Columns.Add(new DataColumn());
            }

            if (e.Columns.Count > 5)
            {
                for (int i = e.Columns.Count - 1; i >= 5; i--)
                {
                    e.Columns.RemoveAt(i);
                }
            }


            var chk = nlista;

            e.Columns[0].ColumnName = "AccountMainID";
            e.Columns[1].ColumnName = "AccountMainDescription";
            e.Columns[2].ColumnName = "DebitAmount";
            e.Columns[3].ColumnName = "CreditAmount";
            e.Columns[4].ColumnName = "AmountBakiye";
            e.AcceptChanges();


            //var json = JsonConvert.SerializeObject(e);
            //var YourConvertedDataType = JsonConvert.DeserializeObject<XmlExcel>(json);

            //DataTable dtCloned = e.Clone();




            //foreach (DataRow row in e.Rows)
            //{
            //    dtCloned.ImportRow(row);
            //}


            try
            {
                //List<XmlExcelCheck> nlistExceln = new List<XmlExcelCheck>();
                //XmlExcelCheck nexceln = new XmlExcelCheck();
                //foreach (var item in e.AsEnumerable())
                //{
                //    try
                //    {
                //        nexceln = new XmlExcelCheck();
                //        nexceln.AccountMainID = checkValz(item.Field<String>("AccountMainID")).ToString();
                //        nexceln.AccountMainDescription = checkValz(item.Field<String>("AccountMainDescription")).ToString();
                //        nexceln.DebitAmount = checkValz(item.Field<String>("DebitAmount")).ToString();
                //        nexceln.CreditAmount = checkValz(item.Field<String>("CreditAmount")).ToString();
                //        nexceln.AmountBakiye = checkValz(item.Field<String>("AmountBakiye")).ToString();
                //        nlistExceln.Add(nexceln);
                //    }
                //    catch (Exception ex)
                //    {
                //        var chkxx = ex;
                //        throw;
                //    }

                //}

                List<XmlExcel> mlstCustomer = new List<XmlExcel>();

                IEnumerable<XmlExcel> lstCustomer = e.AsEnumerable().Select(x => new XmlExcel()
                {
                    AccountMainID = checkValz(x.Field<String>("AccountMainID")).ReplaceLineEndings()
  .Split(Environment.NewLine, StringSplitOptions.None)[0],
                    AccountMainDescription = checkValz(x.Field<String>("AccountMainDescription")).ReplaceLineEndings()
  .Split(Environment.NewLine, StringSplitOptions.None)[0],
                    DebitAmount = checkValz(x.Field<String>("DebitAmount")).ReplaceLineEndings()
  .Split(Environment.NewLine, StringSplitOptions.None)[0],
                    CreditAmount = checkValz(x.Field<String>("CreditAmount")).ReplaceLineEndings()
  .Split(Environment.NewLine, StringSplitOptions.None)[0],
                    AmountBakiye = checkValz(x.Field<String>("AmountBakiye")).ReplaceLineEndings()
  .Split(Environment.NewLine, StringSplitOptions.None)[0]
                }).ToList();
                //XmlExcel nexcel = new XmlExcel();
                //foreach (var item in e.AsEnumerable())
                //{
                //    nexcel = new XmlExcel();
                //    nexcel.AccountMainID = checkValz(item.Field<String>("AccountMainID"));
                //    var nnlist = SplitToLines(nexcel.AccountMainID);
                //    if (nnlist.Where(x=>x.Length>0).Count()>1)
                //    {
                //        foreach (var itemz in nnlist)
                //        {

                //        }
                //    }
                //    else
                //    {
                //        nexcel.AccountMainDescription = checkValz(item.Field<String>("AccountMainDescription"));
                //        nexcel.DebitAmount = checkValz(item.Field<String>("DebitAmount"));
                //        nexcel.CreditAmount = checkValz(item.Field<String>("CreditAmount"));
                //        nexcel.AmountBakiye = checkValz(item.Field<String>("AmountBakiye"));
                //        mlstCustomer.Add(nexcel);
                //    }

                //}

                int conuter = lstCustomer.Count();
                int conuterz = lstCustomer.Where(x => x.AccountMainID.Length < 3).Count();
                if (conuterz > conuter / 2)
                {
                    e.Columns.RemoveAt(0);
                    return CheckColumnRev(e);
                }
                else
                {
                    return lstCustomer;
                }

            }
            catch
            {

                IEnumerable<XmlExcel> lstCustomer = e.AsEnumerable().Select(x => new XmlExcel()
                {
                    AccountMainID = checkValz(x.Field<String>("AccountMainID")),
                    AccountMainDescription = checkValz(x.Field<String>("AccountMainDescription")),
                    DebitAmount = checkValz(x.Field<double?>("DebitAmount")),
                    CreditAmount = checkValz(x.Field<double?>("CreditAmount")),
                    AmountBakiye = checkValz(x.Field<double?>("AmountBakiye"))
                }).ToList();
                int conuter = lstCustomer.Count();
                int conuterz = lstCustomer.Where(x => x.AccountMainID.Length < 3).Count();
                if (conuterz > conuter / 2)
                {
                    e.Columns.RemoveAt(0);
                    return CheckColumnRev(e);
                }
                else
                {
                    return lstCustomer;
                }

            }



        }
        public static IEnumerable<string> SplitToLines(this string input)
        {
            if (input == null)
            {
                yield break;
            }

            using (System.IO.StringReader reader = new System.IO.StringReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
        public static IEnumerable<XmlExcel> CheckColumnRev(DataTable e)
        {
            int counter = 0;

            List<string> nlist = new List<string>();
            List<List<string>> nlista = new List<List<string>>();
            int chkzone = 0;

            foreach (DataColumn column in e.Columns)
            {
                nlist = new List<string>();
                foreach (DataRow row in e.Rows)
                {
                    counter++;
                    if (row[column] != null)
                    {
                        string value = row[column].ToString();
                        if (!String.IsNullOrEmpty(value))
                        {
                            if (!nlist.Contains(value))
                            {
                                nlist.Add(value);
                            }
                        }
                    }


                }
                nlista.Add(nlist);


            }
            List<int> ntechg = new List<int>();
            chkzone = nlista.Max(x => x.Count) / 10;
            for (int i = nlista.Count - 1; i >= 0; i--)
            {
                if (nlista[i].Count < 5)
                {
                    nlista.RemoveAt(i);
                    ntechg.Add(i);
                }
            }
            ntechg.Sort();


            for (int i = ntechg.Count - 1; i >= 0; i--)
            {

                //ntechg.Add(i);
                e.Columns.RemoveAt(ntechg[i]);
            }
            // t.Columns.RemoveAt(columnIndex);
            //for (int i = 0; i < 10; i++)
            //{

            //    for (int z = 0; z < e.Columns.Count; z++)
            //    {
            //        if (!nlist.Contains(e.Rows[i][z]))
            //        {
            //            nlist.Add(e.Rows[i][z]);
            //        }
            //        nlista.Add(nlist);
            //    }

            //}

            while (e.Columns.Count < 5)
            {
                e.Columns.Add(new DataColumn());
            }

            if (e.Columns.Count > 5)
            {
                for (int i = e.Columns.Count - 1; i >= 5; i--)
                {
                    e.Columns.RemoveAt(i);
                }
            }


            var chk = nlista;

            e.Columns[0].ColumnName = "AccountMainID";
            e.Columns[1].ColumnName = "AccountMainDescription";
            e.Columns[2].ColumnName = "DebitAmount";
            e.Columns[3].ColumnName = "CreditAmount";
            e.Columns[4].ColumnName = "AmountBakiye";
            e.AcceptChanges();


            //var json = JsonConvert.SerializeObject(e);
            //var YourConvertedDataType = JsonConvert.DeserializeObject<XmlExcel>(json);

            //DataTable dtCloned = e.Clone();




            //foreach (DataRow row in e.Rows)
            //{
            //    dtCloned.ImportRow(row);
            //}


            try
            {
                //List<XmlExcelCheck> nlistExceln = new List<XmlExcelCheck>();
                //XmlExcelCheck nexceln = new XmlExcelCheck();
                //foreach (var item in e.AsEnumerable())
                //{
                //    try
                //    {
                //        nexceln = new XmlExcelCheck();
                //        nexceln.AccountMainID = checkValz(item.Field<String>("AccountMainID")).ToString();
                //        nexceln.AccountMainDescription = checkValz(item.Field<String>("AccountMainDescription")).ToString();
                //        nexceln.DebitAmount = checkValz(item.Field<String>("DebitAmount")).ToString();
                //        nexceln.CreditAmount = checkValz(item.Field<String>("CreditAmount")).ToString();
                //        nexceln.AmountBakiye = checkValz(item.Field<String>("AmountBakiye")).ToString();
                //        nlistExceln.Add(nexceln);
                //    }
                //    catch (Exception ex)
                //    {
                //        var chkxx = ex;
                //        throw;
                //    }

                //}

                IEnumerable<XmlExcel> lstCustomer = e.AsEnumerable().Select(x => new XmlExcel()
                {
                    AccountMainID = checkValz(x.Field<String>("AccountMainID")),
                    AccountMainDescription = checkValz(x.Field<String>("AccountMainDescription")),
                    DebitAmount = checkValz(x.Field<String>("DebitAmount")),
                    CreditAmount = checkValz(x.Field<String>("CreditAmount")),
                    AmountBakiye = checkValz(x.Field<String>("AmountBakiye"))
                }).ToList();
                return lstCustomer;

            }
            catch
            {

                IEnumerable<XmlExcel> lstCustomer = e.AsEnumerable().Select(x => new XmlExcel()
                {
                    AccountMainID = checkValz(x.Field<String>("AccountMainID")),
                    AccountMainDescription = checkValz(x.Field<String>("AccountMainDescription")),
                    DebitAmount = checkValz(x.Field<double?>("DebitAmount")),
                    CreditAmount = checkValz(x.Field<double?>("CreditAmount")),
                    AmountBakiye = checkValz(x.Field<double?>("AmountBakiye"))
                }).ToList();
                return lstCustomer;
            }



        }
        public static string checkValz(object obb)
        {
            string chkk = string.Empty;
            if (obb != null && Convert.ToString(obb) != string.Empty)
            {
                return obb.ToString();
            }

            return chkk;

        }

        public static IEnumerable<XmlExcel> ChangeColumName(DataTable e)
        {
            e.Columns[0].ColumnName = "AccountMainID";
            e.Columns[1].ColumnName = "AccountMainDescription";
            e.Columns[2].ColumnName = "DebitAmount";
            e.Columns[3].ColumnName = "CreditAmount";
            e.Columns[4].ColumnName = "AmountBakiye";
            e.AcceptChanges();


            //var json = JsonConvert.SerializeObject(e);
            //var YourConvertedDataType = JsonConvert.DeserializeObject<XmlExcel>(json);


            IEnumerable<XmlExcel> lstCustomer = e.AsEnumerable().Select(x => new XmlExcel()
            {
                AccountMainID = x.Field<string>("AccountMainID"),
                AccountMainDescription = x.Field<string>("AccountMainDescription"),
                DebitAmount = x.Field<string>("DebitAmount"),
                CreditAmount = x.Field<string>("CreditAmount"),
                AmountBakiye = x.Field<string>("AmountBakiye")
            }).ToList();

            return lstCustomer;
        }
    }
}
