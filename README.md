Arduino 8 Lamp Manager

Table of Contents
Introduction
Features
Hardware Requirements
Software Requirements
Setup Instructions
Usage
Contributing
License
Acknowledgements
Introduction
The Arduino 8 Lamp Manager is a Windows application designed to control up to 8 LEDs connected to an Arduino via an HC-06 or HC-05 Bluetooth module. This project provides an easy-to-use interface for managing the state of each LED, making it ideal for home automation projects, educational purposes, and prototyping.

Features
Control up to 8 LEDs via Bluetooth
Simple and intuitive Windows interface
Real-time status updates
Easy setup and configuration
Open-source and customizable
Hardware Requirements
Arduino (e.g., Uno, Mega)
HC-06 or HC-05 Bluetooth module
8 LEDs
8 resistors (220Ω recommended)
Breadboard and jumper wires
Bluetooth-enabled Windows PC
Software Requirements
Arduino IDE
HC-05 Bluetooth Serial Library
Windows 10 or higher
Setup Instructions
Arduino Side
Connect the HC-06/HC-05 Bluetooth Module:

VCC to 5V on Arduino
GND to GND on Arduino
TXD to RX on Arduino (pin 0)
RXD to TX on Arduino (pin 1)
Connect the LEDs:

Connect each LED to a digital pin on the Arduino (e.g., pins 2-9) with a resistor in series.
Upload the Sketch:

Open the Arduino IDE.
Load the provided sketch from the Arduino directory of this repository.
Upload the sketch to the Arduino.
Windows Application
Download and Install:

Usage:

Download the project and bin files are given in the same directory or Debug again using Visual Studio.
Connect your arduino project to the source
Open the ArduinoBluetoothManager.exe in bin
Wait for discovering the HC-05, 06 devices by the application
Choose appropriate device from list
Pair the Bluetooth Module by pressing the Connection button:

Controlling LEDs:

Use the app's interface to toggle each LED on or off.
The app provides real-time feedback on the status of each LED.
Contributing
Contributions are welcome! If you'd like to contribute, please fork the repository and use a feature branch. Pull requests are warmly welcome.

Fork the Project
Create your Feature Branch (git checkout -b feature/AmazingFeature)
Commit your Changes (git commit -m 'Add some AmazingFeature')
Push to the Branch (git push origin feature/AmazingFeature)
Open a Pull Request
