using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;
using Microsoft.ProjectOxford.Emotion;
using Plugin.Settings;
using Microsoft.WindowsAzure.MobileServices;

using Xamarin.Forms;
using Fabrikam_Food.DataModels;
using Fabrikam_Food.Resources;

namespace Fabrikam_Food.Views
{
    public partial class MoodPage : ContentPage
    {
        public MoodPage()
        {
            BindingContext = new Fabrirkam_Food.MenuPageViewModel();
            InitializeComponent();
        }

        private async void TakePicture_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaliable.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                Directory = "Fabrikam_food",
                Name = $"{DateTime.UtcNow}.jpg",
                CompressionQuality = 92
            });

            if (file == null)
                return;

            try
            {
                UploadingIndicator.IsRunning = true;
                //88f748eefd944a5d8d337a1765414bba not mine
                string emotionKey = "1c36e4946d994473b89f5edea07f11f6";

                EmotionServiceClient emotionClient = new EmotionServiceClient(emotionKey);

                var result = await emotionClient.RecognizeAsync(file.GetStream());

                var temp = result[0].Scores;
                
                double highestScore = 0.0;
                string currentMood = "";
                if(temp.Anger > highestScore){
                    highestScore = temp.Anger;
                    currentMood = "anger";
                }
                if (temp.Contempt > highestScore){
                    highestScore = temp.Contempt;
                    currentMood = "contempt";
                }
                if (temp.Disgust > highestScore){
                    highestScore = temp.Disgust;
                    currentMood = "disgust";
                }
                if (temp.Fear > highestScore){
                    highestScore = temp.Fear;
                    currentMood = "fear";
                }
                if (temp.Happiness > highestScore){
                    highestScore = temp.Happiness;
                    currentMood = "happiness";
                }
                if (temp.Neutral > highestScore){
                    highestScore = temp.Neutral;
                    currentMood = "neutral";
                }
                if (temp.Sadness > highestScore){
                    highestScore = temp.Sadness;
                    currentMood = "sadness";
                }
                if (temp.Surprise > highestScore){
                    highestScore = temp.Surprise;
                    currentMood = "surprise";
                }

                FoodList fList = new FoodList();
                List<FoodDetail> menuList = fList.getMenuList();
                List<FoodDetail> foodList = new List<FoodDetail>();
                foreach(FoodDetail f in menuList)
                {
                    if (f.mood.Equals(currentMood))
                    {
                        foodList.Add(f);
                    }
                }
                Random rand = new Random();
                int r = rand.Next(foodList.Count);
                FoodDetail foodChosen = foodList[r];

                UploadingIndicator.IsRunning = false;

                moodLabel.Text = "Your mood is: " + foodChosen.mood;
                suggestionLabel.Text = "We suggest " + foodChosen.name;
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
            }
        }

    }
}
