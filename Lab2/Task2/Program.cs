using System;

class Program
{
    static void Main(string[] args)
    {
        // Створення фабрики для бренду IProne
        IDeviceFactory iproneFactory = new IProneFactory();
        var iproneLaptop = iproneFactory.CreateLaptop();
        iproneLaptop.CreateLaptop();

        var iproneNetbook = iproneFactory.CreateNetbook();
        iproneNetbook.CreateNetbook();

        var iproneEBook = iproneFactory.CreateEBook();
        iproneEBook.CreateEBook();

        var iproneSmartphone = iproneFactory.CreateSmartphone();
        iproneSmartphone.CreateSmartphone();

        // Створення фабрики для бренду Kiaomi
        IDeviceFactory kiaomiFactory = new KiaomiFactory();
        var kiaomiLaptop = kiaomiFactory.CreateLaptop();
        kiaomiLaptop.CreateLaptop();

        var kiaomiNetbook = kiaomiFactory.CreateNetbook();
        kiaomiNetbook.CreateNetbook();

        var kiaomiEBook = kiaomiFactory.CreateEBook();
        kiaomiEBook.CreateEBook();

        var kiaomiSmartphone = kiaomiFactory.CreateSmartphone();
        kiaomiSmartphone.CreateSmartphone();

        // Створення фабрики для бренду Balaxy
        IDeviceFactory balaxyFactory = new BalaxyFactory();
        var balaxyLaptop = balaxyFactory.CreateLaptop();
        balaxyLaptop.CreateLaptop();

        var balaxyNetbook = balaxyFactory.CreateNetbook();
        balaxyNetbook.CreateNetbook();

        var balaxyEBook = balaxyFactory.CreateEBook();
        balaxyEBook.CreateEBook();

        var balaxySmartphone = balaxyFactory.CreateSmartphone();
        balaxySmartphone.CreateSmartphone();
    }
}
