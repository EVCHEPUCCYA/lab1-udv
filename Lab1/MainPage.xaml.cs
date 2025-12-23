using System.Net.Http.Json;
using System.Text.Json;

namespace Lab1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnAgeChanged(object sender, ValueChangedEventArgs e)
        {
            var value = (int)e.NewValue;
            AgeSl.Value = value;
            AgeSt.Value = value;
            Age.Text = $"{value} лет";
            if (value >= 5 && value <= 115)
                AgeError.IsVisible = false;
        }

        private void OnNumberChanged(object sender, TextChangedEventArgs e)
        {
            if (PhoneNumber.Text?.Length == 11)
            {
                PhoneNumber.TextColor = Colors.Green;
                PhoneError.IsVisible = false;
            }
            else
                PhoneNumber.TextColor = Colors.Red;
        }

        private void OnAgreeChanged(object sender, ToggledEventArgs e)
        {
            SubButton.IsEnabled = e.Value;
        }

        private async void SendAsync(object sender, EventArgs e)
        {
            if (Validate())
            {
                var dto = new
                {
                    Name = Name.Text,
                    Surname = Surname.Text,
                    Patronymic = Patronymic.Text,
                    Age = AgeSl.Value,
                    PhoneNumber = PhoneNumber.Text,
                    Gender = MaleGender.IsChecked
                };
            }
        }

        private bool Validate()
        {
            bool result = true;
            if (string.IsNullOrEmpty(Surname.Text))
            {
                result = false;
                SurnameError.IsVisible = true;
            }
            if (string.IsNullOrEmpty(Name.Text))
            {
                result = false;
                NameError.IsVisible = true;
            }
            if (AgeSl.Value < 5 || AgeSl.Value > 115)
            {
                result = false;
                AgeError.IsVisible = true;
            }
            if (PhoneNumber.Text?.Length != 11)
            {
                result = false;
                PhoneError.IsVisible = true;
            }
            return result;
        }
    }
}
