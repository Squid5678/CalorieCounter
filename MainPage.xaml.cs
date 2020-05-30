using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;
using Plugin.Media.Abstractions;

using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
using System.Diagnostics;

namespace CalorieCounter
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //https://stackoverflow.com/questions/55198000/customvision-api-returns-operation-returned-an-invalid-status-code-notfound

        string predictionKey = "6a013096c7724b718c6067ca6a540d3d";
        string ENDPOINT = "https://eastus.api.cognitive.microsoft.com";
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            StoreCameraMediaOptions camSettings = new StoreCameraMediaOptions();


            var photo = await CrossMedia.Current.TakePhotoAsync(camSettings);


            // Create a prediction endpoint, passing in the obtained prediction key
            CustomVisionPredictionClient endpoint = new CustomVisionPredictionClient()
            {
                ApiKey = predictionKey,
                Endpoint = ENDPOINT
            };

            Guid myProjectID = Guid.Parse("2bea691a-f6fa-49de-b149-9f58efc38f28");

            var result = endpoint.DetectImage(myProjectID, "Iteration4", photo.GetStream());


            Debug.WriteLine("Testing");


            ListOfFood.ItemsSource = result.Predictions;

            /*

            foreach (var c in result.Predictions)
            {

                MyLabel.Text = c.TagName;

                
            }
            */

        }
    }
}
