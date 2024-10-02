![Phasmophobia Timer Banner](utils/banner.jpg)

# Phasmophobia Timer Overlay (v1.0-alpha)

This project is an overlay timer specifically developed for the game *Phasmophobia*. It is designed to be used during gameplay, helping players track critical times visually without having to exit the game.

## Features

- **Start/Stop Timer**: You can easily start or stop the timer using a button or an assigned key.
- **Quick Reset**: Reset the timer to 0 with just one click or key.
- **Visibility Toggle**: Instantly toggle the overlay visibility with customizable keys to keep your screen clean when needed.
- **Minimalist User Interface**: Clean and simple design to avoid interfering with the gaming experience.

## Installation

1. Download the executable file from the [releases](https://github.com/MenachoRBB/phasmophobia-timer/releases) section.
2. Extract the file to a folder of your choice.
3. Run `PhasmophobiaTimer.exe` and configure the keys according to your preferences.

## Usage

1. **Launch the Application**: Start the Phasmophobia Timer Overlay application. By default, the keys are set to **1** for Start/Stop, **2** for Reset, and **3** for Toggle Visibility. If you wish to change these default keys, you can easily do so by editing the configuration file (`config.json`), where you can specify your desired keys for each action.

2. **Start *Phasmophobia* in Fullscreen Window Mode**: Once you have configured the keys (or accepted the defaults), open *Phasmophobia* and make sure to play the game in fullscreen window mode. This setting allows the timer overlay to appear on top of the game, ensuring that it does not interfere with your gameplay experience.

3. **Utilize the Assigned Keys**: During your gameplay, you can control the timer easily using the keys you configured earlier. Press the assigned key to start or stop the timer as needed, use another key to reset the timer back to zero, and press the toggle key to show or hide the timer overlay. This setup allows you to keep track of critical times without distractions, enhancing your gaming experience.

## Technologies Used

This project is developed in **C#** using **WPF (Windows Presentation Foundation)**.

### Why C# and WPF?

I chose **C# with WPF** for several reasons:
- **Easy integration with the Windows system**: Since Phasmophobia is a Windows-based game, WPF offers a great way to create modern graphical interfaces that interact natively with the system.
- **Flexible UI design**: WPF provides a XAML-based interface design, making it easier to create customizable and responsive interfaces.
- **High performance**: C# and WPF allow for efficient handling of graphics and overlays while maintaining optimal performance during gameplay.

## Contributions

Contributions are welcome! If you'd like to improve any functionality or report a bug, feel free to open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](https://github.com/MenachoRBB/phasmophobia-timer/blob/main/LICENSE).
