using Database.Models.BaseTables;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Database.Lib
{
    public static class Lib
    {
        public static string outputDateTimeFormat = "yyyy-MM-ddTHHmmss";
        public static string outputDateFormat = "yyyy-MM-dd";

        public static string BACK_END_DATE_FORMAT = "yyyy-MM-dd";
        public static int getTotalPages(int Rows, int PageSize)
        {
            int Pages = Rows / PageSize;
            if (Rows < PageSize)
                Pages = 1;
            else if (Pages * PageSize != Rows)
                Pages++;
            return Pages;
        }
        public static int getStartRow(int currentPageNo, int pageSize)
        {
            return (currentPageNo - 1) * pageSize;
            //return (currentPageNo - 1) * pageSize + 1;
        }

        public static int getEndRow(int currentPageNo, int pageSize)
        {
            return currentPageNo * pageSize;
        }
        public static int FindPage(string Action, int CurrentPageNo, int Pages)
        {
            if (Action == "NEXT")
                CurrentPageNo++;
            if (Action == "PREV")
                CurrentPageNo--;
            if (Action == "FIRST")
                CurrentPageNo = 1;
            if (Action == "LAST")
                CurrentPageNo = Pages;
            if (CurrentPageNo < 1)
                CurrentPageNo = 1;
            if (CurrentPageNo > Pages)
                CurrentPageNo = Pages;
            return CurrentPageNo;
        }

        public static string getErrorMessage(Exception ex, string key, string columnName, string ErrorMessage)
        {
            string msg = "";
            string error = ex.InnerException != null ? ex.InnerException.Message.ToUpper() : "";
            if (error.Contains(key.ToUpper()) && error.Contains(columnName.ToUpper()))
            {
                msg = ErrorMessage;
            }
            if (msg != "")
                throw new Exception(msg);
            return msg;
        }

        public static string getErrorMessage(Exception Ex)
        {
            if (Ex.Message.ToString().ToUpper().Contains("SEE THE INNER EXCEPTION"))
            {
                return Ex.InnerException == null ? Ex.Message.ToString() : Ex.InnerException.Message;
            }
            else
                return Ex.Message.ToString();

        }



        public static void LogChanges(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                foreach (var propertyEntry in entry.Properties)
                {
                    if (propertyEntry.IsModified)
                        Console.WriteLine(propertyEntry.OriginalValue + " : " + propertyEntry.CurrentValue + " " + propertyEntry.Metadata.Name);
                }
            }
        }


        public static void AssignDates2DTO(int id, string mode, baseTable_tracking source, basetable_dto target)
        {
            target.rec_created_by = source.rec_created_by;
            target.rec_created_date = source.rec_created_date.ToString(outputDateTimeFormat);
            if (id != 0)
            {
                target.rec_edited_by = source.rec_edited_by;
                target.rec_edited_date = source.rec_edited_date.HasValue ? source.rec_edited_date.Value.ToString(outputDateTimeFormat) : null;
            }
        }



        public static object createObject(string className)
        {
            Type classType = Type.GetType(className);
            object mObj = Activator.CreateInstance(
                classType);
            return mObj;
        }

        public static object ISNULL(object data1, object data2)
        {
            return data1 == null ? data2 : data1;
        }

        public static DateTime? ParseDate(string dateString)
        {
            if (string.IsNullOrEmpty(dateString))
                return null;
            return DateTime.Parse(dateString);
        }


        public static bool IsZero(int? value)
        {
            return value == null || value <= 0;
        }
        public static bool IsZero(decimal? value)
        {
            return value == null || value <= 0;
        }

        public static bool IsBlank(string? value)
        {
            return string.IsNullOrWhiteSpace(value);
        }


        public static string FormatDate(DateTime? date, string format)
        {
            return date.HasValue ? date.Value.ToString(format) : null;
        }

        public static string StringToDate(Object Data)
        {
            string sData = "";
            DateTime Dt;
            if (Data == null || Data.ToString() == "")
                sData = "";
            else
            {
                Dt = DateTime.Parse(Data.ToString());
                sData = Dt.ToString(Lib.BACK_END_DATE_FORMAT);
            }
            return sData;
        }
        public static int StringToInteger(Object value)
        {
            int iValue = 0;
            try
            {
                int.TryParse(value.ToString(), out iValue);
            }
            catch
            {
                iValue = 0;
            }
            return iValue;
        }

        public static decimal StringToDecimal(object value)
        {
            if (value == null)
                return 0m;
            return decimal.TryParse(value.ToString(), out decimal result) ? result : 0m;
        }

    }
}



