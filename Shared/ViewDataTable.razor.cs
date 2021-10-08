using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Shared
{
    public class ViewDataTable_Code: ComponentBase
    {
        [Parameter]
        public System.Data.DataTable table { get; set; }

        public Settings settings = new Settings();

        string lastSortedColumn = "";
        bool sort = true;
        public int pages = 1;
        public int currentpage = 1;

        public string PreviousPage_Name = "Previous Page";
        public string NextPage_Name = "Next Page";

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
            if(!(table is null))
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
    }
}
