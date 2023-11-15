using System;
using System.Collections.Generic;


public class Computer
{
    public string IPAddress { get; set; }
    public int Power { get; set; }
    public string OperatingSystem { get; set; }
}


public class Server : Computer, IConnectable
{
    public int MaxConnections { get; set; }

    public void Connect(Computer target)
    {
        Console.WriteLine($"Connected to {target.IPAddress}");
    }

    public void Disconnect(Computer target)
    {
        Console.WriteLine($"Disconnected from {target.IPAddress}");
    }

    public void TransferData(Computer target, string data)
    {
        Console.WriteLine($"Data sent to {target.IPAddress}: {data}");
    }

    public string ReceiveData(Computer source, string data)
    {
        Console.WriteLine($"Data received from {source.IPAddress}: {data}");
        return "Acknowledgement: Data received successfully.";
    }
}

public class Workstation : Computer, IConnectable
{
    public string Department { get; set; }

    public void Connect(Computer target)
    {
        Console.WriteLine($"Connected to {target.IPAddress}");
    }

    public void Disconnect(Computer target)
    {
        Console.WriteLine($"Disconnected from {target.IPAddress}");
    }

    public void TransferData(Computer target, string data)
    {
        Console.WriteLine($"Data sent to {target.IPAddress}: {data}");
    }

    public string ReceiveData(Computer source, string data)
    {
        Console.WriteLine($"Data received from {source.IPAddress}: {data}");
        return "Acknowledgement: Data received successfully.";
    }
}

public class Router : Computer, IConnectable
{
    public string FirewallConfig { get; set; }

    public void Connect(Computer target)
    {
        Console.WriteLine($"Connected to {target.IPAddress}");
    }

    public void Disconnect(Computer target)
    {
        Console.WriteLine($"Disconnected from {target.IPAddress}");
    }

    public void TransferData(Computer target, string data)
    {
        Console.WriteLine($"Data sent to {target.IPAddress}: {data}");
    }

    public string ReceiveData(Computer source, string data)
    {
        Console.WriteLine($"Data received from {source.IPAddress}: {data}");
        return "Acknowledgement: Data received successfully.";
    }
}


public interface IConnectable
{
    void Connect(Computer target);
    void Disconnect(Computer target);
    void TransferData(Computer target, string data);
    string ReceiveData(Computer source, string data);
}


public class Network
{
    private List<Computer> computers;

    public Network()
    {
        computers = new List<Computer>();
    }

    public void AddComputer(Computer computer)
    {
        computers.Add(computer);
    }

    public void ConnectComputers(Computer source, Computer target)
    {
        if (source is IConnectable connectableSource && target is IConnectable connectableTarget)
        {
            connectableSource.Connect(target);
            connectableTarget.Connect(source);
        }
        else
        {
            Console.WriteLine("Cannot connect these computers.");
        }
    }

    public void DisconnectComputers(Computer source, Computer target)
    {
        if (source is IConnectable connectableSource && target is IConnectable connectableTarget)
        {
            connectableSource.Disconnect(target);
            connectableTarget.Disconnect(source);
        }
        else
        {
            Console.WriteLine("Cannot disconnect these computers.");
        }
    }

    public void TransferData(Computer source, Computer target, string data)
    {
        if (source is IConnectable connectableSource)
        {
            connectableSource.TransferData(target, data);
        }
        else
        {
            Console.WriteLine("Cannot transfer data from this computer.");
        }
    }
}
