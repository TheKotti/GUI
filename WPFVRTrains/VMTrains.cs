using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JAMK.IT
{
    public class TrainsVM
    {
        public static List<JAMK.IT.Train> GetTrainsAt(string station)
        {
            try
            {
                List<Train> trains = new List<Train>();
                if (station == "test" || station == "" || station == null)
                {
                    //Vaihe1: Placebo palauttaa oikean muotoista dataa
                    //keksitään muutama juna
                    Train tr = new Train();
                    tr.TrainNumber = "666";
                    tr.DepDate = new DateTime(2017, 3, 21);
                    tr.TargetStation = "Highway to Hell";
                    trains.Add(tr);
                }
                else
                {
                    //Vaihe2: haetaan liikenneviraston APIsta oikeita junia
                    //muutetaan haettu json oliokokoelmaksi
                    string temp = JAMK.IT.APITrain.GetJsonFromLiikenneVirasto(station);
                    trains = JsonConvert.DeserializeObject<List<Train>>(temp);
                }
                //palautus
                return trains;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
