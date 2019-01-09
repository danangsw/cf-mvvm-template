using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Windows;
using DSW.Core.Utility.Services;

namespace DSW.Core.Utility.Forms
{
    public static class GridServices
    {
        public static void SetFormattableDecimalTextBoxColumn<T>(
            this DataGridTableStyle dataGridTableStyle,
            Expression<Func<T, object>> property, 
            string headerText, int width,
            Action<object, DataGridFormatCellEventArgs> ColumnSetCellFormat
            )
        {
            FormattableDecimalTextBoxColumn column = new FormattableDecimalTextBoxColumn();
            column.MappingName = Helpers.GetNameProperty<T>(property);
            column.HeaderText = headerText;
            column.Format = "N2";
            column.Width = width;
            column.NullText = "0.00";
            dataGridTableStyle.GridColumnStyles.Add(column);
            column.SetCellFormat += new FormatCellEventHandler(ColumnSetCellFormat);
        }


        public static void SetFormattableTextBoxColumn<T>(
            this DataGridTableStyle dataGridTableStyle,
            Expression<Func<T, object>> property, 
            string headerText, 
            int width,
            Action<object, DataGridFormatCellEventArgs> ColumnSetCellFormat)
        {
            FormattableTextBoxColumn column = new FormattableTextBoxColumn();
            column.MappingName = Helpers.GetNameProperty<T>(property);
            column.HeaderText = headerText;
            column.Width = width;
            column.NullText = String.Empty;
            dataGridTableStyle.GridColumnStyles.Add(column);
            column.SetCellFormat += new FormatCellEventHandler(ColumnSetCellFormat);
        }


    }
}
