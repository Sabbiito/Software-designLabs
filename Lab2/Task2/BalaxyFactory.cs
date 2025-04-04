public class BalaxyFactory : IDeviceFactory
{
    public ILaptop CreateLaptop() => new BalaxyLaptop();
    public INetbook CreateNetbook() => new BalaxyNetbook();
    public IEBook CreateEBook() => new BalaxyEBook();
    public ISmartphone CreateSmartphone() => new BalaxySmartphone();
}
