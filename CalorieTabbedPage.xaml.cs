using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Entry = Microcharts.Entry;
using Microcharts;
using SkiaSharp;


using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CalorieCounter.Classes;
using System.Collections.ObjectModel;

namespace CalorieCounter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalorieTabbedPage : TabbedPage
    {
        List<Entry> entries = new List<Entry>
        {
           new Entry(1000)
            {
                Color =SKColor.Parse("#FF1493"),
                Label = "Sun",
                ValueLabel = "10000/2000",
            },
            new Entry(1420)
            {
                Color =SKColor.Parse("#FF1493"),
                Label = "Mon",
                ValueLabel = "1420/2000",
            },
            new Entry(1630)
            {
                Color =SKColor.Parse("#FF1493"),
                Label = "Tue",
                ValueLabel = "1630/2000",
            },
            new Entry(1400)
            {
                Color =SKColor.Parse("#FF1493"),
                Label = "Wed",
                ValueLabel = "1400/2000",
            },
            new Entry(1050)
            {
                Color =SKColor.Parse("#FF1493"),
                Label = "Thu",
                ValueLabel = "1050/2000",
            },
            new Entry(1600)
            {
                Color =SKColor.Parse("#FF1493"),
                Label = "Fri",
                ValueLabel = "1600/2000",
            },

            new Entry(600)
            {
                Color =SKColor.Parse("#FF1493"),
                Label = "Sat",
                ValueLabel = "1900/2000",
                
            },
        };
        int s;
        double calos;
        float cal_dec;
        List<Entry> entries1 = new List<Entry>
        {
            new Entry(1500)
            {
                Color =SKColor.Parse("#FF1493"),
                Label = "Sun",
                ValueLabel = "1500/2000",
            },
            new Entry(2700)
            {
                Color =SKColor.Parse("#FF1493"),
                Label = "Mon",
                ValueLabel = "2700/2000",
            },
            new Entry(1600)
            {
                Color =SKColor.Parse("#FF1493"),
                Label = "Tue",
                ValueLabel = "1600/2000",
            },
            new Entry(100)
            {
                Color =SKColor.Parse("#FF1493"),
                Label = "Wed",
                ValueLabel = "100/2000",
            },
            new Entry(900)
            {
                Color =SKColor.Parse("#FF1493"),
                Label = "Thu",
                ValueLabel = "900/2000",
            },
            new Entry(1200)
            {
                Color =SKColor.Parse("#FF1493"),
                Label = "Fri",

                ValueLabel = "1200/2000",
            },
        
        };

        //https://stackoverflow.com/questions/55198000/customvision-api-returns-operation-returned-an-invalid-status-code-notfound

        string predictionKey = "6a013096c7724b718c6067ca6a540d3d";
        string ENDPOINT = "https://eastus.api.cognitive.microsoft.com";

        //Stores the ingredients in a dish
        ObservableCollection<string> ingredientsInDish = new ObservableCollection<string>();

        ObservableCollection<Ingredient> ingredientsInDishNameAndCalories = new ObservableCollection<Ingredient>();
        public int totalCalories = 0;


        List<Ingredient> calorieDatabase = new List<Ingredient>();

        ObservableCollection<Dish> dishesEatenToday = new ObservableCollection<Dish>();

        //used for temporary storing an image source
        ImageSource imgsrc;

        

        public CalorieTabbedPage()
        {
            InitializeComponent();
            s = 0;
            calos = 0.04 * s;
            float net_cal = (float)calos;
            cal_dec = 1900 - net_cal;
            
            CaloricGain.Chart = new BarChart
            {
                MinValue = -2000,
                MaxValue = 2000,
                LabelTextSize = 20,
                
                Entries = entries1,
            };
            Days.Chart = new BarChart
            {
                Entries = entries,
                MinValue = 0,
                LabelTextSize = 20,
                MaxValue = 2000
            };



            //initializes the calorie database
            setUpCalorieDatabase();



            //Display the dishes eaten in the DishesEatenListView
            DishesEatenListView.ItemsSource = dishesEatenToday;

            ListOfFoodListView.ItemsSource = ingredientsInDishNameAndCalories;


        }





        void setUpCalorieDatabase()
        {


            calorieDatabase.Add(new Ingredient("strawberry", 5, new string[] { "chocolate", "whipped cream"}));
            calorieDatabase.Add(new Ingredient("apple", 26, new string[] { "chocolate", "whipped cream" }));
            calorieDatabase.Add(new Ingredient("blueberries", 42, new string[] { "yogurt", "" }));
            calorieDatabase.Add(new Ingredient("broccoli", 27, new string[] { "chocolate", "whipped cream" }));
            calorieDatabase.Add(new Ingredient("carrots", 23, new string[] { "chocolate", "whipped cream" }));
            calorieDatabase.Add(new Ingredient("cauliflower", 13, new string[] { "chocolate", "whipped cream" }));
            calorieDatabase.Add(new Ingredient("celery", 8, new string[] { "chocolate", "whipped cream" }));
            calorieDatabase.Add(new Ingredient("cucumber", 8, new string[] { "chocolate", "whipped cream" }));
            calorieDatabase.Add(new Ingredient("lettuce", 10, new string[] { "chocolate", "whipped cream" }));
            calorieDatabase.Add(new Ingredient("peppers", 15, new string[] { "chocolate", "whipped cream" }));
            calorieDatabase.Add(new Ingredient("tomato", 18, new string[] { "chocolate", "whipped cream" }));
            calorieDatabase.Add(new Ingredient("cheese", 120, new string[] { "chocolate", "whipped cream" }));
            calorieDatabase.Add(new Ingredient("bread", 100, new string[] { "chocolate", "whipped cream" }));
            calorieDatabase.Add(new Ingredient("patty", 300, new string[] { "chocolate", "whipped cream" }));
            calorieDatabase.Add(new Ingredient("pasta", 149, new string[] { "chocolate", "whipped cream" }));
            calorieDatabase.Add(new Ingredient("milk", 122, new string[] { "chocolate", "whipped cream" }));
            calorieDatabase.Add(new Ingredient("tortilla", 112, new string[] { "chocolate", "whipped cream" }));

        }


        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            

            StoreCameraMediaOptions camSettings = new StoreCameraMediaOptions
            {


                Directory = "Sample",
                Name = DateTime.Now + "_image.jpg"

            };


            var photo = await CrossMedia.Current.TakePhotoAsync(camSettings);


            // Create a prediction endpoint, passing in the obtained prediction key
            CustomVisionPredictionClient endpoint = new CustomVisionPredictionClient()
            {
                ApiKey = predictionKey,
                Endpoint = ENDPOINT
            };

            Guid myProjectID = Guid.Parse("2bea691a-f6fa-49de-b149-9f58efc38f28");

            var result = endpoint.DetectImage(myProjectID, "Iteration8", photo.GetStream());


            

            

            foreach (var i in result.Predictions)
            {

                if(i.Probability > 0.45)
                {
                    ingredientsInDish.Add(i.TagName);
  
                }

            }

            for (int i = 0; i < ingredientsInDish.Count; i++)
            {
                for (int a = 0; a < calorieDatabase.Count; a++)
                {

                    if (calorieDatabase[a].name == ingredientsInDish[i])
                    {
                        ingredientsInDishNameAndCalories.Add(new Ingredient(ingredientsInDish[i], calorieDatabase[a].calorieCount, new string[] { "" }));
                        
                    }

                }


            }






            //This variable takes the image taken and converts it into an ImageSource variable
            imgsrc = ImageSource.FromStream(() =>
            {

                return photo.GetStream();

            });



            DishImageButton.Source = imgsrc;
            

            



            /*
            foreach (var c in result.Predictions)
            {

                MyLabel.Text = c.TagName;

                
            }
            */
        }



        //This function reads whats in ingredientsInDish list and adds up the calories
        int tagToCalories()
        {
            int caloriesInDish = 0;

            //Cycle through all ingredients
            for (int i = 0; i < ingredientsInDish.Count; i++)
            {
                for(int a = 0; a < calorieDatabase.Count; a++)
                {

                    if(calorieDatabase[a].name == ingredientsInDish[i])
                    {

                        caloriesInDish += calorieDatabase[a].calorieCount;
                    }

                }


            }
            totalCalories += caloriesInDish;

            //Clear the ingredients in dish list because it will be used again when next dish is inputted
            //The calculation of calories using it is already done.
            
            return caloriesInDish;

        }

        void AddDishButton_Clicked(System.Object sender, System.EventArgs e)
        {


            //Add to the dishes eaten today all correct parameters, the last one runs a function that calculates calories in dish to store as the dishe's calorie count
            dishesEatenToday.Add(new Dish(DishNameEntry.Text, ingredientsInDish, imgsrc, tagToCalories()));

            //Clear the ingredientsInDish variable as it is used in calculation and needs to be empty for the next dish added
            ingredientsInDish.Clear();
            ingredientsInDishNameAndCalories.Clear();

            DishNameEntry.Text = "";
            //reset the image button back to the default image
            DishImageButton.Source = "addimage.png";

            DisplayCaloriesLabel.Text = totalCalories.ToString();

            entries[6].ValueLabel = totalCalories.ToString() + "/2000";
            entries[6].Value.Equals(totalCalories);
   





        }


        void SubmitStepsButton_Clicked(System.Object sender, System.EventArgs e)
        {
            s = Int32.Parse(steps.Text);
            calos = 0.04 * s;
            float net_cal = (float)calos;
            cal_dec = totalCalories - net_cal;
            NetCaloriesTodayLabel.Text = "Net Calories Today: " + cal_dec;


        }
    }
}
