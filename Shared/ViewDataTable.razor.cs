using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp2.Shared
{
    public class ViewDataTable_Code: ComponentBase
    {
        [Parameter]
        public System.Data.DataTable table { get; set; }

        public Settings settings = new Settings();
        public string Message { get; set; }
        public string MessageHeader { get; set; }

        string lastSortedColumn = "";
        bool sort = true;
        public int pages = 1;
        public int currentpage = 1;

        public static string PreviousPage_Name = "Previous Page";
        public static string NextPage_Name = "Next Page";
        public string TestTextInput = "";

        public void PreviousPage()
        {
            currentpage--;
        }
        public void NextPage()
        {
            currentpage++;
        }

        public ViewDataTable_Code()
        {
            Message = "";
            if (!(table is null))
            {
                pages = (table.Rows.Count / settings.maxRowsToDisplay) + 1;

            }
        }
        public void Sort(string columnName)

        {
            DataView prodView = table.DefaultView;

            if (lastSortedColumn == columnName)
            {
                //Update key value
                sort = !sort;
            }
            else
            {
                lastSortedColumn = columnName;
                sort = true;
            }

            if (sort)
            {
                prodView.Sort = $"{columnName} DESC";
            }
            else
            {
                prodView.Sort = $"{columnName} ASC";
            }
            table = prodView.ToTable();

        }

        public void HandleValidSubmit()
        {
            Console.WriteLine("asd");// Save User object to backend
        }

        public async Task SetDataTableValueAsync(DataRow row,DataColumn column, ChangeEventArgs e)
        {
            //Use to convert value to column type
            if (column.DataType.Name == "DateTimeOffset")
            {
                //This is the only field type I've found that doesn't naturaly convert from Excel to the db fields
                row[column] = DateTimeOffset.Parse(e.Value.ToString());
            }
            else
            {
                try
                {
                    row[column] = e.Value;

                }
                catch(Exception ex)
                {
                    Alert("Error Occured",ex.Message);
                    e.Value = row[column];
                }
            }

        }
        private async Task Alert(string theMessageHeader, string theMessage)
        {
            MessageHeader = theMessageHeader;
            Message = theMessage;
            //await JSRuntime.InvokeAsync<object>("Alert", new object(){message});
        }
    }
}
