using FlashCardApp.Model.Deck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Popups;

namespace FlashCardApp.Model.Logic
{
    public class ManageWholeDeck
    {
        public ManageWholeDeck()
        {
        }
        
        public async void Create()
        {
            FileOpenPicker OpenPicker = new FileOpenPicker();
            OpenPicker.ViewMode = PickerViewMode.List;
            OpenPicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            OpenPicker.FileTypeFilter.Add(".csv");
            OpenPicker.FileTypeFilter.Add(".CSV");

            StorageFile file = await OpenPicker.PickSingleFileAsync();
            if (file != null)
            {
                using (var csv = await file.OpenStreamForReadAsync())
                using (var sr = new StreamReader(csv))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var values = line.Split(',');
                        WholeDeck.Instance().Add(new Cards.Card(values[1], values[2], Convert.ToInt32(values[3])));
                    }
                    sr.Close();
                }
                var dialog = new MessageDialog("Deck imported successfully!");
                await dialog.ShowAsync();
            }
        }
        public void WriteToFile(string FileName)
        {
            var Path = AppDomain.CurrentDomain.BaseDirectory + "/Files/" + FileName + ".csv";
            StreamWriter r = new StreamWriter(Path);
            //string tmp;
            //for (int i = 0; i < WholeDeck.Instance().ListAll().Count; i++)
            //WholeDeck.Instance().Clear();
            //var Path = AppDomain.CurrentDomain.BaseDirectory + "Files\\"+FileName+".csv";
            //StreamReader f = new StreamReader(Path);
            //while (!f.EndOfStream)
            {
               // tmp = Convert.ToString(WholeDeck.Instance().ListAll()[i].ID) + "," + WholeDeck.Instance().ListAll()[i].WordToLearn + ","
               //     + WholeDeck.Instance().ListAll()[i].Meaning + "," + WholeDeck.Instance().ListAll()[i].HitCount;
               // r.Write(tmp);
            }
            r.Close();
        }
    }
}
