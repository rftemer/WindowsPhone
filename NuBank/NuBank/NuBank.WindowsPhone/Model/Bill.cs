using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NuBank.Model
{
    public class Summary 
    {
        public string due_date { get; set; }
        public string close_date { get; set; }
        public int past_balance { get; set; }
        public int total_balance { get; set; }
        public int interest { get; set; }
        public int total_cumulative { get; set; }
        public int paid { get; set; }
        public int minimum_payment { get; set; }
        public string open_date { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class BoletoEmail
    {
        public string href { get; set; }
    }

    public class Barcode
    {
        public string href { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
        public BoletoEmail boleto_email { get; set; }
        public Barcode barcode { get; set; }
    }

    public class LineItem
    {
        public string post_date { get; set; }
        public int amount { get; set; }
        public string title { get; set; }
        public int index { get; set; }
        public int charges { get; set; }
        public string href { get; set; }
    }

    public class Bill
    {

        public Bill()
        {
            summary = new Summary();
            line_items = new List<LineItem>();
            _links = new Links();
        }
        public string state { get; set; }
        public string id { get; set; }
        public Summary summary { get; set; }
        public Links _links { get; set; }
        public string barcode { get; set; }
        public string linha_digitavel { get; set; }
        public IList<LineItem> line_items { get; set; }
    }
    
    public class Bills
    {
        public string state { get; set; }
        public Summary summary { get; set; }
        public IList<LineItem> line_items { get; set; }
        public Links _links { get; set; }
    }
  

    
}
