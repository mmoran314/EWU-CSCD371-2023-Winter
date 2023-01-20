namespace ClassDemo;

public class Train : Vehicle
{
    
    
    public int Carriages { get; set; }
    public Train(int carriages, string model) : base("model")
    {
        Carriages = carriages;
    }
}