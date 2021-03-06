﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AT.Service.VModel
{
    public class DataTableVM
    {
    } 
    public class DataTablePostVm
    {

        // properties are not capital due to json mapping
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public string search { get; set; }
        public List<Order> order { get; set; }
        public int filter { get; set; }
    }

    public class Column
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public List<Search> search { get; set; }
        public List<Order> order { get; set; }
    }

    public class Search
    {
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class Order
    {
        public int column { get; set; }
        public string dir { get; set; }
    }

    public class DataTableResponseVm
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public string status { get; set; }
        public object data { get; set; }
    }
}
