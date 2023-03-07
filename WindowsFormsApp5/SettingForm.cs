using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace WindowsFormsApp5
{
    public partial class SettingForm : Form
    {
        public WeatherSettings Settings;

        public SettingForm()
        {
            InitializeComponent();

            InitializeFormSize();

            Settings = new WeatherSettings();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateCitySelection())
            {
                return;
            }

            GetSettings();

            ShowWeatherForm(Settings);

            this.Close();
        }

        private WeatherSettings GetSettings()
        {
            Settings.Cities = new List<string>();
            foreach (var item in checkedListBoxCities.CheckedItems)
            {
                Settings.Cities.Add(item.ToString());
            }

            Settings.RefreshTime = numericUpDownTime.Value.ToString();
            return Settings;
        }

        private bool ValidateCitySelection()
        {
            if (checkedListBoxCities.CheckedItems.Count == 0)
            {
                MessageBox.Show(MyStrings.ValidationMessage);
                return false;
            }

            return true;
        }

        private void ShowWeatherForm(WeatherSettings settings)
        {
            WeatherData weatherDataForm = Application.OpenForms.OfType<WeatherData>().FirstOrDefault();

            if (weatherDataForm != null)
            {
                weatherDataForm.Show();
            }
            else
            {
                WeatherData weather = new WeatherData(settings);

                weather.Show();
            }
        }

        private void InitializeCities()
        {
            checkedListBoxCities.Items.Add(MyStrings.City1);
            checkedListBoxCities.Items.Add(MyStrings.City2);
            checkedListBoxCities.Items.Add(MyStrings.City3);
            checkedListBoxCities.Items.Add(MyStrings.City4);
            checkedListBoxCities.Items.Add(MyStrings.City5);
            checkedListBoxCities.CheckOnClick = true;
        }

        private void InitializeRefreshTime()
        {
            numericUpDownTime.Minimum = 5;
            numericUpDownTime.Maximum = 15;
            numericUpDownTime.Value = 5;
            numericUpDownTime.Increment = 5;
        }

        private void SettingForm_Load_1(object sender, EventArgs e)
        {
            InitializeCities();

            InitializeRefreshTime();
        }

        private void InitializeFormSize()
        {
            this.Width = 460;
            this.Height = 400;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
        }
    }
}





