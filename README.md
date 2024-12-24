# Panorama App

This is a simple WinForms application that takes three images and stitches them together to create a panorama.

## How to Run the Application

To run the application, follow these steps:

1. Clone or download the project.
2. Install the required libraries using NuGet:
   - OpenCvSharp4.runtime.windows
   - OpenCvSharp4
   - OpenCvSharp4.Extensions

## Required Libraries

Before running the application, make sure to install the following NuGet packages:

- **OpenCvSharp4.runtime.windows**: Contains the runtime files needed to run OpenCvSharp on Windows.
- **OpenCvSharp4**: The core OpenCVSharp library for image processing.
- **OpenCvSharp4.Extensions**: Provides extension methods for converting OpenCV `Mat` objects to .NET `Bitmap` objects.

## Usage

1. After launching the app, you can upload three images by clicking the "Load Image" button.
2. Once all three images are loaded, click the "Create Panorama" button to generate the panorama.
3. The stitched panorama will be displayed in the PictureBox.
