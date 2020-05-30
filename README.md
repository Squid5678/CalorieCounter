# Inspiration
The United States is one of the most obese countries in the world. The National Center for Health Statistics estimates that, for 2015-2016 in the U.S., 39.8% of adults aged 20 and over were obese (including 7.6% with severe obesity) and that another 31.8% were overweight. Obesity rates have increased for all population groups in the United States over the last several decades. Obesity is particularly bad, as it increases the susceptibility to diseases like cancer and COVID-19. Many of us have started to take initiative by either going on a diet, or trying to exercise at certain times. However, even when people try to get fit, they either only exercise or diet. What about both? 

Many people have even considered using applications on their mobile devices, but what we don’t get from conventional exercising applications is real data, and how it impacts our body. People want to see whether the exercising and dieting they are doing is actually making an impact on their health. This is when we realized we can combine the power of Machine Learning and algorithms to create the perfect application that allows users to be able to easily manage their health on a daily basis. 


# What it does
Features:
This app has a wide variety of features to ensure you are in hold of your health. For starters, we have our meal page, where the user simply takes a picture of their meal. The app will then use a Machine Learning platform to detect the various items and ingredients found and provide the user with the caloric information of their meal. This is cloud based object detection trained on a custom dataset. 

All this information is recorded on another page, where you can see all of your items in a list view, as well as the total calories you have consumed for the day shown below. This will allow the user to see exactly what they have eaten and the amount of calories in each food item. 

In addition to this, we also provide the user with their daily statistics in the form of various bar graphs. The first bar graph, located on the top, provides the user with the amount of calories that the user has consumed on a daily basis. This data is shown in the span of one week. Next, we have a text field where the user can log the amount of steps they have walked that day. These steps are then put into an algorithm to precisely calculate the amount of calories that the user has burned in that one day. Once the app calculates this, it subtracts the burned calories from the calories eaten and provides the user with their net gain of calories per day. This is incredibly useful because it motivates the user to keep working and exercising in order to bring the net gain calorie amount down to 0. 

Finally, the app also contains a brief list of other nutritious and healthy recipes that other users of the app have recommended. This allows the user to explore various different types of foods that not only taste amazing, but are also assisting them in their adventure to become as fit as possible. These recipes are crowdsourced and will be changed depending on the popularity of the item. 

Finally, in addition to all of these features, this app is also completely native to both iOS and Android. This means that no matter what type of smartphone you use, anyone, anywhere, and at any time can become their healthiest self!


# How is our app different from the other conventional apps?
Our app is different from other conventional apps because first off, it is incredibly easy to use and it does not clutter you with any unnecessary information. Additionally, this app also combines the power of exercise and food together, something that has never been done before. We have the ability to take the food that you eat and use this data to actually encourage the user to exercise and show them how their diet and exercising habits have made an impact on their health. This is an incredibly revolutionary concept and it will allow us to have a whole other view on how we can maintain a fit and healthy lifestyle.  


# How we built it
We built it using Microsoft’s Azure, which has a platform known as CustomVision AI. This allows us to import and test all of our images and train them in order to properly identify our images. In addition to this, we also added some auxiliary machine learning features to better fit our products, as there are many different types of foods that need to be taken into consideration. To integrate it into a fully-functional Android/iOS application, we used Xamarin.Forms in Visual Studio. This uses the native Xamarin programming language XAML, which is used for the front end, and C#, which is used for the back end. 

# Challenges we ran into
Some challenges that we ran into were learning how to use Machine Learning with Xamarin and Visual Studios. This was our first attempt at incorporating machine learning into an app, and we didn’t really have much background information about how machine learning works. However, as we started to play around with the platform, we quickly learned about how to incorporate this into VisualStudios and how to train various objects and use different iterations. Additionally, another challenge that we ran into was being able to compare the food with a large list of items in our database. Many times, the app would crash, and we would need to always reset our system, however once we realized that there were other ways of being efficient with our coding and being able to easily analyze our data. Finally, another challenge that we ran into is that we needed to be able to code a simple and good-looking front-end design in order to make the app easily usable. 

# Accomplishments that we're proud of
We are proud of the fact that we were able to train and incorporate a wide variety of foods with our Machine Learning. Additionally, we are proud of creating a nice front-end design while also maintaining a strong back-end that flows nicely. Additionally, we are proud of being able to address this problem in a meaningful way, by creating an application that can be used by anyone, anywhere. Finally, we are very proud of the results of our app - we were able to create what we envisioned, and we are happy that we were able to overcome a majority of our barriers. 


# What we learned

We learned how to use machine learning in IOS and Android apps and we learned how to train a cloud based Microsoft Azure Custom Vision project. We also learned a lot about incorporating machine learning into code and also incorporating different algorithms in our back-end to make our code much more accurate and precise. 
We also learned how to improve our frontend design skills of Mobile Apps and we learned how to implement graphs in our application. Finally, we also learned how to deal with various images and how to make our app look very useful while also not making it look too cluttered. 

# What's next for CalorieCounter
We plan to further train our algorithm to ensure more reliable results and to also teach our model to recognize more images. There are millions of types of foods out there, and we envision that we can use machine learning to predict them all. Additionally, in addition to our walking incorporation, we would also like to add a section of recommended exercises in order to make our app more useful so that users can easily be able to burn their calories without having to struggle to find proper exercises that can help them. All in all, we have high hopes for this app and we hope that one day, we’ll be able to take this app far and make a difference in everyone’s lives. 

