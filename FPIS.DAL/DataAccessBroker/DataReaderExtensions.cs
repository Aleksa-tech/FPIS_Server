using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FPIS.DAL.DataAccessBroker
{
    public static class DataReaderExtensions
    {
        public static T GetColumnValue<T>(this SqlDataReader dataReader, string columnName, T defaultValue)
        {
            T result = defaultValue;
            var columnValue = dataReader.GetValue(dataReader.GetOrdinal(columnName));
            if (columnValue != DBNull.Value && columnValue != null)
            {
                result = (T)columnValue;
            }

            return result;
        }

        public static string GetString(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<string>(dataReader, columnName, null);
        }

        public static short GetInt16(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<short>(dataReader, columnName, 0);
        }

        public static short? GetInt16Nullable(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<short?>(dataReader, columnName, null);
        }

        public static int GetInt32(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<int>(dataReader, columnName, 0);
        }

        public static int? GetInt32Nullable(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<int?>(dataReader, columnName, null);
        }

        public static long GetInt64(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<long>(dataReader, columnName, 0L);
        }

        public static long? GetInt64Nullable(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<long?>(dataReader, columnName, null);
        }

        public static double GetDouble(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<double>(dataReader, columnName, 0d);
        }

        public static double? GetDoubleNullable(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<double?>(dataReader, columnName, null);
        }

        public static decimal GetDecimal(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<decimal>(dataReader, columnName, 0m);
        }

        public static decimal? GetDecimalNullable(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<decimal?>(dataReader, columnName, null);
        }

        public static float GetFloat(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<float>(dataReader, columnName, 0f);
        }

        public static float? GetFloatNullable(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<float?>(dataReader, columnName, null);
        }

        public static bool GetBoolean(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<bool>(dataReader, columnName, false);
        }

        public static bool? GetBooleanNullable(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<bool?>(dataReader, columnName, null);
        }

        public static DateTime GetDateTime(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<DateTime>(dataReader, columnName, DateTime.MinValue);
        }

        public static DateTime? GetDateTimeNullable(this SqlDataReader dataReader, string columnName)
        {
            return GetColumnValue<DateTime?>(dataReader, columnName, null);
        }
    }
}
