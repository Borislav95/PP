using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GalaxyCatalog.Samples;

namespace GalaxyCatalog
{
    class Run
    {

        static void Main(string[] args)
        {

            string commandToDo, gName, sName, planetName, moonName;

            int commandLength;

            string[] comandVals;

            char[] separators = new char[] { '[', ']' };

            //create log
            GalaxyLog galaxyLog = new GalaxyLog();

            do
            {
                 
                commandToDo = Console.ReadLine();

                if (String.IsNullOrEmpty(commandToDo))
                { break; }

                else
                {
                    //break to words
                    string[] commandWords = commandToDo.Split(' ');
                    commandLength = commandWords.Length;


                    switch (commandLength)
                    {
                        case 1:

                            switch (commandWords[0])
                            {
                                case "stats":

                                    galaxyLog.printStat();

                                    break;

                                case "exit":

                                    Console.WriteLine("\n");

                                    break;

                                default:
                                    Console.WriteLine("Invalid Command");
                                    break; //exit
                            }
                            break;

                        default:
                            

                            switch (commandWords[0])
                            {
                                case "add":

                                    switch (commandWords[1])
                                    {

                                        //Galaxy
                                        case "galaxy":
                                            comandVals = commandToDo.Split(']')[1].Trim(' ').Split(' ');

                                            string gt = commandToDo.Split('[', ']')[2].Split(' ')[1].Trim();
                                                 GalaxyTypes gTobj = (GalaxyTypes)Enum.Parse(typeof(GalaxyTypes), gt);
                                                    float age = float.Parse(comandVals[1].Substring(0, comandVals[1].Length - 1), CultureInfo.InvariantCulture);
                                                        char ageS = char.Parse(comandVals[1].Substring(comandVals[1].Length - 1));
                                                             gName = commandToDo.Split('[', ']')[1].Trim();                                       

                                            Galaxy g = new Galaxy(gName, gTobj, age, ageS);
                                           

                                           
                                            galaxyLog.Galaxies.Add(g);

                                            break;
                                        //Galaxy END

                                        //STAR
                                        case "star":
                                            comandVals = commandToDo.Split('[', ']');
                                            gName = commandToDo.Split('[', ']')[1];
                                            sName = commandToDo.Split('[', ']')[3];
                                            string[] sParm = commandToDo.Split('[', ']')[4].Trim().Split(" ");

                                            float mass = float.Parse(sParm[0], CultureInfo.InvariantCulture);
                                                 float size = float.Parse(sParm[1], CultureInfo.InvariantCulture);
                                                        int temp = int.Parse(sParm[2]);
                                                            float luminosity = float.Parse(sParm[3], CultureInfo.InvariantCulture);

                                            Stars currStar = new Stars(sName, mass, size, temp, luminosity);

                                            if (galaxyLog.Galaxies.Any(g => g.GalaxyName == gName))
                                            {
                                                    galaxyLog.Galaxies.Find(g => g.GalaxyName == gName).addStar(currStar);
                                            }
                                                 else
                                            {
                                                            galaxyLog.Galaxies.Add(new Galaxy(gName, new List<Stars>() { currStar }));
                                            }


                                            break;
                                        //Star END

                                        //PLANET
                                        case "planet":
                                            comandVals = commandToDo.Split('[', ']');

                                            sName = comandVals[1];
                                            planetName = comandVals[3].Trim();
                                            string[] planetParam = comandVals[4].Trim().Split(' ');
                                            //<support life>
                                            bool life = planetParam.Last() == "yes" ? true : false;
                                            //takes type
                                            string pt = String.Join(" ", planetParam.SkipLast(1));

                                            Planets currPlanet = new Planets(planetName, pt, life);


                                            if (galaxyLog.Galaxies.Any(g => g.Stars.Any(s => s.StarName == sName)))
                                            {
                                                foreach (Galaxy glx in galaxyLog.Galaxies)
                                                {
                                                    if (glx.Stars.Any(s => s.StarName == sName))
                                                    {
                                                             glx.Stars.Find(s => s.StarName == sName).addPlanet(currPlanet);
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($" Its nessesery to add  Star to the galaxy! ");
                                            }

                                            break;
                                        //Planet END

                                        // MOON
                                        case "moon":
                                            comandVals = commandToDo.Split('[', ']');
                                            planetName = comandVals[1].Trim();
                                            moonName = comandVals[3].Trim();

                                            Moons currMoon = new Moons(moonName);


                                            if (galaxyLog.Galaxies.Any(g => g.Stars.Any(s => s.Planets.Any(p => p.PlanetName == planetName))))
                                            {
                                                foreach (Galaxy glx in galaxyLog.Galaxies)
                                                {
                                                    foreach (Stars s in glx.Stars)
                                                    {

                                                        if (s.Planets.Any(x => x.PlanetName == planetName))
                                                            { s.Planets.Find(p => p.PlanetName == planetName).addMoon(currMoon); }


                                                    }
                                                }
                                            }

                                            else
                                            {

                                                Console.WriteLine("Its nessesery to add Planet star to the galaxy!");

                                            }

                                            break;
                                            // moon end 
                                    }
                                    break;

                                //LIST 
                                case "list":
                                    switch (commandWords[1])
                                    {
                                        case "galaxies":

                                                 galaxyLog.printGalaxies();

                                            break;

                                        case "stars":

                                                  galaxyLog.printStars();

                                            break;

                                        case "planets":

                                                  galaxyLog.printPlanets();

                                            break;

                                        case "moons":

                                                   galaxyLog.printMoons();

                                            break;
                                    }
                                    break;
                                // END LIST 

                                //Print
                                case "print":

                                    gName = commandToDo.Split('[', ']')[1];

                                    if (galaxyLog.Galaxies.Any(g => g.GalaxyName == gName))
                                    {
                                        Console.WriteLine(galaxyLog.Galaxies.Find(g => g.GalaxyName == gName).ToString());
                                    }
                                    else
                                    { Console.WriteLine($"No Galaxy entered: {gName}"); }

                                    break;
                                //end

                                default:
                                    Console.WriteLine("Invalid Command");
                                    break;

                            }
                            break;
                    }
                }
            }
            while (!commandToDo.Equals("exit"));




        } 
    } 
}
