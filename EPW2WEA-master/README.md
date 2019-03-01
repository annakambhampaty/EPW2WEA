# EPW2WEA

## EPW Files
The EPW file format was developed for the U.S. Department of Energy's EnergyPlus building 
simulation model. EPW files store comma-delimited data, and use the extension .epw.
* The first eight lines of a file in EPW format stores header data. Data in the header records includes 
latitude, longitude, elevation, and time zone data.  This data helps calculate solar angles.

* The remaining 8760 lines store weather data, each record consists of 34 comma separated fields. Each field is a recording
of specific whether data element such as Dry Bulb Temperature, Relative Humidity, Direct Normal Radiation, Diffuse Horizontal Radiation Etc 
* Eighth record,Periods Record, describes start and end date of the data and number of recordings per hour.   365 days * 24 hours = 8760 data records.
* For complete description of the EPW format [Download EPW Data Dictionary](https://energyplus.net/sites/default/files/pdfs_v8.3.0/AuxiliaryPrograms.pdf)
* More weather file [formats](https://www.nrel.gov/analysis/sam/help/html-php/index.html?weather_format.htm)

## WEA Files
The DAYSIM header file consist of a series of date and time stamp 
along with a pair of direct and diffuse irradiances. 
* The file is used by ds_illum program to generate an annual illuminance profile. 
* The general format of the file is an optional six line header file followed by  
typically 8670 lines
* For WEA or DAYSIM [Format info](http://daysim.ning.com/page/daysim-file-type-daysim-weather-file)

## EPW2WEA C# program

EPW2WEA.cs is a Console Program that can be used to convert EPW file format to WEA file format.
* This program assumes weather_data_file_units to 1  (hard coded)
* Not 100% sure about time-step calculation. Seems to work fine with the data I have.

## Usage
* Download EPW2WEA.cs
* Compile the program and create executable by running *csc EPW2WEA.cs*. This command will create EPW2WEA.exe
* In windows, type *EPW2WEA epwFileName weaFileName*
* In Mac, type *mono EPW2WEA epwFileName weaFileName*
* weaFile will be created
