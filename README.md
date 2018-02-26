# SpotlightBackgrounds
Have you ever woken your Windows 10 computer and been awestruck by the beautiful images displayed on the lock screen? Bringing the beauty of the lock screen to the desktop is the inspiration for this application.
![Inspiration](https://github.com/keenanmcnamara12/SpotlightBackgrounds/blob/master/WindowsSpotlightLookingGreat.jpg)

Now you can have those magnificent backgrounds on your desktop.
![On the desktop!](https://github.com/keenanmcnamara12/SpotlightBackgrounds/blob/master/SpotlightAsBackgroundWoohoo.png)

# Background
This application allows for a user to ad-hoc copy the windows lock screen backgrounds into a specified directory that can be used as a desktop background. Additionally, one can set up a windows task to periodically pull updates from the lock screen background folder as it's updated. An app data file is used to specify where the images should be saved (background folder).

# How to 
1. Download the .msi here: https://github.com/keenanmcnamara12/SpotlightBackgrounds/blob/master/SpotlightBackgroundsInstaller/Release/SpotlightBackgroundsInstaller.msi
2. Run the installer.
3. You'll see a shortcut on your desktop "Spotlight to Background".
4. Double click on the shortcut.
5. Choose the directory you want the Spotlight images to be saved to.
6. Make sure the resolution matches that of your primary monitor - update if necessary.
7. Cick run to perform the first copy!
8. Open your background directory and verify there are images now.
9. Optional - consider clicking the "Sched" button to have this application run in the background once per day to add new backgrounds to your folder.

# Additional details
A file with the background directory and pixel dimensions is saved in "C:\Users\<User>\AppData\Roaming\SpotlightBackground\preferences.txt"

Details on windows tasks can be found here: https://technet.microsoft.com/en-us/library/cc748993(v=ws.11).aspx)
