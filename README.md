# Keep_Lighting
VR Horror game based on Hyper-realistic interaction contents using Meta Quest. Although the `Dependencies` section says that the available device is Meta Quest Pro, you can play this project using Meta Quest 3 or Oculus 2 or any other HMD device as well.

## Contents
Despite it's low perfection, enough to utilize for development environment. This project has somethings that you can utilize:
- Player Interaction for Head Mounted Display(HMD)
- Canvas Interaction during the play
- Object Interaction changing color each time the user aims
- Sounds Interaction <br><br>

Controller controls are as follow:
- Left Controller `Joystick` : Move to user position.<br><br>
- Right Controller `Joystick` : Rotates to user's view. <br>
- Right Controller `A` : Interaction
- Right Controller `B` : Inventory for items that you got by interaction.<br><br>
  - If you target the items that you want to interact by using Ray on right controller in playing, pushing interaction button, you can get the items. And it will be into inventory.
<img src="https://github.com/TF-polygon/VR-Basketball-play-simulation/assets/111733156/a704b5dd-eb79-486c-b24e-53a93603e500"> 

<br><br>

## Dependencies
- Meta Quest Pro
- Unity  >=  2020.3.32f1

## Setup
- In 'File > Build Settings', set the following :
  - Android, Texture Compression: ASTC<br>
  - And exeute Switch Platform

- In 'Player Settings' or 'Edit > Project Settings' at the bottom left of 'Building Settings', select 'Player' and set the following :
  - Company name (option)<br>
  - product name (option)<br>
  - Other Setting: Color Space - Linear<br>
  - Delete a Vulkan<br>
  - Package name: (check up company name, product name)<br>
  - Minimum API Level: API level 23<br>
  - Scripting Backend: Mono<br>

- Install Oculus Interation
  - Open the 'Window > Asset Store'.
  - Click the 'Search Online' and open the store.
  - Search 'Oculus Integration' in asset store and open it.
  - Click the 'Open In Unity' and load as package manager.
  - Click the 'Download' at the bottom right of 'Package Mangager' and  Click the 'Import'.
  - Declude unnecessary components in 'Import' list. (Avatar, LipSync, SampleFramewok etc.)
  - Import it. If it need to upgrade, do it.
  - Configure and install necessary components.

- Install XR Plugin Management
  - Open the 'Unity Registory' at 'Packages' at the top right of 'Pacakge Manager' and install as following:
    - Select 'XR Plugin Management' and click the 'Install'.
    - Select 'Oculus XR Plugin' and click the 'Install'.
  - Open the 'Edit > Project Settings' and set as following :
    - XR Plugin Management
      - Android > Plugin Provider: Oculus
      - PC > Plugin Provider: Oculus
    - XR Plugin Management > Oculus
      - Android > Stereo Rendering Mode: Multi Pass
      - PC > Stereo Rendering Mode: Multi Pass
  - In PC, select a 'PC' at 'Building Settings' and execute 'Build & Run'.

- Modify Oculus Quest 2 Developer
  - Install Oculus app in android smartphone and set a initial according to command.
    - Execute 'til success to pair between Oculus Quest 2 and Oculus App.
  - Open the Oculus app and 'settings' at the bottom right of.
  - Tap to open the connected Coulus Quest 2 and open the 'More Settings'.
  - Select 'Developer mode' and Trasnfer to ON.

- Build App
  - Connect to PC a Oculus Quest 2 using USB Type-C cable.
  - Agree some dialogs like 'do you agree to debug usb?', in display of Oculus Quest 2.
  - Open the VR sample 'Assets > Oculus > VR > Scenes > ControllerModels' at Unity project created in 2.1 version.
  - Open the 'File > Building Settings' and execute 'Build & Run'. Agree it when the prompted with the dialogs, etc.
  - If Oculus Quest 2 is prompted the app, Build complete.
  - If you want to quit, close the app on the Quest 2 side.
