using System;
using System.Collections.Generic;

public class LivingOrganism
{
    public int Energy { get; set; }
    public int Age { get; set; }
    public int Size { get; set; }
}


public class Animal : LivingOrganism, IReproducible, IPredator
{
    public string Species { get; set; }
    public string Habitat { get; set; }

    public void Reproduce()
    {
       
    }

    public void Hunt(LivingOrganism prey)
    {
        
    }
}

public class Plant : LivingOrganism, IReproducible
{
    public string Type { get; set; }
    public string Location { get; set; }

    public void Reproduce()
    {
        
    }
}

public class Microorganism : LivingOrganism, IReproducible
{
    public string Type { get; set; }
    public string Environment { get; set; }

    public void Reproduce()
    {
        
    }
}


public interface IReproducible
{
    void Reproduce();
}

public interface IPredator
{
    void Hunt(LivingOrganism prey);
}


public class Ecosystem
{
    private List<LivingOrganism> organisms;

    public Ecosystem()
    {
        organisms = new List<LivingOrganism>();
    }

    public void AddOrganism(LivingOrganism organism)
    {
        organisms.Add(organism);
    }

    public void SimulateInteractions()
    {
        foreach (var organism in organisms)
        {
           
            if (organism is IPredator predator)
            {
                
                foreach (var prey in organisms)
                {
                    if (predator != prey && prey is LivingOrganism preyOrganism)
                    {
                        predator.Hunt(preyOrganism);
                    }
                }
            }

            if (organism is IReproducible reproducible)
            {
                
                reproducible.Reproduce();
            }

            
        }
    }
}
