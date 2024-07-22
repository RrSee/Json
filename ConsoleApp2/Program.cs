using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

public class Car
{
    public int Id { get; set; }
    public string Marka { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Car(int ıd, string marka, string model, int year)
    {
        Id = ıd;
        Marka = marka;
        Model = model;
        Year = year;
    }


    public override string ToString()
        => $"{Marka}-{Model}-{Year}";
}

public class CarGallery
{
    public string Name { get; set; }
    public List<Car> cars { get; set; }

    public CarGallery(string name, List<Car> cars)
    {
        Name = name;
        this.cars = cars;
    }


    public void JsonSerializeMethod()
    {
        JsonSerializerOptions op = new JsonSerializerOptions();
        op.WriteIndented = true;
        var jsonString = JsonSerializer.Serialize(cars, op);
        File.WriteAllText("cars.json", jsonString);
    }
    public void addCar(Car car)
    {
        cars.Add(car);
        JsonSerializeMethod();
        
    }

    public void removeCar(int id)
    {
        foreach(Car car in cars)
        {
            if(car.Id == id)
            {
                cars.Remove(car);
                JsonSerializeMethod();
                break;
            }
        }
    }

    public void getAllCar()
    {
        JsonSerializeMethod();
    }

    public Car getById(int id)
    {
        foreach (Car car in cars)
        {
            if (car.Id == id)
            {
                return car;
            }
        }
        return null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car(1, "F10", "Bmw", 2012);
        Car car2 = new Car(2, "E200", "Mercedes", 2014);
        Car car3 = new Car(3, "011", "Lada", 2011);
        List<Car> carss = new List<Car>();
        carss.Add(car1);
        carss.Add(car2);
        //carss.Add(car3);

        CarGallery cg = new CarGallery("Galery", carss);

        cg.addCar(car3);
        //cg.removeCar(2);
        cg.getAllCar();
    }
}
