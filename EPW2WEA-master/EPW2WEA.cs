using System;
using System.IO;
namespace EPW2WEA
{
    public class EPW2WEA
    {
		public static int Main(String[] args)
		{
            if(args.Length != 2){
                Console.WriteLine("Please enter EPW file and WEA file names");
                return -1;
            }

			StreamWriter weaFile = new StreamWriter(args[1], true);

            Console.WriteLine("Reading EPW File ... ", args[0]);

			if (File.Exists(args[0])){
				StreamReader sr = new StreamReader(args[0]);
                int lineNumber = 0;
                int minuteStep =0;
			    String line = sr.ReadLine();
                while (line != null)
                {   lineNumber++;
                    
                    if (lineNumber == 1){
                        writeLocationRecord(weaFile, line);
                    }
                    if (lineNumber == 8){
                        minuteStep = 60 * getTimeStep( line);
                    }
                    if(lineNumber>8){
                        writeDataRecord(weaFile,line,minuteStep);
                    }

                    line = sr.ReadLine();
                }
			}
            else{
                Console.WriteLine("Specified EPW File Doesn't exist. WEA file is not created.");
            }


                // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
			weaFile.Dispose();
			return 0;
		}

        protected static void writeDataRecord(StreamWriter weaFile, String line, int minuteStep){
			//EPW Record 1991,1,1,1,0,?9?9?9?9E0?9?9?9?9?9?9?9?9?9?9?9?9?9?9?9*9*9?9?9?9,-2.2,-12.8,40,103500,0,0,229,0,0,0,0,0,0,0,330,4.6,0,0,32.0,77777,9,999999999,120,0.0880,0,88,0.160,0.0,1.0
			// WEA Record  month (field2)  day(field3)  hour_in (field4) direct_normal_radiation(field15)  Diffuse_Horizontal_Radiation(field16)
			    //1 1 0.500 0 0   

			String[] lineElements   = line.Split(',');
            String month            = lineElements[1];
            String day              = lineElements[2];    
            String hourIn           = lineElements[3];
			
            String directNormalRadiation        = lineElements[14];
            String diffuseHorzontalRadiation    = lineElements[15];


			Double hourInDouble = Double.Parse(hourIn);
            //TODO not sure why this calculation needed. Check with WEA record specifications
            hourInDouble = hourInDouble * 1.0 - minuteStep * (0.5 / 60);

            weaFile.WriteLine(month + " " + day + " " + hourInDouble + " "  +directNormalRadiation + " " +diffuseHorzontalRadiation);

		}

        protected static int getTimeStep(String line){
			//EPW Record Format  - DATA PERIODS,1,1,Data,Sunday, 1/ 1,12/31
			//WEA Record
			//weather_data_file_units 1     This is third element in EPW record
			String[] lineElements = line.Split(',');

			String dataPeriods          = lineElements[0];
			String ignoreThis           = lineElements[1];
			String timeStep = lineElements[2];
            return Int32.Parse(timeStep);
		}

		protected static void writeLocationRecord(StreamWriter weaFile, String line){
			//EPW Record Format -  LOCATION,New York Laguardia Arpt, NY, USA, TMY3,725030,40.78,-73.88,-5.0,3.0
			//WEA Records 
                //place Boston Logan IntL Arpt_USA
				//latitude 42.37
				//longitude 71.02
				//time_zone 75
				//site_elevation 6.0
                //weather_data_file_units 1    THIS IS HARDCODED

            String[] lineElements = line.Split(',');

            String location1 = lineElements[1];
			String location2 = lineElements[2];
			String location3 = lineElements[3];
            weaFile.WriteLine("place " + location1 + " "+ location2 +"_"+location3);    

            String latitude    = lineElements[6];
			weaFile.WriteLine("Latitude " + latitude);
			
            String longitude  = lineElements[7];
            Double longitudeDouble = -1 * Double.Parse(longitude);
            weaFile.WriteLine("Longitude " +longitudeDouble );

            String timeZone = lineElements[8];
            Double timeZoneDouble = -15 * Double.Parse(timeZone);
            weaFile.WriteLine("TimeZone " + timeZoneDouble);

			String siteElevation = lineElements[9];
			weaFile.WriteLine("site_elevation " + siteElevation);
            weaFile.WriteLine("weather_data_file_units 1" );

		}


    }
}
