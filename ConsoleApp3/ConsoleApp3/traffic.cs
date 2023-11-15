using System;
using System.Collections.Generic;

public class Road
{
    public double Length { get; set; }
    public double Width { get; set; }
    public int NumberOfLanes { get; set; }
    public double TrafficLevel { get; set; } 
}

public class Vehicle : IDriveable
{
    public string Type { get; set; }
    public double Speed { get; set; }
    public double Size { get; set; }

    public void Move()
    {
       
    }

    public void Stop()
    {
        
    }
}


public interface IDriveable
{
    void Move();
    void Stop();
}


public class TrafficSimulation
{
    private List<Vehicle> vehicles;
    private Road road;

    public TrafficSimulation(Road road)
    {
        this.road = road;
        vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void SimulateTraffic()
    {
        foreach (var vehicle in vehicles)
        {
            
            if (vehicle.Speed < road.TrafficLevel)
            {
                vehicle.Stop();
            }
            else
            {
                vehicle.Move();
            }
        }
    }
}
