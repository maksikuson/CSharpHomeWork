namespace _18_Factory
{
    public abstract class Box
    {
        public abstract string Name { get; }
    }

    public abstract class Processor
    {

        public abstract string Name { get; }
    }

    public abstract class MainBoard
    {

        public abstract string Name { get; }
    }

    public abstract class Hdd
    {

        public abstract string Name { get; }

    }

    public abstract class Memory
    {
        public abstract string Name { get; }

    }

    public interface IPcFactory
    {
        Box CreateBox();
        Processor CreateProcessor();
        MainBoard CreateMainBoard();
        Hdd CreateHdd();
        Memory CreateMemory();
    }

    public class PcConfigurator
    {

        private IPcFactory _pcFactory;
        public PcConfigurator(IPcFactory pcFactory)
        {
            _pcFactory = pcFactory;
        }

        public void Configure()
        {

            Box box = _pcFactory.CreateBox();

            Processor processor = _pcFactory.CreateProcessor();

            MainBoard mainBoard = _pcFactory.CreateMainBoard();

            Hdd hdd = _pcFactory.CreateHdd();

            Memory memory = _pcFactory.CreateMemory();

            Console.WriteLine("Computer configured with the following components :");
            Console.WriteLine($"Box : {box.Name}");
            Console.WriteLine($"Processor : {processor.Name}");
            Console.WriteLine($"MainBoard : {mainBoard.Name}");
            Console.WriteLine($"HDD : {hdd.Name}");
            Console.WriteLine($"Memory : {memory.Name}");
        }
    }

    public class BlackBox : Box
    {

        public override string Name => "Black Box";
    }


    public class SilverBox : Box
    {

        public override string Name => "Silver Box";
    }

    public class AmdProcessor : Processor
    {

        public override string Name => "AMD Processor";
    }

    public class IntelProcessor : Processor
    {

        public override string Name => "Intel Processor";
    }

    public class AsusMainBoard : MainBoard
    {

        public override string Name => "Asus MainBoard";

    }

    public class MSIMainBoard : MainBoard
    {
        public override string Name => "MSI MainBoard";
    }

    public class LGHdd : Hdd

    {
        public override string Name => "LG HDD";
    }

    public class SamsungHdd : Hdd
    {
        public override string Name => "Samsung HDD";
    }

    public class DdrMemory : Memory
    {
        public override string Name => "DDR Memory";
    }

    public class Ddr2Memory : Memory
    {
        public override string Name => "DDR2 Memory";
    }

    public class OfficePcFactory : IPcFactory
    {

        public Box CreateBox()
        {
            return new BlackBox();
        }

        public Processor CreateProcessor()
        {
            return new IntelProcessor();
        }

        public MainBoard CreateMainBoard()
        {
            return new MSIMainBoard();
        }

        public Hdd CreateHdd()
        {
            return new SamsungHdd();
        }

        public Memory CreateMemory()
        {
            return new DdrMemory();
        }

    }

    public class HomePcFactory : IPcFactory
    {

        public Box CreateBox()
        {
            return new SilverBox();
        }

        public Processor CreateProcessor()
        {
            return new AmdProcessor();
        }

        public MainBoard CreateMainBoard()
        {
            return new AsusMainBoard();
        }

        public Hdd CreateHdd()
        {
            return new LGHdd();
        }

        public Memory CreateMemory()
        {
            return new Ddr2Memory();
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Office PC Configuration:");
            IPcFactory officePcFactory = new OfficePcFactory();
            PcConfigurator officePcConfigurator = new PcConfigurator(officePcFactory);
            officePcConfigurator.Configure();
            Console.WriteLine("\nHome PC Configuration:");
            IPcFactory homePcFactory = new HomePcFactory();
            PcConfigurator homePcConfigurator = new PcConfigurator(homePcFactory);
            homePcConfigurator.Configure();
        }
    }

}
