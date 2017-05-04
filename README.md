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



Full description of th
Convert EPW file to WEA file.
