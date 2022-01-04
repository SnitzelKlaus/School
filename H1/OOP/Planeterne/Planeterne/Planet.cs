using System;
using System.Collections.Generic;
using System.Text;

namespace Planeterne
{
    public class Planet
    {
        public string Name { get; set; }
        public double Mass { get; set; }
        public double Diameter { get; set; }
        public double Density { get; set; }
        public double Gravity { get; set; }
        public double RotationPeriod { get; set; }
        public double LengthOfDays { get; set; }
        public double DistanceFromSun { get; set; }
        public double OrbitalPeriod { get; set; }
        public double OrbitalVelocity { get; set; }
        public double MeanTemperature { get; set; }
        public double NumberOfMoons { get; set; }
        public bool RingSystem { get; set; }

        public Planet(string name, double mass, double diameter, double density, double gravity, double rotationPeriod, double lengthOfDays, double distanceFromSun, double orbitalPeriod, double orbitalVelocity, double meanTemperature, double numberOfMoons, bool ringSystem)
        {
            Name = name;
            Mass = mass;
            Diameter = diameter;
            Density = density;
            Gravity = gravity;
            RotationPeriod = rotationPeriod;
            LengthOfDays = lengthOfDays;
            DistanceFromSun = distanceFromSun;
            OrbitalPeriod = orbitalPeriod;
            OrbitalVelocity = orbitalVelocity;
            MeanTemperature = meanTemperature;
            NumberOfMoons = numberOfMoons;
            RingSystem = ringSystem;
        }

   
    }
}
