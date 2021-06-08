using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Linear_Regresion;

namespace LinearRegresions
{
    public partial class MainPage : ContentPage
    {
        private LinearRegresion libLinearReg = new LinearRegresion();
        private List<double> XValues = new List<double>();
        private List<double> YValues = new List<double>();
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e) //Evento de valores de X
        {
            //List<double> XValues = new List<double>();
            //Sacar valores del Entry de X y meterlos en la lista
            //TODO Checar que Get FormmateValues != null
            XValues = GetFormattedValues(xvaluesEntry);
        }

        private void Button_Clicked_1(object sender, EventArgs e) //Evento de valores de Y
        {
            //Sacar valores del Entry de Y y meterlos en la lista
            YValues = GetFormattedValues(yvaluesEntry);
        }
        private void Button_Clicked_2(object sender, EventArgs e) //Metodo para aplicar regresion Lineal
        {
           List<double> vs =  libLinearReg.CalculateLinearRegresion(XValues, YValues, 400);
            Avalue.Text = vs[0].ToString();
            Bvalue.Text = vs[1].ToString();
            FXvalue.Text = vs[2].ToString();
        }

        private List<double> GetFormattedValues(Entry entry)
        {
            if (String.IsNullOrEmpty(entry.Text) || String.IsNullOrWhiteSpace(entry.Text))
            {
                return null;
            }
            List<double> xyvalues = new List<double>();

            List<string> valuesObtained = entry.Text.Split(',').ToList();

            foreach (var item in valuesObtained)
            {
                xyvalues.Add(Double.Parse(item));
            }

            return xyvalues;
        }

    }
}
