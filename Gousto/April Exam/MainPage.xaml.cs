using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace April_Exam
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ListView1.ItemsSource = App.ListItems;
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            if (Button1.Text == "Display") // Creating an if loop for the display button
            {
                string Change = Index1.Text; //Generating variables for entry fields
                string Change1 = Index2.Text;
                bool x = int.TryParse(Index1.Text, out int result); // Converting entry fields to a boolean equivalent
                bool y = int.TryParse(Index2.Text, out int result2);
                if (x == true & y == true)  // This loop will commence if input is numerical
                {
                    if(Convert.ToInt32(Change) <= Convert.ToInt32(Change1))   // If loop for the numerical values of entry fields
                    {
                        App.Input2 = Convert.ToInt32(Change1);    // Converting the entry fields to numerical values
                        App.Input1 = Convert.ToInt32(Change);
                        App.ListItems = new ListItem[App.Input2 - App.Input1 + 1];

                        for (int i = 0; i <= App.Input2 - App.Input1; i++)     // Loop for the fibonacci sequence calculation
                        {
                            App.ListItems[i] = new ListItem();   //This generates a list for the fibonacci sequence of set integers

                            int number = App.Input1 + i;
                            ulong[] Fib = new ulong[number + 1];  
                            // All validation works but there is an error with minus integers
                            Fib[0] = 0;
                            Fib[1] = 1;
                            for (int j = 2; j <= number; j++)
                            {
                                Fib[j] = Fib[j - 2] + Fib[j - 1]; // Calculation to calculate fibonacci numbers
                            }
                            App.ListItems[i].Text = Fib[number].ToString();

                            App.total += Fib[number];      //Adding all the fibonacci numbers
                        }
                        ListView1.ItemsSource = App.ListItems;

                        ListView1.IsVisible = true;        
                        TheTotal.IsVisible = true;
                        Button1.Text = "Clear";          //This will change the text of the button from 'Display' to 'Clear'
                        Button1.BackgroundColor = Color.Orange;  //This changes the colour of the button
                        Index1.IsEnabled = false;
                        Index2.IsEnabled = false;
                    }  
                    else    // If integers implemented in the from entry are bigger than to entry, this else loop will commence
                    {
                        DisplayAlert("Invalid input", "Index 'from' cannot be bigger than index 'to'.", "OK");  //Alert text
                        Index1.Text = null;
                        App.Input1 = 0;
                        Index2.Text = null;
                        App.Input2 = 0;
                    }
                }
            else         // Likewise, if integers are negative, this loop will commence
                {
                    DisplayAlert("Invalid input", "Indices must be nonnegative integers.", "OK");   //Alert text
                    Index1.Text = null;
                    App.Input1 = 0;
                    Index2.Text = null;
                    App.Input2 = 0;
                }
                       
            }
            else      //This final loop for button click generates after uses presses on click, resulting in the application returning to its normal state
            {
                App.ListItems = null;
                App.Input1 = 0;
                App.Input2= 0;
                Index1.Text = null;
                Index2.Text = null;   
                TheTotal.IsVisible = false;         //Setting IsVisible commands to the labels and listviews
                ListView1.IsVisible = false;
                Button1.Text = "Display";
                Total.Text = null;
                Index1.IsEnabled = true;
                Index2.IsEnabled = true;
                Button1.BackgroundColor = Color.LightSeaGreen;
            }
        }
        private void Button1_Clicked(object sender, EventArgs e)
        {
            Total.Text = App.total.ToString();    //This will show the total of the numbers
        }

        private void Index1_TextChanged(object sender, TextChangedEventArgs e)
        {
             // These index text changed fields did not allow my code to run properly, therefore, i implemented them in the button click
        }

        private void Index2_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }

        private void Svalue_OnChanged(object sender, ToggledEventArgs e)
        {
            if (!e.Value) //Switch cell loop 
            {
                var selectedItem = ((SwitchCell)sender).BindingContext as ListItem;
                App.total -= Convert.ToUInt64(selectedItem.Text); //gets the value of the selected switch cell and removes it from the total
            }
            else
            {
                var selectedItem = ((SwitchCell)sender).BindingContext as ListItem;
                App.total += Convert.ToUInt64(selectedItem.Text); // gets the value of the selected switch cell and adds it to the total
            }
        }
    }
    public class ListItem     // The list Item class
    {
        public string Text { get; set; }
    }
}
