using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuBank.Model;
using System.Collections.ObjectModel;
using NuBank.RestApi;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.Graphics.Display;
using System.Windows.Input;



namespace NuBank.ViewModel
{
    public class MainWindowVM
    {

        private ObservableCollection<Bill> bills;

        public ObservableCollection<Bill> Bills
        {
            get { return bills; }
            set { bills = value; }
        }

        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new Commands(ShowBoleto,  param => true));
            }
        }

        private double uiHeight;

        public double UiHeight
        {
            get 
            {
                var bounds = Window.Current.Bounds;
                uiHeight = bounds.Height;
                return uiHeight; 
            }
            set { uiHeight = value; }
        }

        private double uiWidth;

        public double UiWidth
        {
            get
            {
                var bounds = Window.Current.Bounds;
                uiWidth = bounds.Width;
                return uiWidth;
            }
            set { uiWidth = value; }
        }
        
        public MainWindowVM()
        {
            RestAPI rest = new RestAPI("https://s3-sa-east-1.amazonaws.com/mobile-challenge/bill/bill.json");
            string jsonData;
            int result = rest.GetJson(out jsonData);
            bills = new ObservableCollection<Bill>();
            _clickCommand = new Commands(ShowBoleto,  param => true);

            if(result == 0)
            {
                try
                {
                    JArray json = JArray.Parse(jsonData);
                    foreach (JObject item in json.Children<JObject>())
                    {
                        if (item["bill"] != null)
                        {
                            string jsonBill = item["bill"].ToString();
                            JObject parseJsonBill = JObject.Parse(jsonBill);
                            Bill bill = JsonConvert.DeserializeObject<Bill>(jsonBill);

                            //add in my classes
                            Bill billItem = new Bill();
                            billItem.state = bill.state;
                            billItem.barcode = bill.barcode;
                            billItem.linha_digitavel = bill.linha_digitavel;
                            billItem.id = bill.id;
                            billItem.summary = bill.summary;
                            billItem.line_items = bill.line_items;
                            billItem._links = bill._links;
                            bills.Add(billItem);
                        }
                        else
                            if(item["bills"] != null)
                        {
                            for(int i = 0; i < item["bills"].Count(); i++)
                            {
                                JObject parseJsonBill = JObject.Parse(item["bills"][i].ToString());
                                Bills bill = JsonConvert.DeserializeObject<Bills>(item["bills"][i].ToString());

                                ////add in my classes
                                Bill billItem = new Bill();
                                billItem.state = bill.state;
                                billItem.summary = bill.summary;
                                billItem.line_items = bill.line_items;
                                bills.Add(billItem);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowMessageBox("Was not able to parse JSON \n Error: " + ex.Message);
                }
            }
            else
            {
                ShowMessageBox(jsonData);
               
            }
        }
        public void ShowBoleto(object obj)
        {
          //TODO
        }


        private async void ShowMessageBox(string msg)
        {
            MessageDialog msgbox = new MessageDialog(msg);
            msgbox.Commands.Add(new UICommand("Ok", null, "OK"));
            var op = await msgbox.ShowAsync();
            if ((string)op.Id == "OK")
            {
                Application.Current.Exit();
            }            
        }
    }
}
