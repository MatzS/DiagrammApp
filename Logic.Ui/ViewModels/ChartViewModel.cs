﻿using De.HsFlensburg.DiagrammApp.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.DiagrammApp.Logic.Ui.ViewModels
{
    public class ChartViewModel
    {
        private TableViewModel table;
        private string selectedChart;
        public TableViewModel Table
        {
            get
            {
                return table;
            }
            set
            {
                this.table = value;
            }
        }

        public string SelectedChart
        {
            get { return selectedChart; }
            set { this.selectedChart = value; }
        }
    }
}
