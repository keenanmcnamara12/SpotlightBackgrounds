# SpotlightBackgrounds
Sick of finding good backgrounds yourself when you already know that the windows lock screen has beautiful images and would be happy to see them when you don't have 9001 windows open? Me too!

# Background
This application allows for a user to ad-hoc copy the windows lock screen backgrounds into a specified directory that can be used as a desktop background. Additionally, one can set up a windows task to periodically pull updates from the lock screen background folder as it's updated. An app data file is used to specify where the images should be saved (background folder).

# How to (one time)
1st - run the .exe. This will create a "SpotlightBackground" directory and "preferences.txt" file at your app data path, which looks something like: "C:\Users\<User>\AppData\Roaming\SpotlightBackground\preferences.txt"

2nd - navigate to the preferenes.txt file where you want the backgrounds to be saved (folder should already exist). Ex: "BackgroundFolderPath=C:\Users\<User>\Pictures\Backgrounds\SlideShow\

3rd - still in the preferences.txt file, set the minimum pixel resolution that you want to copy over. Ex: MinPixelHeight=1080 and MinPixelWidth=1920

4th - still in the preferences.txt file, verify that your settings are in the following order and on separate lines BackgroundFolderPath, MinPixelHeight, MinPixelWidth.

5th - if step 4 checks out save preferences.txt and close.

6th - run the .exe and you should see images populate your specified folder.

7th - verify that your windows background is in slide show mode an pointing to the directory you created (or reused) in step 2.

# How to (continual updates)
Set up a windows task that runs this application daily to continue to add to new backgrounds to your folder (details here: https://technet.microsoft.com/en-us/library/cc748993(v=ws.11).aspx)
