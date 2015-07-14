using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTFA.NUBANK.MODEL.ITEM
{
    public class Item
    {
        private int index = -1;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        private string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private decimal amount = -1;

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private int changes = -1;

        public int Changes
        {
            get { return changes; }
            set { changes = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private string href = string.Empty;

        public string Href
        {
            get { return href; }
            set { href = value; }
        }

        public Item(int _index, string _title, decimal _amount, int _changes, DateTime _date, string _href)
        {
            index = _index;
            title = _title;
            amount = _amount;
            changes = _changes;
            date = _date;
            href = _href;
        }

    }
}
